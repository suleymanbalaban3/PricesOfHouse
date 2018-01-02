<%@ Page Title="Advert" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Adverts.aspx.cs" Inherits="HouseOfPrices.Account.Adverts" Async="true" %>

<%@ Register Src="~/Account/OpenAuthProviders.ascx" TagPrefix="uc" TagName="OpenAuthProviders" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>

    <div class="row">
        <asp:TextBox runat="server" ID="TextBox1">

        </asp:TextBox>
    </div> 
</asp:Content>
