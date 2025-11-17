
using Microsoft.Extensions.DependencyInjection;
using WinFormsClient.Forms.Person;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.Factories
{
    public class PersonDetailsFormFactory : IPersonDetailsFormFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public PersonDetailsFormFactory (IServiceProvider serviceProvider)
        {
           _serviceProvider = serviceProvider;
        }

        public ShowPersonDetailsForm Create(int personId)
        {
            var personDetailsForm = _serviceProvider.GetRequiredService<ShowPersonDetailsForm>();
            personDetailsForm.SetPersonId(personId);
            return personDetailsForm;
        }
    }
}
