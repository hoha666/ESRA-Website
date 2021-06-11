using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;
using Esra.WebUI.Common;

namespace Esra.WebUI.admin
{
    public partial class ConsultationManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
                btnCancelAddAnswer.Visible = false;

            }
        }
        protected void btnAddAnswer_OnServerClick(object sender, EventArgs e)
        {
            string id = hfselectedQuestionForAnswer.Value;
            Tbl_Question question = new Tbl_Question
            {
                Answer = txtAnswer.Text,
                AnswerDateTime = DateTime.Now
            };
            Tbl_Question resulUpdate = busTbl_Question.UpdateQuestionsById(id, question);
            if (resulUpdate != null && resulUpdate.ID > 0)
            {
                Common.UICommon.Sendmail2(resulUpdate.senderEmail, "نتیجه مشاوره", $"مشاوره با موفقیت انجام شد\r\nنتیجه مشاوره:\r\n{resulUpdate.Answer}");
                UICommon.Message message = new UICommon.Message();
                message.Sender = "10008008800888";
                message.Receptor = resulUpdate.senderMobile;
                message.Text = $"به مشاوره شما با کد رهگیری {resulUpdate.TrackingCode} در سایت اسرا پاسخ داده شده است.";
                string ApiKey = "7732413959694F6845484961497662676F796B7146413D3D";


                com.kavenegar.api.v1 client = new com.kavenegar.api.v1();
                int statusCode = 0;
                string statusMessage = "";
                string[] receptors = message.Receptor.Split(',');
                var result = client.SendSimpleByApikey(ApiKey, message.Sender, message.Text, receptors, 0, 0, ref statusCode, ref statusMessage);
            }
            Response.Redirect("ConsultationManager.aspx");
        }
        private void BindGridView()
        {
            List<Tbl_Question> questions = busTbl_Question.GetAllQuestions();
            if (questions.Any())
            {
                gvConsultationList.DataSource = questions;
                gvConsultationList.DataBind();
                gvConsultationList.UseAccessibleHeader = true;
                gvConsultationList.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            else
            {
                gvConsultationList.Columns.Clear();
                DataTable dt = new DataTable();
                DataRow dr = null;
                dt.Columns.Add(new DataColumn("Col1", typeof(string)));
                dr = dt.NewRow();
                dr["Col1"] = "رکوردی برای نمایش وجود ندارد";
                dt.Rows.Add(dr);
                gvConsultationList.DataSource = dt;
                gvConsultationList.DataBind();
            }
        }

        protected void gvConsultationList_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            string id = gvConsultationList.Rows[e.NewEditIndex].Cells[0].Text; //cells 0 mean id

            Tbl_Question question = busTbl_Question.GetQuestionsById(id);
            if (question != null && question.ID > 0)
            {
                lblSenderInfo.Text = $"آقا/خانم {question.senderFullName} با شماره موبایل {question.senderMobile} و ایمیل {question.senderEmail} پرسیده اند:";
                lblQuestion.Text = question.senderQuestion;
                txtAnswer.Text = question.Answer;
                btnCancelAddAnswer.Visible = true;
                hfselectedQuestionForAnswer.Value = id;
                gvConsultationList.DataSource = null;
                gvConsultationList.DataBind();
            }

        }

        protected void btnCancelAddAnswer_OnServerClick(object sender, EventArgs e)
        {
            Response.Redirect("ConsultationManager.aspx");

        }
    }
}