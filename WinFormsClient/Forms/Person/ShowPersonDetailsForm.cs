using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.Forms.Person
{
    public partial class ShowPersonDetailsForm : BaseForm
    {
        private int _personId;
        private readonly IPersonViewModel _personViewModel;
        private readonly ICreateUpdatePersonFormFactory _createUpdatePersonFormFactory;
        public ShowPersonDetailsForm(IPersonViewModel personViewModel, ICreateUpdatePersonFormFactory createUpdatePersonFormFactory)
        {
            InitializeComponent();
            ApplyTheme();
            _personViewModel = personViewModel;
            _createUpdatePersonFormFactory = createUpdatePersonFormFactory;
        }

        public void SetPersonId(int personId)
        {
            _personId = personId;
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void ShowPersonDetailsForm_Load(object sender, EventArgs e)
        {
            await LoadPersonData();
        }

        private async Task LoadPersonData()
        {
            if (!await ctrlShowPersonDetails1.ShowPersonDetails(_personViewModel, _personId))
            {
                MessageBox.Show($"There is not a person exist with id = {_personId}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            llblUpdatePerson.Enabled = true;
        }

        private void llblUpdatePerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var frm = _createUpdatePersonFormFactory.Create(_personId);
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.ShowDialog();

             _=  ctrlShowPersonDetails1.RefreshControl();
        }
    }
}
