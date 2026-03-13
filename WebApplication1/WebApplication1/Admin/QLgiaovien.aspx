<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="QLgiaovien.aspx.cs" Inherits="WebApplication1.QLgiaovien" %>





<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="page-title">Quản lý giáo viên</h2>

    <div class="form-card">

        <table class="table">

            <tr>
                <td width="200">Mã GV</td>
                <td>
                    <asp:TextBox ID="txtmagv" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Họ GV</td>
                <td>
                    <asp:TextBox ID="txtHo" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Tên GV</td>
                <td>
                    <asp:TextBox ID="txtTen" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Địa chỉ</td>
                <td>
                    <asp:TextBox ID="txtDiachi" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>

                    <asp:Button
                        ID="btnThem"
                        runat="server"
                        Text="➕ Thêm"
                        CssClass="btn-custom btn-add"
                        OnClick="btnLogin_Click" />

                    <asp:Button
                        ID="btnsua"
                        runat="server"
                        Text="✏ Sửa"
                        CssClass="btn-custom btn-edit"
                        OnClick="Btnsua_Click" />

                </td>
            </tr>

        </table>

    </div>



    <div class="form-card">

        <table class="table">

            <tr>

                <td width="150">

                    <asp:Button
                        ID="btntim"
                        runat="server"
                        Text="🔍 Tìm kiếm"
                        CssClass="btn-custom btn-search"
                        OnClick="btntim_Click" />

                </td>

                <td>

                    <asp:TextBox
                        ID="txttim"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                </td>

            </tr>

        </table>

    </div>



    <div class="table-card">

        <h4>Danh sách giáo viên</h4>

        <asp:GridView
            ID="qlgv"
            runat="server"
            CssClass="table table-bordered table-hover"
            DataKeyNames="MaGV"
            OnRowDeleting="qlgv_RowDeleting"
            OnSelectedIndexChanged="qlgv_SelectedIndexChanged">

            <Columns>

                <asp:CommandField
                    ShowSelectButton="True"
                    SelectText="Chọn" />

                <asp:CommandField
                    ShowDeleteButton="True"
                    DeleteText="Xóa" />

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
