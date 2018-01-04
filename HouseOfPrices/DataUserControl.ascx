<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DataUserControl.ascx.cs" Inherits="HouseOfPrices.DataUserControl" %>
<link href="Content/Site.css" type="text/css"  rel="stylesheet" />

<asp:Linkbutton runat="server" OnClick="LinkClick" ID="lbtn" >
<div class="Rectangle" ID="Panel1" runat="server" onClick="asd" >
     <table>
      <tr style="height:30px;">
        
          <th runat="server" style="width:70px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <img ID="picture" runat="server"/>
            </div>
        </th>
        <th runat="server" style="width:70px;border-left: 1px solid #fff;padding: 3px 3px 0 3px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <asp:label id="col0" runat="server"  Font-Bold="false">

                </asp:label>
            </div>
        </th>
        <th runat="server" style="width:70px;border-left: 1px solid #fff;padding: 3px 3px 0 3px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <asp:label id="col1" runat="server"  Font-Bold="false">

                </asp:label>
            </div>
        </th>
        <th runat="server" style="width:70px;border-left: 1px solid #fff;padding: 3px 3px 0 3px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <asp:label id="col2" runat="server"  Font-Bold="false">

                </asp:label>
            </div>
        </th>
        <th runat="server" style="width:250px;border-left: 1px solid #fff;padding: 3px 3px 0 3px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <asp:label id="col3" runat="server"  Font-Bold="false">

                </asp:label>
            </div>
        </th>
        <th runat="server" style="width:70px;border-left: 1px solid #fff;padding: 3px 3px 0 3px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <asp:label id="col7" runat="server"  Font-Bold="false">

                </asp:label>
            </div>
        </th>
        <th runat="server" style="width:70px;border-left: 1px solid #fff;padding: 3px 3px 0 3px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <asp:label id="col5" runat="server"  Font-Bold="false">

                </asp:label>
            </div>
        </th>
        <th  runat="server" id="EstimatedTab" style="width:100px;border-left: 1px solid #fff;padding: 3px 3px 0 3px;background-color:#cac5c5;text-align:center;">
            <div runat="server">
                <asp:label id="col6" runat="server"  Font-Bold="false">

                </asp:label>
            </div>
        </th>
    </table>
</div>
</asp:Linkbutton>