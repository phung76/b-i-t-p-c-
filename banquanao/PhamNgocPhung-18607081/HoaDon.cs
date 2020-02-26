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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        string phung = @"Data Source=WIN10\SQLEXPRESS;Initial Catalog=BanQuanAo;Integrated Security=True";
        SqlConnection conn = null;
        SqlDataAdapter daHD = null;
        DataTable dtHD = null;


        SqlDataAdapter daNhanVien = null;
        DataTable dtNhanVien = null;

        SqlDataAdapter daaonam = null;
        DataTable dtaonam = null;

        SqlDataAdapter daKH = null;
        DataTable dtKH = null;

        bool them;
        void loadData()
        {
            try
            {
                conn = new SqlConnection(phung);

                daHD = new SqlDataAdapter("select *from HoaDonKH", conn);
                dtHD = new DataTable();
                dtHD.Clear();
                daHD.Fill(dtHD);
                dgvhdkh.DataSource = dtHD;
                dgvhdkh.AutoResizeColumns();

                daHD = new SqlDataAdapter("select * from HoaDonKH", conn);


                daNhanVien = new SqlDataAdapter("select *from NhanVien", conn);
                dtNhanVien = new DataTable();
                dtNhanVien.Clear();
                daNhanVien.Fill(dtNhanVien);

                daNhanVien = new SqlDataAdapter("select * from NhanVien", conn);


                daaonam = new SqlDataAdapter("select * from AoNam", conn);
                dtaonam = new DataTable();
                dtaonam.Clear();
                daaonam.Fill(dtaonam);
                daaonam = new SqlDataAdapter("select * from AoNam", conn);

                daKH = new SqlDataAdapter("select * from KhachHang", conn);
                dtKH = new DataTable();
                dtKH.Clear();
                daKH.Fill(dtKH);
                daKH = new SqlDataAdapter("select * from KhachHang", conn);

                
               
                txtdonGia.ResetText();
              //  txtSoluong.ResetText();
                cboMakh.ResetText();
                cboMaNV.ResetText();
                txtngaylap.ResetText();
                cboMaAo.ResetText();
                txtMaHD.ResetText();

                btnhuybo.Enabled = false;
                btntrove.Enabled = false;
                btnluu.Enabled = false;


                txtdonGia.Enabled = false;
               // txtSoluong.Enabled = false;
                txtngaylap.Enabled = false;
                txtMaHD.Enabled = false;
                cboMakh.Enabled = false;
                cboMaAo.Enabled = false;
                cboMaNV.Enabled = false;

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
        private void hoaDon_Load(object sender, EventArgs e)
        {
          loadData();
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            them = false;

            int r = dgvhdkh.CurrentCell.RowIndex;

            //chuyển thông tin lên pannel

            this.txtMaHD.Text = dgvhdkh.Rows[r].Cells[0].Value.ToString();
            this.cboMaNV.Text = dgvhdkh.Rows[r].Cells[1].Value.ToString();
            this.cboMakh.Text = dgvhdkh.Rows[r].Cells[2].Value.ToString();
            //this.txtSoluong.Text = dgvhdkh.Rows[r].Cells[3].Value.ToString();
            this.txtdonGia.Text = dgvhdkh.Rows[r].Cells[4].Value.ToString();
            this.txtngaylap.Text = dgvhdkh.Rows[r].Cells[5].Value.ToString();
            
            //Cho thao tác trên các Lưu /Hủy/Panel
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;

            txtMaHD.Enabled = true;
            cboMaNV.Enabled = true;
            cboMakh.Enabled = true;
           // txtSoluong.Enabled = true;
            txtdonGia.Enabled = true;
            txtngaylap.Enabled = true;

            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.txtMaHD.Focus();
        }

        private void btntrove_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;

            txtdonGia.ResetText();
           // txtSoluong.ResetText();
            cboMakh.ResetText();
            cboMaNV.ResetText();
            txtngaylap.ResetText();
            cboMaAo.ResetText();
            txtMaHD.ResetText();

            btnhuybo.Enabled = true;
            btntrove.Enabled = false;
            btnluu.Enabled = true;



            txtdonGia.Enabled = true;
           // txtSoluong.Enabled = true;
            txtngaylap.Enabled = true;
            txtMaHD.Enabled = true;
            cboMakh.Enabled = true;
            cboMaAo.Enabled = true;
            cboMaNV.Enabled = true;

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnreload.Enabled = true;

            this.cboMaAo.DataSource = dtaonam;
            cboMaAo.DisplayMember = "MaAo";
            cboMaAo.ValueMember = "MaAo";


            this.cboMaNV.DataSource = dtNhanVien;
            cboMaNV.DisplayMember = "MaNV";
            cboMaNV.ValueMember = "MaNV";
            
            this.cboMakh.DataSource = dtKH;
            cboMakh.DisplayMember = "MaKH";
            cboMakh.ValueMember = "MaKH";
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

                    cmd.CommandText = System.String.Concat("Insert Into HoaDonKH Values(" + "'" +
                        this.txtMaHD.Text.ToString() + "','" +
                        this.cboMaNV.Text.ToString() + "',N'" +
                        //this.cboMaAo.Text.ToString() + "',N'" +
                        this.cboMakh.Text.ToString() + "',N'" +
                       // this.txtSoluong.Text.ToString() + "',N'" +
                        this.txtdonGia.Text.ToString() + "',N'" +
                        this.txtngaylap.Text.ToString() + "')");

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

                int r = dgvhdkh.CurrentCell.RowIndex;
                string straonam = dgvhdkh.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Update HoaDonKH Set MaHD='" +
                    this.txtMaHD.Text.ToString() + "'," + "MaNV='" +
                    cboMaNV.Text.ToString() + "'," + "MaKH='" +
                    //cboMaAo.Text.ToString() + "'," + "MaKH='" +
                    cboMakh.Text.ToString() + "'," + "DonGia='" +
                  //  txtSoluong.Text.ToString() + "'," + "DonGia='" +
                    txtdonGia.Text.ToString() + "'," + "NgayLap='" +
                    txtngaylap.Text.ToString() +
                    "' Where MaHD ='" + straonam + "'");

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
                int r = dgvhdkh.CurrentCell.RowIndex;
                string straonam = dgvhdkh.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Delete from HoaDonKH where MaHD='" + straonam + "' ");
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            txtdonGia.ResetText();
         //   txtSoluong.ResetText();
            cboMakh.ResetText();
            cboMaNV.ResetText();
            txtngaylap.ResetText();
            cboMaAo.ResetText();
            txtMaHD.ResetText();

            btnhuybo.Enabled = true;
            btntrove.Enabled = false;
            btnluu.Enabled = true;



            txtdonGia.Enabled = true;
          //  txtSoluong.Enabled = true;
            txtngaylap.Enabled = true;
            txtMaHD.Enabled = true;
            cboMakh.Enabled = true;
            cboMaAo.Enabled = true;
            cboMaNV.Enabled = true;

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnreload.Enabled = true;
        }

        private void txtdonGia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
