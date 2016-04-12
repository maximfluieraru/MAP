using System;
using System.Web.UI;
using BusinessLogicLayer;
using Common.DataTransferObject;
using Common.Exceptions;

namespace PresentationLayer
{
    public partial class ConnectionView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) { }
        }

        protected void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                Employee emp = ConnectionBll.LoadEmployee(TextBoxCode.Text);
                if (emp == null)
                {
                    TextBoxCode.Text = "";
                    TextBoxPassword.Text = "";
                    LabelCodeError.Text = "Code d'utilisateur invalide.";
                    LabelPasswordError.Text = "";
                }
                else if (!ConnectionBll.ValidatePassword(TextBoxPassword.Text, emp.emp_pw))
                {
                    TextBoxPassword.Text = "";
                    LabelCodeError.Text = "";
                    LabelPasswordError.Text = "Mot de passe invalide.";
                }
                else
                {
                    Session["logged"] = emp;
                    Session["role"] = ConnectionBll.GetRoleName(emp.rol_id);
                    switch ((String)Session["role"])
                    {
                        case "admin":
                            Response.Redirect("~/RoleAdmin/WelcomeView.aspx", false);
                            break;
                        case "feed":
                            Response.Redirect("~/RoleFeed/WelcomeView.aspx", false);
                            break;
                        case "stock":
                            Response.Redirect("~/RoleStock/WelcomeView.aspx", false);
                            break;
                        case "supplier":
                            Response.Redirect("~/RoleSupplier/WelcomeView.aspx", false);
                            break;
                        default:
                            Response.Redirect("~/LogoutView.aspx");  // ici il serait préférable d'afficher une page d'erreur "Role inexistant".
                            break;
                    }
                }
            }
            catch (ManagedException ex)
            {
                String msg = String.Format("alert(\"{0}\");", ex.Message);
                Utils.DisplayMessage(this, msg);
            }
            catch (Exception ex)
            {
                ExHandler.Parse(ex, null);
            }
        }

    }
}
