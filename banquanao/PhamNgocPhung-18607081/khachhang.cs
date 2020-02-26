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
    public partial class khachhang : Form
    {
        public khachhang()
        {
            InitializeComponent();
        }
        string phung = @"Data Source=WIN10\SQLEXPRESS;Initial Catalog=BanQuanAo;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;

        bool them;
        void loadData()
        {
            try
            {
                conn = new SqlConnection(phung);
                daNhanVien = new SqlDataAdapter("select *from KhachHang", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                dgvkhachhang.DataSource = dtNhanVien;
                dgvkhachhang.AutoResizeColumns();

                daNhanVien = new SqlDataAdapter("select * fromKhachHang", conn);
                
                txtMaKH.ResetText();
                txtTenKH.ResetText();
                txtSdt.ResetText();
                txtDiachi.ResetText();
            
                btnhuybo.Enabled = true;
                btntrove.Enabled = false;
                btnluu.Enabled = false;

                txtMaKH.Enabled = false;
                txtTenKH.Enabled = false;
                txtSdt.Enabled = false;
                txtDiachi.Enabled = false;

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

        private void khachhang_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtSdt.ResetText();
            txtDiachi.ResetText();

            btnhuybo.Enabled = true;
            btntrove.Enabled = false;
            btnluu.Enabled = false;

            txtMaKH.Enabled = false;
            txtTenKH.Enabled = false;
            txtSdt.Enabled = false;
            txtDiachi.Enabled = false;

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnreload.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    
                    cmd.CommandText = System.String.Concat("Insert Into KhachHang Values(" + "'" +
                        this.txtMaKH.Text.ToString() + "','" +
                        this.txtTenKH.Text.ToString() + "',N'" +
                        this.txtDiachi.Text.ToString() + "',N'" +
                        this.txtSdt.Text.ToString() + "')");

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

                int r = dgvkhachhang.CurrentCell.RowIndex;
                string strkhachhang = dgvkhachhang.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Update KhachHang Set MaKH='" +
                    this.txtMaKH.Text.ToString() + "'," + "TenKH='" +
                    txtTenKH.Text.ToString() + "'," + "DiaChi='" +
                    txtDiachi.Text.ToString() + "'," + "Sdt='" +
                    txtSdt.Text.ToString() +
                    "' Where MaKH ='" + strkhachhang + "'");
                
                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                loadData();
                MessageBox.Show("Sửa xong");
            }
            conn.Close();
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
                
                int r = dgvkhachhang.CurrentCell.RowIndex;
                string strKhachHang = dgvkhachhang.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Delete from KhachHang where MaKH='" + strKhachHang + "' ");
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

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaKH.ResetText();
            txtTenKH.ResetText();
            txtSdt.ResetText();
            txtDiachi.ResetText();

            btnhuybo.Enabled = false;
            btntrove.Enabled = false;
            btnluu.Enabled = true;


            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtSdt.Enabled = true;
            txtDiachi.Enabled = true;
          

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnreload.Enabled = true;

        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
          
            int r = dgvkhachhang.CurrentCell.RowIndex;

            //chuyển thông tin lên pannel

            this.txtMaKH.Text = dgvkhachhang.Rows[r].Cells[0].Value.ToString();
            this.txtTenKH.Text = dgvkhachhang.Rows[r].Cells[1].Value.ToString();
            this.txtDiachi.Text = dgvkhachhang.Rows[r].Cells[2].Value.ToString();
            this.txtSdt.Text = dgvkhachhang.Rows[r].Cells[3].Value.ToString();


            //Cho thao tác trên các Lưu /Hủy/Panel
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;
            
            txtMaKH.Enabled = true;
            txtTenKH.Enabled = true;
            txtDiachi.Enabled = true;
            txtSdt.Enabled = true;

            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.txtMaKH.Focus();
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnreload_Click(object sender, EventArgs e)
        {

        }
    }
}
