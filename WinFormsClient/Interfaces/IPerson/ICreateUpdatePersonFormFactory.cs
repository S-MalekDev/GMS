
using WinFormsClient.Forms.Person;

namespace WinFormsClient.Interfaces.IPerson
{
    public interface ICreateUpdatePersonFormFactory
    {
        AddAndUpdatePersonForm Create(int? personId = null);
    }
}
