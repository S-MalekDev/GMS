using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.PersonDTOs.PhoneNumber;
using CoreLayer.Interfaces.IPerson;
using CoreLayer.Interfaces.IPerson.Phone;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace APILayer.Controllers
{
    [Route("api/people/phone-numbers")]
    [ApiController]
    [ValidateModelAttribute]
    public class PhoneNumberController : BaseApiController
    {
        private readonly IPhoneNumberService _phoneNumberService;
        private readonly IPersonService _personService;
        public PhoneNumberController(IPhoneNumberService phoneNumberService, IPersonService personService)
        {
            _phoneNumberService = phoneNumberService;
            _personService = personService;
        }

        [HttpGet(Name = "GetPhoneNumbersAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PhoneNumberListDTO>>> GetPhoneNumbersAsync()
        {
            var phoneNumbers = (await _phoneNumberService.GetAllAsync()).Data;

            if(phoneNumbers.IsNullOrEmpty())
                 return NoContent();

            return Ok(phoneNumbers);
        }




        [HttpPost(Name = "AddPhoneNumberAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddPhoneNumberAsync( AddPhoneNumberDTO phoneNumberToAdd)
        {
            var operationResult = await _phoneNumberService.AddAsync(phoneNumberToAdd);

            return HandleOperationResult(operationResult);
        }




        [HttpGet("{Id}", Name = "GetPhoneByIdAsync")]
        [ValidateIdAttribute(parameterName:"Id")]
        [ProducesResponseType(typeof(PhoneNumberDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PhoneNumberDTO>> GetPhoneByIdAsync(int Id)
        {

            var operationResult = await _phoneNumberService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult); ;
        }




        [HttpGet("by-person/{personId}", Name = "GetPhoneByPersonIdAsync")]
        [ValidateIdAttribute(parameterName: "personId")]
        [ProducesResponseType(typeof(IEnumerable<PhoneNumberDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<PhoneNumberDTO>>> GetPhoneByPersonIdAsync(int personId)
        {
            var phoneNumbers = (await _phoneNumberService.GetByPersonIdAsync(personId)).Data;

            if (phoneNumbers.IsNullOrEmpty())
                return NoContent();
          
            return Ok(phoneNumbers);
        }




        [HttpGet("{Id}/exists", Name = "ExistsByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ExistsByIdAsync(int Id)
        {

            var operationResult = await _phoneNumberService.ExistsByIdAsync(Id);
            return HandleOperationResult(operationResult);
        }




        [HttpGet("is-phone-exists", Name = "ExistsByPhoneNumberAsync")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ExistsByPhoneNumberAsync([FromQuery]string phoneNumber)
        {
            var operationResult = await _phoneNumberService.ExistsByPhoneNumberAsync(phoneNumber);
            return HandleOperationResult(operationResult);
        }




        [HttpPut("{Id}", Name = "UpdateAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, UpdatePhoneNumberDTO phoneNumberToUpdate)
        {
            
            var operationResult = await _phoneNumberService.UpdateAsync(Id, phoneNumberToUpdate);
            return HandleOperationResult(operationResult);
        }




        [HttpDelete("{Id}", Name = "DeleteAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {
            var operationResult = await _phoneNumberService.DeleteAsync(Id);
            return HandleOperationResult(operationResult);
        }
    }
}
