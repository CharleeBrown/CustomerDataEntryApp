﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Text.RegularExpressions;


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
            if (phoneNum.TextLength == 7)
            {
                phoneNum.Text = phoneNum.Text + "-";
                phoneNum.SelectionStart = phoneNum.TextLength;
            }
       

        private void button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(firstName.Text)||string.IsNullOrEmpty(lastName.Text)||string.IsNullOrEmpty(phoneNum.Text)||

                string.IsNullOrEmpty(companyName.Text))
                {
                 MessageBox.Show("Enter missing information", "Customer Entry", MessageBoxButtons.OK);
                }
            else {
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

     
    }
    public class Connector

    {
        

        public  void SubmitData(string fName, string lastname, string phoneNum, string comp)
        {
            
            SqlConnection mainConn = new SqlConnection();
        
            mainConn.ConnectionString = ConfigurationManager.ConnectionStrings["maindb"].ConnectionString;

            string enterData = @"INSERT INTO customerInfo  VALUES ('"+fName+"' ,'"+ lastname + "' ,'"+phoneNum+"','"+comp+"');";

            SqlCommand dataComm = new SqlCommand(enterData);

            dataComm.Connection = mainConn;

            using (mainConn)
            {
                try
                {
                    mainConn.Open();
                    dataComm.ExecuteNonQuery();


                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    mainConn.Close();
                    
                }
                
                
            }
            
            
        }

    }
}
