<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="MyTrips.aspx.cs" Inherits="CS412Final_Al_Goboori.MyTripsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
        <div class="col">
            <div class="title-information">
                <div><h3>Membership number</h3></div>
                <div><h2>544534542</h2></div>
            </div>
        </div>
        <div class="col">
            <div class="title-information">
                <div ><h3>Gift miles</h3></div>
                <div ><h2>3000</h2></div>
            </div>
        </div>
       
    </div>

    <div class="row">
        <div class="col">
            <div class="back-information">
                <div><h3>Upcoming trips</h3></div>
                <table class="table table-sm table-striped">
                    <thead>
                        <tr>
                            <th>Booking reference</th>
                            <th>Customer </th>
                            <th>Flight</th>
                            <th>From</th>
                            <th>To</th>
                            <th>Departure</th>
                            <th>Return </th>
                            <th>Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>TVN55</td>
                            <td>Rousol Al Goboori</td>
                            <td>A 15</td>
                            <td>Chicago</td>
                            <td>Turkish</td>
                            <td>07/30/2021</td>
                            <td>08/30/2021</td>
                            <td><a href="#" class="color_deletemark">X</a></td>
                        </tr>
                        <tr>
                            <td>TSN95</td>
                            <td>Rousol Al Goboori</td>
                            <td>A 100</td>
                            <td>Chicago</td>
                            <td>New York</td>
                            <td>09/30/2021</td>
                            <td>11/30/2021</td>
                            <td><a href="#" class="color_deletemark">X</a></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col">
            <div class="back-information">
                <div><h3>Previous trips</h3></div>
                <table class="table table-sm table-striped">
                    <thead>
                        <tr>
                            <th>Booking reference</th>
                            <th>Customer </th>
                            <th>Flight</th>
                            <th>From</th>
                            <th>To</th>
                            <th>Departure</th>
                            <th>Return </th>
                            <th>Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>AHI45</td>
                            <td>Rousol Al Goboori</td>
                            <td>A 364</td>
                            <td>Chicago</td>
                            <td>Texas</td>
                            <td>01/30/2021</td>
                            <td>02/30/2021</td>
                            <td><a href="#" class="color_deletemark">X</a></td>
                        </tr>
                        
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>
