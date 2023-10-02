using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace QLSach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void load_data()
        {
            SqlConnection con = new SqlConnection(" server = LAPTOP-67F1561J\\DUONGNGOCMAI_SQL ; database = Sach; integrated security = true ");
            SqlDataAdapter da = new SqlDataAdapter(" select * from Sach01", con);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btthem_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" server = LAPTOP-67F1561J\\DUONGNGOCMAI_SQL ; database = Sach; integrated security = true ");
            SqlCommand cmd = new SqlCommand ("insert into Sach01 values ('" +txtma.Text+ "', '" +txttieude.Text+ "', '" + Convert.ToDouble(txtgia.Text)+"', '" +Convert.ToInt16(txtsoluong.Text)+"' )", con);
            con.Open();
            int ret = cmd.ExecuteNonQuery();
            if(ret ==1)
            MessageBox.Show("Them sach thanh cong");
            con.Close();
            load_data();
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" server = LAPTOP-67F1561J\\DUONGNGOCMAI_SQL ; database = Sach; integrated security = true ");
            SqlCommand cmd = new SqlCommand("update Sach01 set tieude = '" + txttieude.Text + "', dongia = '" + Convert.ToDouble(txtgia.Text) + "', soluong = '" + Convert.ToInt16(txtsoluong.Text) + "' where masach = '" + txtma.Text + "'", con);
            con.Open();
            int ret = cmd.ExecuteNonQuery();
            if (ret == 1)
                MessageBox.Show("Cap nhat thanh cong");
            con.Close();
            load_data();
        }

        private void btxoa_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" server = LAPTOP-67F1561J\\DUONGNGOCMAI_SQL ; database = Sach; integrated security = true ");
            SqlCommand cmd = new SqlCommand("delete from Sach01 where masach = '" + txtma.Text + "'", con);
            con.Open();
            int ret = cmd.ExecuteNonQuery();
            if (ret == 1)
                MessageBox.Show("Xoa Sach thanh cong");
            con.Close();
            load_data();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            load_data();

        }

        private void bttim_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(" server = LAPTOP-67F1561J\\DUONGNGOCMAI_SQL ; database = Sach; integrated security = true ");
            SqlDataAdapter da = new SqlDataAdapter(" select * from Sach01 where masach LIKE '%" + txttim.Text+ "%' ", con);
            DataTable dt = new DataTable();
            con.Open();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtma.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txttieude.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtgia.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtsoluong.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
    }
}
