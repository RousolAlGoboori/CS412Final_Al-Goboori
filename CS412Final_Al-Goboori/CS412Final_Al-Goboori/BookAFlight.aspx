<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BookAFlight.aspx.cs" Inherits="CS412Final_Al_Goboori.BookAFlightPage
    " %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="back-information">
                <div>
                    <h3>Flights</h3>
                </div>
                <hr />
                <asp:RadioButton ID="RadioButton1" GroupName="1" runat="server" Text="Round trip" />
                <asp:RadioButton ID="RadioButton2" GroupName="1" runat="server" Text="One way" />
                <asp:RadioButton ID="RadioButton3" GroupName="1" runat="server" Text="Multi-city" />
                <asp:Button ID="Button1" runat="server" Text="Choose" OnClick="Button1_Click" /><br />
                <label class="fw-bold" for="<%= from.ClientID %>">From</label>
                <asp:TextBox ID="from" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="fw-bold" for="<%= to.ClientID %>">To</label>
                <asp:TextBox ID="to" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="fw-bold" for="Depart">Depart</label>
                <input class="form-control" type="date" id="Depart" />
                <label class="fw-bold" for="Return">Return</label>
                <input class="form-control" type="date" id="Return" />
                <label class="fw-bold" for="Passenger">Passenger</label>
                <input class="form-control" type="number" id="Passenger" />

                <div class="clearfix">
                    <asp:Button ID="search" runat="server" Text="Show flights" CssClass="btn btn-primary log"  OnClick="search_Click" />
                </div>
                     <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <asp:Label ID="mErrors" runat="server" Text="Label" CssClass="error-color"></asp:Label>
                </asp:Panel>

            </div>
        </div>
    </div>

</asp:Content>
