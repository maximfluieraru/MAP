using System;
using Common.DataTransferObject;
using System.Web.UI.WebControls;

namespace PresentationLayer
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Employee emp = (Employee)Session["logged"];
            String role = (String)Session["role"];
            Boolean logged = (emp != null && role != null);
            LabelLoggedEmp.Text = logged ? String.Format("{0} {1}", emp.emp_fname, emp.emp_lname) : String.Empty;
            LabelLoggedEmp.Visible = logged;
            HyperLinkDisconnect.Visible = logged;
            NavigationMenuAdmin.Visible = (logged && role.Equals("admin"));
            NavigationMenuFeed.Visible = (logged && role.Equals("feed"));
            NavigationMenuManager.Visible = (logged && role.Equals("manager"));
            NavigationMenuStock.Visible = (logged && role.Equals("stock"));
            NavigationMenuSupplier.Visible = (logged && role.Equals("supplier"));
        }

    }
}
