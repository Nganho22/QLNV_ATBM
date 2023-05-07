using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;


namespace QLNV_ATBM
{
    public partial class QLNV_TONGGIAMDOC : Form
    {
        private OracleConnection conn;
        public QLNV_TONGGIAMDOC(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void QLNV_TONGGIAMDOC_Load(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.SEE_TABLE";
            command.Connection = conn;
            OracleParameter param = new OracleParameter();
            command.Parameters.Add("p_table_output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            comboBox1.DataSource = table;
            comboBox1.DisplayMember = "table";

            conn.Close();
        }
    }
}
