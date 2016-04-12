<%@ Page Title="Bienvenue" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="LogoutView.aspx.cs" Inherits="PresentationLayer.LogoutView" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Vous êtes déconnecté</h2>
    <p>
        <asp:HyperLink ID="HyperLinkConnection" runat="server" NavigateUrl="~/ConnectionView.aspx">Connexion</asp:HyperLink></p>
    <p>
        &nbsp;</p>
</asp:Content>
