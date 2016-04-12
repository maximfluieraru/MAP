using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer.RoleSupplier;
using BusinessLogicLayer.RoleAdmin;
using Common.DataTransferObject;
using Common.Exceptions;
using System.Web.Query.Dynamic;

namespace PresentationLayer.RoleSupplier
{
    public partial class SupplierView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.SecurityCheck(Response, Session, "supplier");
            if (!Page.IsPostBack)
            {
                BindDataSite();
                BindDataSupplier();
                BindDataProduct();

                if (Session["site"] != null)
                {
                    GridViewSite.SelectRow((int)Session["selected_row_site"]);
                }

            }
        }

        //___________________________________SITE_________________________________________________________________________________//

        private void BindDataSite()
        {
            GridViewSite.DataSource = SiteBll.LoadAllSite();
            GridViewSite.DataBind();
            GridViewSite.SelectedIndex = -1;
        }

        protected void GridViewSite_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewSite.PageIndex = e.NewPageIndex;

            BindDataSupplier();
        }

        protected void GridViewSite_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbl.Text = GridViewSite.SelectedIndex.ToString();
            Site site = new Site();
            site.sit_id = Convert.ToUInt32(((Label)GridViewSite.Rows[GridViewSite.SelectedIndex].FindControl("lbl_sit_id")).Text);

            Session["site"] = site;
            Session["supplier"] = null;

            BindDataSupplier();

            BindDataProduct();


            Session["selected_row_site"] = GridViewSite.SelectedIndex;
            lbl.Text = "";

        }


        //___________________________________SUPPLIER_________________________________________________________________________________//

        private void BindDataSupplier()
        {

            Site site = (Site)Session["site"];
            if (site != null)
            {
                List<Supplier> list = SupplierBll.LoadAllSupplier(site);

                if (list.Count() < 1)
                {
                    list.Add(new Supplier());
                }

                GridViewSupplier.DataSource = list;
                GridViewSupplier.DataBind();
                GridViewSupplier.SelectedIndex = -1;
            }
            else
            {
                GridViewSupplier.DataSource = null;
                GridViewSupplier.DataBind();
                lbl.Text = "Choisissez un SITE";
            }

        }



        protected void GridViewSupplier_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewSupplier.EditIndex = e.NewEditIndex;

            BindDataSupplier();
        }

        protected void GridViewSupplier_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewSupplier.EditIndex = -1;

            BindDataSupplier();
        }

        protected void GridViewSupplier_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Supplier sup = new Supplier();
            sup.sup_id = Convert.ToUInt32(((Label)GridViewSupplier.Rows[e.RowIndex].FindControl("lbl_sup_id")).Text);
            sup.sup_name = ((TextBox)GridViewSupplier.Rows[e.RowIndex].FindControl("txt_sup_name")).Text;
            sup.sup_tel = ((TextBox)GridViewSupplier.Rows[e.RowIndex].FindControl("txt_sup_tel")).Text;
            sup.sup_adr_no = ((TextBox)GridViewSupplier.Rows[e.RowIndex].FindControl("txt_sup_adr_no")).Text;
            sup.sup_adr_street = ((TextBox)GridViewSupplier.Rows[e.RowIndex].FindControl("txt_sup_adr_street")).Text;
            sup.sup_adr_city = ((TextBox)GridViewSupplier.Rows[e.RowIndex].FindControl("txt_sup_adr_city")).Text;
            sup.sup_adr_prov = ((TextBox)GridViewSupplier.Rows[e.RowIndex].FindControl("txt_sup_adr_prov")).Text;
            sup.sup_adr_pcode = ((TextBox)GridViewSupplier.Rows[e.RowIndex].FindControl("txt_sup_adr_pcode")).Text;
            SupplierBll.UpdateSupplier(sup);
            GridViewSupplier.EditIndex = -1;

            BindDataSupplier();
        }

        protected void GridViewSupplier_AddSup(object sender, EventArgs e)
        {

            Supplier sup = new Supplier();
            sup.sup_name = ((TextBox)GridViewSupplier.FooterRow.FindControl("txt_sup_name")).Text;
            sup.sup_tel = ((TextBox)GridViewSupplier.FooterRow.FindControl("txt_sup_tel")).Text;
            sup.sup_adr_no = ((TextBox)GridViewSupplier.FooterRow.FindControl("txt_sup_adr_no")).Text;
            sup.sup_adr_street = ((TextBox)GridViewSupplier.FooterRow.FindControl("txt_sup_adr_street")).Text;
            sup.sup_adr_city = ((TextBox)GridViewSupplier.FooterRow.FindControl("txt_sup_adr_city")).Text;
            sup.sup_adr_prov = ((TextBox)GridViewSupplier.FooterRow.FindControl("txt_sup_adr_prov")).Text;
            sup.sup_adr_pcode = ((TextBox)GridViewSupplier.FooterRow.FindControl("txt_sup_adr_pcode")).Text;

            Boolean suppExist = false;

            if (String.IsNullOrEmpty(sup.sup_name) || String.IsNullOrWhiteSpace(sup.sup_name))
            {
                return;
            }

            foreach (Supplier supp in SupplierBll.LoadAllSupplier())
            {
                if (supp.sup_name.Equals(sup.sup_name))
                {
                    suppExist = true;
                    sup.sup_id = supp.sup_id;
                }
            }

            Site site = (Site)Session["site"];
            SiteSupplier ss = new SiteSupplier();
            ss.sit_id = site.sit_id;
            ss.sup_id = sup.sup_id;

            if (suppExist)
            {
                foreach (SiteSupplier ssup in SupplierBll.LoadAllSiteSupplier())
                {
                    if (ssup.sit_id.Equals(ss.sit_id) && ssup.sup_id.Equals(ss.sup_id))
                    {
                        return;
                    }
                }
            }

            try
            {
                if (suppExist)
                {
                    SupplierBll.InsertSupplierSite(ss);
                }
                else
                {
                    SupplierBll.InsertSupplier(sup, ss);
                }

                GridViewSupplier.PageIndex = GridViewSupplier.PageCount;

                BindDataSupplier();
            }
            catch (ManagedException ex)
            {
                Utils.DisplayMessage(UpdatePanelSupplier, String.Format("alert(\"{0}\");", ex.Message));
            }
        }

        protected void GridViewSupplier_DeleteSup(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            Site site = (Site)Session["site"];
            SupplierBll.DeleteSupplier(Convert.ToUInt32(lb.CommandArgument), site.sit_id);
            Session["supplier"] = null;
            BindDataSupplier();
            BindDataProduct();
        }

        protected void GridViewSupplier_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewSupplier.PageIndex = e.NewPageIndex;

            BindDataSupplier();
        }

        protected void GridViewSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {


            lbl.Text = GridViewSupplier.SelectedIndex.ToString();
            Supplier sup = new Supplier();
            sup.sup_id = Convert.ToUInt32(((Label)GridViewSupplier.Rows[GridViewSupplier.SelectedIndex].FindControl("lbl_sup_id")).Text);

            Session["supplier"] = sup;

            BindDataProduct();

            Session["selected_row_suplier"] = GridViewSite.SelectedIndex;
            lblProduct.Text = "";


        }



        //___________________________________PRODUCT_________________________________________________________________________________//

        private void BindDataProduct()
        {
            Supplier sup = (Supplier)Session["supplier"];
            if (sup != null)
            {
                List<Product> list = SupplierBll.LoadAllProduct(sup);
                if (list.Count < 1)
                {
                    list.Add(new Product());
                }
              
                GridViewProduct.DataSource = list;
                GridViewProduct.DataBind();
                GridViewProduct.SelectedIndex = -1;
                

            }
            else
            {
                GridViewProduct.DataSource = null;
                GridViewProduct.DataBind();
                lblProduct.Text = "Choisir un fourniseur";
            }

        }

        protected void GridViewProduct_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void GridViewProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewProduct.PageIndex = e.NewPageIndex;

            BindDataProduct();
        }

        protected void GridViewProduct_DeleteProd(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;

            SupplierBll.DeleteProduct(Convert.ToUInt32(lb.CommandArgument));

            BindDataProduct();

        }


        protected void GridViewProduct_AddProd(object sender, EventArgs e)
        {


            Product prd = new Product();

            String price = ((TextBox)GridViewProduct.FooterRow.FindControl("txt_prd_price")).Text;
            if (String.IsNullOrEmpty(price) || String.IsNullOrWhiteSpace(price))
            {
                return;
            }

            prd.prd_name = ((TextBox)GridViewProduct.FooterRow.FindControl("txt_prd_name")).Text;
            try
            {
                prd.prd_price = Decimal.Parse(price);
            }
            catch (Exception ex)
            {
                prd.prd_price = (Decimal)0.00;
            }

            prd.prd_sup_no = ((TextBox)GridViewProduct.FooterRow.FindControl("txt_prd_sup_no")).Text;
            prd.prd_memo = ((TextBox)GridViewProduct.FooterRow.FindControl("txt_prd_memo")).Text;

            if (String.IsNullOrEmpty(prd.prd_name) || String.IsNullOrWhiteSpace(prd.prd_name))
            {
                return;
            }


            foreach (Product prod in SupplierBll.LoadAllProduct())
            {
                if (prod.prd_sup_no.Equals(prd.prd_sup_no))
                {

                    return;
                }
            }

            Supplier sup = (Supplier)Session["supplier"];

            prd.sup_id = sup.sup_id;

            try
            {

                SupplierBll.InsertProduct(prd);

                GridViewProduct.PageIndex = GridViewProduct.PageCount;

                BindDataProduct();

            }
            catch (ManagedException ex)
            {
                Utils.DisplayMessage(UpdatePanelSupplier, String.Format("alert(\"{0}\");", ex.Message));
            }
        }

        protected void GridViewProduct_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Product prd = new Product();
            Supplier sup = (Supplier)Session["supplier"];

            prd.sup_id = sup.sup_id;

            prd.prd_id = Convert.ToUInt32(((Label)GridViewProduct.Rows[e.RowIndex].FindControl("lbl_prd_id")).Text);
            prd.prd_name = ((TextBox)GridViewProduct.Rows[e.RowIndex].FindControl("txt_prd_name")).Text;


            String price = ((TextBox)GridViewProduct.Rows[e.RowIndex].FindControl("txt_prd_price")).Text;
            if (String.IsNullOrEmpty(price) || String.IsNullOrWhiteSpace(price))
            {
                return;
            }


            try
            {
                prd.prd_price = Decimal.Parse(price);
            }
            catch (Exception ex)
            {
                prd.prd_price = (Decimal)0.00;
            }

            prd.prd_sup_no = ((TextBox)GridViewProduct.Rows[e.RowIndex].FindControl("txt_prd_sup_no")).Text;
            prd.prd_memo = ((TextBox)GridViewProduct.Rows[e.RowIndex].FindControl("txt_prd_memo")).Text;

            SupplierBll.UpdateProduct(prd);

            GridViewProduct.EditIndex = -1;

            BindDataProduct();
        }

        protected void GridViewProduct_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewProduct.EditIndex = -1;

            BindDataProduct();
        }

        protected void GridViewProduct_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewProduct.EditIndex = e.NewEditIndex;

            BindDataProduct();
        }

        //____________________________________________________________________________________________________________________//


    }
}