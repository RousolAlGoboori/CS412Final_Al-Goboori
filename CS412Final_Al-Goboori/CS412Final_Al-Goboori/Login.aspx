<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CS412Final_Al_Goboori.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="center"><h2>Welcom to my airline reservation system</h2></div>
     <div class="back-information">
        <label class="fw-bold" for="Membership number or Username">Membership number or Username</label>
        <input type="text" id="Membership number or Username" class="form-control" />
        <label class="fw-bold" for="pass">Password</label>
        <input type="password" id="pass" class="form-control" />
        <div class="clearfix">
            <input type="submit" value="Login" class="btn btn-primary float-end log" />
        </div>
    </div>
</asp:Content>
