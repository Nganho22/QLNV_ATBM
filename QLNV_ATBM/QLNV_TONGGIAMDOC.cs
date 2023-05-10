using System;
using System.Collections.Generic;
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

namespace QLNV_ATBM
{
    public partial class QLNV_TONGGIAMDOC : Form
    {
        OracleConnection conn;
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
            command.CommandText = "NGAN.DA_PROC_SELECT_KEY";
            command.Connection = conn;
            OracleParameter param = new OracleParameter();
            command.Parameters.Add("p_table_output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();


            OracleCommand command2 = new OracleCommand();
            command2.CommandType = CommandType.StoredProcedure;
            command2.CommandText = "NGAN.DA_PROC_SELECT_DIARY";
            command2.Connection = conn;
            command2.Parameters.Add("p_table_output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter2 = new OracleDataAdapter(command2);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            dataGridView2.AutoResizeRows();
            dataGridView2.AutoResizeColumns();
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            QLNV_NHANVIEN USER = new QLNV_NHANVIEN(conn);
            this.Hide();
            USER.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLNV_TONGGIAMDOC USER = new QLNV_TONGGIAMDOC(conn);
                this.Hide();
                USER.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.DA_PROC_U_KEY";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = textBox1.Text;
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
            OracleCommand command2 = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            MessageBox.Show(outputValue);
            conn.Close();
            QLNV_TONGGIAMDOC USER = new QLNV_TONGGIAMDOC(conn);
            this.Hide();
            USER.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
