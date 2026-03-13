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
    public partial class QLNguoiDung : System.Web.UI.Page
    {
        Ketnoi kn = new Ketnoi();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["user"] == null)
            //{
            //    Response.Redirect("Login.aspx");
            //}
            if (!IsPostBack)
            {
                hienthi();

            }
            btnsua1.Enabled = false;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            //string magv = txtmagv.Text;
            //string ho = txtHo.Text;
            //string ten = txtTen.Text;
            //string diachi = txtDiachi.Text;

            //string checkus = "select * from [GiaoVien] where MaGV='" + magv + "'";
            //SqlDataAdapter da = new SqlDataAdapter(checkus, kn.con);
            //DataTable dt = new DataTable();
            //da.Fill(dt);
            //if (dt.Rows.Count > 0)

            //    Response.Write("<script>alert('MaGV đã tồn tại');</script>");

            //else
            //{
            //    string sql = "insert into GiaoVien (MaGV,HoGV,TenGV,DiaChi) values ('" + magv + "',N'" + ho + "',N'" + ten + "',N'" + diachi + "')";
            //    SqlCommand cmd = new SqlCommand(sql, kn.con);
            //    kn.con.Open();
            //    cmd.ExecuteNonQuery();
            //    kn.con.Close();
            //    hienthi();
            //}

        }
        void hienthi()
        {
            string sql = "select Fullname,UserName,Address,Status,Role,Email from [User]";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlNguoiDung.DataSource = ds;
            qlNguoiDung.DataBind();
        }

        protected void qlgv_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserName.Text = qlNguoiDung.SelectedRow.Cells[0].Text;
            txtFullName.Text = qlNguoiDung.SelectedRow.Cells[1].Text;
            txtDiaChi.Text = HttpUtility.HtmlDecode(qlNguoiDung.SelectedRow.Cells[2].Text);
            ddlTrangThai.SelectedValue = qlNguoiDung.SelectedRow.Cells[3].Text;
            //chkAdmin./Checked = qlNguoiDung.SelectedRow.Cells[4].Che;
            CheckBox chk = (CheckBox)qlNguoiDung.SelectedRow.FindControl("chkRole");

            chkAdmin.Checked = chk.Checked;
            txtEmail.Text = qlNguoiDung.SelectedRow.Cells[5].Text; ;
            btnThem1.Enabled = false;
            btnsua1.Enabled = true;
        }

        protected void qlgv_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string magv = qlNguoiDung.DataKeys[e.RowIndex].Values["MaGV"].ToString();
            string sql = "delete from GiaoVien where MaGV='" + magv + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);

            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();

            hienthi();
        }

        protected void Btnsua_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            string fullName = txtFullName.Text;
            int trangThai =int.Parse(ddlTrangThai.SelectedValue);
            string diachi = txtDiaChi.Text;
            string mail = txtEmail.Text;

            int admin = chkAdmin.Checked ? 1 : 0;
            string sql = "update [User] set  Role=N'" + admin + "', Email=N'" + mail + "',Fullname=N'" + fullName + "',Status=N'" + trangThai + "',[Address]=N'" + diachi + "' where Username='" + userName + "'";
            SqlCommand cmd = new SqlCommand(sql, kn.con);
            kn.con.Open();
            cmd.ExecuteNonQuery();
            kn.con.Close();
            hienthi();

            btnThem1.Enabled = true;
            chkAdmin.Enabled = true;
            txtFullName.Text = "";
            ddlTrangThai.SelectedValue ="";
            txtUserName.Text = "";
            txtDiaChi.Text = "";
            txtEmail.Text = "";


        }
        void timkiem(string keywords)
        {
            string sql = "select  Fullname,UserName,Address,Status,Role,Email from [User] where [Fullname] like '%" + keywords + "%'";
            SqlDataAdapter da = new SqlDataAdapter(sql, kn.con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            qlNguoiDung.DataSource = ds;
            qlNguoiDung.DataBind();
        }


        protected void btntim_Click(object sender, EventArgs e)
        {
            string tengv = btntim1.Text;
            timkiem(tengv);
        }
    }
}