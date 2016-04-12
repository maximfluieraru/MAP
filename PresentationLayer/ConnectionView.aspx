<%@ Page Title="Connexion" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConnectionView.aspx.cs" Inherits="PresentationLayer.ConnectionView" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Connexion
    </h2>
    <p>
        Code d&#39;employé<br />
        <asp:TextBox ID="TextBoxCode" runat="server"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelCodeError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        Mot de passe<br />
        <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <asp:Label ID="LabelPasswordError" runat="server" ForeColor="Red"></asp:Label>
    </p>
    <p>
        <asp:Button ID="ButtonConnect" runat="server" OnClick="ButtonConnect_Click" Text="Connecter" />
    </p>
</asp:Content>
