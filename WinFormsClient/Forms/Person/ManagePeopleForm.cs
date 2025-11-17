using Microsoft.Extensions.DependencyInjection;
using ReaLTaiizor.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using WinFormsClient.Events;
using WinFormsClient.Interfaces.IPerson;

namespace WinFormsClient.Forms.Person
{
    public partial class ManagePeopleForm : BaseForm
    {
        private readonly IPersonViewModel _personViewModel;
        private readonly IServiceProvider _serviceProvider;
        private readonly IPersonDetailsFormFactory _personDetailsFormFactory;
        private readonly ICreateUpdatePersonFormFactory _createUpdatePersonFormFactory;
        private readonly BindingSource _bindingSource = new();
        public ManagePeopleForm(IPersonViewModel personViewModel, IServiceProvider serviceProvider,
            IPersonDetailsFormFactory personDetailsFormFactory, ICreateUpdatePersonFormFactory createUpdatePersonFormFactory)
        {
            InitializeComponent();
            ApplyTheme();

            _serviceProvider = serviceProvider;
            _personViewModel = personViewModel;
            _personDetailsFormFactory = personDetailsFormFactory;
            _createUpdatePersonFormFactory = createUpdatePersonFormFactory;

            SubscribeToPersonViewModelEvents();
            BindGrid();

        }


        private void OpenFormInTheCenter(Form frm)
        {
            frm.StartPosition = FormStartPosition.Manual;

            // الحصول على مستطيل الفورم الحالي داخل الشاشة
            var parentRect = this.RectangleToScreen(this.ClientRectangle);

            int x = parentRect.Left + (parentRect.Width - frm.Width) / 2;
            int y = parentRect.Top + (parentRect.Height - frm.Height) / 2;

            frm.Location = new Point(Math.Max(x, 0), Math.Max(y, 0));

            frm.ShowDialog();
        }

        private void BindGrid()
        {
            //dgvPersonList.AutoGenerateColumns = false;
            _bindingSource.DataSource = _personViewModel.People;
            dgvPeopleList.DataSource = _bindingSource;
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

        }

        private void OnOperationCompleted(object? sender, OperationCompletedEventArgs e)
        {

        }
        #endregion

        #region DataGridView Configuration & Data Loading
        private void ConfigureDataGridViewColumns()
        {
            if (dgvPeopleList.DataSource != null)
            {

                dgvPeopleList.Columns[0].HeaderText = "ID";
                dgvPeopleList.Columns[0].Width = 90;

                dgvPeopleList.Columns[1].HeaderText = "First Name";
                dgvPeopleList.Columns[1].Width = 180;

                dgvPeopleList.Columns[2].HeaderText = "Meddle Name";
                dgvPeopleList.Columns[2].Width = 180;

                dgvPeopleList.Columns[3].HeaderText = "Last Name";
                dgvPeopleList.Columns[3].Width = 180;

                dgvPeopleList.Columns[4].HeaderText = "Date of Birth";
                dgvPeopleList.Columns[4].Width = 250;

                dgvPeopleList.Columns[5].HeaderText = "Gender";
                dgvPeopleList.Columns[5].Width = 100;

                dgvPeopleList.Columns[6].HeaderText = "Email";
                dgvPeopleList.Columns[6].Width = 320;

            }
        }

        private async Task LoadAndBindPeopleAsync()
        {
            await _personViewModel.LoadPeopleAsync();

            // Data will be already updated inside _personViewModel.People
            // which is bound to _bindingSource, so we just need to refresh it.
            _bindingSource.ResetBindings(false);
        }

        private async Task LoadAndShowPeopleList()
        {
            await LoadAndBindPeopleAsync();
            ConfigureDataGridViewColumns();
            ShowRecordCount();
        }

        private void ShowRecordCount()
        {
            lblRecordsCount.Text = dgvPeopleList.Rows.Count.ToString("D2");
        }
        #endregion

        private async void ManagePeopleForm_Load(object sender, EventArgs e)
        {
            await LoadAndShowPeopleList();

        }

        private void ManagePeopleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnsubscribeToPersonViewModelEvents();
        }

        private void addNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _createUpdatePersonFormFactory.Create();
            OpenFormInTheCenter(frm);
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _createUpdatePersonFormFactory.Create((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            OpenFormInTheCenter(frm);
        }

        private void ibtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showDtailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = _personDetailsFormFactory.Create((int)dgvPeopleList.CurrentRow.Cells[0].Value);
            OpenFormInTheCenter(frm);
        }


        private async void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var personId = (int)dgvPeopleList.CurrentRow.Cells[0].Value;

            var Result = MessageBox.Show($"Are you sure you want to remove the person with id : [{personId}]?", "Confirm delete.",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                if (await _personViewModel.DeletePersonAsync(personId))
                    MessageBox.Show("The person deleted successfully.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else 
                    MessageBox.Show("This record cannot be deleted because it is linked to other " +
                        "data in the system. Please remove or update the related data first before attempting to delete.",
                        "Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
