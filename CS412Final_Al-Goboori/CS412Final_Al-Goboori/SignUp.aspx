<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="CS412Final_Al_Goboori.SignUpPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="Scripts/SignUp.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="back-information">
        <label class="fw-bold" for="<%= first.ClientID %>">First Name</label>
        <asp:TextBox ID="first" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= last.ClientID %>">Last Name</label>
        <asp:TextBox ID="last" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= email.ClientID %>">Email</label>
        <asp:TextBox ID="email" TextMode="Email" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="<%= phone.ClientID %>">Phone</label>
        <asp:TextBox ID="phone" TextMode="phone" runat="server" CssClass="form-control"></asp:TextBox>
        <label class="fw-bold" for="show">Gender</label>
        <div>
            <asp:RadioButton ID="RadioButton1" GroupName="1" runat="server" Text="Male" />
            <asp:RadioButton ID="RadioButton2" GroupName="1" runat="server" Text="Female" />
        </div>
        <div>
            <label class="fw-bold" for="<%= txtPassword.ClientID %>">Password</label>
            <asp:TextBox ID="txtPassword" ClientIDMode="Static" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
            <input type="checkbox" id="chkPass" />show
            
        </div>
        <div>
            <label class="fw-bold" for="<%= vpass.ClientID %>">Verify Password</label>
            <asp:TextBox ID="vpass" TextMode="Password" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:CheckBox ID="CheckBox5" runat="server" />
            <label for="show">Show</label>
        </div>
        <div class="clearfix">
            <asp:Button ID="Signup" runat="server" Text="Sign Up" CssClass="btn btn-primary float-end log" OnClick="Signup_Click" />
        </div>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <asp:Label ID="mErrors" runat="server" Text="Label" CssClass="error-color"></asp:Label>
        </asp:Panel>
    </div>
</asp:Content>
