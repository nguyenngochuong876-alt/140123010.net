using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class BangDiem : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hienthi();
                
            }
        }
        void hienthi()
        {
            string sql = "SELECT hv.MaHV,hv.HoHV + ' ' + hv.TenHV AS HoTen,mh.TenMH,d.DiemQT,d.DiemThi,d.DiemTB FROM Diem d JOIN HocVien hv ON d.MaHV = hv.MaHV JOIN MonHoc mh ON d.MaMH = mh.MaMH";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            gvDiem.DataSource = ds;
            gvDiem.DataBind();
        }
    }
}