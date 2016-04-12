<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SupplierView.aspx.cs" Inherits="PresentationLayer.RoleSupplier.SupplierView" %>

<asp:Content ID="HeaderContent" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.blockUI.js" type="text/javascript"></script>
    <h1>
        Sites
    </h1>
    <div id="dvGridSite">
        <asp:GridView ID="GridViewSite" runat="server" AutoGenerateColumns="false" AllowPaging="true"
            PageSize="10" ShowFooter="true" OnPageIndexChanging="GridViewSite_PageIndexChanging"
            OnSelectedIndexChanged="GridViewSite_SelectedIndexChanged" DataKeyNames="sit_id">
            <Columns>
                <asp:CommandField ShowSelectButton="true" />
                <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_id" runat="server" Width="30px" Text='<%# Eval("sit_id")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Nom">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_name" runat="server" Text='<%# Eval("sit_name")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_sit_name" runat="server" Width="125px" Text='<%# Eval("sit_name")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Téléphone">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_tel" runat="server" Text='<%# Eval("sit_tel")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_sit_tel" runat="server" Width="100px" Text='<%# Eval("sit_tel")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Adresse">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_adr_no" runat="server" Text='<%# Eval("sit_adr_no")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_sit_adr_no" runat="server" Width="50px" Text='<%# Eval("sit_adr_no")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Rue">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_adr_street" runat="server" Text='<%# Eval("sit_adr_street")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_sit_adr_street" runat="server" Width="125px" Text='<%# Eval("sit_adr_street")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Ville">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_adr_city" runat="server" Text='<%# Eval("sit_adr_city")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_sit_adr_city" runat="server" Width="125px" Text='<%# Eval("sit_adr_city")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Province">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_adr_prov" runat="server" Text='<%# Eval("sit_adr_prov")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_sit_adr_prov" runat="server" Width="55px" Text='<%# Eval("sit_adr_prov")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Code postal">
                    <ItemTemplate>
                        <asp:Label ID="lbl_sit_adr_pcode" runat="server" Text='<%# Eval("sit_adr_pcode")%>'></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_sit_adr_pcode" runat="server" Width="75px" Text='<%# Eval("sit_adr_pcode")%>'></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
            </Columns>
            <SelectedRowStyle BackColor="#E6E6E6" />
        </asp:GridView>
    </div>
    <h1>
        Fournisseurs
    </h1>
    <h2>
        <asp:Label runat="server" ID="lbl" /></h2>
    <div id="dvGridSup">
        <asp:ScriptManager ID="ScriptManagerSupplier" runat="server" />
        <asp:UpdatePanel ID="UpdatePanelSupplier" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridViewSupplier" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridViewSupplier" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="10" ShowFooter="true" OnPageIndexChanging="GridViewSupplier_PageIndexChanging"
                    OnRowEditing="GridViewSupplier_RowEditing" OnRowUpdating="GridViewSupplier_RowUpdating"
                    OnRowCancelingEdit="GridViewSupplier_RowCancelingEdit" OnSelectedIndexChanged="GridViewSupplier_SelectedIndexChanged"
                    DataKeyNames="sup_id">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_id" runat="server" Width="30px" Text='<%# Eval("sup_id")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbl_sup_id" runat="server" Width="30px" Text='<%# Eval("sup_id")%>'></asp:Label>
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nom">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_name" runat="server" Text='<%# Eval("sup_name")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sup_name" runat="server" Width="125px" Text='<%# Eval("sup_name")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sup_name" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Téléphone">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_tel" runat="server" Text='<%# Eval("sup_tel")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sup_tel" runat="server" Width="100px" Text='<%# Eval("sup_tel")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sup_tel" runat="server" Width="100px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Adresse">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_adr_no" runat="server" Text='<%# Eval("sup_adr_no")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sup_adr_no" runat="server" Width="50px" Text='<%# Eval("sup_adr_no")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sup_adr_no" runat="server" Width="50px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Rue">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_adr_street" runat="server" Text='<%# Eval("sup_adr_street")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sup_adr_street" runat="server" Width="125px" Text='<%# Eval("sup_adr_street")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sup_adr_street" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ville">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_adr_city" runat="server" Text='<%# Eval("sup_adr_city")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sup_adr_city" runat="server" Width="125px" Text='<%# Eval("sup_adr_city")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sup_adr_city" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Province">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_adr_prov" runat="server" Text='<%# Eval("sup_adr_prov")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sup_adr_prov" runat="server" Width="55px" Text='<%# Eval("sup_adr_prov")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sup_adr_prov" runat="server" Width="55px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Code postal">
                            <ItemTemplate>
                                <asp:Label ID="lbl_sup_adr_pcode" runat="server" Text='<%# Eval("sup_adr_pcode")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_sup_adr_pcode" runat="server" Width="75px" Text='<%# Eval("sup_adr_pcode")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_sup_adr_pcode" runat="server" Width="75px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandArgument='<%# Eval("sup_id")%>'
                                    OnClientClick="return confirm('Êtes-vous sûr de vouloir supprimer cet enregistrement?')"
                                    Text="Supprimer" OnClick="GridViewSupplier_DeleteSup"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="ButtonAddSup" runat="server" Text="Ajouter" Width="60px" OnClick="GridViewSupplier_AddSup" />
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:CommandField ShowEditButton="True" />
                    </Columns>
                    <SelectedRowStyle BackColor="#E6E6E6" />
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <h1>
        Produits
    </h1>
    <h2>
        <asp:Label runat="server" ID="lblProduct" /></h2>
    <div id="dvGridPrd">
        <asp:UpdatePanel ID="UpdatePanelProduct" runat="server">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="GridViewProduct" />
            </Triggers>
            <ContentTemplate>
                <asp:GridView ID="GridViewProduct" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="10" ShowFooter="true" OnPageIndexChanging="GridViewProduct_PageIndexChanging"
                    OnRowEditing="GridViewProduct_RowEditing" OnRowUpdating="GridViewProduct_RowUpdating"
                    OnRowCancelingEdit="GridViewProduct_RowCancelingEdit" OnSelectedIndexChanged="GridViewProduct_SelectedIndexChanged"
                    DataKeyNames="prd_id">
                    <Columns>
                        <asp:CommandField ShowSelectButton="true" />
                        <asp:TemplateField HeaderText="ID" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:Label ID="lbl_prd_id" runat="server" Width="30px" Text='<%# Eval("prd_id")%>'></asp:Label>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Label ID="lbl_prd_id" runat="server" Width="30px" Text='<%# Eval("prd_id")%>'></asp:Label>
                            </FooterTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Furniseur">
                            <ItemTemplate>
                                <asp:Label ID="lbl_prd_sup_id" runat="server" Text='<%# Eval("sup_id")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Label ID="lbl_prd_sup_id" runat="server" Width="125px" Text='<%# Eval("sup_id")%>'></asp:Label>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="ID Prod - Fourn">
                            <ItemTemplate>
                                <asp:Label ID="lbl_prd_sup_no" runat="server" Text='<%# Eval("prd_sup_no")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_prd_sup_no" runat="server" Width="125px" Text='<%# Eval("prd_sup_no")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_prd_sup_no" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nom Produit">
                            <ItemTemplate>
                                <asp:Label ID="lbl_prd_name" runat="server" Text='<%# Eval("prd_name")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_prd_name" runat="server" Width="125px" Text='<%# Eval("prd_name")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_prd_name" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Prix">
                            <ItemTemplate>
                                <asp:Label ID="lbl_prd_price" runat="server" Text='<%# Eval("prd_price")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_prd_price" runat="server" Width="125px" Text='<%# Eval("prd_price")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_prd_price" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Note">
                            <ItemTemplate>
                                <asp:Label ID="lbl_prd_memo" runat="server" Text='<%# Eval("prd_memo")%>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:TextBox ID="txt_prd_memo" runat="server" Width="125px" Text='<%# Eval("prd_memo")%>'></asp:TextBox>
                            </EditItemTemplate>
                            <FooterTemplate>
                                <asp:TextBox ID="txt_prd_memo" runat="server" Width="125px"></asp:TextBox>
                            </FooterTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkButtonDeleteProd" runat="server" CommandArgument='<%# Eval("prd_id")%>'
                                    OnClientClick="return confirm('Êtes-vous sûr de vouloir supprimer cet enregistrement?')"
                                    Text="Supprimer" OnClick="GridViewProduct_DeleteProd"></asp:LinkButton>
                            </ItemTemplate>
                            <FooterTemplate>
                                <asp:Button ID="ButtonAddPrd" runat="server" Text="Ajouter" Width="60px" OnClick="GridViewProduct_AddProd" />
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
