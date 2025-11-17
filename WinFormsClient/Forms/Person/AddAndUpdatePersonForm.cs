using ReaLTaiizor.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.CustomControls;
using WinFormsClient.DTOs.PersonDTOs;
using WinFormsClient.DTOs.PersonDTOs.PhoneNumberDTOs;
using WinFormsClient.Events;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.Forms.Person
{
    public partial class AddAndUpdatePersonForm : BaseForm
    {
        private enum Mode { AddNew, Update }
        private Mode _mode = Mode.AddNew;

        private Mode _Mode
        {
            get => _mode;

            set
            {
                _mode = value;
                this.lblTitle.Text = (_mode == Mode.AddNew) ? "Add New Person" : "Update Person";
                if(_mode == Mode.Update) pbPersonImage.Image = null;
            }
        }
        private int? _personId;
        private readonly IPersonViewModel _personViewModel;
        private readonly IPhoneNumberViewModel _phoneNumberViewModel;

        private CreatePersonWithImageDTO createPersonDTO = new()
        { MiddleName = null, Email = null, ImageFilePath = null, Gender = true };
        private UpdatePersonWithImageDTO updatePersonDTO = new();

        private List<string> phoneNumbersAdded = new();
        private List<string> phoneNumbersRemoved = new();
        private List<PersonPhoneNumberDTO> phoneListToUpdate = new();


        private readonly DateTime _dateOfBirthMaxDate = DateTime.Now.AddYears(-10);
        public AddAndUpdatePersonForm(IPersonViewModel personViewModel, IPhoneNumberViewModel phoneNumberViewModel)
        {
            InitializeComponent();
            ApplyTheme();

            _personViewModel = personViewModel;
            _phoneNumberViewModel = phoneNumberViewModel;

            //SubscribeToPersonViewModelEvents();

        }


        #region ViewModel Events Subscription
        private void SubscribeToPersonViewModelEvents()
        {
            _personViewModel.OperationCompleted += OnOperationCompleted;
            _personViewModel.OperationFailed += OnOperationFailed;
        }

        private void UnsubscribeToPersonViewModelEvents()
        {
            _personViewModel.OperationCompleted -= OnOperationCompleted;
            _personViewModel.OperationFailed -= OnOperationFailed;
        }
        private void OnOperationFailed(object? sender, OperationFailedEventArgs e)
        {
            MessageBox.Show(e.Message);
        }

        private void OnOperationCompleted(object? sender, OperationCompletedEventArgs e)
        {
            MessageBox.Show(e.Message);
        }
        #endregion


        public async Task SetPersonId(int? personId)
        {
            _personId = personId;

            if (_personId.HasValue)
            {
                _Mode = Mode.Update;
                await LoadPersonData(_personId.Value);
            }
            else
            {
                _Mode = Mode.AddNew;
            }
        }

        private async Task LoadPersonData(int personId)
        {
            var personFound = await _personViewModel.GetPersonByIDAsync(personId);

            if (personFound != null)
            {
                //Load person data on the form
                lblPersonId.Text = $"[ {personFound.PersonID} ]";
                gtbFirstName.Text = personFound.FirstName;
                gtbMiddleName.Text = personFound.MiddleName ?? "";
                gtbLastName.Text = personFound.LastName;
                gtbDateOfBirth.Text = personFound.DateOfBirth.ToString("yyyy-MM-dd");
                gtbEmail.Text = personFound.Email ?? "";
                hrbMale.Checked = personFound.Gender;
                hrbFemale.Checked = !hrbMale.Checked;

                if(!string.IsNullOrEmpty(personFound.ImageUrl))
                {
                    pbPersonImage.Load(personFound.ImageUrl);
                    ibtnUploadImage.Text = "Update Image";
                }
                else
                {
                    pbPersonImage.Image = personFound.Gender ? Properties.Resources.Man_Default_Pictuer : Properties.Resources.Woman_Default_Picture;
                    ibtnUploadImage.Text = "Upload Image";
                }

                //Load person phone numbres list.
                VisiblePhoneNumberControls(personFound.PhoneNumbers.Count > 0);

                foreach (var phone in personFound.PhoneNumbers)
                {
                    phoneListToUpdate.Add(phone);
                    lstPhoneNumbers.Items.Add(phone.PhoneNumber);
                }

            }
        }

        private void AddAndUpdatePersonForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnsubscribeToPersonViewModelEvents();
        }

        private void AddAndUpdatePersonForm_Load(object sender, EventArgs e)
        {

        }

        private void ibtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ibtnUploadImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select an image";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff;*.ico;*.webp;*.jfif";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedImagePath = openFileDialog.FileName;
                    pbPersonImage.ImageLocation = selectedImagePath;

                    createPersonDTO.ImageFilePath = selectedImagePath;

                    ibtnRemoveImage.Visible = true;
                    ibtnUploadImage.Visible = false;
                }
            }
        }

        private void ibtnAddPhone_Click(object sender, EventArgs e)
        {
            VisiblePhoneNumberControls(true);

            if(_Mode == Mode.Update) phoneNumbersAdded.Add(gtbPhoneNumber.Text);
            lstPhoneNumbers.Items.Add(gtbPhoneNumber.Text);

            ibtnAddPhone.Enabled = false;
            gtbPhoneNumber.Text = string.Empty;
            gtbPhoneNumber.Focus();
        }

        private void ibtnRemovePhone_Click(object sender, EventArgs e)
        {
            if (lstPhoneNumbers.SelectedIndex != -1)
            {
                if (_Mode == Mode.Update)
                {
                    var phoneString = lstPhoneNumbers.SelectedItem?.ToString();
                    if(phoneString != null )
                    {
                        phoneNumbersRemoved.Add(phoneString);

                        if(phoneNumbersAdded.Contains(phoneString))
                            phoneNumbersAdded.Remove(phoneString);
                    }

                }
                lstPhoneNumbers.Items.RemoveAt(lstPhoneNumbers.SelectedIndex);

                VisiblePhoneNumberControls(lstPhoneNumbers.Items.Count > 0);
            }
        }

        private void VisiblePhoneNumberControls(bool visible)
        {
            ibtnRemovePhone.Visible = visible;
            lstPhoneNumbers.Visible = visible;
            lblPhoneList.Visible = visible;
        }

        private bool _isPhoneExistBefore = false;
        private async void gtbPhoneNumber_TextChanged(object sender, EventArgs e)
        {
            if (gtbPhoneNumber.Text.Length == 13)
            {

                _isPhoneExistBefore = (await _phoneNumberViewModel.ExistsByPhoneNumberAsync(gtbPhoneNumber.Text))
                    || lstPhoneNumbers.Items.Contains(gtbPhoneNumber.Text);

                ibtnAddPhone.Enabled = !_isPhoneExistBefore;

                if (ibtnAddPhone.Enabled == false)
                {
                    if (!lstPhoneNumbers.Items.Contains(gtbPhoneNumber.Text))
                        gtbPhoneNumber.ShowError("The phone number is already exist in the systme.");
                    else
                        gtbPhoneNumber.ShowError("The phone number is already has add in the list.");


                }

                else
                    gtbPhoneNumber.ClearError();
            }

        }

        private void lstPhoneNumberList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ibtnRemovePhone.Enabled = (lstPhoneNumbers.SelectedIndex != -1);
        }

        private async void ibtnSave_Click(object sender, EventArgs e)
        {
            if (!FormValidate())
                return;

            if(_Mode == Mode.AddNew)
            {
                var newPersonId = await _personViewModel.AddPersonAsync(createPersonDTO);

                if (newPersonId != null)
                {
                    bool isAllPhoneNumbersAddedSuccessfully = true;

                    if (lstPhoneNumbers.Items.Count > 0)
                    {
                        var phoneNumbers = new List<AddPhoneNumberDTO>();

                        foreach (var item in lstPhoneNumbers.Items)
                        {
                            var phone = item as string;
                            if (phone != null)
                                phoneNumbers.Add(new AddPhoneNumberDTO { PhoneNumber = phone , PersonID = newPersonId.Value});
                        }

                        isAllPhoneNumbersAddedSuccessfully = await _phoneNumberViewModel.AddRangeAsync(phoneNumbers);
                    }
                    if (isAllPhoneNumbersAddedSuccessfully)
                    {
                        MessageBox.Show($"The person add successfully and his id : {newPersonId.Value}", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        lblPersonId.Text = newPersonId != null ? $"[ {newPersonId?.ToString("D2")} ]" : "[ ??? ]";
                        _= SetPersonId(newPersonId);
                    }
                }
            }
            else// _Mode == Mode.Update
            {
                UploadDateFromForm();
                if (await _personViewModel.UpdatePersonAsync(_personId!.Value, updatePersonDTO)
                    && await UpdatePhoneNumbers())
                {
                    MessageBox.Show($"The person updated successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }

        private async Task<bool> UpdatePhoneNumbers()
        {
           
            if(phoneNumbersAdded.Count>0)
            {
                foreach (var phone in phoneNumbersAdded)
                {
                    if(await _phoneNumberViewModel.AddAsync(new AddPhoneNumberDTO { PersonID = _personId!.Value, PhoneNumber = phone} ) == null)
                        return false;
                }
            }
            if (phoneNumbersRemoved.Count > 0)
            {
                foreach (var phone in phoneNumbersRemoved)
                {
                    var phoneId = phoneListToUpdate.FirstOrDefault(p => p.PhoneNumber == phone)?.PhoneNumberID;

                    if (phoneId != null)
                        if (!await _phoneNumberViewModel.DeleteAsync(phoneId.Value))
                            return false;
                }
            }

            return true;
        }

        private void UploadDateFromForm()
        {
            updatePersonDTO.FirstName = gtbFirstName.Text;
            updatePersonDTO.MiddleName = string.IsNullOrEmpty(gtbMiddleName.Text)? null : gtbMiddleName.Text;
            updatePersonDTO.LastName = gtbLastName.Text;
            updatePersonDTO.DateOfBirth = DateTime.ParseExact(gtbDateOfBirth.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture); ;
            updatePersonDTO.Gender = hrbMale.Checked;
            updatePersonDTO.Email = string.IsNullOrEmpty(gtbEmail.Text) ? null : gtbEmail.Text;
            updatePersonDTO.ImageFilePath = string.IsNullOrEmpty(pbPersonImage.ImageLocation) ? null : pbPersonImage.ImageLocation;
        }

        private bool FormValidate()
        {
            bool isFormValidate = true;

            var generalTextBoxeLeaveActions = new Dictionary<GeneralTextBox, Action<object, EventArgs>>
            {
                {this.gtbFirstName, gtbFirstName_Leave }, {this.gtbMiddleName, gtbMiddleName_Leave}, {this.gtbLastName, gtbLastName_Leave}, {this.gtbDateOfBirth,gtbDateOfBirth_Leave },
                {this.gtbEmail, gtbEmail_Leave}, {this.gtbPhoneNumber, gtbPhoneNumber_Leave}
            };

            foreach (var item in generalTextBoxeLeaveActions)
            {
                if (
                    !item.Key.IsValid()
                    || ((item.Key.Tag?.ToString()?.ToLower() == "phone number" && _isPhoneExistBefore))
                    || ((item.Key.Tag?.ToString()?.ToLower() == "date of birth" && _isDateEnteredAfterMaxDateOfBirth))
                   )
                {
                    ShowErrorMessageOfGeneralTextBox(item.Key, item.Value);
                    isFormValidate = false;
                }
            }

            return isFormValidate;
        }

        private void ShowErrorMessageOfGeneralTextBox(GeneralTextBox generalTextBox, Action<object, EventArgs> leaveAction)
        {
            leaveAction(generalTextBox, EventArgs.Empty);
        }

        #region Person Form Validations (Leave Events)
        private void gtbFirstName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gtbFirstName.Text))
            {
                if(_Mode == Mode.AddNew) createPersonDTO.FirstName = gtbFirstName.Text;
                gtbFirstName.ClearError();
                return;
            }

            if (!gtbFirstName.IsValid())
            {
                gtbFirstName.ShowError();
                return;
            }


        }

        private void gtbMiddleName_Leave(object sender, EventArgs e)
        {

            if (!gtbMiddleName.IsValid())
            {
                gtbMiddleName.ShowError();
                return;
            }
            else
            {
                if (_Mode == Mode.AddNew) createPersonDTO.MiddleName = gtbMiddleName.Text;
                gtbMiddleName.ClearError();
            }


            if (string.IsNullOrEmpty(gtbMiddleName.Text))
                createPersonDTO.MiddleName = null;
        }

        private void gtbLastName_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gtbLastName.Text))
            {
                if (_Mode == Mode.AddNew)  createPersonDTO.LastName = gtbLastName.Text;
                gtbLastName.ClearError();
                return;
            }

            if (!gtbLastName.IsValid())
            {
                gtbLastName.ShowError();
                return;
            }

        }


        private bool _isDateEnteredAfterMaxDateOfBirth = false;

        private void gtbDateOfBirth_Leave(object sender, EventArgs e)
        {
            DateTime dateEntered;

            if (gtbDateOfBirth.Text.Length == 10)
            {
                dateEntered = DateTime.ParseExact(gtbDateOfBirth.Text, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);


                if (_isDateEnteredAfterMaxDateOfBirth = (dateEntered > _dateOfBirthMaxDate))
                {
                    gtbDateOfBirth.ShowError($"The max date of birth is {_dateOfBirthMaxDate.ToShortDateString()}");
                }
                else
                {
                    gtbDateOfBirth.ClearError();
                    if (_Mode == Mode.AddNew)  createPersonDTO.DateOfBirth = dateEntered;
                }

            }
            else
            {
                if (!gtbDateOfBirth.IsValid())
                    gtbDateOfBirth.ShowError();
                else
                    gtbDateOfBirth.Clear();
            }

        }

        private void gtbEmail_Leave(object sender, EventArgs e)
        {

            if (!gtbEmail.IsValid())
            {
                gtbEmail.ShowError();
                return;
            }
            else
            {
                if (_Mode == Mode.AddNew) createPersonDTO.Email = gtbEmail.Text;
                gtbEmail.ClearError();
            }


            if (string.IsNullOrEmpty(gtbEmail.Text))
                if (_Mode == Mode.AddNew) createPersonDTO.Email = null;
        }

        private void gtbPhoneNumber_Leave(object sender, EventArgs e)
        {
            if (!gtbPhoneNumber.IsValid() || _isPhoneExistBefore)
            {
                gtbPhoneNumber.ShowError();
                return;
            }

            //_isPhoneExistBefore = false;
            gtbPhoneNumber.ClearError();
        }
        #endregion
        private void GenderHopeRadioButtonChekedChanged(object sender, EventArgs e)
        {
            if (hrbMale.Checked) pbPersonImage.Image = Properties.Resources.Man_Default_Pictuer;
            else pbPersonImage.Image = Properties.Resources.Woman_Default_Picture;


            createPersonDTO.Gender = hrbMale.Checked;
        }

        private void ibtnRemoveImage_Click(object sender, EventArgs e)
        {
            pbPersonImage.Image = hrbMale.Checked ? Properties.Resources.Man_Default_Pictuer : Properties.Resources.Woman_Default_Picture;
            createPersonDTO.ImageFilePath = null;

            ibtnRemoveImage.Visible = false;
            ibtnUploadImage.Visible = true;
        }

        private void AddAndUpdatePersonForm_Activated(object sender, EventArgs e)
        {
            gtbFirstName.Focus();
        }

    }
}
