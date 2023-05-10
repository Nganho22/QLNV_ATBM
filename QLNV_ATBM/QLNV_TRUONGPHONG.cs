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
    public partial class QLNV_TRUONGPHONG : Form
    {
        OracleConnection conn;
        public QLNV_TRUONGPHONG(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void QLNV_TRUONGPHONG_Load(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.DA_PROC_SELECT_MY_NV_PC";
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
            command2.CommandText = "NGAN.DA_PROC_SELECT_MY_NV_PC";
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

        private void button1_Click(object sender, EventArgs e)
        {
            QLNV_TRUONGPHONG USER =  new QLNV_TRUONGPHONG(conn);
            this.Hide();
            USER.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.DA_PROC_I_MY_NV_PC";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = textBox1.Text;
            command.Parameters.Add("p_input2", OracleDbType.Varchar2).Value = textBox2.Text;
            OracleCommand command2 = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            conn.Close();
            QLNV_TRUONGPHONG USER = new QLNV_TRUONGPHONG(conn);
            this.Hide();
            USER.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.DA_PROC_DELE_MY_NV_PC";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = textBox4.Text;
            command.Parameters.Add("p_input2", OracleDbType.Varchar2).Value = textBox5.Text;
            OracleCommand command2 = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            conn.Close();
            QLNV_TRUONGPHONG USER = new QLNV_TRUONGPHONG(conn);
            this.Hide();
            USER.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.DA_PROC_U_MY_NV_PC";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = textBox5.Text;
            command.Parameters.Add("p_input2", OracleDbType.Varchar2).Value = textBox6.Text;
            command.Parameters.Add("p_input3", OracleDbType.Varchar2).Value = textBox7.Text;
            OracleCommand command2 = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            conn.Close();
            QLNV_TRUONGPHONG USER = new QLNV_TRUONGPHONG(conn);
            this.Hide();
            USER.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
