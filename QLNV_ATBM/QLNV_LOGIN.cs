using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.VsDevTools;
using Oracle.ManagedDataAccess.Client;


namespace QLNV_ATBM
{
    public partial class QLNV_LOGIN : Form
    {

        OracleConnection conn;
        public QLNV_LOGIN()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //QLNV_MENU tamga = new QLNV_MENU();
            //tamga.Show();
            string UconnectDBOracle = @"Data source = localhost:1521/xe;" + " USER ID = " + textBox1.Text + "; Password = " + textBox2.Text + ";";
            try
            {
                conn = new OracleConnection(UconnectDBOracle);
                conn.Open();
                QLNV_MENU menu = new QLNV_MENU(conn);
                menu.ShowDialog();
                //MessageBox.Show("Dang nhap thanh cong!");
                //conn.Close();
                this.Hide();
            }
            catch(Exception exp)
            {
                MessageBox.Show("ERROR!" + exp.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
