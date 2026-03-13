<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QLNguoiDung.aspx.cs" Inherits="WebApplication1.Admin.QLNguoiDung" MasterPageFile="~/Admin/Admin.Master" %>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="page-title">Quản lý người dùng</h2>

    <div class="form-card">

        <table class="table">
           <tr>
                <td width="200">UserName</td>
                <td>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control" Enable="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td width="200">Họ tên</td>
                <td>
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Địa chỉ</td>
                <td>
                    <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>Trạng thái</td>
                <td>
                    <asp:DropDownList ID="ddlTrangThai" runat="server" CssClass="form-control">
                        <asp:ListItem Text="Đang sử dụng" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Đã thu hồi" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>

            <tr>
                <td>Là Admin</td>
                <td>
                    <asp:CheckBox ID="chkAdmin" runat="server" />
                </td>
            </tr>
            <tr>
                <%-- <td>Avatar</td>
                <td>
                    <asp:TextBox ID="txtAvatar" runat="server" CssClass="form-control"></asp:TextBox>
                </td>--%>
                <td>Email</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td></td>
                <td>

                    <asp:Button
                        ID="btnThem1"
                        runat="server"
                        Text="➕ Thêm"
                        CssClass="btn-custom btn-add"
                        OnClick="btnAdd_Click" />

                    <asp:Button
                        ID="btnsua1"
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
                        ID="btntim1"
                        runat="server"
                        Text="🔍 Tìm kiếm"
                        CssClass="btn-custom btn-search"
                        OnClick="btntim_Click" />

                </td>

                <td>

                    <asp:TextBox
                        ID="txttim1"
                        runat="server"
                        CssClass="form-control">
                    </asp:TextBox>

                </td>

            </tr>

        </table>

    </div>



    <div class="table-card">

        <h4>Danh sách người dùng</h4>

        <asp:GridView
            ID="qlNguoiDung"
            runat="server"
            CssClass="table table-bordered table-hover"
            DataKeyNames="UserName"
            OnRowDeleting="qlgv_RowDeleting"
            OnSelectedIndexChanged="qlgv_SelectedIndexChanged"
            AutoGenerateColumns="False">

            <Columns>
                <asp:BoundField DataField="UserName" HeaderText="Tên đăng nhập" />
                <asp:BoundField DataField="Fullname" HeaderText="Họ và tên" />
                <asp:BoundField DataField="Address" HeaderText="Địa chỉ" />
                <asp:TemplateField HeaderText="Trạng thái">
                    <ItemTemplate>
                        <%# Convert.ToInt32(Eval("Status")) == 1 ? "🟢 Online" : "🔴 Offline" %>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Admin">
                    <ItemTemplate>
                        <asp:CheckBox
                            ID="chkRole"
                            runat="server"
                            Checked='<%# Convert.ToInt32(Eval("Role")) == 1 %>'
                            Enabled="false" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Email" HeaderText="Email" />
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
