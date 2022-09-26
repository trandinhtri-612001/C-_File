 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

namespace QLTeamleaders
{
  static class TruyXuatCSDL
    {
        private static string DuongDan = @"Data Source=.\sqlexpress;Initial Catalog=dbTeamleaders;Integrated Security=True";
        // phương thức sinh ra đường ống dẫn
        private static SqlConnection TaoKetNoi()
        {
          return  new SqlConnection(DuongDan);
        }

        // phương thức lấy dữ liệu từ database
        public static DataTable LayBang(string sql)
        {
            SqlConnection DuongOng = TaoKetNoi();
            DuongOng.Open();
            SqlDataAdapter MayBom = new SqlDataAdapter(sql, DuongOng);
            DataTable ThungChua = new DataTable();
            MayBom.Fill(ThungChua);
            DuongOng.Close();
            MayBom.Dispose();
            return ThungChua;
        }

        // phương thức thêm sửa xóa
        public static void ThemSuaXoa(string sql)
        {
            SqlConnection DuongOng = TaoKetNoi();
            DuongOng.Open();
            SqlCommand Lenh = new SqlCommand(sql, DuongOng);
            Lenh.ExecuteNonQuery();
            DuongOng.Close();
            Lenh.Dispose();
        }
        
    }
}
