using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Security.Cryptography;

namespace Portfolio
{
    public partial class Authenticate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uid"] == null)
            {
                if (IsPostBack)
                {
                    //validate login
                    dataClassesDataContext d = new dataClassesDataContext();
                    IQueryable<User> users = from User user in d.Users
                                             where user.uname == uname.Text
                                             select user;
                    
                    if (users.Count() != 1)
                    {
                        err.Text = "Username or password incorrect";
                        return;
                    }
                    User authenticatingUser = users.First();
                    if (authenticatingUser.pswHash == Hash(authenticatingUser.pswSalt, password.Text))
                    {
                        //logged in
                        Session["uid"] = authenticatingUser.id;
                        //redirect
                        Response.Redirect("/");
                    }
                    else
                    {
                        err.Text = "Username or password incorrect";
                        return;
                    }
                }
                //show the login page

            } else
            {
                //user is already logged in, so log them out.
                Session["uid"] = null;
            }
        }

        public static string Hash(string salt, string pass)
        {
           SHA1 hasher=SHA1.Create();
           
            string concat=salt+pass;
            byte[] bytes=new byte[concat.Length];

            for (int i = 0; i < concat.Length; i++)
                bytes[i] = (byte)concat[i];

            byte[] output = hasher.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in output)
                hash += (char)b;
            return hash;
        }
    }
}