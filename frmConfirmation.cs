using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmConfirmation: Form
    {
        public frmConfirmation()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            lblStudentNo.Text = StudentInformationClass.SetStudentNo.ToString();
            lblName.Text = StudentInformationClass.SetFullName;
            lblProgram.Text = StudentInformationClass.SetProgram;
            lblBirthday.Text = StudentInformationClass.SetBirthday;
            lblGender.Text = StudentInformationClass.SetGender;
            lblContactNo.Text = StudentInformationClass.SetContactNo.ToString();
            lblAge.Text = StudentInformationClass.SetAge.ToString();








            /*StudentInformationClass.SetFullName = FullName(lblName.Text);
            StudentInformationClass.SetStudentNo = StudentNumber(lblStudentNo.Text);
            StudentInformationClass.SetProgram = cbPrograms.Text;

            StudentInformationClass.SetGender = cbGender.Text;
            StudentInformationClass.SetContactNo = ContactNo(lblContactNo.Text);
            StudentInformationClass.SetAge = Age(lblAge.Text);
            StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyyMM-dd");

            frmConfirm frm = new frmConfirm();

            frm.ShowDialog();*/
        }
    }
}
