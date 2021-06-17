<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="CS412Final_Al_Goboori.ContactUs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   

    <div class="row">
        <div class="col">
            <div >
                <label class="fw-bold" for="show">Contact US</label>
                <div><label  for="show">Our mailing address is:</label></div>
                <div><label  for="show">123 W Street</label></div>
                <div><label  for="show">Chicago,IL,60600</label></div>
                <div><label  for="show">Phone:123-456-7891</label></div>
            </div>
     </div>
       <div class="col">
          <div class="contact">
            <div><label class="fw-bold" for="<%= name.ClientID %>">Name</label></div>
            <div><asp:TextBox ID="name" runat="server" CssClass="form-control"></asp:TextBox></div>
            <div><label class="fw-bold" for="<%= email.ClientID %>">Email</label></div>
            <div><asp:TextBox ID="email" runat="server" CssClass="form-control"></asp:TextBox></div>
            <div><label class="fw-bold" for="<%= comment.ClientID %>">Enter your message</label></div>
            <div><asp:TextBox ID="comment" Rows="15" TextMode="MultiLine" runat="server" CssClass="form-control"></asp:TextBox></div>
            <div class="d-grid">
                <asp:Button ID="countactus" runat="server" Text="Send" CssClass="btn btn-primary log" />
            </div>
        </div>
      </div>    
    </div>
        

</asp:Content>
