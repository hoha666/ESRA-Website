using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Esra.COMMON;
using Esra.Dal;

namespace Esra.BUSINESS
{
    public class busTbl_Question
    {
        public static List<Tbl_Question> GetAllQuestions()
        {
            return dalTbl_Question.GetAllQuestions();

        }

        public static Tbl_Question UpdateQuestionsById(string id, Tbl_Question question)
        {
            return  dalTbl_Question.UpdateQuestionsById(id, question);
        }
        public static Tbl_Question GetQuestionsByTrackingCode(string trackingCode)
        {
            return dalTbl_Question.GetQuestionsByTrackingCode(trackingCode);
        }

        public static Tbl_Question GetQuestionsById(string ID)
        {
            return dalTbl_Question.GetQuestionsById(ID);

        }
        public static int InsertOne_Question(Tbl_Question tblQuestion)
        {
            return dalTbl_Question.InsertOne_Question(tblQuestion);

        }
    }
}
