using System;
using System.Web.UI;
using System.Web.SessionState;
using System.Web;

namespace PresentationLayer
{
    internal static class Utils
    {

        public static void DisplayMessage(Control control, String message)
        {
            String msg = String.Format("alert(\"{0}\");", message);
            ScriptManager.RegisterStartupScript(control, control.GetType(), "alertscript", msg, true);
        }

        public static void SecurityCheck(HttpResponse response, HttpSessionState session, String view_role)
        {
            String user_role = (String)session["role"];
            if (user_role == null || !user_role.Equals(view_role)) response.Redirect("~/LogoutView.aspx", false);
        }

    }
}