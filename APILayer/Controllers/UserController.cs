using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.UserDTOs;
using CoreLayer.Interfaces.IUser;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/users")]
    [ApiController]
    [ValidateModelAttribute]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetAllUsersAsync")]
        [ProducesResponseType(typeof(IEnumerable<UserListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<UserListDTO>>> GetAllAsync()
        {
            var users = (await _userService.GetAllAsync()).Data;

            if (users == null || !users.Any())
                return NoContent();

            return Ok(users);
        }




        [HttpPost(Name = "AddUserAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddUserDTO userToAdd)
        {
            var operationResult = await _userService.AddAsync(userToAdd);

            return HandleOperationResult(operationResult);
        }




        [HttpGet("{Id}", Name = "GetUserByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<UserDTO>> GetByIdAsync(int Id)
        {

            var operationResult = await _userService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }



        [HttpGet("{Id}/exists", Name = "ExistsUserAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ExistsAsync(int Id)
        {

            var operationResult = await _userService.ExistsAsync(Id);

            return HandleOperationResult(operationResult);
        }



        [HttpGet("by-person/{personId}/active", Name = "HasActiveUserAsync")]
        [ValidateIdAttribute(parameterName: "personId")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> HasActiveUserAsync(int personId)
        {

            var operationResult = await _userService.HasActiveUserAsync(personId);

            return HandleOperationResult(operationResult);
        }




        [HttpGet("by-person/{personId}/exists-ever", Name = "PersonHasOrHadUserAsync")]
        [ValidateIdAttribute(parameterName: "personId")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> PersonHasOrHadUserAsync(int personId)
        {

            var operationResult = await _userService.PersonHasOrHadUserAsync(personId);

            return HandleOperationResult(operationResult);
        }




        [HttpPut("{Id}", Name = "UpdateUserAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, [FromBody] UpdateUserDTO userToUpdate)
        {

            var operationResult = await _userService.UpdateAsync(Id, userToUpdate);

            return HandleOperationResult(operationResult);
        }




        [HttpDelete("{Id}", Name = "DeleteUserAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {

            var operationResult = await _userService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }




        [HttpPut("by-person/{personId}/restore", Name = "UnDeleteUserAsync")]
        [ValidateIdAttribute(parameterName: "personId")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> RestoreAsync(int personId)
        {

            var operationResult = await _userService.RestoreAsync(personId);

            return HandleOperationResult(operationResult);
        }




        [HttpPost("authenticate", Name = "ValidateCredentialsAsync")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ValidateCredentialsAsync([FromBody] UserCredentialsDTO dto)
        {

            var operationResult = await _userService.IsUserCredentialsValidAsync(dto);

            return HandleOperationResult(operationResult);
        }




        [HttpPut("{Id}/activate", Name = "ActiveUserAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ActiveAsync(int Id)
        {

            var operationResult = await _userService.ChangeUserActivationAsync(Id, true);

            return HandleOperationResult(operationResult);
        }


        [HttpPut("{Id}/deactivate", Name = "DeactivateUserAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeactiveAsync(int Id)
        {

            var operationResult = await _userService.ChangeUserActivationAsync(Id, false);

            return HandleOperationResult(operationResult);
        }



        [HttpPut("{Id}/update-password", Name = "UpdateUserPasswordAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateUserPasswordAsync(int Id, [FromBody] UpdatePasswordDTO dto)
        {

            var operationResult  = await _userService.UpdateUserPasswordAsync(Id, dto);

            return HandleOperationResult(operationResult);
        }




        [HttpGet("is-username-taken", Name = "IsUsernameTakenAsync")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> IsUsernameTakenAsync([FromQuery] string username)
        {

            var operationResult = await _userService.IsUsernameTakenAsync(username!);

            return HandleOperationResult(operationResult);
        }
    }
}
