using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrganizationProfile
{
    public partial class frmRegistration: Form
    {
        private String _FullName;
        private int _Age;
        private long _ContactNo; 
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]
            {
              "BS Information Technology",
              "BS Computer Science",
              "BS Information Systems",
              "BS in Accountancy",
              "BS in Hospitality Management",
              "BS in Tourism Management"
            };

            //new code
            foreach (string program in ListOfProgram)
            {
                cbPrograms.Items.Add(program);
            }

            /* for (int i = 0; i < 6; i++)
             {
                 cbPrograms.Items.Add(ListOfProgram[i].ToString());
             } */
        }

        public long StudentNumber(string studNum)
        {
            //new code
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (FormatException)
            {
                throw new FormatException("Student Number is not a valid number.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Student Number is too large.");
            }
            finally
            {
                Console.WriteLine("Student Number validation attempted.");
            }
            return _StudentNo;
            /* _StudentNo = long.Parse(studNum);

             return _StudentNo; */
        }

        public long ContactNo(string Contact)
        {
            //new code
            try
            {
                if (!Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    throw new FormatException("Contact number must contain 10-11 digits only.");
                }
                _ContactNo = long.Parse(Contact);
            }
            catch (FormatException)
            {
                throw new FormatException("Contact number is not a valid number.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Contact number is too large.");
            }
            finally
            {
                Console.WriteLine("Contact Number validation attempted.");
            }
            return _ContactNo;
            /*if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
            {
                _ContactNo = long.Parse(Contact);
            }

            return _ContactNo;*/
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            //new code
            try
            {
                if (!Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || !Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || !Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    throw new FormatException("Full Name must contain only letters.");
                }
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }
            catch (FormatException)
            {
                throw new FormatException("Full Name format is incorrect.");
            }
            finally
            {
                Console.WriteLine("Full Name validation attempted.");
            }
            return _FullName;
            /*if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
            {
                _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
            }

            return _FullName;*/
        }

        public int Age(string age)
        {
            //new code
            try
            {
                if (!Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    throw new FormatException("Age must contain only digits.");
                }
                _Age = Int32.Parse(age);
            }
            catch (FormatException)
            {
                throw new FormatException("Age is not a valid number.");
            }
            catch (OverflowException)
            {
                throw new OverflowException("Age value is too large.");
            }
            finally
            {
                Console.WriteLine("Age validation attempted.");
            }
            return _Age;
            /*if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
            {
                _Age = Int32.Parse(age);
            }

            return _Age;*/
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            //new code
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text,
                txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthday = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ex)
            {
                MessageBox.Show(ex.Message, "Input too large", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IndexOutOfRangeException ex)
            {
                MessageBox.Show(ex.Message, "Invalid Index", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Console.WriteLine("Registration process finished.");
            }
        }

    }
}
