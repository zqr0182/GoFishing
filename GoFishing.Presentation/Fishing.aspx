<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fishing.aspx.cs" Inherits="GoFishing.Presentation.Fishing" %>
<!DOCTYPE html>

<html ng-app="fishingApp">
<head>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">        
         <%: Scripts.Render("~/bundles/jquery") %>
         <%: Scripts.Render("~/bundles/angular") %>
         <%: Styles.Render("~/Content/css") %>
    </asp:PlaceHolder>
    <base href="/">
</head>
    
    <%--<script>
        jQuery(document).ready(function($) {

            $("#btnGetTrips").click(function() {

                $.ajax({
                    url: '/api/GoFishingAPI',
                    type: 'GET',
                    dataType: 'json',
                    success: function (data) {
                        alert("fff");
                    },
                    error: function (x, y, z) {
                        alert(x + '\n' + y + '\n' + z);
                    }
                });
            });
        });


    </script>--%>
<body>
    <div class="container">
        <div class="row">
            <div class="navbar navbar-default">
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="/Fishing/trip">Trip</a></li>
                        <li><a href="/Fishing/trophy">Trophies</a></li>
                    </ul>

                </div>
            </div>
        </div>
        <div ng-view></div>
    </div>
</body>
</html>
