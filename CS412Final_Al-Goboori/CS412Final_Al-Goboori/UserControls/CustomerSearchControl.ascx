<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomerSearchControl.ascx.cs" Inherits="CS412Final_Al_Goboori.UserControls.CustomerSearchControl" %>
<link href="../Styles/CustomerSearchControl.css" rel="stylesheet" />
<asp:Panel ID="CustomerSearch" runat="server" CssClass="customerSearch" >
    <asp:Label ID="BlankCustomer" runat="server" Text="Label"  CssClass="d-none blankCustomerElement"></asp:Label>
    <asp:Panel ID="CustomerList" runat="server"></asp:Panel>
</asp:Panel>