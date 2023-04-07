//using Oracle.DataAccess.Client;
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
    public partial class QLNV_MENU : Form
    {
        private OracleConnection conn;
        public QLNV_MENU(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            QLVN_LIST_USERS USER = new QLVN_LIST_USERS(conn);
            USER.ShowDialog();
            this.Hide();
        }
    }
}
