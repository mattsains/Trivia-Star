using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Web.SessionState;
namespace Portfolio
{
    /// <summary>
    /// Summary description for Question1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
     [System.Web.Script.Services.ScriptService]
    public class Question1 : System.Web.Services.WebService, IRequiresSessionState
    {

        [WebMethod]
        public XMLQuestion GetQuestion()
        {
            dataClassesDataContext d = new dataClassesDataContext();
            var questions = from Question q in d.Questions
                            select q;
            //get a random question
            int skip = new Random().Next(0, questions.Count());
            Question question = questions.Skip(skip).First();

            XMLQuestion output = new XMLQuestion()
            {
                id = question.id,
                text = question.question1,
                image = question.image
            };

            output.answer = question.answer;
            output.wrong1 = question.wrong1;
            output.wrong2 = question.wrong2;
            output.wrong3 = question.wrong3;

            return output;
        }
        [WebMethod]
        public void PostAnswer(int uid, int id, bool answer)
        {
            dataClassesDataContext d = new dataClassesDataContext();

            var users = from User user in d.Users
                        where user.id == uid
                        select user;
            User AuthenticatedUser = users.First();

            var questions = from Question q in d.Questions
                            where q.id == id
                            select q;
            Question question = questions.First();

            Score score = new Score()
            {
                Question = question,
                User = AuthenticatedUser,
                correct = answer
            };
            d.Scores.InsertOnSubmit(score);
            d.SubmitChanges();
        }
    }
    public class XMLQuestion
    {
        public int id;
        public string text;
        public string image;
        public string answer;
        public string wrong1;
        public string wrong2;
        public string wrong3;
    }
}
