using System;
using System.Web.UI;

namespace PresentationLayer.RoleAdmin
{
    public partial class WelcomeView : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Utils.SecurityCheck(Response, Session, "admin");
            if (!Page.IsPostBack) { }
        }


    }
}
