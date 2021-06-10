<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CS412Final_Al_Goboori.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="contact">
       <div><label class="fw-bold" for="name">Name</label></div> 
        <div><input type="text" id="name" class="form-control" /></div>
        <div><label class="fw-bold" for="email">Email</label></div>
        <div><input type="email" id="email" class="form-control" /></div>
        <div><label class="fw-bold" for="phone">Phone</label></div> 
        <div><input type="tel" id="phone"class="form-control"/></div>
        <div><label class="fw-bold" for="comment">Enter your message</label></div>
        <div><textarea id="comment" rows="15" class="form-control"></textarea></div>
        <div class="d-grid">
            <input type="submit" value="Send" class="btn btn-primary log" />
        </div>
    </div>
</asp:Content>
