using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;

namespace Esra.Dal
{
    public class dalTbl_Question
    {
        public static List<Tbl_Question> GetAllQuestions()
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_Questions
                             select p).OrderByDescending(q => q.CreateDateTime);
                return query.ToList();
            }
        }

        public static Tbl_Question UpdateQuestionsById(string id, Tbl_Question question)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_Questions
                             where p.ID.ToString() == id
                             select p).SingleOrDefault();
                if (query != null && query.ID > 0)
                {
                    query.Answer = question.Answer;
                    query.AnswerDateTime = question.AnswerDateTime;
                    db.SubmitChanges();
                }
                return query;
            }
        }
        public static Tbl_Question GetQuestionsByTrackingCode(string trackingCode)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_Questions
                             where p.TrackingCode == trackingCode
                             select p).SingleOrDefault();
                return query;
            }
        }
        public static Tbl_Question GetQuestionsById(string ID)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                var query = (from p in db.Tbl_Questions
                             where p.ID.ToString() == ID
                             select p).SingleOrDefault();
                return query;
            }
        }

        public static int InsertOne_Question(Tbl_Question tblQuestion)
        {
            using (DataClassesDataContext db = new DataClassesDataContext())
            {
                Tbl_Question q = new Tbl_Question
                {
                    CreateDateTime = tblQuestion.CreateDateTime,
                    TrackingCode = tblQuestion.TrackingCode,
                    senderEmail = tblQuestion.senderEmail,
                    senderFullName = tblQuestion.senderFullName,
                    senderMobile = tblQuestion.senderMobile,
                    senderQuestion = tblQuestion.senderQuestion
                };
                db.Tbl_Questions.InsertOnSubmit(q);
                db.SubmitChanges();
                return q.ID;
            }
        }
    }
}