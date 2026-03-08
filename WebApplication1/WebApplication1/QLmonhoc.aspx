<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="QLmonhoc.aspx.cs" Inherits="WebApplication1.QLmonhoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Quản Lý Môn Học</h2>
        <hr />
        
        <div class="row mb-3">
            <div class="col-md-3">
                Mã môn học: <asp:TextBox ID="txtmamh" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                Tên môn học: <asp:TextBox ID="txtTenmh" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                Số tiết: <asp:TextBox ID="txtsotiet" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="col-md-3">
                Học Phí: <asp:TextBox ID="txthocphi" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        
        <div class="mb-4">
            <asp:Button ID="btnThem" runat="server" Text="Thêm" OnClick="btnThem_Click" CssClass="btn btn-primary" />
            <asp:Button ID="btnsua" runat="server" Text="Sửa" OnClick="btnsua_Click" CssClass="btn btn-warning" />
        </div>

        <input class="form-control" id="myInput" type="text" placeholder="Search..">
        <br />

        <asp:Repeater runat="server" ID="rpMH">
            <HeaderTemplate>
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr>
                            <th>Mã môn học</th>
                            <th>Tên môn học</th>
                            <th>Số tiết</th>
                            <th>Học Phí</th>
                            <th>Thao tác</th>
                        </tr>
                    </thead>
                    <tbody id="myTable">
            </HeaderTemplate>
            
            <ItemTemplate>
                <tr>
                    <td><%# Eval("MaMH") %></td>
                    <td><%# Eval("TenMH") %></td>
                    <td><%# Eval("SoTiet") %></td>
                    <td><%# Eval("HocPhi") %></td>
                    <td>
                        <a href='QLmonhoc.aspx?mamhs=<%# Eval("MaMH") %>' class="btn btn-sm btn-info">Sửa</a>
                        &nbsp;
                        <a href='QLmonhoc.aspx?mamhx=<%# Eval("MaMH") %>' 
                           onclick="return confirm('Bạn có chắc chắn muốn xóa?')" 
                           class="btn btn-sm btn-danger">Xóa</a>
                    </td>
                </tr>
            </ItemTemplate>

            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
    </div>

    <script>
        $(document).ready(function(){
          $("#myInput").on("keyup", function() {
            var value = $(this).val().toLowerCase();
            $("#myTable tr").filter(function() {
              $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
            });
          });
        });
    </script>
</asp:Content>