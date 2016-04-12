using System;
using System.Web.UI;

namespace PresentationLayer.RoleSupplier
{
    public partial class WelcomeView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.SecurityCheck(Response, Session, "supplier");
            if (!Page.IsPostBack) { }
        }


    }
}
