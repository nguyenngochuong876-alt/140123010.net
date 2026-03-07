using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using Microsoft.SqlServer.Server;


namespace WebApplication1
{
    public partial class QLgiaovien : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                hienthi();

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string magv = txtmagv.Text;
            string ho = txtHo.Text;
            string ten = txtTen.Text;
            string diachi = txtDiachi.Text;

            string checkus = "select * from [GiaoVien] where MaGV='" + magv + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)

                Response.Write("<script>alert('MaGV đã tồn tại');</script>");

            else
            {
                string sql = "insert into GiaoVien (MaGV,HoGV,TenGV,DiaChi) values ('" + magv + "',N'" + ho + "',N'" + ten + "',N'" + diachi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
            }

        }
        void hienthi()
        {
            string sql = "select MaGV,HoGV,TenGV, DiaChi from GiaoVien";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlgv.DataSource = ds;
            qlgv.DataBind();
        }
    }
}