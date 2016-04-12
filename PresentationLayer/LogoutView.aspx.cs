using System;
using System.Web.UI;

namespace PresentationLayer
{
    public partial class LogoutView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["logged"] = null;
            Session["role"] = null;
        }
    }
}
