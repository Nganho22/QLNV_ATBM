﻿using System;
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
    public partial class QLNV_USER_ROLE_PRIV : Form
    {
        private OracleConnection conn;
        public QLNV_USER_ROLE_PRIV(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_USER_ROLE_PRIV USER = new QLNV_USER_ROLE_PRIV(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLVN_LIST_USERS USER = new QLVN_LIST_USERS(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_LIST_ROLES USER = new QLNV_LIST_ROLES(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_LIST_TABLES USER = new QLNV_LIST_TABLES(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_LIST_VIEWS USER = new QLNV_LIST_VIEWS(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_ADD_PRIV USER = new QLNV_ADD_PRIV(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_REVOKE_PRIV USER = new QLNV_REVOKE_PRIV(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_CREATE_TABLE USER = new QLNV_CREATE_TABLE(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_ADD_COL USER = new QLNV_ADD_COL(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_CREATE_USER USER = new QLNV_CREATE_USER(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_CREATE_ROLE USER = new QLNV_CREATE_ROLE(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_CREATE_VIEW USER = new QLNV_CREATE_VIEW(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_ADD_ROLE USER = new QLNV_ADD_ROLE(conn);
            USER.ShowDialog();
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.SEE_USER_ROLE_PRIVS";
            command.Connection = conn;
            command.Parameters.Add("p_input", OracleDbType.Varchar2).Value = textBox1.Text;
            command.Parameters.Add("p_table_output", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            command.Parameters.Add("p_table_output2", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            OracleDataAdapter adapter = new OracleDataAdapter(command);
            DataSet ds1 = new DataSet();
            adapter.Fill(ds1);
            DataTable dt1 = ds1.Tables[0];
            DataTable dt2 = ds1.Tables[1];

            dt1.Merge(dt2);

            dataGridView1.DataSource = dt1;

            dataGridView1.AutoResizeRows();
            dataGridView1.AutoResizeColumns();
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
