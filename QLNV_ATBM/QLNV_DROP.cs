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
    public partial class QLNV_DROP : Form
    {
        private OracleConnection conn;
        public QLNV_DROP(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void QLNV_DROP_Load(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Close();
            QLNV_USER_ROLE_PRIV USER = new QLNV_USER_ROLE_PRIV(conn);
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
            conn.Open();
            string a = comboBox1.Text;
            OracleCommand command = new OracleCommand();
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "NGAN.DROP_OBJECT";
            command.Connection = conn;
            command.Parameters.Add("p_input1", OracleDbType.Varchar2).Value = textBox1.Text;
            command.Parameters.Add("p_input2", OracleDbType.Varchar2).Value = a;
            command.Parameters.Add("p_output", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
            OracleCommand command2 = new OracleCommand("ALTER SESSION SET \"_ORACLE_SCRIPT\" = TRUE", conn);
            command2.ExecuteNonQuery();
            command.ExecuteNonQuery();
            string outputValue = command.Parameters["p_output"].Value.ToString();
            MessageBox.Show(outputValue);
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
