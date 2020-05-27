using System.Windows.Forms;

namespace CustomerDataEntry
{
    public partial class dataForm : Form
    {
        public dataForm()
        {
            InitializeComponent();
        }

        private void dataForm_Load(object sender, System.EventArgs e)
        {
            dataList.View = View.Details;
            dataList.Columns.Add("ID");
            dataList.Columns.Add("First Name");
            dataList.Columns.Add("Last Name");
            dataList.Columns.Add("Phone Number");
            dataList.Columns.Add("Company");

            dataList.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);



            Connector conn = new Connector();
            dataList.Items.Add(conn.PullData());
        }

    }
}
