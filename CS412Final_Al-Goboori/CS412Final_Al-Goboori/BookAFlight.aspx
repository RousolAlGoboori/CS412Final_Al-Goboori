<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BookAFlight.aspx.cs" Inherits="CS412Final_Al_Goboori.BookAFlightPage
    " %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="back-information">
                <div >Book A Flight</div>
                <hr />
                <label class="fw-bold">Select </label>
                <asp:CheckBoxList ID="bookingList" runat="server" CssClass="form-check"></asp:CheckBoxList>
                <div runat="server" visible="<%# bookingList.Items.Count > 0 %>">
                    None
                </div>
              
                <label class="fw-bold" for="<%= from.ClientID %>">From</label>
                <asp:TextBox ID="from" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="fw-bold" for="<%= to.ClientID %>">To</label>
                <asp:TextBox ID="to" runat="server" CssClass="form-control"></asp:TextBox>

                <label class="fw-bold" for="<%= depart.ClientID %>">Depart Date</label>
                <asp:TextBox ID="depart" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>

                <label class="fw-bold" for="<%= returnDate.ClientID %>">Return Date</label>
                <asp:TextBox ID="returnDate" CssClass="form-control" TextMode="Date" runat="server"></asp:TextBox>


                <div class="clearfix">
                    <asp:Button ID="createFlight" runat="server" Text="Create flight" CssClass="btn btn-primary log"  OnClick="createFlight_Click" />
                </div>
                     <asp:Panel ID="Panel1" runat="server" Visible="false">
                    <asp:Label ID="mErrors" runat="server" Text="Label" CssClass="error-color"></asp:Label>
                </asp:Panel>

            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="back-information">
                <div>Create Trip Type</div>
                <hr />
                <label class="fw-bold" for="tripName">Trip Name</label>
                <asp:TextBox ID="tripName" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                <label class="fw-bold" for="servicePrice">Trip Price</label>
                <asp:TextBox ID="tripPrice" ClientIDMode="Static" runat="server" CssClass="form-control"></asp:TextBox>
                <div class="d-grid">
                    <asp:Button ID="createTrip" runat="server" Text="Create" CssClass="btn btn-primary btn-push-top-10" OnClick="createTrip_Click"/>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
