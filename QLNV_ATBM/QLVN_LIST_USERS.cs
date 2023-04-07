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
    public partial class QLVN_LIST_USERS : Form
    {
        private OracleConnection conn;

        public QLVN_LIST_USERS(OracleConnection conn)
        {
            InitializeComponent();
            this.conn = conn;
        }
        /*
        public void QLVN_LOAD(object sender, EventArgs e)
        {
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT * FROM DA_TABLE_NHANVIEN", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        */
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QLVN_LIST_USERS_Load(object sender, EventArgs e)
        {
            OracleDataAdapter adapter = new OracleDataAdapter("SELECT * FROM DA_TABLE_NHANVIEN", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
