using APILayer.DTOs.Person;
using APILayer.Extentions;
using APILayer.Fillters.ActionFilters;
using CoreLayer.Configurations;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.DTOs.PersonDTOs.PersonImage;
using CoreLayer.Interfaces.Helpers;
using CoreLayer.Interfaces.IPerson;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/people")]
    [ApiController]
    [ValidateModelAttribute]
    public class PersonController : BaseApiController
    {
        private readonly IPersonService _personService;

        private readonly IFileService _fileService;
        public PersonController(IPersonService personService,IFileService fileService)
        {
            _personService = personService;
            _fileService = fileService;
        }


        [HttpGet(Name = "GetPeopleAsync")]
        [ProducesResponseType(typeof(IEnumerable<PersonListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PersonListDTO>>> GetPeopleAsync()
        {
            var peopleList = (await _personService.GetPeopleAsync()).Data;

            if (peopleList == null || !peopleList.Any())
                return NoContent();

            return Ok(peopleList);

        }



        [HttpGet("{Id}", Name = "GetPersonByIDAsync")]
        [ValidateIdAttribute(parameterName:"Id")]
        [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PersonDTO>> GetPersonByIDAsync(int Id)
        {
            var operationResult = await _personService.GetByIdAsync(Id);

            return HandleOperationResult<PersonDTO>(operationResult);
        }



        [HttpGet("{Id}/exists", Name = "IsPersonExistAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> IsPersonExistAsync(int Id)
        {
            var operationResult = await _personService.ExistsAsync(Id);

            return HandleOperationResult<bool>(operationResult);
        }



        [HttpPost(Name = "CreatePersonWithImageDTO")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddPersonAsync([FromForm]CreatePersonWithImageDTO personWithImageToCreate)
        {

            string? savedImageName = null;

            if (personWithImageToCreate.Image?.Length > 0)
            {
                var image = personWithImageToCreate.Image;
                var imageFileDTO = new ImageFileDTO(image.OpenReadStream(), image.FileName);

                if(! await _fileService.SavePersonImageAsync(imageFileDTO))
                    return StatusCode(StatusCodes.Status500InternalServerError, "Saving the image failed.");

                savedImageName = Path.GetFileName(imageFileDTO.SavedFilePath);
            }

            var personToCreate = new CreatePersonDTO
            {
                FirstName = personWithImageToCreate.FirstName,
                MiddleName = personWithImageToCreate.MiddleName,
                LastName = personWithImageToCreate.LastName,
                DateOfBirth = personWithImageToCreate.DateOfBirth,
                Gender = personWithImageToCreate.Gender,
                Email = personWithImageToCreate.Email,
                ImageName = savedImageName
            };

            var operationResult = await _personService.AddAsync(personToCreate);

            if (!operationResult.IsSuccess)
                return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new { message = operationResult.Message });

            return Ok(operationResult.Data);
            
        }



        [HttpPut("{Id}",Name = "UpdatePersonAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(PersonDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PersonDTO>> UpdatePersonAsync(int Id, [FromForm] UpdatePersonWithImageDTO personWithImageToUpdate)
        {


            string finalImageName = null!;
            var oldImageName = (await _personService.GetImageNameByIdAsync(Id)).Data;

            if (personWithImageToUpdate.Image?.Length>0)
            {
                var image = personWithImageToUpdate.Image;
                var imageFileDTO = new ImageFileDTO(image.OpenReadStream(), image.FileName);
                
                if (!await _fileService.UpdatePersonImageAsync(imageFileDTO, oldImageName))
                    return StatusCode(StatusCodes.Status500InternalServerError, "Saving the new image failed.");

                finalImageName = Path.GetFileName(imageFileDTO.SavedFilePath);
            }

            var personToUpdate = new UpdatePersonDTO()
            {
                FirstName = personWithImageToUpdate.FirstName,
                MiddleName = personWithImageToUpdate.MiddleName,
                LastName = personWithImageToUpdate.LastName,
                DateOfBirth = personWithImageToUpdate.DateOfBirth,
                Gender = personWithImageToUpdate.Gender,
                Email = personWithImageToUpdate.Email,
                ImageName = oldImageName
            };

            if(!string.IsNullOrEmpty(finalImageName))
            {
                personToUpdate.ImageName = finalImageName;
            }

            var operationResult = await _personService.UpdateAsync(Id,personToUpdate);

            if (!operationResult.IsSuccess)
                return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new { message = operationResult.Message });

            return Ok(operationResult.Data);
        }



        [HttpDelete("{Id}", Name = "DeletePersonAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeletePersonAsync(int Id)
        {
            // Delete person's image if he has one.
            var operationResult = await _personService.GetImageNameByIdAsync(Id);

            if (!operationResult.IsSuccess)
                return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new { message = operationResult.Message });

            var personProfileImageName = operationResult.Data;


            // Delete the person
            var operationDeleteResult = await _personService.DeletePersonAsync(Id);

            if (!operationDeleteResult.IsSuccess)
                return StatusCode(operationResult.StatusCode.ToHttpStatusCode(), new { message = operationResult.Message });

            
            // Delete person's image profile.
            if (personProfileImageName != null)
            {
                await _fileService.DeletePersonImageAsync(personProfileImageName);
            }
            return Ok(operationDeleteResult.Data);

        }        
    }
}
