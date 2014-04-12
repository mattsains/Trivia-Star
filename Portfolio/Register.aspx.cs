using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Portfolio
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                bool validationErrors = false;

                passworderr.Text = "";
                if (password.Text != password2.Text)
                {
                    validationErrors = true;
                    passworderr.Text = "The passwords do not match";
                }
                else if (password.Text.Length < 4)
                {
                    validationErrors = true;
                    passworderr.Text = "Please enter a password longer than four characters";
                }

                emailerr.Text = "";
                if (!Regex.IsMatch(email.Text, "^.+@.+$"))
                {
                    validationErrors = true;
                    emailerr.Text = "Please enter a valid email";
                }
                dataClassesDataContext d=new dataClassesDataContext();
                //check for uniqueness of username
                var users = from User user in d.Users
                            where user.uname == uname.Text
                            select user.id;
                if (users.Count() != 0)
                {
                    validationErrors = true;
                    unameerr.Text = "That username is taken";
                }

                if (!validationErrors)
                {
                    string salt=MakeSalt();
                    User newUser = new User()
                    {
                        uname = uname.Text,
                        firstName = firstname.Text,
                        lastName = lastname.Text,
                        pswSalt = salt,
                        pswHash = Authenticate.Hash(salt, password.Text),
                        email = email.Text
                    };
                    d.Users.InsertOnSubmit(newUser);
                    d.SubmitChanges();
                    users = from User user in d.Users
                            where user.uname == newUser.uname
                            select user.id;
                    Session["uid"] = users.First();
                    Response.Redirect("/");
                }

            }
        }
        public static string MakeSalt()
        {
            Random r = new Random();
            byte[] bytes = new byte[50];
            r.NextBytes(bytes);
            string output="";
            foreach (byte b in bytes)
                output+=(char)b;
            return output;
        }
    }
}