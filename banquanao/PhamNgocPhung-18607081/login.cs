using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhamNgocPhung_18607081
{
    public partial class dangnhap : Form
    {
        public dangnhap()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            if ((this.txtuser.Text == "phamngocphung") && (this.txtpassword.Text == "P@ssword"))
            {
                new Form2().ShowDialog();
            }
            else
            {
                MessageBox.Show("không đúng tên người dùng /mật khẩu sai!!!!", "thông báo");
                this.txtuser.Focus();
                txtuser.ResetText();
                txtpassword.ResetText();
            }
           
            
        }

        private void dangnhap_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
