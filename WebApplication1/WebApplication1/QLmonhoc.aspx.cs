using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class QLmonhoc : System.Web.UI.Page
    {
        // Khởi tạo đối tượng kết nối từ class Ketnoi
        Ketnoi kn = new Ketnoi();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra đăng nhập
            if (Session["user"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                hienthi();
                btnsua.Enabled = false;

                // Kiểm tra nếu có mã môn học truyền qua QueryString để thực hiện Sửa/Xóa
                if (!string.IsNullOrEmpty(Request.QueryString["mamhs"]))
                {
                    string mamh = Request.QueryString["mamhs"];
                    string sql = "select * from [MonHoc] where MaMH='" + mamh + "'";
                    SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        txtmamh.Text = dt.Rows[0][0].ToString();
                        txtTenmh.Text = dt.Rows[0][1].ToString();
                        txtsotiet.Text = dt.Rows[0][2].ToString();
                        txthocphi.Text = dt.Rows[0][3].ToString();
                    }

                    txtmamh.Enabled = false;
                    btnThem.Enabled = false;
                    btnsua.Enabled = true;
                }

                // Xử lý xóa môn học nếu có tham số mahvx (mã môn học xóa)
                if (!string.IsNullOrEmpty(Request.QueryString["mamhx"]))
                {
                    string mamh = Request.QueryString["mamhx"];
                    string sql = "delete from [MonHoc] where MaMH='" + mamh + "'";
                    SqlCommand cmd = new SqlCommand(sql, kn.con);
                    kn.con.Open();
                    cmd.ExecuteNonQuery();
                    kn.con.Close();
                    hienthi();
                    Response.Redirect("QLmonhoc.aspx");
                }
            }
        }

        // Hàm hiển thị dữ liệu lên Repeater
        void hienthi()
        {
            string sql = "select MaMH,TenMH, SoTiet,HocPhi from MonHoc";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rpMH.DataSource = dt;
            rpMH.DataBind();
        }

        // Sự kiện Click nút Thêm
        protected void btnThem_Click(object sender, EventArgs e)
        {
            string mamh = txtmamh.Text;
            string ten = txtTenmh.Text;
            string sotiet = txtsotiet.Text;
            string hocphi = txthocphi.Text;

            // Kiểm tra mã học viên đã tồn tại chưa
            string checkus = "select * from [MonHoc] where MaMH='" + mamh + "'";
            SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                Response.Write("<script>alert('Mã môn học đã tồn tại');</script>");
            }
            else
            {
                string sql = "insert into MonHoc(MaMH, TenMH, SoTiet, HocPhi) values('" + mamh + "', N'" + ten + "', N'" + sotiet + "', N'" + hocphi + "')";
                SqlCommand cmd = new SqlCommand(sql, kn.con);
                kn.con.Open();
                cmd.ExecuteNonQuery();
                kn.con.Close();
                hienthi();
                Response.Redirect("QLmonhoc.aspx");
            }
        }

        // Sự kiện Click nút Sửa
        protected void btnsua_Click(object sender, EventArgs e)
        {
            string mamh = txtmamh.Text;
            string ten = txtTenmh.Text;
            string sotiet = txtsotiet.Text;
            string hocphi = txthocphi.Text;

            string sql = "update [MonHoc] set TenMH=N'" + ten + "', SoTiet=N'" + sotiet + "', HocPhi=N'" + hocphi + "' where MaMH='" + mamh + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();
            Response.Redirect("QLmonhoc.aspx");
        }
    }
}