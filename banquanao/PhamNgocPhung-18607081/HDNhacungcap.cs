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
    public partial class HDNhacungcap : Form
    {
        public HDNhacungcap()
        {
            InitializeComponent();
        }
        string phung = @"Data Source=WIN10\SQLEXPRESS;Initial Catalog=BanQuanAo;Integrated Security=True";
        SqlConnection conn = null;

        SqlDataAdapter dahdncc = null;
        DataTable dthdncc = null;


        SqlDataAdapter daaonam = null;
        DataTable dtaonam = null;

        SqlDataAdapter dancc = null;
        DataTable dtncc = null;


        bool them;
        void loadData()
        {
            try
            {
                conn = new SqlConnection(phung);
                dahdncc = new SqlDataAdapter("select *from HoaDonNCC", conn);
                dthdncc = new DataTable();
                dthdncc.Clear();
                dahdncc.Fill(dthdncc);
                dgvHDNCC.DataSource = dthdncc;
                dgvHDNCC.AutoResizeColumns();

                dahdncc = new SqlDataAdapter("select * from HoaDonNCC", conn);

                daaonam = new SqlDataAdapter("select * from AoNam", conn);
                dtaonam = new DataTable();
                dtaonam.Clear();
                daaonam.Fill(dtaonam);
                daaonam = new SqlDataAdapter("select * from AoNam", conn);

                dancc = new SqlDataAdapter("select * from NhaCungCap", conn);
                dtncc = new DataTable();
                dtncc.Clear();
                dancc.Fill(dtncc);
                dancc = new SqlDataAdapter("select * from NhaCungCap", conn);



                
                txtGia.ResetText();
                txtMHDNCC.ResetText();
                txtSoLuong.ResetText();
                cboMaAo.ResetText();
                cboMaNCC.ResetText();
             
                btnhuybo.Enabled = false;
                btntrove.Enabled = false;
                btnluu.Enabled = false;


                txtGia.Enabled = false;
                txtMHDNCC.Enabled = false;
                txtSoLuong.Enabled = false;
                cboMaAo.Enabled = false;
                cboMaNCC.Enabled = false;
               

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
        private void HDNhacungcap_Load(object sender, EventArgs e)
        {
            loadData();

      
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            them = true;


            txtGia.ResetText();
            txtMHDNCC.ResetText();
            txtSoLuong.ResetText();
            cboMaAo.ResetText();
            cboMaNCC.ResetText();

            btnhuybo.Enabled = true;
            btntrove.Enabled = false;
            btnluu.Enabled = true;


            txtGia.Enabled = true;
            txtMHDNCC.Enabled = true;
            txtSoLuong.Enabled = true;
            cboMaAo.Enabled = true;
            cboMaNCC.Enabled = true;

            btnxoa.Enabled = true;
            btnthem.Enabled = true;
            btnsua.Enabled = true;
            btnreload.Enabled = true;


            this.cboMaAo.DataSource = dtaonam;
            cboMaAo.DisplayMember = "MaAo";
            cboMaAo.ValueMember = "MaAo";

            this.cboMaNCC.DataSource = dtncc;
            cboMaNCC.DisplayMember = "MaNCC";
            cboMaNCC.ValueMember = "MaNCC";
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

                    cmd.CommandText = System.String.Concat("Insert Into HoaDonNCC Values(" + "'" +
                        this.txtMHDNCC.Text.ToString() + "','" +
                        this.cboMaAo.Text.ToString() + "',N'" +
                        this.txtSoLuong.Text.ToString() + "',N'" +
                        this.cboMaNCC.Text.ToString() + "',N'" +
                        this.txtGia.Text.ToString() + "')");

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

                int r = dgvHDNCC.CurrentCell.RowIndex;
                string straonam = dgvHDNCC.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Update HoaDonNCC Set MaHDNCC='" +
                    this.txtMHDNCC.Text.ToString() + "'," + "MaAO='" +
                    cboMaAo.Text.ToString() + "'," + "SoLuong='" +
                    txtSoLuong.Text.ToString() + "'," + "MaNCC='" +
                    cboMaNCC.Text.ToString() + "'," + "Gia='" +

                    txtGia.Text.ToString() +
                    "' Where MaHDNCC ='" + straonam + "'");

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
            int r = dgvHDNCC.CurrentCell.RowIndex;

            //chuyển thông tin lên pannel

            this.txtMHDNCC.Text = dgvHDNCC.Rows[r].Cells[0].Value.ToString();
            this.cboMaAo.Text = dgvHDNCC.Rows[r].Cells[1].Value.ToString();
            this.txtSoLuong.Text = dgvHDNCC.Rows[r].Cells[2].Value.ToString();
            this.cboMaNCC.Text = dgvHDNCC.Rows[r].Cells[3].Value.ToString();
            this.txtGia.Text = dgvHDNCC.Rows[r].Cells[4].Value.ToString();
          

            //Cho thao tác trên các Lưu /Hủy/Panel
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;

            txtMHDNCC.Enabled = true;
            cboMaAo.Enabled = true;
            txtSoLuong.Enabled = true;
            cboMaNCC.Enabled = true;
            txtGia.Enabled = true;
            
            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.txtGia.Focus();
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
                int r = dgvHDNCC.CurrentCell.RowIndex;
                string straonam = dgvHDNCC.Rows[r].Cells[0].Value.ToString();
                cmd.CommandText = System.String.Concat("Delete from HoaDonNCC where MaHDNCC='" + straonam + "' ");
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

        private void btnhuybo_Click(object sender, EventArgs e)
        {
            this.btnluu.Enabled = true;
            this.btnhuybo.Enabled = true;


            txtGia.ResetText();
            txtMHDNCC.ResetText();
            txtSoLuong.ResetText();
            cboMaAo.ResetText();
            cboMaNCC.ResetText();

            txtMHDNCC.Enabled = true;
            cboMaAo.Enabled = true;
            txtSoLuong.Enabled = true;
            cboMaNCC.Enabled = true;
            txtGia.Enabled = true;

            //Không cho thao tác trên các nút thêm/xóa/thoát
            this.btnthem.Enabled = false;
            this.btnsua.Enabled = false;
            this.btnxoa.Enabled = false;
            this.btntrove.Enabled = false;

            this.txtGia.Focus();
        }
    }
}
