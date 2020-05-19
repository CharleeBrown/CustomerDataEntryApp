using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace CustomerDataEntry
{
    public partial class Form1 : Form
    {

        Connector connector = new Connector();

        public Form1()
        {
            InitializeComponent();
            firstName.MaxLength = 18;
            lastName.MaxLength = 30;
            phoneNum.MaxLength = 14;
            companyName.MaxLength = 50;
        }



        private void phoneNum_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[a-z]");
            if (regex.IsMatch(phoneNum.Text))
            {
                //Clears the first name textbox if a number is entered. 
                //Currently working on a better way to do this. 
                phoneNum.Clear();


            }
            if (phoneNum.TextLength == 3)
            {
                phoneNum.Text = phoneNum.Text + "-";
                phoneNum.SelectionStart = phoneNum.TextLength;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(firstName.Text) || string.IsNullOrWhiteSpace(lastName.Text) || string.IsNullOrWhiteSpace(phoneNum.Text) ||

                string.IsNullOrWhiteSpace(companyName.Text))
            {
                MessageBox.Show("Enter missing information", "Customer Entry", MessageBoxButtons.OK);
            }
            else
            {
                connector.SubmitData(firstName.Text, lastName.Text, phoneNum.Text, companyName.Text);
                firstName.Text = " ";
                lastName.Text = " ";
                phoneNum.Text = "";
                companyName.Text = " ";
                firstName.Focus();
            }

        }

        private void firstName_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(firstName.Text))
            {
                //Clears the first name textbox if a number is entered. 
                //Currently working on a better way to do this. 
                firstName.Clear();


            }
        }

        private void lastName_TextChanged(object sender, EventArgs e)
        {
            Regex regex = new Regex("[0-9]");
            if (regex.IsMatch(lastName.Text))
            {
                //Clears the first name textbox if a number is entered. 
                //Currently working on a better way to do this. 
                lastName.Clear();


            }
        }

        private void viewData_Click(object sender, EventArgs e)
        {
            Connector conn = new Connector();

            dataForm form = new dataForm();
            form.Show();
           
              
        }
    }






}
