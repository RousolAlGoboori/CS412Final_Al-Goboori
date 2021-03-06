<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MyTrips.aspx.cs" Inherits="CS412Final_Al_Goboori.MyTripsPage" %>

<%@ Register Src="~/UserControls/BookingControl.ascx" TagPrefix="ROUSOLControl" TagName="BookingControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
       

         <div class="col">
            <div class="title-information">
                <div class="site-title">Number of trips </div>
                <div class="number-text"><asp:Literal ID="litCount" runat="server"></asp:Literal></div>
            </div>
        </div>

        <div class="col">
            <div class="title-information">
                <div class="site-title">Gift miles</div>
                <div class="number-text">
                    <asp:Literal ID="litGiftMiles" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <asp:Repeater ID="BookingControlRepeater" runat="server" OnItemDataBound="BookingControlRepeater_ItemDataBound1">
            <ItemTemplate>
                <div class="col-5 title-information">
                    <ROUSOLControl:BookingControl runat="server" id="BookingControl" />
                    
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

    <div class="row">
        <div class="col">
            <div class="back-information">
                <div>Upcoming trips</div>
                <asp:GridView ID="userTrips" runat="server" CssClass="table table-sm table-striped" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowDataBound="userTrips_RowDataBound" OnRowDeleting="userTrips_RowDeleting">
                    <EmptyDataTemplate>
                        No records found.
                    </EmptyDataTemplate>
                    <Columns>
                        <asp:BoundField HeaderText="Booking reference" DataField="Id" />
                        <asp:TemplateField HeaderText="Customer">
                            <ItemTemplate>
                                <asp:HiddenField ID="id" runat="server" />
                                <asp:Label ID="userName" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Flight">
                            <ItemTemplate>
                                <asp:Label ID="flightType" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="From">
                            <ItemTemplate>
                                <asp:Label ID="from" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="To">
                            <ItemTemplate>
                                <asp:Label ID="to" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Departure">
                            <ItemTemplate>
                                <asp:Label ID="dDate" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Return">
                            <ItemTemplate>
                                <asp:Label ID="rDate" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Price">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderPrice" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" DeleteText="X" ControlStyle-CssClass="color_deletemark" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>


