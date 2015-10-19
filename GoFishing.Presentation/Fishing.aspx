<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Fishing.aspx.cs" Inherits="GoFishing.Presentation.Fishing" %>
<!DOCTYPE html>

<html ng-app="fishingApp">
<head>
    <base href="/">
</head>
<link href="Appbuild/css/styles.min.css" rel="stylesheet" />
<%--<script src="Scripts/jquery-2.1.4.min.js"></script>
<script src="Scripts/angular.min.js"></script>
<script src="Scripts/angular-resource.min.js"></script>
<script src="Scripts/angular-route.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
<script src="App/js/app.js"></script>
<script src="App/js/fishingSvc.js"></script>
<script src="App/js/controllers/trip-controller.js"></script>--%>
<script src="Appbuild/js/all.min.js"></script>
    
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
