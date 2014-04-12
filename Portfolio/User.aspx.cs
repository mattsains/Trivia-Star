using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class User1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* try //keep quiet about errors since they're probably all input errors
            {*/
                int uid = int.Parse(Request["uid"]);

                dataClassesDataContext d = new dataClassesDataContext();

                User user = (from User u in d.Users
                             where u.id == uid
                             select u).First();

                name.InnerText = user.firstName + " " + user.lastName;
                uname.InnerText = user.uname;
                if (user.Scores.Count == 0)
                    percent.InnerText = "No accuracy data available";
                else
                    percent.InnerText = Math.Round(user.Scores.Average(score => score.correct ? 1.0 : 0) * 10000) / 100 + "% Accuracy";

                count.InnerText="Correctly answered "+(from Score s in user.Scores where s.correct select s).Count()+
                                " out of "+(from Score s in user.Scores select s).Count()+" questions";
                var worst = from Score s in user.Scores
                            group s by s.Question into grouped
                            orderby grouped.Average(score => score.correct ? 1.0 : 0)
                            select grouped;

                foreach (var s in worst.Take(10))
                {
                    worstlist.Items.Add(s.Key.question1 + " (" + Math.Round(s.Average(score => score.correct ? 1.0 : 0)*1000)/10+"%)");
                }
                                         
           /* }
            catch { Response.StatusCode = 404; }*/
        }
    }
}