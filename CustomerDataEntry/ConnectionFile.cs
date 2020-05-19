using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;


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
    }

    public ListViewItem PullData()
    {
        using (SqlConnection mainConn = new SqlConnection())
        {
            string pullComm = @"SELECT * FROM  customerInfo;";

            SqlCommand dataComm = new SqlCommand(pullComm);

            dataComm.Connection = mainConn;
            mainConn.ConnectionString = ConfigurationManager.ConnectionStrings["maindb"].ConnectionString;
            ListViewItem mainList = new ListViewItem();
            try
            {
                mainConn.Open();
                dataComm.ExecuteNonQuery();
                SqlDataReader reader = dataComm.ExecuteReader();
               
                while (reader.Read())
                {
                    ListViewItem listItem = new ListViewItem(reader["id"].ToString());
                    listItem.SubItems.Add(reader["fname"].ToString());
                    listItem.SubItems.Add(reader["lastName"].ToString());
                    listItem.SubItems.Add(reader["phoneNum"].ToString());
                    listItem.SubItems.Add(reader["comp"].ToString());
                    mainList = listItem;

                }
               

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mainConn.Close();
                
            }

            return mainList;
        }
        
    }
}