<%@ Page Title="" Language="C#" MasterPageFile="~/first.Master" AutoEventWireup="true" CodeBehind="introGame.aspx.cs" Inherits="Esra.WebUI.introGame" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <link href="/CSS/result-Template.css" rel="stylesheet" />
    <link href="/CSS/result-responsive.css" rel="stylesheet" />
    <style>
        .height8 {
            margin-top: 50px;
        }

        .height3 {
            height: 86px;
        }

        .divLastGameRateTitle {
            margin-top: 50px;
        }
        /*.gameLargLogo:nth-child(1){ float:right !important;}*/
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
    <%--<div class="width100 height3 imgbk3">
            <p>معرفی بازی</p>
            <img src="/IMG/NewsLogo2.png" alt="Alternate Text" />
        </div>--%>
    <div class="">
        <div class="width1000 contCent">
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
                        <div class="select">
                            <div class="c_select">
                                <option>پلتفرم بازی</option>
                                <div class="js-open-drop js-intro" runat="server" id="ddlGamePlatform">
                                </div>
                            </div>
                        </div>
                        <div class="select js-ddlGameCategory" style="display: none;">
                            <div class="c_select">
                                <option>دسته بندی</option>
                                <div class="js-open-drop" runat="server" id="ddlMobileGameType">
                                    <option id="1">چند نفره</option>
                                    <option id="2">خردسالان</option>
                                    <option id="3">مفید و آموزشی</option>
                                    <option id="4">جذاب و جالب</option>
                                    <option id="5">معمایی و چالش بر انگیز</option>
                                    <option id="6">دفاع مقدس</option>
                                    <option id="7">قرآنی</option>
                                    <option id="8">ایرانی و اسلامی</option>
                                    <option id="9">فوتبالی</option>
                                    <option id="10">ورزشی</option>
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
    </div>
    <div class="ffffff width100 height8 shadow1">
        <div class="width1000 contCent" runat="server" id="gameIntro">
        </div>
    </div>
    <div class="height4">
        <div class="width1000 contCent">
            <div class="divLastGameRateTitle">
                <div class="DivTag2"></div>
                <div class="DivTag">
                    <p>
                        <a href="#" runat="server" id="relatedGameLink">بازی های مشابه</a>
                    </p>
                </div>
            </div>
            <div runat="server" id="searchResult" class="clb"></div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">   
    <asp:HiddenField runat="server" Value="0" ID="hfSearchGenres" />
    <asp:HiddenField runat="server" Value="0" ID="hfSearchAges" />
    <asp:HiddenField runat="server" Value="0" ID="hfSearchPlatform" />
</asp:Content>
