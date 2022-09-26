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
 
    public partial class Form1 : Form
    {
        private int LoaiTK;
        public Form1(int LoaiTK)
        {
            this.LoaiTK = LoaiTK;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvNoiDung.DataSource =
                TruyXuatCSDL.LayBang("select * from tbTeamleader");

            dgvNoiDung.Columns[0].HeaderText = "Mã";
            dgvNoiDung.Columns[1].HeaderText = "Họ Tên";
            dgvNoiDung.Columns[2].HeaderText = "Năm Sinh";
            dgvNoiDung.Columns[3].HeaderText = "Lương";
            dgvNoiDung.Columns[4].HeaderText = "Tài Khoản";
            dgvNoiDung.Columns[5].HeaderText = "Lương Trách Nhiệm";

            dgvNoiDung.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvNoiDung.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvNoiDung.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvNoiDung.Columns[3].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvNoiDung.Columns[4].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dgvNoiDung.Columns[5].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.Fill;

            for (int i = 0; i < dgvNoiDung.Rows.Count; i++)
                dgvNoiDung.Rows[i].HeaderCell.Value = i.ToString();

            // Hiển thị form theo loại tài khoản
            if (LoaiTK==1)
            {
                btnNhap.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }

            //if (DangNhap.TK == 0)
            //    MessageBox.Show("Xin chào Admin!");
            //else
            //    MessageBox.Show("Xin chào nhân viên!");

        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            string sql = "insert into tbTeamleader values(N'" +
                txtMa.Text + "', N'" +
                txtHoTen.Text + "', " +
                txtNamSinh.Text + ", " +
                txtLuong.Text + ", " +
                txtTienTK.Text + ", " +
                txtLuongTN.Text + ")";
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvNoiDung.DataSource =
               TruyXuatCSDL.LayBang("select * from tbTeamleader");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string sql = "update tbTeamleader set HoTen=N'"+
                txtHoTen.Text+"', NS="+
                txtNamSinh.Text+", Luong ="+
                txtLuong.Text+", tientk ="+
                txtTienTK.Text+", luongtn = "+
                txtLuongTN.Text+"  where Ma=N'"+
                txtMa.Text+"'";
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvNoiDung.DataSource =
               TruyXuatCSDL.LayBang("select * from tbTeamleader");
        }

        private void dgvNoiDung_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNoiDung.CurrentRow!=null)
            {
                txtMa.Text = dgvNoiDung.CurrentRow.Cells[0].Value.ToString();
                txtHoTen.Text = dgvNoiDung.CurrentRow.Cells[1].Value.ToString();
                txtNamSinh.Text = dgvNoiDung.CurrentRow.Cells[2].Value.ToString();
                txtLuong.Text = dgvNoiDung.CurrentRow.Cells[3].Value.ToString();
                txtTienTK.Text = dgvNoiDung.CurrentRow.Cells[4].Value.ToString();
                txtLuongTN.Text = dgvNoiDung.CurrentRow.Cells[5].Value.ToString();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string sql = "delete from tbTeamleader where Ma=N'" +
                txtMa.Text + "'";
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvNoiDung.DataSource =
              TruyXuatCSDL.LayBang("select * from tbTeamleader");
            MessageBox.Show("Đã xóa bản ghi", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn thực sự muốn đóng chương trình này?",
                "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs==DialogResult.Yes)
            this.Close();
        }

        private void thêmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "insert into tbTeamleader values(N'" +
               txtMa.Text + "', N'" +
               txtHoTen.Text + "', " +
               txtNamSinh.Text + ", " +
               txtLuong.Text + ", " +
               txtTienTK.Text + ", " +
               txtLuongTN.Text + ")";
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvNoiDung.DataSource =
               TruyXuatCSDL.LayBang("select * from tbTeamleader");
        }

        private void sửaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "update tbTeamleader set HoTen=N'" +
                txtHoTen.Text + "', NS=" +
                txtNamSinh.Text + ", Luong =" +
                txtLuong.Text + ", tientk =" +
                txtTienTK.Text + ", luongtn = " +
                txtLuongTN.Text + "  where Ma=N'" +
                txtMa.Text + "'";
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvNoiDung.DataSource =
               TruyXuatCSDL.LayBang("select * from tbTeamleader");
        }

        private void xóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sql = "delete from tbTeamleader where Ma=N'" +
               txtMa.Text + "'";
            TruyXuatCSDL.ThemSuaXoa(sql);
            dgvNoiDung.DataSource =
              TruyXuatCSDL.LayBang("select * from tbTeamleader");
            MessageBox.Show("Đã xóa bản ghi", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn thực sự muốn đóng chương trình này?",
                "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
                this.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
