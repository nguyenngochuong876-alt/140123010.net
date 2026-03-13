<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BangDiem.aspx.cs" Inherits="WebApplication1.Admin.BangDiem" MasterPageFile="~/Admin/Admin.Master" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h2 class="page-title">📊 Bảng điểm học viên</h2>

<div class="card">

<asp:GridView
ID="gvDiem"
runat="server"
CssClass="table table-bordered table-hover gridview"
AutoGenerateColumns="False">

<Columns>

<asp:BoundField DataField="MaHV" HeaderText="Mã học viên" />

<asp:BoundField DataField="HoTen" HeaderText="Họ tên" />

<asp:BoundField DataField="TenMH" HeaderText="Môn học" />

<asp:BoundField DataField="DiemQT" HeaderText="Điểm QT" />

<asp:BoundField DataField="DiemThi" HeaderText="Điểm thi" />

<asp:TemplateField HeaderText="Điểm TB">
<ItemTemplate>

<span class='<%# Convert.ToDouble(Eval("DiemTB")) >=5 ? "pass" : "fail" %>'>

<%# Eval("DiemTB") %>

</span>

</ItemTemplate>
</asp:TemplateField>

</Columns>

</asp:GridView>

</div>

</asp:Content>