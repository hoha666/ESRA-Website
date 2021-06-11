<%@ Page Title="" Language="C#" MasterPageFile="~/first.Master" AutoEventWireup="true" CodeBehind="CMSPages.aspx.cs" Inherits="Esra.WebUI.CMSPages" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <link href="/CSS/cms.css" rel="stylesheet" />
    <link href="/CSS/responsive.css" rel="stylesheet" />
    <link href="/ckeditor/contents.css" rel="stylesheet" />
    <style>
        body {
            margin: 0px;
        }
        .navTop ul {
            padding: 0;
            border: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
    <div class="ffffff width100  ">
        <div class="width1000 contCent cke_contents_rtl cke_reset_all">
            <div runat="server" id="pageContent"></div>
                
        </div>
    </div>
    <script src="/ckeditor/ckeditor.js"></script>

</asp:Content>

