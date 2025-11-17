using ApplicationLayer.Helpers;
using AutoMapper;
using CoreLayer.Common;
using CoreLayer.DTOs.PersonDTOs;
using CoreLayer.Entities;
using CoreLayer.Enums.Logging;
using CoreLayer.Interfaces.IBusinessRuleValidators;
using CoreLayer.Interfaces.ILogging;
using CoreLayer.Interfaces.IPerson;


namespace ApplicationLayer.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _loggerManager;
        private readonly IPersonRuleValidator _personRuleValidator;


        public PersonService(IPersonRepository personRepository, IMapper mapper, ILoggerManager loggerManager,
            IPersonRuleValidator personRuleValidator)
        {
            _personRepository = personRepository;
            _mapper = mapper;
            _loggerManager = loggerManager;
            _personRuleValidator = personRuleValidator;
        }

        public async Task<OperationResult<IEnumerable<PersonListDTO>>> GetPeopleAsync()
        {

            try
            {
                IEnumerable<Person>? allPeople = await _personRepository.GetAllAsync();
                return OperationResult<IEnumerable<PersonListDTO>>.Success(data: _mapper.Map<List<PersonListDTO>>(allPeople));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetPeopleAsync)}", ex);

                throw;
            }

        }

        public async Task<OperationResult<PersonDTO>> GetByIdAsync(int personID)
        {
           
            try
            {
                var validationResult = await _personRuleValidator.ValidateGetByIdAsync(personID);
                if(! validationResult.IsSuccess) return OperationResult<PersonDTO>.MapFrom(validationResult);


                var person = await _personRepository.GetByIdAsync(personID);
                
                return OperationResult<PersonDTO>.Success(data: _mapper.Map<PersonDTO>(person));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetByIdAsync)}", ex);
               
                throw;
            }

            
        }

        public async Task<OperationResult<bool>> ExistsAsync(int personID)
        {

           try
           {
                return OperationResult<bool>.Success(data: await _personRepository.ExistsAsync(personID));
           }
           catch(Exception ex)
           {

                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(ExistsAsync)}", ex);

                throw;
            }

        }

        public async Task<OperationResult<int>> AddAsync(CreatePersonDTO personToCreate)
        {

            try
            {
                var validationResult = await  _personRuleValidator.ValidateAddAsync(personToCreate);
                if (!validationResult.IsSuccess) return OperationResult<int>.MapFrom(validationResult);

                var person = _mapper.Map<Person>(personToCreate);
                return OperationResult<int>.Success(data: await _personRepository.AddAsync(person));

            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(AddAsync)}", ex);

                throw;
            }


        }

        public async Task<OperationResult<bool>> UpdateAsync(int personID, UpdatePersonDTO personToUpdate)
        {

            try
            {
                var validationResult = await _personRuleValidator.ValidateUpdateAsync(personID, personToUpdate);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                Person person = _mapper.Map<Person>(personToUpdate);
                person.PersonID = personID;

                
                return OperationResult<bool>.Success(data: await _personRepository.UpdateAsync(person));
            }
            catch (Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(UpdateAsync)}", ex);

                throw;
            }

        }

        public async Task<OperationResult<bool>> DeletePersonAsync(int personID)
        {

            try
            {
                var validationResult = await _personRuleValidator.ValidateDeleteAsync(personID);
                if (!validationResult.IsSuccess) return OperationResult<bool>.MapFrom(validationResult);

                return OperationResult<bool>.Success(data: await _personRepository.DeleteAsync(personID));
            }
            catch(Exception ex)
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(DeletePersonAsync)}", ex);

                throw;
            }

        }

        public async Task<OperationResult<string?>> GetImageNameByIdAsync(int personID)
        {

            try
            {
                var validationResult = await _personRuleValidator.ValidateGetImageNameByIdAsync(personID);
                if (!validationResult.IsSuccess) return OperationResult<string?>.MapFrom(validationResult);

                return OperationResult<string?>.Success(data: await _personRepository.GetImageNameByIdAsync(personID));
            }
            catch(Exception ex) 
            {
                // Fire-and-forget logging to avoid delaying the response.
                _ = _loggerManager.LogWithFallbackAsync(enLogEntryType.Error, $"Exception: {nameof(GetImageNameByIdAsync)}", ex);

                throw;
            }

        }

    }
}
