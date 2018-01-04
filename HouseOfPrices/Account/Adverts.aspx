<%@ Page Title="Advert" Language="C#" AutoEventWireup="true" CodeBehind="Adverts.aspx.cs" Inherits="HouseOfPrices.Account.Adverts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>Show Google Map with Latitude and Longitude in asp.net website</title>


<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
<meta http-equiv="content-type" content="text/html; charset=UTF-8" />
<webopt:bundlereference runat="server" path="~/Content/css" />
<link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
<style type="text/css">
    html { height: 100% }
    body { height: 100%; margin: 0; padding: 0 }
    #map_canvas { height: 100% }
</style>
<script type="text/javascript"
src="https://maps.googleapis.com/maps/api/js?key=AIzaSyC6v5-2uaq_wusHDktM9ILcqIrlPtnZgEk&sensor=false">
</script>
<script type="text/javascript">
    function initialize() {
        var lat = document.getElementById('txtlat').value;
        var lon = document.getElementById('txtlon').value;
        var myLatlng = new google.maps.LatLng(lat, lon) // This is used to center the map to show our markers
        var mapOptions = {
            center: myLatlng,
            zoom: 10,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            marker: true
        };
        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        var marker = new google.maps.Marker({
            position: myLatlng
        });
        marker.setMap(map);
    }
</script>
</head>
    <body>
        <form runat ="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see http://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="MsAjaxBundle" />
                <asp:ScriptReference Name="jquery" />
                <asp:ScriptReference Name="bootstrap" />
                <asp:ScriptReference Name="respond" />
                <asp:ScriptReference Name="WebForms.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebForms.js" />
                <asp:ScriptReference Name="WebUIValidation.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebUIValidation.js" />
                <asp:ScriptReference Name="MenuStandards.js" Assembly="System.Web" Path="~/Scripts/WebForms/MenuStandards.js" />
                <asp:ScriptReference Name="GridView.js" Assembly="System.Web" Path="~/Scripts/WebForms/GridView.js" />
                <asp:ScriptReference Name="DetailsView.js" Assembly="System.Web" Path="~/Scripts/WebForms/DetailsView.js" />
                <asp:ScriptReference Name="TreeView.js" Assembly="System.Web" Path="~/Scripts/WebForms/TreeView.js" />
                <asp:ScriptReference Name="WebParts.js" Assembly="System.Web" Path="~/Scripts/WebForms/WebParts.js" />
                <asp:ScriptReference Name="Focus.js" Assembly="System.Web" Path="~/Scripts/WebForms/Focus.js" />
                <asp:ScriptReference Name="WebFormsBundle" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
         <div class="navbar navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" runat="server" href="~/">House Of Prices</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a runat="server" href="~/">Home</a></li>
                        <li><a runat="server" href="~/About">About</a></li>
                        <li><a runat="server" href="~/Contact">Contact</a></li>
                    </ul>
                    <asp:LoginView runat="server" ViewStateMode="Disabled">
                        <AnonymousTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Register">Register</a></li>
                                <li><a runat="server" href="~/Account/Login">Log in</a></li>
                            </ul>
                        </AnonymousTemplate>
                        <LoggedInTemplate>
                            <ul class="nav navbar-nav navbar-right">
                                <li><a runat="server" href="~/Account/Manage" title="Manage your account">Hello, <%: Context.User.Identity.GetUserName()  %> !</a></li>
                                <li>
                                    <asp:LoginStatus runat="server" LogoutAction="Redirect" LogoutText="Log off" LogoutPageUrl="~/" />
                                </li>
                            </ul>
                        </LoggedInTemplate>
                    </asp:LoginView>
                </div>
            </div>
        </div>
       
        <center>
            <br />
            <br />
            <br />
            <br />
                 <%--<input type="text" id="txtlat" hidden="hidden"/>
                <input type="text" id="txtlon" hidden="hidden"/> --%>
            <input id="work" type="button" value="Submit" onclick="javascript: initialize()" hidden="hidden"/>
                <div id="map_canvas" style="width: 500px; height: 400px"></div>
        </center> 


    
       
            <%--lat:<span id="lat" runat="server"></span>
            lon:<span id="lon" runat="server"></span>--%>
            <input type="text" id="btnQueryString" value="Send" runat="server" style="visibility:hidden;"/>
            

            

                <div class="form-horizontal" style="margin-left:15%;margin-right:15%;">
                    
                   <input type="text" id="txtlat" value="" runat="server" style="visibility:hidden"/>
                   <input type="text" id="txtlon" value="" runat="server" style="visibility:hidden"/>
                    <br />
                    <br />
                    <table class="style11">
                    <tbody><tr>
                        
                            
                            <center>
                                <div>
                                    <img id="picture" runat="server"/></center>
                        <br />
                                </div>
                                
                            <%--<asp:FileUpload ID="FileUpload1" runat="server"/>--%>
                     
                        
                    </tr>
                    
                    <tr>
                        <td class="style22">
                           Room Number</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="RoomNumberText" runat="server" width="200px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Floor Number</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="FloorNumberText" runat="server" maxlength="2" width="200px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Square Meter</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="SquareMeterText" runat="server" width="200px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            House Age</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="AgeText" runat="server" width="200px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Heating</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="HeatingText" runat="server" width="200px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Proximity To Transportation</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="ProximityToTranportationText" runat="server" width="200px" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Requested Price</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="RequestedPriceText" runat="server" width="200px"/>

                        </td>
                    </tr>
                    <tr id="special_row" runat="server">
                        <td class="style22">
                            Estimated Price</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:Label id="EstimatedPriceText" runat="server" width="200px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Information</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:textbox id="InformationText" runat="server" height="200px" width="50%" ReadOnly="true" ></asp:textbox>

                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                             </td>
                        <td class="style33">
                             </td>
                        <td>
                             </td>
                    </tr>                    
                </tbody></table>
            </div>
        </form>
    </body>
</html>

