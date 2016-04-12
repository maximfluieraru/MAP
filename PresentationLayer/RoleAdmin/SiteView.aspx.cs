using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.RoleAdmin;
using Common.DataTransferObject;
using Common.Exceptions;

namespace PresentationLayer.RoleAdmin
{
    public partial class SiteView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.SecurityCheck(Response, Session, "admin");
            if (!Page.IsPostBack) BindDataSite();
        }

        private void BindDataSite()
        {
            GridViewSite.DataSource = SiteBll.LoadAllSite();
            GridViewSite.DataBind();
            GridViewSite.SelectedIndex = -1;
            // ici on supprime l'affichage des données détails par exemple (commande/détails).
            // GridViewDetail.DataSource = null; --> devrait être suffisant.
        }

        protected void GridViewSite_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewSite.EditIndex = e.NewEditIndex;
            BindDataSite();
        }

        protected void GridViewSite_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewSite.EditIndex = -1;
            BindDataSite();
        }

        protected void GridViewSite_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Site sit = new Site();
            sit.sit_id = Convert.ToUInt32(((Label)GridViewSite.Rows[e.RowIndex].FindControl("lbl_sit_id")).Text);
            sit.sit_name = ((TextBox)GridViewSite.Rows[e.RowIndex].FindControl("txt_sit_name")).Text;
            sit.sit_tel = ((TextBox)GridViewSite.Rows[e.RowIndex].FindControl("txt_sit_tel")).Text;
            sit.sit_adr_no = ((TextBox)GridViewSite.Rows[e.RowIndex].FindControl("txt_sit_adr_no")).Text;
            sit.sit_adr_street = ((TextBox)GridViewSite.Rows[e.RowIndex].FindControl("txt_sit_adr_street")).Text;
            sit.sit_adr_city = ((TextBox)GridViewSite.Rows[e.RowIndex].FindControl("txt_sit_adr_city")).Text;
            sit.sit_adr_prov = ((TextBox)GridViewSite.Rows[e.RowIndex].FindControl("txt_sit_adr_prov")).Text;
            sit.sit_adr_pcode = ((TextBox)GridViewSite.Rows[e.RowIndex].FindControl("txt_sit_adr_pcode")).Text;
            SiteBll.UpdateSite(sit);
            GridViewSite.EditIndex = -1;
            BindDataSite();
        }

        protected void GridViewSite_AddSite(object sender, EventArgs e)
        {
            Site sit = new Site();
            sit.sit_name = ((TextBox)GridViewSite.FooterRow.FindControl("txt_sit_name")).Text;
            sit.sit_tel = ((TextBox)GridViewSite.FooterRow.FindControl("txt_sit_tel")).Text;
            sit.sit_adr_no = ((TextBox)GridViewSite.FooterRow.FindControl("txt_sit_adr_no")).Text;
            sit.sit_adr_street = ((TextBox)GridViewSite.FooterRow.FindControl("txt_sit_adr_street")).Text;
            sit.sit_adr_city = ((TextBox)GridViewSite.FooterRow.FindControl("txt_sit_adr_city")).Text;
            sit.sit_adr_prov = ((TextBox)GridViewSite.FooterRow.FindControl("txt_sit_adr_prov")).Text;
            sit.sit_adr_pcode = ((TextBox)GridViewSite.FooterRow.FindControl("txt_sit_adr_pcode")).Text;
            try
            {
                SiteBll.InsertSite(sit);
                GridViewSite.PageIndex = GridViewSite.PageCount;
                BindDataSite();
            }
            catch (ManagedException ex)
            {
                Utils.DisplayMessage(UpdatePanelSite, String.Format("alert(\"{0}\");", ex.Message));
            }
        }

        protected void GridViewSite_DeleteSite(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            SiteBll.DeleteSite(Convert.ToUInt32(lb.CommandArgument));
            BindDataSite();
        }

        protected void GridViewSite_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewSite.PageIndex = e.NewPageIndex;
            BindDataSite();
        }

        protected void GridViewSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["fdsfd"] = "fdfdf";
            // ici on peut démarrer l'actualisation des données détails par exemple (commande/détails).
        }

    }
}
