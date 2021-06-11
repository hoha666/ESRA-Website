<%@ Page Title="" Language="C#" MasterPageFile="~/first.Master" AutoEventWireup="true" CodeBehind="introGameResults.aspx.cs" Inherits="Esra.WebUI.introGameResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <meta http-equiv="cache-control" content="no-cache" />
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <link href="/CSS/result-Template.css" rel="stylesheet" />
    <link href="/CSS/result-responsive.css" rel="stylesheet" />
    <style>
        .imgbk4 {
            overflow: hidden;
            background-color: #1c1c1c;
        }

            .imgbk4 p {
                height: 100%;
                float: right;
                right: 25%;
                position: relative;
                font-size: 53px;
                padding: 14px;
                color: white;
            }

            .imgbk4 img {
                height: 100%;
                float: left;
                left: 30%;
                position: relative;
            }

        .height99 {
            height: 86px;
        }

        @media only screen and (max-width: 1050px) {
            .imgbk4 img {
                display: none;
            }

            .imgbk4 p {
                float: none;
                right: auto;
            }

            .imgbk4 {
                text-align: center;
            }
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
    <%--    <div class="width100 height99 imgbk4">
        <p></p>
        <img src="/IMG/NewsLogo2.png" alt="Alternate Text">
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
                                <div class="js-open-drop" runat="server" id="ddlCategory"></div>
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
    <div class="height3">
        <div class="width1000 contCent height100">
            <div class="sort">
                <div class="sort-right">
                    <div class="sort-item">
                        نام بازی<input id="chbSortGameName" runat="server" type="radio" name="sort-game" value="" />
                    </div>
                    <div class="sort-item">
                        آخرین بازی<input id="chbSortLastGame" runat="server" type="radio" name="sort-game" value="" />
                    </div>
                    <div class="sort-item">
                        سال انتشار<input id="chbSortGameYear" runat="server" type="radio" name="sort-game" value="" />
                    </div>
                </div>
                <asp:LinkButton ID="btnSort" runat="server" OnClick="btnSort_OnClick">
                    <div class="sort-left">
                        <%--<img src="" alt=""/>--%>
                        <p>مرتب کردن</p>
                    </div>
                </asp:LinkButton>

            </div>
        </div>
    </div>
    <div class="height4">
        <div class="width1000 contCent">
            <div runat="server" id="searchResult"></div>
        </div>
    </div>
    <div class="center">
        <div class="pagination" runat="server" id="pagination"></div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">
    <script src="/COMPONENT/tilt.js-master/src/tilt.jquery.js"></script>
    <asp:HiddenField runat="server" Value="0" ID="hfSearchGenres" />
    <asp:HiddenField runat="server" Value="0" ID="hfSearchAges" />
    <asp:HiddenField runat="server" Value="0" ID="hfSearchPlatform" />
    <asp:HiddenField runat="server" Value="0" ID="hfSearchCategories" />
    <script>
        $(document).ready(function () {

            var platform = getParameterByName('pf');
            if (platform === "8") {
                var tag = $('#cpBodyMiddle_ddlGamePlatform option#8');
                window.showAndroidButton(tag);;
            }
            $('.sort-item').on('click', function () {
                console.log($(this).find('input'));
                $(this).find('input').prop('checked', true);
            });
            $('.c_select option.js-active').parent().parent().css('background-color', '#1fb25a');
        })
    </script>
</asp:Content>
