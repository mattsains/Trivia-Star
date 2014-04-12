using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portfolio
{
    public partial class Leaderboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dataClassesDataContext d=new dataClassesDataContext();
            var leaders = (from User u in d.Users
                          orderby u.Scores.Average(score => score.correct ? 0 : 1.0 )
                          select u).ToList();

            List<string> entries = new List<string>();
            foreach (User u in leaders)
                if (u.Scores.Count != 0)
                    entries.Add("<a href=\"User.aspx?uid=" + u.id + "\">" + u.firstName + " " + u.lastName + "</a> (" + Math.Round(u.Scores.Average(score => score.correct ? 1 : 0) * 1000) / 10 + "%)");

            leaderboard.DataSource = entries;
            leaderboard.DataBind();
        }
    }
}