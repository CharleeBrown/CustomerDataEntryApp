using System;
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


public class Connector

{


    public void SubmitData(string fName, string lastname, string phoneNum, string comp)
    {

        

      
      

        using (SqlConnection mainConn = new SqlConnection())
        {
            string enterData = @"INSERT INTO customerInfo  VALUES ('" + fName + "' ,'" + lastname + "' ,'" + phoneNum + "','" + comp + "');";

            SqlCommand dataComm = new SqlCommand(enterData);

            dataComm.Connection = mainConn;
            mainConn.ConnectionString = ConfigurationManager.ConnectionStrings["maindb"].ConnectionString;

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