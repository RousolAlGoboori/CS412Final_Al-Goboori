<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CS412Final_Al_Goboori.SignUpPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="back-information">
        <label class="fw-bold" for="first">First Name</label>
        <input type="text" id="first" class="form-control" />
        <label class="fw-bold" for="last">Last Name</label>
        <input type="text" id="last" class="form-control" />
        <label class="fw-bold" for="email">Email</label>
        <input type="email" id="email" class="form-control" />
        <label class="fw-bold" for="phone">Phone</label>
        <input type="tel" id="phone" class="form-control" />
        <label class="fw-bold" for="pass">Password</label>
        <input type="text" id="pass" class="form-control" />
        <input type="checkbox" id="checkbox1">    
        <span>Show</span> 
        <div>
            <label class="fw-bold" for="vpass">Verify Password</label>
            <input type="text" id="vpass" class="form-control" />
        </div>
        <input type="checkbox" id="checkbox2">    
        <span>Show</span>
        <div class="fw-bold"<h0>Gender</h0></div>
        <input type="checkbox" id="checkbox3">
        <span>Male</span>
        <input type="checkbox" id="checkbox4">
        <span>Female</span>
        <div class="clearfix">
            <input type="submit" value="Sign Up" class="btn btn-primary float-end log" />
        </div>
    </div>
</asp:Content>
