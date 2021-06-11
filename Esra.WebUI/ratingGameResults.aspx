<%@ Page Title="" Language="C#" MasterPageFile="~/first.Master" AutoEventWireup="true" CodeBehind="ratingGameResults.aspx.cs" Inherits="Esra.WebUI.ratingGameResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <link href="/CSS/result-Template.css" rel="stylesheet" />
    <link href="/CSS/result-responsive.css" rel="stylesheet" />
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
            margin: 20px 0px 0px 5px;
            line-height: 15px;
            min-width: 150px;
            max-width: 150px;
        }

            .btn i {
                padding-right: 0.3em;
            }
        .jizpalavak{
            font-size: 1.1em;
        }
    </style>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
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
    <style>
        .mosha {
            color: blue;
        }

            .mosha:hover {
                cursor: pointer;
            }
    </style>
    <script>
        $(document).ready(function () {
            $('.sort-item').on('click', function () {
                console.log($(this).find('input'));
                $(this).find('input').prop('checked', true);
            });
            $('.c_select option.js-active').parent().parent().css('background-color', '#1fb25a');
        })
        function myFunction(gid) {
            document.getElementById('modal' + gid).style.display = 'block';
        }
    </script>
    <asp:HiddenField runat="server" Value="0" ID="hfSearchGenres" />
    <asp:HiddenField runat="server" Value="0" ID="hfSearchAges" />
    <asp:HiddenField runat="server" Value="0" ID="hfSearchPlatform" />
</asp:Content>
