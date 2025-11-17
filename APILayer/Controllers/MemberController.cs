using APILayer.Fillters.ActionFilters;
using CoreLayer.DTOs.MemberDTOs;
using CoreLayer.Interfaces.IMember;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/members")]
    [ApiController]
    [ValidateModelAttribute]
    public class MemberController : BaseApiController
    {
        private readonly IMemberService _memberService;

        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet(Name = "GetAllMembersAsync")]
        [ProducesResponseType(typeof(IEnumerable<MemberListDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<MemberListDTO>>> GetAllAsync()
        {
            var members = (await _memberService.GetAllAsync()).Data;
            if (members == null || !members.Any())
                return NoContent();

            return Ok(members);
        }



        [HttpGet("{Id}", Name = "GetMemberByIdAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(MemberDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<MemberDTO>> GetByIdAsync(int Id)
        {
            var operationResult = await _memberService.GetByIdAsync(Id);

            return HandleOperationResult(operationResult);
        }



        [HttpPost(Name = "AddMemberAsync")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<int>> AddAsync([FromBody] AddMemberDTO memberToAdd)
        {
            var operationResult = await _memberService.AddAsync(memberToAdd);

            return HandleOperationResult(operationResult);
        }



        [HttpPut("{Id}", Name = "UpdateMemberAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> UpdateAsync(int Id, [FromBody] UpdateMemberDTO memberToUpdate)
        {

            var operationResult = await _memberService.UpdateAsync(Id, memberToUpdate);

            return HandleOperationResult(operationResult);
        }



        [HttpDelete("{Id}", Name = "DeleteMemberAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteAsync(int Id)
        {

            var operationResult = await _memberService.DeleteAsync(Id);

            return HandleOperationResult(operationResult);
        }




        [HttpPut("by-person/{personId}/restore", Name = "RestoreMemberAsync")]
        [ValidateIdAttribute(parameterName: "personId")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> RestoreAsync(int personId)
        {
            var operationResult = await _memberService.RestoreAsync(personId);

            return HandleOperationResult(operationResult);
        }




        [HttpGet("{Id}/exists", Name = "ExistsMemberAsync")]
        [ValidateIdAttribute(parameterName: "Id")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> ExistsAsync(int Id)
        {
            var operationResult = await _memberService.ExistsAsync(Id);

            return HandleOperationResult(operationResult);
        }
    }
}
