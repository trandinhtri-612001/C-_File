using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTeamleaders
{
    public partial class DangNhap : Form
    {
        //public static int TK;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string sql = "select type from tbTaiKhoan where ID=N'" +
                txtID.Text + "' and PW=N'" +
                txtPassword.Text + "'";
            DataTable tk = TruyXuatCSDL.LayBang(sql);
            if (tk!=null)
            {
                //TK = int.Parse(tk.Rows[0][0].ToString());
                Form1 frmMain = new Form1(int.Parse(tk.Rows[0][0].ToString()));
                frmMain.Show();
                this.Hide();
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtID.Text.Trim() == "")
                    MessageBox.Show("UserID không thể để trống!",
                        "Thống báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtID.Text.Trim() == "")
                    MessageBox.Show("Password không thể để trống!",
                        "Thống báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                else
                    btnDangNhap.Focus();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
