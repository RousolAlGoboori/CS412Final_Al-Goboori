<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MyTrips.aspx.cs" Inherits="CS412Final_Al_Goboori.MyTripsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="row">
        <div class="col">
            <div class="back-information">
                <div>Upcoming trips</div>
                <asp:GridView ID="userTrips" runat="server" CssClass="table table-sm table-striped"  AutoGenerateColumns="false" AllowPaging="true" PageSize="10" OnRowDataBound="userTrips_RowDataBound" >                
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
                    <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" DeleteText="X" ControlStyle-CssClass="color_deletemark" />
                </Columns>
            </asp:GridView>    
            </div>
        </div>
    </div>

    

</asp:Content>


