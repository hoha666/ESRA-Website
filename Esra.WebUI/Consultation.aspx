<%@ Page Title="" Language="C#" MasterPageFile="~/Consultation.master" AutoEventWireup="true" CodeBehind="Consultation.aspx.cs" Inherits="Esra.WebUI.Consultation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <link href="/CSS/news.css" rel="stylesheet" />
    <link href="/CSS/Consultation-responsive.css" rel="stylesheet" />
    <style>
        .text {
            border: 1px solid gainsboro;
            -ms-border-radius: 2px;
            border-radius: 5px;
            height: 25px;
            margin: 10px 10px;
            font-family: iransanslight;
            padding: 5px;
        }

            .text:focus {
                border: 1px solid rgb(184, 184, 184);
                outline: none;
            }

        .wid30 {
            width: calc(100% / 3 - 35px);
        }

        .wid100 {
            width: calc(100% - 35px);
            max-width: calc(100% - 35px);
        }

        .hei1 {
            min-height: 150px;
        }

        ::-webkit-input-placeholder { /* Chrome/Opera/Safari */
            color: darkgrey;
        }

        ::-moz-placeholder { /* Firefox 19+ */
            color: darkgrey;
        }

        :-ms-input-placeholder { /* IE 10+ */
            color: darkgrey;
        }

        :-moz-placeholder { /* Firefox 18- */
            color: darkgrey;
        }

        .btnGreen {
            background-color: #1fb25a;
            border: 1px solid white;
            border-radius: 3px;
            margin: 3px;
            width: 95%;
            height: 30px;
            font-family: inherit;
            color: white;
            cursor: pointer;
        }

            .btnGreen:focus {
                outline: none;
                background-color: #0d9243;
                border: 1px solid;
            }

        .btnGreenContainer {
            border-radius: 3px;
            background-color: #1fb25a;
            width: 120px;
            display: inline-block;
        }

            .btnGreenContainer.contCent {
                display: block;
            }

        .answereBox {
            border: 1px solid gainsboro;
            line-height: 30px;
            height: auto;
            display: inline-block;
            color: black;
            font-family: iransansBold;
        }

            .answereBox .wid30 {
                width: calc(100% / 3);
            }

        .greenP {
            color: #1fb25a;
        }

        .redP {
            color: #cc2127;
        }

        .answerCode {
            padding: 10px 25px;
            border: 1px solid #1fb25a;
            border-radius: 3px;
            display: block;
            margin: 10px auto;
            width: 100px;
            font-size: 15px;
        }

        .answerTitle {
            padding: 5px;
            margin: 10px 5px 10px 0px;
            display: block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
    <div class="f7f7f7 width100 height9 ">
        <div class="width1000 contCent">
            <asp:Panel runat="server" ID="pnlNewQuestion" ClientIDMode="Static">
                <div class="divLastGameRateTitle">
                    <div class="DivTag2"></div>
                    <div class="DivTag">
                        <p>
                            <a>جواب سوال</a>
                        </p>
                    </div>
                </div>
                <div class="width800 contCent">
                    <asp:TextBox runat="server" CssClass="text wid30" placeholder="کد سوال را وارد نمایید" ID="txtTrackingCode"></asp:TextBox>
                    <div class="btnGreenContainer ">
                        <asp:Button CssClass="btnGreen" runat="server" Text="دریافت پاسخ" ID="btnGetAnswer" OnClick="btnGetAnswer_OnClick" />
                    </div>
                </div>
                <div class="divLastGameRateTitle">
                    <div class="DivTag2"></div>
                    <div class="DivTag">
                        <p>
                            <a>سوال جدید</a>
                        </p>
                    </div>
                </div>
                <div class="width800 contCent">
                    <asp:TextBox runat="server" CssClass="text wid30" placeholder="نام و نام خانوادگی" ID="txtNameFamily"></asp:TextBox>
                    <asp:TextBox runat="server" CssClass="text wid30" placeholder="ایمیل" ID="txtEmail"></asp:TextBox>
                    <asp:TextBox runat="server" CssClass="text wid30" placeholder="شماره تماس" ID="txtMobile"></asp:TextBox>
                    <asp:TextBox runat="server" CssClass="text wid100 hei1" TextMode="MultiLine" ID="txtQuestion" placeholder="سوال مورد نظر را بنویسید"></asp:TextBox>
                    <br />
                    <div class="btnGreenContainer contCent">
                        <asp:Button CssClass="btnGreen" runat="server" Text="ارسال" ID="btnSendQuestion" OnClick="btnSendQuestion_OnClick" />
                    </div>
                </div>
                <br />
                <br />
                <br />
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlRecivedQuestion" ClientIDMode="Static">
                <br />
                <br />
                <div class="width800 contCent">
                    <p class="greenP center answerTitle">سوال با موفقیت ارسال شد</p>
                    <div class="text wid100 answereBox center">
                        <asp:Label runat="server" class=" wid30  flR" ID="lblFullName"></asp:Label>
                        <asp:Label runat="server" class=" wid30  flR" ID="lblEmail"></asp:Label>
                        <asp:Label runat="server" class=" wid30  flR" ID="lblMobile"></asp:Label>
                    </div>
                    <asp:Label runat="server" TextMode="MultiLine" CssClass="text wid100 answereBox clb" ID="lblQuestion"></asp:Label>
                    <p class="greenP center answerTitle">کد سوال شما</p>
                    <asp:Label runat="server" class="answerCode center greenP" ID="lblTrackingCode"></asp:Label>
                </div>
                <br />
                <br />
                <br />
                <br />
            </asp:Panel>
            <asp:Panel runat="server" ID="pnlAnswer" ClientIDMode="Static">
                <br />
                <br />

                <div class="width800 contCent">
                    <p class="greenP center answerTitle">جواب سوال</p>
                    <asp:Label runat="server" class="answerCode center greenP" ID="lblTrackingCode2"></asp:Label>
                    <div class="text wid100 answereBox center">
                        <asp:Label runat="server" class=" wid30  flR" ID="lblFullName2"></asp:Label>
                        <asp:Label runat="server" class=" wid30  flR" ID="lblEmail2"></asp:Label>
                        <asp:Label runat="server" class=" wid30  flR" ID="lblMobile2"></asp:Label>


                    </div>
                    <asp:Label runat="server" TextMode="MultiLine" CssClass="text wid100 answereBox clb" ID="lblQuestion2"></asp:Label>

                    <asp:Label runat="server" CssClass="redP answerTitle" ID="lblHaveNotAnswer">جواب آماده نیست</asp:Label>
                    <asp:Label runat="server" CssClass="greenP answerTitle" ID="lblHaveAnswer">جواب سوال شما</asp:Label>
                    <asp:Label runat="server" TextMode="MultiLine" CssClass="text wid100 answereBox clb" ID="lblAnswer"></asp:Label>
                </div>
            </asp:Panel>
        </div>
    </div>
    <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">
    
    <script>

        $(document).ready(function () {
            var hash = $(location).attr('hash').replace('#+', '');
            if (hash !== '')
                $('[href="' + hash + '"]').click();
            console.log(hash);

        });

    </script>
</asp:Content>
