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
    public partial class QLNV_NHANVIEN : Form
    {
        private OracleConnection conn;
        public QLNV_NHANVIEN(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void QLNV_NHANVIEN_Load(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.DA_PROC_SELECT_INFO";
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
            command2.CommandText = "NGAN.DA_PROC_SELECT_MY_PC";
            command2.Connection = conn;
            command2.Parameters.Add("p_table_output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter2 = new OracleDataAdapter(command2);
            DataSet ds2 = new DataSet();
            adapter2.Fill(ds2);
            dataGridView2.DataSource = ds2.Tables[0];
            dataGridView2.AutoResizeRows();
            dataGridView2.AutoResizeColumns();

            OracleCommand command3 = new OracleCommand();
            command3.CommandType = CommandType.StoredProcedure;
            command3.CommandText = "NGAN.DA_PROC_SELECT_PHONGBAN";
            command3.Connection = conn;
            command3.Parameters.Add("p_table_output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter3 = new OracleDataAdapter(command3);
            DataSet ds3 = new DataSet();
            adapter3.Fill(ds3);
            dataGridView3.DataSource = ds3.Tables[0];
            dataGridView3.AutoResizeRows();
            dataGridView3.AutoResizeColumns();

            OracleCommand command4 = new OracleCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.CommandText = "NGAN.DA_PROC_SELECT_DEAN";
            command4.Connection = conn;
            command4.Parameters.Add("p_table_output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter4 = new OracleDataAdapter(command4);
            DataSet ds4 = new DataSet();
            adapter4.Fill(ds4);
            dataGridView4.DataSource = ds4.Tables[0];
            dataGridView4.AutoResizeRows();
            dataGridView4.AutoResizeColumns();
            conn.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command4 = new OracleCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.CommandText = "NGAN.DA_PROC_UPDATE_MY_INFO";
            command4.Connection = conn;
            command4.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = textBox1.Text;
            command4.Parameters.Add("p_input2", OracleDbType.Varchar2).Value = textBox2.Text;
            command4.Parameters.Add("p_input3", OracleDbType.Varchar2).Value = textBox3.Text;
            command4.ExecuteNonQuery();
            conn.Close();
            QLNV_NHANVIEN USER = new QLNV_NHANVIEN(conn);
            this.Hide();
            USER.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command4 = new OracleCommand();
            command4.CommandType = CommandType.StoredProcedure;
            command4.CommandText = "NGAN.DA_PROC_CHECK_PRIV_2";
            command4.Connection = conn;
            command4.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command4.ExecuteNonQuery();
            string outputValue = command4.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "QL")
            {
                QLNV_QUANLY USER = new QLNV_QUANLY(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else if(outputValue == "TP")
            {
                QLNV_TRUONGPHONG USER = new QLNV_TRUONGPHONG(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else if (outputValue =="TC")
            {
                QLNV_TAICHINH USER = new QLNV_TAICHINH(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else if (outputValue =="NS")
            {
                QLNV_NHANSU USER = new QLNV_NHANSU(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else if (outputValue =="TDA")
            {
                QLNV_TRUONGDEAN USER = new QLNV_TRUONGDEAN(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else if (outputValue == "GD")
            {
                QLNV_TONGGIAMDOC USER = new QLNV_TONGGIAMDOC(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            QLNV_NHANVIEN USER = new QLNV_NHANVIEN(conn);   
            this.Hide();
            USER.ShowDialog();
        }
    }
}
