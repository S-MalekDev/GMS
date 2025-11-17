using System.Threading.Tasks;
using WinFormsClient.DTOs.PersonDTOs;
using WinFormsClient.Extensions;
using WinFormsClient.Forms.Person;
using WinFormsClient.Interfaces.IPerson;
using WinFormsClient.ViewModels;

namespace WinFormsClient.Controls.Person
{
    public partial class ctrlShowPersonDetails : UserControl
    {
        private int _personId;
        private IPersonViewModel? _personViewModel;
        public ctrlShowPersonDetails()
        {
            InitializeComponent();
        }

        private void LoadDefaultPersonImage(bool isMale)
        {
            pbPersonImage.Image = isMale ?
                Properties.Resources.Man_Default_Pictuer : Properties.Resources.Woman_Default_Picture;
        }

        private async Task<bool> LoadPerson(IPersonViewModel personViewMode, int personId)
        {
            PersonDTO? person = await personViewMode.GetPersonByIDAsync(personId);

            if (person == null)
                return false;


            lblPersonId.Text = $"[ {person!.PersonID.ToString("D2")} ]";
            lblFullName.Text = person.GetFullName();
            lblEmail.Text = person.Email;
            lblGender.Text = person.GetGenderText();
            lblDateOfBirth.Text = person.DateOfBirth.ToString("yyyy-MM-dd");
            lblPhoneNumber.Text = person.GetNoPhoneOrOnePhoneIfExists();

            // Loading image profile.
            if (person.ImageUrl is null) LoadDefaultPersonImage(person.Gender);
            else pbPersonImage.Load(person.ImageUrl);


            return true;
        }

        public  Task<bool> ShowPersonDetails(IPersonViewModel personViewMode, int personId)
        {
            _personId = personId;
            _personViewModel = personViewMode;

            return LoadPerson(personViewMode, personId);
        }

        public async Task RefreshControl()
        {
            if (_personViewModel is null)
                return; 

           _ = await LoadPerson(_personViewModel, _personId);
        }

    }
}
