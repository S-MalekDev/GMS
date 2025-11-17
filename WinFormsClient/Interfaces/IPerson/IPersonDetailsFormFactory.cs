

using WinFormsClient.Forms.Person;

namespace WinFormsClient.Interfaces.IPerson
{
    public interface IPersonDetailsFormFactory
    {
         ShowPersonDetailsForm Create(int personId);
    }
}
