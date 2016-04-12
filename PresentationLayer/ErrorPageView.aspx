<%@ Page Title="Erreur système" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ErrorPageView.aspx.cs" Inherits="PresentationLayer.ErrorPageView" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2><b>Une erreur non gérée est survenue</b></h2>
    <p>L'administrateur du site en a été informé et des actions seront prises sous peu pour résoudre le problème.</p>
    <p>Nous sommes désolé pour les inconvénients.</p>
</asp:Content>
