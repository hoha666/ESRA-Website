using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Esra.BUSINESS;
using Esra.COMMON;
using Esra.WebUI.Common;

namespace Esra.WebUI
{
    public partial class Consultation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pnlNewQuestion.Visible = true;
                pnlAnswer.Visible = false;
                pnlRecivedQuestion.Visible = false;
            }

        }

        protected void btnSendQuestion_OnClick(object sender, EventArgs e)
        {
            string cTrackingCode = myCommon.RandomString(10);
            Tbl_Question question = new Tbl_Question
            {
                CreateDateTime = DateTime.Now,
                TrackingCode = cTrackingCode,
                senderEmail = txtEmail.Text,
                senderFullName = txtNameFamily.Text,
                senderMobile = txtMobile.Text,
                senderQuestion = txtQuestion.Text
            };
            int questionId = busTbl_Question.InsertOne_Question(question);
            if (questionId > 0)
            {
                pnlNewQuestion.Visible = false;
                pnlRecivedQuestion.Visible = true;
                lblFullName.Text = txtNameFamily.Text;
                lblEmail.Text = txtEmail.Text;
                lblMobile.Text = txtMobile.Text;
                lblQuestion.Text = txtQuestion.Text;
                lblTrackingCode.Text = cTrackingCode;
                Common.UICommon.Sendmail2(txtEmail.Text, "دریافت مشاوره", $"سوال مشاوره شما با موفقیت دریافت شد\r\nسوال پرسیده شده:\r\n{txtQuestion.Text}\r\nکدرهگیری:{cTrackingCode}");



                UICommon.Message message = new UICommon.Message();
                message.Sender = "10008008800888";
                message.Receptor = txtMobile.Text;
                message.Text = $"مشاوره شما با موفقیت دریافت شد\r\nکد رهگیری:{cTrackingCode}";
                string ApiKey = "5A664F51754D436F37574263434D704F5A2B762B42413D3D";


                com.kavenegar.api.v1 client = new com.kavenegar.api.v1();
                int statusCode = 0;
                string statusMessage = "";
                string[] receptors = message.Receptor.Split(',');
                var result = client.SendSimpleByApikey(ApiKey, message.Sender, message.Text, receptors, 0, 0, ref statusCode, ref statusMessage);

            }
        }

        protected void btnGetAnswer_OnClick(object sender, EventArgs e)
        {
            string cTrackingCode = txtTrackingCode.Text.Trim();
            Tbl_Question Question = busTbl_Question.GetQuestionsByTrackingCode(cTrackingCode);
            if (Question != null && Question.ID > 0)
            {
                pnlNewQuestion.Visible = false;
                pnlAnswer.Visible = true;
                lblTrackingCode2.Text = Question.TrackingCode;
                lblFullName2.Text = Question.senderFullName;
                lblEmail2.Text = Question.senderEmail;
                lblMobile2.Text = Question.senderMobile;
                lblQuestion2.Text = Question.senderQuestion;

                if (!string.IsNullOrEmpty(Question.Answer))
                {
                    lblAnswer.Text = Question.Answer;
                    lblHaveAnswer.Visible = true;
                    lblHaveNotAnswer.Visible = false;
                }
                else
                {
                    lblAnswer.Visible = false;
                    lblHaveAnswer.Visible = false;
                    lblHaveNotAnswer.Visible = true;
                }

            }
        }
    }
}