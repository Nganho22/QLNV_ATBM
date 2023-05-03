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
    public partial class QLNV_ADD_PRIV : Form
    {
        private OracleConnection conn;
        public QLNV_ADD_PRIV(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "GRANT_PRIV_TO_USER";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_ADD_PRIV USER = new QLNV_ADD_PRIV(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "SEE_USER";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLVN_LIST_USERS USER = new QLVN_LIST_USERS(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "SEE_ROLE";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_LIST_ROLES USER = new QLNV_LIST_ROLES(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "SEE_TABLE";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_LIST_TABLES USER = new QLNV_LIST_TABLES(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "SEE_VIEW";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_LIST_VIEWS USER = new QLNV_LIST_VIEWS(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "SEE_USER_ROLE_PRIVS";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_USER_ROLE_PRIV USER = new QLNV_USER_ROLE_PRIV(conn);
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
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "REVOKE_PRIV";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_REVOKE_PRIV USER = new QLNV_REVOKE_PRIV(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "CREATE_TABLE";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_CREATE_TABLE USER = new QLNV_CREATE_TABLE(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "ADD_COLUMN";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_ADD_COL USER = new QLNV_ADD_COL(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "CREATE_USERR";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_CREATE_USER USER = new QLNV_CREATE_USER(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "CREATE_ROLEE";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_CREATE_ROLE USER = new QLNV_CREATE_ROLE(conn);
                this.Hide();
                USER.ShowDialog();
            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "CREATE_VIEW";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_CREATE_VIEW USER = new QLNV_CREATE_VIEW(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.CHECK_PRIV";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = "GRANT_ROLE_TO_USER";
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "YES")
            {
                QLNV_ADD_ROLE USER = new QLNV_ADD_ROLE(conn);
                this.Hide();
                USER.ShowDialog();

            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.GRANT_PRIV_TO_USER";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = textBox1.Text;
            command.Parameters.Add("p_input2", OracleDbType.Varchar2).Value = textBox2.Text;
            command.Parameters.Add("p_input3", OracleDbType.Varchar2).Value = textBox3.Text;
            if (checkBox1.Checked)
            {
                command.Parameters.Add("p_input4", OracleDbType.Varchar2).Value = " WITH GRANT OPTION";
            }
            else
            {
                command.Parameters.Add("p_input4", OracleDbType.Varchar2).Value = " ";
            }
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 20).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            MessageBox.Show(outputValue);
            conn.Close();

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            conn.Open();
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.GET_CUR_USER";
            command.Connection = conn;
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 100).Direction = ParameterDirection.Output;
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            conn.Close();
            if (outputValue == "NGAN")
            {
                QLNV_DROP USER = new QLNV_DROP(conn);
                USER.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show("YOU DON'T HAVE PERMISSION!");
            }
        }
    }
}
