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

namespace PhamNgocPhung_18607081
{
    public partial class aonam : Form
    {
        public aonam()
        {
            InitializeComponent();
        }
        string phung = @"Data Source=WIN10\SQLEXPRESS;Initial Catalog=BanQuanAo;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daaonam = null;
        DataTable dtaonam = null;

        bool them;
        void loadData()
        {
            try
            {
                conn = new SqlConnection(phung);
                daaonam = new SqlDataAdapter("select *from AoNam", conn);
                dtaonam = new DataTable();
                dtaonam.Clear();
                daaonam.Fill(dtaonam);
                dgvao.DataSource = dtaonam;
                dgvao.AutoResizeColumns();

                daaonam = new SqlDataAdapter("select * from AoNam", conn);                 

                txtchatlieu.ResetText();
               // txtdongia.ResetText();
                txtdonvitinh.ResetText();
                txtfontsize.ResetText();
                txtmaao.ResetText();
                txttenao.ResetText();
             
                btnhuybo.Enabled = false;
                btntrove.Enabled = false;
                btnluu.Enabled = false;


                txtchatlieu.Enabled = false;
               // txtdongia.Enabled = false;
                txtdonvitinh.Enabled = false;
                txtfontsize.Enabled = false;
                txtmaao.Enabled = false;
                txttenao.Enabled = false;

                btnxoa.Enabled = true;
                btnthem.Enabled = true;
                btnsua.Enabled = true;
                btnreload.Enabled = true;



            }
            catch (SqlException)
            {
                MessageBox.Show("không lấy được nội dung table .lỗi");
            }
        }
        private void aonam_Load(object sender, EventArgs e)
        {
            loadData();

        }

        private void btnxoa_Click(object sender, EventArgs e)
        {
            conn.Open();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                //Lấy thứ tự record hiện hành
                int r = dgvao.CurrentCell.RowIndex;
                string straonam = dgvao.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Delete from AoNam where MaAo='" + straonam + "' ");
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                loadData();
                
                MessageBox.Show("Đã xong");

            }
            catch (SqlException)
            {
                MessageBox.Show("lỗi rồi xóa không được");
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;

            txtchatlieu.ResetText();
           // txtdongia.ResetText();
            txtdonvitinh.ResetText();
            txtfontsize.ResetText();
            txtmaao.ResetText();
            txttenao.ResetText();

            btnhuybo.Enabled = true;
            btntrove.Enabled = false;
            btnluu.Enabled = true;


            txtchatlieu.Enabled = true;
           // txtdongia.Enabled = true;
            txtdonvitinh.Enabled = true;
            txtfontsize.Enabled = true;
            txtmaao.Enabled = true;
            txttenao.Enabled = true;

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnreload.Enabled = true;

     
        }

        private void btnluu_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (them)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = System.String.Concat("Insert Into AoNam Values(" + "'" +
                        this.txtmaao.Text.ToString() + "','" +
                        this.txttenao.Text.ToString() + "',N'" +
                        this.txtdonvitinh.Text.ToString() + "',N'" +
                       // this.txtdongia.Text.ToString() + "',N'" +
                        this.txtfontsize.Text.ToString() + "',N'" +
                        this.txtchatlieu.Text.ToString() + "')");
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.ExecuteNonQuery();
                    loadData();
                    MessageBox.Show("Thêm thành công");
                }
                catch (SqlException)
                {
                    MessageBox.Show("Không thêm được");
                }
            }
        
          if (!them)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;

                int r = dgvao.CurrentCell.RowIndex;
                string straonam = dgvao.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Update AoNam Set MaAo='" +
                    this.txtmaao.Text.ToString() + "'," + "TenAo='" +
                    txttenao.Text.ToString() + "'," + "DonViTinh='" +
                    txtdonvitinh.Text.ToString() + "'," + "FontSize='" +
                   // txtdongia.Text.ToString() + "'," + "FontSize='" +
                    txtfontsize.Text.ToString() + "'," + "ChatLieu='" +
                    txtchatlieu.Text.ToString() +
                    "' Where MaAo ='" + straonam + "'");

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                loadData();
                MessageBox.Show("Sửa xong");
            }
            conn.Close();
        }
    
        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            this.panel1.Enabled = true;
            int r = dgvao.CurrentCell.RowIndex;
            
            //chuyển thông tin lên pannel

            this.txtmaao.Text = dgvao.Rows[r].Cells[0].Value.ToString();
            this.txttenao.Text = dgvao.Rows[r].Cells[1].Value.ToString();
            this.txtdonvitinh.Text = dgvao.Rows[r].Cells[2].Value.ToString();
           // this.txtdongia.Text = dgvao.Rows[r].Cells[3].Value.ToString();
            this.txtfontsize.Text = dgvao.Rows[r].Cells[3].Value.ToString();
            this.txtchatlieu.Text = dgvao.Rows[r].Cells[4].Value.ToString();
            
            //Cho thao tác trên các Lưu /Hủy/Panel
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;

            txtchatlieu.Enabled = true;
           // txtdongia.Enabled = true;
            txtdonvitinh.Enabled = true;
            txtfontsize.Enabled = true;
            txtmaao.Enabled = true;
            txttenao.Enabled = true;
            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.txtchatlieu.Focus();
        }

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;

            txtchatlieu.ResetText();
            //txtdongia.ResetText();
            txtdonvitinh.ResetText();
            txtfontsize.ResetText();
            txtmaao.ResetText();

            txtchatlieu.Enabled = true;
          //  txtdongia.Enabled = true;
            txtdonvitinh.Enabled = true;
            txtfontsize.Enabled = true;
            txtmaao.Enabled = true;
            txttenao.Enabled = true;
            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.txtchatlieu.Focus();
        
        }

   
    }         
}
