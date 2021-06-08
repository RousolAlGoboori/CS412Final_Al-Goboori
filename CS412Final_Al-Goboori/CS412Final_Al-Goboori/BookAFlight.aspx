<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="BookAFlight.aspx.cs" Inherits="CS412Final_Al_Goboori.BookAFlightPage
    " %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col">
            <div class="data-content no-margin">
                <div class="site-title">Flights</div>
                <hr />
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="Round trip" />
                    <label class="form-check-label" for="Round trip">Round trip</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="One way" />
                    <label class="form-check-label" for="One way">One way</label>
                </div>
                <div class="form-check">
                    <input class="form-check-input" type="checkbox" value="" id="Multi-city" />
                    <label class="form-check-label" for="Multi-city">Multi-city</label>
                </div>
                <label class="fw-bold" for="customerName">From</label>
                <input class="form-control" type="text" id="From" />
                <label class="fw-bold" for="customer">To </label>
                <input class="form-control" type="text" id="To" />
                <label class="fw-bold" for="Depart">Depart</label>
                <input class="form-control" type="date" id="Depart" />
                <label class="fw-bold" for="Return"> Return</label>
                <input class="form-control" type="date" id="Return" />
                <label class="fw-bold" for="Passenger"> Passenger</label>
                <input class="form-control" type="number" id="Passenger" />
                
                <div class="d-grid">
                    <input type="search" value="Show flights" class="btn btn-primary btn-push-top-10" />
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
