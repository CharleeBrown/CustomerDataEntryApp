using System;
using System.Configuration;
using System.Data;
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
        SqlConnection mainConn = new SqlConnection(ConfigurationManager.ConnectionStrings["maindb"].ConnectionString));
        string pullComm = "SELECT * FROM  Customers.dbo.customerInfo";
        SqlCommand dataComm = new SqlCommand(pullComm);
        dataComm.Connection = mainConn;
        ListViewItem mainList = new ListViewItem();

        try
        {
            mainConn.Open();

            SqlDataAdapter ada = new SqlDataAdapter(pullComm, mainConn);
            DataTable dt = new DataTable();
            ada.Fill(dt);

            foreach (DataRow row in dt.Rows)
            {

                ListViewItem listItem = new ListViewItem(row["id"].ToString());
                listItem.SubItems.Add(row["firstName"].ToString());
                listItem.SubItems.Add(row["lastName"].ToString());
                listItem.SubItems.Add(row["phoneNumber"].ToString());
                listItem.SubItems.Add(row["companyName"].ToString());

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