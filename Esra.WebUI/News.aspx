<%@ Page Title="" Language="C#" MasterPageFile="~/NewsMaster.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Esra.WebUI.News" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <link href="/CSS/news.css" rel="stylesheet" />
    <link href="/CSS/news-responsive.css" rel="stylesheet" />
    <style>
        .height5 {
            min-height: initial;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">

    <asp:Panel runat="server" ID="pnlSingleNews">
        <div class="height5">
            <div class="width1000 contCent">
                <div class="news" runat="server" id="newsRow">
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlAllNews">
        <div class="f7f7f7 width100 height5">
            <div class="width1000 contCent height100">
                <div class="divLastGameRateTitle">
                    <div class="DivTag2"></div>
                    <div class="DivTag">
                        <p>
                            <a href="News.aspx">خبرهای دیگر</a>
                        </p>
                    </div>
                </div>
                <section runat="server" id="secLast3GameNews"></section>
            </div>
        </div>
        <div class="center">
            <div class="pagination" runat="server" id="pagination"></div>
        </div>
    </asp:Panel>


</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">
    <script src="/COMPONENT/tilt.js-master/src/tilt.jquery.js"></script>
    
</asp:Content>
