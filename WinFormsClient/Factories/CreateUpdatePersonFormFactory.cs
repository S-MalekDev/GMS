using Microsoft.Extensions.DependencyInjection;
using WinFormsClient.Forms.Person;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.Factories
{
    public class CreateUpdatePersonFormFactory : ICreateUpdatePersonFormFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public CreateUpdatePersonFormFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public AddAndUpdatePersonForm Create(int? personId = null)
        {
            var frm = _serviceProvider.GetRequiredService<AddAndUpdatePersonForm>();
            _ = frm.SetPersonId(personId);
            return frm;
        }
    }
}
