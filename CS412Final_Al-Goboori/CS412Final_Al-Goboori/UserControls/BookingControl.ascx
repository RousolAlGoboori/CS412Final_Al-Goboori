<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookingControl.ascx.cs" Inherits="CS412Final_Al_Goboori.UserControls.BookingControl" %>
<link href="../Styles/BookingControl.css" rel="stylesheet" />
<div class="bookingControl">
    <div>Booking #<asp:Literal ID="litBookingNumber" runat="server"></asp:Literal></div>
    <div>Customer Name: <asp:Literal ID="litCustomerName" runat="server"></asp:Literal></div>
    <div>Trips</div>
    <div>
        <asp:Repeater ID="TripRepeater" runat="server" OnItemDataBound="TripRepeater_ItemDataBound">
            <ItemTemplate>
                <div class="trip">
                    <asp:Label ID="TripName" runat="server" Text="Label"></asp:Label>
                    <asp:Label ID="TripPrice" CssClass="fw-bold" runat="server" Text="Label"></asp:Label>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div>DepartDate: <asp:Literal ID="litDepartDate" runat="server"></asp:Literal></div>
    <div>ReturnDate: <asp:Literal ID="litReturnDate" runat="server"></asp:Literal></div>
     <div>From: <asp:Literal ID="litFrom" runat="server"></asp:Literal></div>
     <div>To: <asp:Literal ID="litTo" runat="server"></asp:Literal></div>
    
    <div>Total: <asp:Label ID="lblTotal" CssClass="fw-bold" runat="server" Text="Label"></asp:Label></div>
</div>