<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CS412Final_Al_Goboori.LoginPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center">
        <label class="fw-bold" for="show">Welcom to my airline reservation system</label>
    </div>
    <div class="back-information">
        <label class="fw-bold" for="<%= email.ClientID %>">Email</label>
        <asp:TextBox ID="email" runat="server" TextMode="Email" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= pass.ClientID %>">Password</label>
        <asp:TextBox ID="pass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
        <div class="clearfix">
            <asp:Button ID="Login" runat="server" Text="Login" CssClass="btn btn-primary float-end log" OnClick="Login_Click" />
        </div>

        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Label ID="Label" runat="server" Text="label" ForeColor="Red">"></asp:Label>
        </asp:Panel>

    </div>
</asp:Content>
