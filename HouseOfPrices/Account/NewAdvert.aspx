<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAdvert.aspx.cs" Inherits="HouseOfPrices.Account.NewAdvert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title><%:"" %>  House Of Prices</title>
    <link rel="Stylesheet" type="text/css" href="Content/InsertAd.css"/>
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
        var myLatlng = new google.maps.LatLng(40.75144846253955, 30.39237665914298);
        var myOptions = {
            zoom:7,
            center: myLatlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        }
        map = new google.maps.Map(document.getElementById("gmap"), myOptions);
        // marker refers to a global variable
        marker = new google.maps.Marker({
            position: myLatlng,
            map: map
        });
        // if center changed then update lat and lon document objects
        google.maps.event.addListener(map, 'center_changed', function () {
            var location = map.getCenter();
            document.getElementById("latt1").value = location.lat();
            document.getElementById("lonn1").value = location.lng();
            document.getElementById("btnQueryString").innerHTML = location.lng();
            
            // call function to reposition marker location
            placeMarker(location);
        });
        // if zoom changed, then update document object with new info
        google.maps.event.addListener(map, 'zoom_changed', function () {
            zoomLevel = map.getZoom();
            document.getElementById("zoom_level").innerHTML = zoomLevel;
        });
        // double click on the marker changes zoom level
        google.maps.event.addListener(marker, 'dblclick', function () {
            zoomLevel = map.getZoom() + 1;
            if (zoomLevel == 20) {
                zoomLevel = 10;
            }
            document.getElementById("zoom_level").innerHTML = zoomLevel;
            map.setZoom(zoomLevel);
        });

        function placeMarker(location) {
            var clickedLocation = new google.maps.LatLng(location);
            marker.setPosition(location);
        }
    }
    window.onload = function () { initialize() };
</script>
     <style>
         div#gmap {
                width: 70%;
                height: 400px;
                border:double;
         }
        .style11 {
            width: 100%;
        }
        .style22
        {
            width: 200px;
            font-weight: bold;
        }
        .style33
        {
            width: 3px;
            font-weight: bold;
        }
    </style>
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
       
        <h1 style="margin-left:15%;margin-top:7%;">Please mark your house on this map</h1>
        <center>
            
            <div id="gmap">
            </div>
        </center> 


    
       
            <%--lat:<span id="lat" runat="server"></span>
            lon:<span id="lon" runat="server"></span>--%>
            <input type="text" id="btnQueryString" value="Send" runat="server" style="visibility:hidden;"/>
            

            

                <div class="form-horizontal" style="margin-left:15%;margin-right:15%;">
                    
                    Latt :<input type="text" id="latt1" value="" runat="server" />
                    Lonn :<input type="text" id="lonn1" value="" runat="server"/>
                    <h2>Please give some information</h2>
                    <br />
                    <table class="style11">
                    <tbody><tr>
                        <td class="style22">
                            Upload an Image</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server"/>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="style22">
                           Room Number</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:dropdownlist id="RoomNumbers" runat="server" width="200px">
                                <asp:listitem>1 + 0</asp:listitem>
                                <asp:listitem>1 + 1</asp:listitem>
                                <asp:listitem>2 + 1</asp:listitem>
                                <asp:listitem>2 + 2</asp:listitem>
                                <asp:listitem>3 + 1</asp:listitem>
                                <asp:listitem>3 + 2</asp:listitem>
                                <asp:listitem>4 + 1</asp:listitem>
                                <asp:listitem>4 + 2</asp:listitem>
                                <asp:listitem>4 + 3</asp:listitem>
                                <asp:listitem>4 + 4</asp:listitem>
                                <asp:listitem>5 + 1</asp:listitem>
                                <asp:listitem>5 + 2</asp:listitem>
                                <asp:listitem>5 + 3</asp:listitem>
                                <asp:listitem>5 + 4</asp:listitem>
                                <asp:listitem>6 + 1</asp:listitem>
                                <asp:listitem>6 + 2</asp:listitem>
                                <asp:listitem>6 + 3</asp:listitem>
                                <asp:listitem>7 + 1</asp:listitem>
                                <asp:listitem>7 + 2</asp:listitem>
                                <asp:listitem>7 + 3</asp:listitem>
                                <asp:listitem>8 + 1</asp:listitem>
                                <asp:listitem>8 + 2</asp:listitem>
                                <asp:listitem>8 + 3</asp:listitem>
                                <asp:listitem>8 + 4</asp:listitem>
                            </asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Floor Number</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:textbox id="FloorNumber" runat="server" maxlength="2" width="200px" TextMode="Number"></asp:textbox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="FloorNumber"
                                CssClass="text-danger" ErrorMessage="The floor number field is required." />
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Square Meter</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:textbox id="SquareMeter" runat="server" width="200px" TextMode="Number"></asp:textbox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="SquareMeter"
                                CssClass="text-danger" ErrorMessage="The square meter field is required." />
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            House Age</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:textbox id="Age" runat="server" width="200px" TextMode="Number"></asp:textbox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Age"
                                CssClass="text-danger" ErrorMessage="The house age field is required." />
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Heating</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:dropdownlist id="Heating" runat="server" width="200px">
                                <asp:listitem>Heater</asp:listitem>
                                <asp:listitem>Central Heating</asp:listitem>
                                <asp:listitem>Stove</asp:listitem>
                            </asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Proximity To Transportation</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:dropdownlist id="ProximityToTransportation" runat="server" width="200px">
                                <asp:listitem>0 - 200 m</asp:listitem>
                                <asp:listitem>200 - 400 m</asp:listitem>
                                <asp:listitem>400 - 600 m</asp:listitem>
                                <asp:listitem>600 - 1000 m</asp:listitem>
                                <asp:listitem>1 - 1.5 km</asp:listitem>
                                <asp:listitem>1.5 - 2 km</asp:listitem>
                                <asp:listitem>2+ km</asp:listitem>
                            </asp:dropdownlist>
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Requested Price</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:textbox id="RequestedPrice" runat="server" width="200px" TextMode="Number"></asp:textbox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="RequestedPrice"
                                CssClass="text-danger" ErrorMessage="The requested price (TL) field is required." />
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                            Information</td>
                        <td class="style33">
                            :</td>
                        <td>
                            <asp:textbox id="Information" runat="server" height="200px" width="30%" TextMode="MultiLine"></asp:textbox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Information"
                                CssClass="text-danger" ErrorMessage="The information field is required." />
                        </td>
                    </tr>
                    <tr>
                        <td class="style22">
                             </td>
                        <td class="style33">
                             </td>
                        <td>
                            <asp:button id="Load" runat="server" onclick="Button1_Click" text="LOAD" height="50px" width="20%">
                        </asp:button></td>
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

