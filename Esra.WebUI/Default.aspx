        <%@ Page Title="" Language="C#" MasterPageFile="~/first.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Esra.WebUI.Default1" %>

        <asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server"></asp:Content>
        <asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
            <link href="/CSS/template.css" rel="stylesheet" />
            <link href="/CSS/responsive.css" rel="stylesheet" />

            <style>
                .modal-window {
                    position: fixed;
                    background-color: rgba(255, 255, 255, 0.25);
                    /*background-color: #008000;*/
                    top: 0;
                    right: 0;
                    bottom: 0;
                    left: 0;
                    z-index: 999;
                    visibility: hidden;
                    opacity: 0;
                    pointer-events: none;
                    transition: all 0.3s;
                }

                    .modal-window:target {
                        visibility: visible;
                        opacity: 1;
                        pointer-events: auto;
                    }

                    .modal-window > div {
                        width: 400px;
                        position: absolute;
                        top: 50%;
                        left: 50%;
                        -webkit-transform: translate(-50%, -50%);
                        transform: translate(-50%, -50%);
                        padding: 2em;
                        background: #40a040;
                        line-height: 1em;
                    }

                    .modal-window header {
                        font-weight: bold;
                    }

                    .modal-window h1 {
                        font-size: 150%;
                        margin: 0 0 15px;
                    }

                .modal-close {
                    color: #fff;
                    line-height: 50px;
                    font-size: 1.5em;
                    /*position: absolute;*/
                    right: 0;
                    text-align: center;
                    top: 0;
                    width: 70px;
                    text-decoration: none;
                }

                    .modal-close:hover {
                        color: black;
                    }

                /* Demo Styles */
                .btn {
                    background-color: #fff;
                    text-decoration: none;
                    float: right;
                    /*margin: 20px 0px 0px 5px;*/
                    line-height: 15px;
                    min-width: 150px;
                    max-width: 150px;
                }

                    .btn i {
                        padding-right: 0.3em;
                    }

                .jizpalavak {
                    font-size: 1.1em;
                }
            </style>
            <style>
                /** {
                    box-sizing: border-box;
                }*/

                /* Create three equal columns that floats next to each other */
                .hcolumn {
                    float: right;
                    width: 33.33%;
                    /*padding: 10px;*/
                    box-sizing: border-box;
                }

                /* Clear floats after the columns */
                .hrow:after {
                    content: "";
                    display: table;
                    clear: both;
                    box-sizing: border-box;
                }
            </style>
            <style>
                .switch {
                    position: relative;
                    display: inline-block;
                    width: 60px;
                    height: 34px;
                }

                    .switch input {
                        opacity: 0;
                        width: 0;
                        height: 0;
                    }

                .slider {
                    position: absolute;
                    cursor: pointer;
                    top: 0;
                    left: 0;
                    right: 0;
                    bottom: 0;
                    background-color: #ccc;
                    -webkit-transition: .4s;
                    transition: .4s;
                }

                    .slider:before {
                        position: absolute;
                        content: "";
                        height: 26px;
                        width: 26px;
                        left: 4px;
                        bottom: 4px;
                        background-color: white;
                        -webkit-transition: .4s;
                        transition: .4s;
                    }

                input:checked + .slider {
                    background-color: #2196F3;
                }

                input:focus + .slider {
                    box-shadow: 0 0 1px #2196F3;
                }

                input:checked + .slider:before {
                    -webkit-transform: translateX(26px);
                    -ms-transform: translateX(26px);
                    transform: translateX(26px);
                }

                /* Rounded sliders */
                .slider.round {
                    border-radius: 34px;
                }

                    .slider.round:before {
                        border-radius: 50%;
                    }
            </style>
        </asp:Content>
        <asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server"></asp:Content>
        <asp:Content ID="Content6" ContentPlaceHolderID="ContentPlaceHolderBlackBar" runat="server"></asp:Content>
        <asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
            <div class="f7f7f7 width100 height3 shadow1">
                <div class="dviSearch ffffff">
                    <div class="hamburger hamburger--collapse hamburgerSearch">
                        <div class="hamburger-box">
                            <div class="hamburger-inner"></div>
                        </div>
                    </div>
                    <asp:Panel runat="server" DefaultButton="btnSearch">
                        <div class="SubSearch">
                            <div class="select">
                                <div class="c_select">
                                    <option>سبک بازی</option>
                                    <div class="js-open-drop" runat="server" id="ddlGenres">
                                    </div>

                                </div>
                            </div>
                            <div class="select">
                                <div class="c_select">
                                    <option>رده سنی</option>
                                    <div class="js-open-drop" runat="server" id="ddlAges">
                                    </div>
                                </div>
                            </div>
                   <%--         <div class="select">
                                <div class="c_select">
                                    <option>نوع بازی</option>
                                    <asp:DropDownList ID="DropDownList12" runat="server" AutoPostBack="true" SelectionMode="Multiple">
                                        <asp:ListItem Text="Please Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="One" Value="1"></asp:ListItem>
                                        <asp:ListItem Text="Two" Value="2"></asp:ListItem>
                                    </asp:DropDownList>
                                      <div class="js-open-drop" runat="server" id="ddlKind">
                                        <option id="1">تلفن همراه</option>
                                        <option id="2">رایانه و کنسول</opt
                                    </div>
                                </div>
                            </div>--%>

                            <div class="select" style="display: block" id="gplatform">
                                <div class="c_select">
                                    <option>پلتفرم بازی</option>
                                    <div class="js-open-drop" runat="server" id="ddlGamePlatform">
                                    </div>
                                </div>
                            </div>
                            <p>نام بازی</p>
                            <asp:TextBox type="text" runat="server" ID="txtSearchGameName" />

                            <div class="round-button">
                                <asp:LinkButton runat="server" ID="btnSearch" OnClick="btnSearch_OnClick">
                                    <div class="round-button-circle"></div>
                                </asp:LinkButton>

                            </div>
                        </div>
                    </asp:Panel>
                </div>
            </div>
            <br />
            <div class="ffffff width100 height4 shadow1">
                <div class="width1000 contCent">
                    <a href="ages.aspx#+18">
                        <div class="cartRed18 _4881"></div>
                    </a>
                    <a href="ages.aspx#+15">
                        <div class="cartOrang15 _4881"></div>
                    </a>
                    <a href="ages.aspx#+12">
                        <div class="cartOrang12 _4881"></div>
                    </a>
                    <a href="ages.aspx#+7">
                        <div class="cartGreen7 _4881"></div>
                    </a>
                    <a href="ages.aspx#+3">
                        <div class="cartGreen3 _4881"></div>
                    </a>
                </div>
            </div>
            <div class="f7f7f7 width100 height5">
                <div class="width1000 contCent height100">
                    <div class="divLastGameRateTitle">
                        <div class="DivTag2"></div>
                        <div class="DivTag">
                            <p>
                                <a href="ratingGameResults.aspx?s=LastGame">آخرین بازی های رده بندی شده</a>
                            </p>
                        </div>
                    </div>
                    <section runat="server" id="secLast4RatedGame"></section>
                    <section runat="server" id="secLast3GameNews"></section>
                    <%--            <div class="divMoreNews clb">--%>
                    <%--                <a href="#">بیشتر</a>--%>
                    <%--            </div>--%>
                </div>
            </div>
            <div class="e1e1e1 width100 height6">
                <div class="width1000 contCent height6">
                    <a href="signs.aspx#دخانیات" class="divCart cart1 data-tilt2"></a>
                    <a href="signs.aspx#مهارت_بازی" class="divCart cart2 data-tilt2"></a>
                    <a href="signs.aspx#ترس" class="divCart cart3 data-tilt2"></a>
                    <a href="signs.aspx#خشونت" class="divCart cart4 data-tilt2"></a>
                    <a href="signs.aspx#ناهنجاری_اجتماعی" class="divCart cart5 data-tilt2"></a>
                    <a href="signs.aspx#یاس_ناامیدی" class="divCart cart6 data-tilt2"></a>
                </div>
            </div>
            <div class="f7f7f7 width100 height7"></div>
            <div class="ffffff width100 height8 shadow1">
                <div class="width1000 contCent" runat="server" id="gameIntro">
                </div>
            </div>
            <div class="f7f7f7 width100 height9 shadow1">
                <div class="width1000 contCent DivAboutEsra">
                    <p>درباره ESRA</p>

                    <p>
                        از ابتدای تاسیس بنیاد ملی بازی های رایانه ای در سال 1386، تدوین نظامی با عنوان نظام ملی رده بندی سنی بازی های رایانه ای(Entertainment Software Rating Association) در دستور کار قرار گرفت که وظیفه آن نظارت بر محتوای بازی ها و مشخص کردن رده سنی مناسب برای هر بازی بود. در همین راستا در سال 1387 پژوهشهایی با سه رویکرد مطالعاتی از جمله روانشناسی، جامعه شناسی و علوم و معارف اسلامی با همکاری اساتید مجرب دانشگاهی انجام شد. پس از انجام پژوهش ها و طبقه بندی محتواهای آسیب رسان در بازی ها، نظام رده بندی سنی کار اجرایی خود را از ابتدای سال 88 آغاز نمود و از آن پس صدور مجوز نشر بازی ها منوط به بررسی بازی ها در این نظام و تعیین رده سنی مناسب هر یک از بازی ها شد.           
                    </p>
                    <p>
                        عدم وجود الگوی مناسب در استفاده از بازيها، نگرانی والدین و عدم اطلاع آنها از محتواهای نامناسب این رسانه جدید تعاملی، تأثیرات سوء جسمانی و روانی بازی‌های رایانه‌ای و همچنین استفاده هژمونیک نظام سرمایه‌داری از بازی‌ها در جهت تاثیرگذاری فرهنگی-اجتماعی را میتوان از مهمترین عوامل ضرورت ایجاد نظام ESRA دانست.
                    </p>
                </div>
                <div class="auLogo">
                    <img src="IMG/auLogo.png">
                </div>
            </div>
        </asp:Content>
        <asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">
            <script src="/COMPONENT/tilt.js-master/src/tilt.jquery.js"></script>
            <script type="text/javascript">
                (function () {
                    var now = new Date();
                    var version = now.getFullYear().toString() + "0" + now.getMonth() + "0" + now.getDate() +
                        "0" + now.getHours();

                    var head = document.getElementsByTagName("head")[0];

                    var link = document.createElement("link");
                    link.rel = "stylesheet";
                    link.href = "https://app.najva.com/static/css/local-messaging.css" + "?v=" + version;
                    head.appendChild(link);

                    var script = document.createElement("script");
                    script.type = "text/javascript";
                    script.async = true;
                    script.src = "https://app.najva.com/static/js/scripts/ircg-website-9071-03914613-0623-4837-a1dd-a6b5ef3d7a9a.js" + "?v=" + version;
                    head.appendChild(script);
                })()
            </script>
            <asp:HiddenField runat="server" Value="0" ID="hfSearchGenres" />
            <asp:HiddenField runat="server" Value="0" ID="hfSearchAges" />
            <asp:HiddenField runat="server" Value="0" ID="hfSearchPlatform" />
            <asp:HiddenField runat="server" Value="0" ID="hfSearchKind" OnValueChanged="hfSearchKind_ValueChanged" />

        </asp:Content>
