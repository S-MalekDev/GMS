using AutoMapper;
using AutoMapper.Execution;
using CoreLayer.Common;
using CoreLayer.DTOs.MemberDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.IMember;

namespace ApplicationLayer.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IMemberRuleValidator _memberRuleValidator;


        public MemberService(IMemberRepository memberRepository, IMapper mapper, ILoggerManager loggerManager,
            IMemberRuleValidator memberRuleValidator)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _memberRuleValidator = memberRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<MemberListDTO>>> GetAllAsync()
        {
            try
            {
                
                var members = await _memberRepository.GetAllAsync();
                return OperationResult<IEnumerable<MemberListDTO>>.Success(data: _mapper.Map<List<MemberListDTO>>(members));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetAllAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<MemberDTO>> GetByIdAsync(int memberId)
        {
            try
            {
                var validationResult = await _memberRuleValidator.ValidateGetByIdAsync(memberId);
                if (!validationResult.IsSuccess) return OperationResult<MemberDTO>.MapFrom(validationResult);


                var member = await _memberRepository.GetByIdAsync(memberId);
                return OperationResult<MemberDTO>.Success(data: _mapper.Map<MemberDTO>(member));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<int>> AddAsync(AddMemberDTO memberToAdd)
        {
            try
            {
                var validationResult = await _memberRuleValidator.ValidateAddAsync(memberToAdd);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);


                var member = _mapper.Map<CoreLayer.Entities.Member>(memberToAdd);
                return OperationResult<int>.Success(data: await _memberRepository.AddAsync(member));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> UpdateAsync(int memberId, UpdateMemberDTO updateModel)
        {
            try
            {
                var validationResult = await _memberRuleValidator.ValidateUpdateAsync(memberId, updateModel);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                var memberToUpdate = await _memberRepository.GetByIdAsync(memberId);

                if (memberToUpdate == null) throw new Exception($"Member with ID {memberId} not found.");

                _mapper.Map(updateModel, memberToUpdate);

                return OperationResult<bool>.Success(data: await _memberRepository.UpdateAsync(memberToUpdate));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> DeleteAsync(int memberId)
        {
            try
            {
                var validationResult = await _memberRuleValidator.ValidateDeleteAsync(memberId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _memberRepository.DeleteAsync(memberId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeleteAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> RestoreAsync(int personId)
        {
            try
            {
                var validationResult = await _memberRuleValidator.ValidateRestoreAsync(personId);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _memberRepository.RestoreAsync(personId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(RestoreAsync)}", ex);
                throw;
            }
        }

        public async Task<OperationResult<bool>> ExistsAsync(int memberId)
        {
            try
            {
                return OperationResult<bool>.Success(data: await _memberRepository.ExistsByIdAsync(memberId));
            }
            catch (Exception ex)
            {
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ExistsAsync)}", ex);
                throw;
            }
        }
    }
}
