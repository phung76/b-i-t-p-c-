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
    public partial class nhanvien : Form
    {
        public nhanvien()
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
                daNhanVien = new SqlDataAdapter("select *from NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                dgvnhanvien.DataSource = dtNhanVien;
                dgvnhanvien.AutoResizeColumns();

                daNhanVien = new SqlDataAdapter("select * from NhanVien", conn);
                
                txtMaNV.ResetText();
                txtHoNV.ResetText();
                txtTenNV.ResetText();
                txtDiaChi.ResetText();
                txtgioitinh.ResetText();
                txtNgaySinh.ResetText();
                txtMaNV.ResetText();

                btnhuybo.Enabled = false;
                btntrove.Enabled = false;
                btnluu.Enabled = false;


                txtMaNV.Enabled = false;
                txtHoNV.Enabled = false;
                txtTenNV.Enabled = false;
                txtDiaChi.Enabled = false;
                txtgioitinh.Enabled = false;
                txtNgaySinh.Enabled = false;
                txtMaNV.Enabled = false;

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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void nhanvien_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;

            txtMaNV.ResetText();
            txtHoNV.ResetText();
            txtTenNV.ResetText();
            txtDiaChi.ResetText();
            txtgioitinh.ResetText();
            txtNgaySinh.ResetText();
            txtSdt.ResetText();

            btnhuybo.Enabled = false;
            btntrove.Enabled = false;
            btnluu.Enabled = true;


            txtMaNV.Enabled = true;
            txtHoNV.Enabled = true;
            txtTenNV.Enabled = true;
            txtDiaChi.Enabled = true;
            txtgioitinh.Enabled = true;
            txtNgaySinh.Enabled = true;
            txtSdt.Enabled = true; ;

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

                    cmd.CommandText = System.String.Concat("Insert Into NhanVien Values(" + "'" +
                        this.txtMaNV.Text.ToString() + "','" +
                        this.txtHoNV.Text.ToString() + "',N'" +
                        this.txtTenNV.Text.ToString() + "',N'" +
                        this.txtDiaChi.Text.ToString() + "',N'" + 
                        this.txtgioitinh.Text.ToString() + "',N'" +
                        this.txtSdt.Text.ToString() + "',N'" +
                        this.txtNgaySinh.Text.ToString() + "')");

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

                int r = dgvnhanvien.CurrentCell.RowIndex;
                string straonam = dgvnhanvien.Rows[r].Cells[0].Value.ToString();

                cmd.CommandText = System.String.Concat("Update NhanVien Set MaNV='" +
                    this.txtMaNV.Text.ToString() + "'," + "HoNV='" +
                    txtHoNV.Text.ToString() + "'," + "TenNV='" +
                    txtTenNV.Text.ToString() + "'," + "DiaChi='" +
                    txtDiaChi.Text.ToString() + "'," + "GioiTinh='" +
                    txtgioitinh.Text.ToString() + "',"  +"Sdt='" +
                    txtSdt.Text.ToString() + "'," + "NgaySinh='" +
                    txtNgaySinh.Text.ToString() +
                    "' Where MaNV ='" + straonam + "'");

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

                int r = dgvnhanvien.CurrentCell.RowIndex;
                string strNhanVien = dgvnhanvien.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Delete from NhanVien where MaNV='" + strNhanVien + "' ");
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

        private void btnreload_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
            this.panel1.Enabled = true;
            int r = dgvnhanvien.CurrentCell.RowIndex;
            
            //chuyển thông tin lên pannel

            this.txtMaNV.Text = dgvnhanvien.Rows[r].Cells[0].Value.ToString();
            this.txtHoNV.Text = dgvnhanvien.Rows[r].Cells[1].Value.ToString();
            this.txtTenNV.Text = dgvnhanvien.Rows[r].Cells[2].Value.ToString();
            this.txtDiaChi.Text = dgvnhanvien.Rows[r].Cells[3].Value.ToString();
           // this.rdNu.Text = dgvnhanvien.Rows[r].Cells[4].Value.ToString();
            this.txtSdt.Text = dgvnhanvien.Rows[r].Cells[5].Value.ToString();
            this.txtNgaySinh.Text = dgvnhanvien.Rows[r].Cells[5].Value.ToString();

            //Cho thao tác trên các Lưu /Hủy/Panel
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;

            txtMaNV.Enabled = true;
            txtHoNV.Enabled = true;
            txtTenNV.Enabled = true;
            txtDiaChi.Enabled = true;
            txtgioitinh.Enabled = true;
            txtSdt.Enabled = true;
            txtNgaySinh.Enabled = true;
               
            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.txtMaNV.Focus();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtgioitinh_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
