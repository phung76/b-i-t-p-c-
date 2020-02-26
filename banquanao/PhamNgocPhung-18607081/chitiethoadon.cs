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
    public partial class chitiethoadon : Form
    {
        public chitiethoadon()
        {
            InitializeComponent();
        }
        string phung = @"Data Source=WIN10\SQLEXPRESS;Initial Catalog=BanQuanAo;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;

        SqlDataAdapter daaonam = null;
        DataTable dtaonam = null;

        SqlDataAdapter daHD = null;
        DataTable dtHD = null;

        bool them;
        void loadData()
        {
            try
            {
                conn = new SqlConnection(phung);
                daNhanVien = new SqlDataAdapter("select *from ChiTietHoaDon", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);
                dgvchitiethoadon.DataSource = dtNhanVien;
                dgvchitiethoadon.AutoResizeColumns();

                daNhanVien = new SqlDataAdapter("select * from ChiTietHoaDon", conn);

                daaonam = new SqlDataAdapter("select * from AoNam", conn);
                dtaonam = new DataTable();
                dtaonam.Clear();
                daaonam.Fill(dtaonam);
                daaonam = new SqlDataAdapter("select * from AoNam", conn);

                daHD = new SqlDataAdapter("select * from HoaDonKH", conn);
                dtHD = new DataTable();
                dtHD.Clear();
                daHD.Fill(dtHD);
                daHD = new SqlDataAdapter("select * from HoaDonKH", conn);

                txtdongia.ResetText();
                txtsoluong.ResetText();
                txtthanhtien.ResetText();
                cboMaAo.ResetText();
                cboMaHD.ResetText();

                txtsoluong.Enabled = false;
                btntrove.Enabled = false;
                txtthanhtien.Enabled = false;
                cboMaAo.Enabled = false;
                cboMaHD.Enabled = false;

                btnhuybo.Enabled = true;
                btntrove.Enabled = false;
                btnluu.Enabled = false;

             

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

       
         
        private void chitiethoadon_Load(object sender, EventArgs e)
        {
            loadData();

            
         
         
        }

        private void dgvchitiethoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnluu_Click(object sender, EventArgs e)
        {

            int a;
            int b;
            a = Convert.ToInt16(txtdongia.Text);
            b = Convert.ToInt16(txtsoluong.Text);
            int c;
            c = a * b;
            txtthanhtien.Text = c.ToString();

            if (them)
            {
                try
                {
                   

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.Text;

                    cmd.CommandText = System.String.Concat("Insert Into ChiTietHoaDon Values(" + "'" +
                        this.cboMaHD.Text.ToString() + "','" +
                        this.cboMaAo.Text.ToString() + "',N'" +
                        this.txtsoluong.Text.ToString() + "',N'" +
                        this.txtdongia.Text.ToString() + "',N'" +
                        this.txtthanhtien.Text.ToString() + "')");

                    

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

                int r = dgvchitiethoadon.CurrentCell.RowIndex;
                string strkhachhang = dgvchitiethoadon.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Update ChiTietHoaDon Set MaHD='" +
                    this.cboMaHD.Text.ToString() + "'," + "MaAo='" +
                    cboMaAo.Text.ToString() + "'," + "SoLuong='" +
                    txtsoluong.Text.ToString() + "'," + "DonGia='" +
                     txtdongia.Text.ToString() + "'," + "ThanhTien='" +
                    txtthanhtien.Text.ToString() +
                    "' Where MaHD ='" + strkhachhang + "'");
             

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

                int r = dgvchitiethoadon.CurrentCell.RowIndex;
                string strKhachHang = dgvchitiethoadon.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Delete from ChiTietHoaDon where MaHD='" + strKhachHang + "' ");
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
            
            txtdongia.ResetText();
            txtsoluong.ResetText();
            txtthanhtien.ResetText();
            cboMaAo.ResetText();
            cboMaHD.ResetText();

            btnhuybo.Enabled = false;
            btntrove.Enabled = false;
            btnluu.Enabled = true;


            txtsoluong.Enabled = true;
            btntrove.Enabled = true;
            txtdongia.Enabled=true;
            cboMaAo.Enabled = true;
            cboMaHD.Enabled = true;


            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnreload.Enabled = true;


            this.cboMaAo.DataSource = dtaonam;
            cboMaAo.DisplayMember = "MaAo";
            cboMaAo.ValueMember = "MaAo";


            this.cboMaHD.DataSource = dtHD;
            cboMaHD.DisplayMember = "MaHD";
            cboMaHD.ValueMember = "MaHD";

            conn.Open();

          
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void btnsua_Click(object sender, EventArgs e)
        {
            them = false;
          
            int r = dgvchitiethoadon.CurrentCell.RowIndex;
            txtdongia.ResetText();
            txtsoluong.ResetText();
            txtthanhtien.ResetText();
            cboMaAo.ResetText();
            cboMaHD.ResetText();

            //chuyển thông tin lên pannel

            this.cboMaHD.Text = dgvchitiethoadon.Rows[r].Cells[0].Value.ToString();
            this.cboMaAo.Text = dgvchitiethoadon.Rows[r].Cells[1].Value.ToString();
            this.txtsoluong.Text = dgvchitiethoadon.Rows[r].Cells[2].Value.ToString();
            this.txtdongia.Text = dgvchitiethoadon.Rows[r].Cells[3].Value.ToString();
             this.txtthanhtien.Text = dgvchitiethoadon.Rows[r].Cells[4].Value.ToString();

            //Cho thao tác trên các Lưu /Hủy/Panel
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;
            
            txtsoluong.Enabled = true;
            btntrove.Enabled = true;
            
            cboMaAo.Enabled = true;
            cboMaHD.Enabled = true;

            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.cboMaHD.Focus();

            this.cboMaAo.DataSource = dtaonam;
            cboMaAo.DisplayMember = "MaAo";
            cboMaAo.ValueMember = "MaAo";


            this.cboMaHD.DataSource = dtHD;
            cboMaHD.DisplayMember = "MaHD";
            cboMaHD.ValueMember = "MaHD";

        }
        }
    }

