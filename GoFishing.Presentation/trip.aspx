<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trip.aspx.cs" Inherits="GoFishing.Presentation.trip" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
     <asp:PlaceHolder ID="PlaceHolder1" runat="server">        
         <%: Scripts.Render("~/bundles/jquery") %>
         <%: Styles.Render("~/Content/css") %>
    </asp:PlaceHolder>
    
</head>
    
    <script>
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


    </script>
<body>
   
    <div class= "container" >
        <div class="row">
        <div class="col-xs-3">
    <input type="button" id="btnGetTrips" value="Get"/>
    </div>
        <div class="col-xs-3">
    <input type="button" id="Button1" value="Post"/>
    </div>
    </div>
        </div>
   
</body>
</html>
