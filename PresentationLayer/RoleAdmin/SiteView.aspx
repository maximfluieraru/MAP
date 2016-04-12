<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SiteView.aspx.cs" Inherits="PresentationLayer.RoleAdmin.SiteView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script src="../Scripts/JScriptMap.js" type="text/javascript"></script>
    <h1>
        SITE
    </h1>

    <div id="dvGrid">
        <asp:ScriptManager ID="ScriptManagerSite" runat="server" />
        <asp:UpdatePanel ID="UpdatePanelSite" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridViewSite" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridViewSite" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="10" ShowFooter="true" OnPageIndexChanging="GridViewSite_PageIndexChanging"
                    OnRowEditing="GridViewSite_RowEditing" OnRowUpdating="GridViewSite_RowUpdating"
                    OnRowCancelingEdit="GridViewSite_RowCancelingEdit" OnSelectedIndexChanged="GridViewSite_SelectedIndexChanged"
                    DataKeyNames="sit_id">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_id" runat="server" Width="30px" Text='<%# Eval("sit_id")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbl_sit_id" runat="server" Width="30px" Text='<%# Eval("sit_id")%>'></asp:Label>
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nom">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_name" runat="server" Text='<%# Eval("sit_name")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sit_name" runat="server" Width="125px" Text='<%# Eval("sit_name")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sit_name" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Téléphone">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_tel" runat="server" Text='<%# Eval("sit_tel")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sit_tel" runat="server" Width="100px" Text='<%# Eval("sit_tel")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sit_tel" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Adresse">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_adr_no" runat="server" Text='<%# Eval("sit_adr_no")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sit_adr_no" runat="server" Width="50px" Text='<%# Eval("sit_adr_no")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sit_adr_no" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rue">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_adr_street" runat="server" Text='<%# Eval("sit_adr_street")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sit_adr_street" runat="server" Width="125px" Text='<%# Eval("sit_adr_street")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sit_adr_street" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ville">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_adr_city" runat="server" Text='<%# Eval("sit_adr_city")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sit_adr_city" runat="server" Width="125px" Text='<%# Eval("sit_adr_city")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sit_adr_city" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Province">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_adr_prov" runat="server" Text='<%# Eval("sit_adr_prov")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sit_adr_prov" runat="server" Width="55px" Text='<%# Eval("sit_adr_prov")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sit_adr_prov" runat="server" Width="55px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code postal">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sit_adr_pcode" runat="server" Text='<%# Eval("sit_adr_pcode")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sit_adr_pcode" runat="server" Width="75px" Text='<%# Eval("sit_adr_pcode")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sit_adr_pcode" runat="server" Width="75px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandArgument='<%# Eval("sit_id")%>'
                                    OnClientClick="return confirm('Êtes-vous sûr de vouloir supprimer cet enregistrement?')" Text="Supprimer" OnClick="GridViewSite_DeleteSite"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="ButtonAddSite" runat="server" Text="Ajouter" Width="60px" OnClick="GridViewSite_AddSite" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#E6E6E6" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
