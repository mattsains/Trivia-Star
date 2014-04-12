using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] != null)
            {
                dataClassesDataContext d=new dataClassesDataContext();
                var users = from User user in d.Users
                            where user.id == (int)Session["uid"]
                            select user;
                User authenticatedUser = users.First();
                rightnav.Text = "<span id=\"uname\"><a href=\"User.aspx?uid="+authenticatedUser.id+"\">"+authenticatedUser.firstName+"</a></span> | <a href=\"Authenticate.aspx\">Log out</a>";
            }
            else
                rightnav.Text = "<a href=\"Authenticate.aspx\">Log in</a> | <a href=\"Register.aspx\">Register</a>";
        }
    }
}