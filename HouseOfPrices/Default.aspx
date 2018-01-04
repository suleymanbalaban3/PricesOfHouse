<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HouseOfPrices._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        
        
        <div style="margin:auto auto auto auto;height:100%;width:960px;">
              <table>
          <tr style="background-color:#c2c3c7;height:50px;">
            <%--<th runat="server" id="img0" style="width:100px;">Resim</th>--%>
             <th runat="server" id="Th1" style="width:70px;text-align:center">Picture</th>
            <th runat="server" id="col0" style="width:70px;text-align:center">Area</th>
            <th runat="server" id="col1" style="width:70px;text-align:center">Room</th>
            <th runat="server" id="col2" style="width:70px;text-align:center">Age</th>
            <th runat="server" id="col3" style="width:250px;text-align:center">Information</th>
            <th runat="server" id="col7" style="width:70px;text-align:center">Floor</th>
            <th runat="server" id="col5" style="width:70px;text-align:center">Price</th>
            <th runat="server" id="col6" style="width:100px;text-align:center">Estimated</th>
            
            <%--<th runat="server" id="col8" style="width:100px;">Information</th>--%>
          </tr>   
        </table>
         <asp:PlaceHolder ID="DataPlaceHolder" runat="server"/>
          </div>
    </div>

</asp:Content>
