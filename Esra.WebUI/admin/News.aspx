<%@ Page Title="" Language="C#" MasterPageFile="~/admin/a-first.Master" AutoEventWireup="true" CodeBehind="News.aspx.cs" Inherits="Esra.WebUI.admin.News" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.6.2, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <style>
        .form-group label {
            padding-top: 7px;
        }

        input[type="file"] {
            margin-top: 5px;
        }

        .clt {
            clear: right;
        }

            .clt, .clt ul, .clt li {
                position: relative;
            }

                .clt ul {
                    list-style: none;
                    padding-right: 32px;
                }

                .clt li::before, .clt li::after {
                    content: "";
                    position: absolute;
                    right: -12px;
                }

                .clt li::before {
                    border-top: 1px solid #000;
                    top: 9px;
                    width: 8px;
                    height: 0;
                }

                .clt li::after {
                    border-left: 1px solid #000;
                    height: 100%;
                    width: 0px;
                    top: 2px;
                }

                .clt ul > li:last-child::after {
                    height: 8px;
                }

        .js-select-tag {
            cursor: pointer;
        }

        .js-selected-tag {
            color: black;
            background-color: #dddddd;
            -ms-border-radius: 2px;
            border-radius: 2px;
            padding: 0px 5px;
            margin: 1px 0px 1px 0px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
    <div class="">
        <div class="row">
            <div class="col-md-6 col-sm-6 col-xs-6">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>اضافه کردن خبر جدید<small>در صفحه اصلی و صفحه اخبار</small>
                        </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li>
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu" role="menu">
                                    <li>
                                        <a href="#">Settings 1</a>
                                    </li>
                                    <li>
                                        <a href="#">Settings 2</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a class="close-link">
                                    <i class="fa fa-close"></i>
                                </a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <p>اطلاعات اخبار جدید را به صورت دقیق در فرم زیر وارد کنید و در نهایت کلید "اضافه کردن خبر" را بزنید.</p>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                عنوان خبر
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsTitle" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                مقدمه
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsIntro" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                متن خبر
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <CKEditor:CKEditorControl ID="txtNewsContent" runat="server" ClientIDMode="Static" />

                                <%--<div class="editor-wrapper" contenteditable="true" runat="server" id="txtNewsContent"></div>--%>
                                <asp:HiddenField ID="hfNewsContent" runat="server" Value="0" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                نویسنده
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsAuther" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                تگ خبر
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input id="tags_1" type="text" class="tags form-control" value="" />
                                <asp:HiddenField ID="hfNewsTag" runat="server" Value="0" />
                            </div>
                        </div>
                        <%--                        <div class="form-group">--%>
                        <%--                            <label class="control-label col-md-3 col-sm-3 col-xs-6">--%>
                        <%--                                گروه خبری--%>
                        <%--                            </label>--%>
                        <%--                            <div class="col-md-8 col-sm-8 col-xs-12">--%>
                        <%--                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsCategoryID" />--%>
                        <%--                            </div>--%>
                        <%--                        </div>--%>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                گروه خبری
                            </label>
                            <div runat="server" id="NewsCategoryList" class="clt"></div>
                            <asp:HiddenField ID="hfNewsCategoryList" runat="server" Value="0" />

                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                لینک ادامه خبر
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsLink" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                عکس
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:FileUpload runat="server" ID="fileUploadPicture" />
                            </div>
                        </div>

                        <button runat="server" onclick="setHfNew();" type="button" class="btn btn-primary" id="btnAddNewNews" onserverclick="btnAddNewNews_OnServerClick">اضافه کردن خبر</button>

                    </div>
                </div>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-6">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>ویرایش خبر قدیمی<small>در صفحه اصلی و صفحه اخبار</small>
                        </h2>
                        <ul class="nav navbar-right panel_toolbox">
                            <li>
                                <a class="collapse-link">
                                    <i class="fa fa-chevron-up"></i>
                                </a>
                            </li>
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-expanded="false">
                                    <i class="fa fa-wrench"></i>
                                </a>
                                <ul class="dropdown-menu" role="menu">
                                    <li>
                                        <a href="#">Settings 1</a>
                                    </li>
                                    <li>
                                        <a href="#">Settings 2</a>
                                    </li>
                                </ul>
                            </li>
                            <li>
                                <a class="close-link">
                                    <i class="fa fa-close"></i>
                                </a>
                            </li>
                        </ul>
                        <div class="clearfix"></div>
                    </div>
                    <div class="x_content">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <section runat="server" id="secSelectPageForEdit">
                                    <p>خبر مورد نظر را از لیست انتخاب کنید</p>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            عنوان خبر
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <asp:DropDownList class="form-control" AutoPostBack="True" runat="server" ID="ddlNewsList" OnSelectedIndexChanged="ddlNewsList_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </section>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <section runat="server" id="secEditControls" visible="False">
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            عنوان خبر
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsEditTitle" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            مقدمه
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsEditIntro" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            متن خبر
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <CKEditor:CKEditorControl ID="txtNewsEditContent" runat="server" ClientIDMode="Static" />

                                            <%--<div class="editor-wrapper" contenteditable="true" runat="server" id="txtNewsEditContent"></div>--%>
                                            <asp:HiddenField runat="server" Value="0" ID="hfNewsEditContent" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            نویسنده
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsEditAuther" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            تگ خبر
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsEditTag" />
                                        </div>
                                    </div>
                                    <%--                                    <div class="form-group">--%>
                                    <%--                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">--%>
                                    <%--                                            گروه خبری--%>
                                    <%--                                        </label>--%>
                                    <%--                                        <div class="col-md-8 col-sm-8 col-xs-12">--%>
                                    <%--                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsEditCategoryID" />--%>
                                    <%--                                        </div>--%>
                                    <%--                                    </div>--%>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            لینک ادامه خبر
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewsEditLink" />
                                        </div>
                                    </div>
                                    <%--                                    <div class="form-group">--%>
                                    <%--                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">--%>
                                    <%--                                            عکس--%>
                                    <%--                                        </label>--%>
                                    <%--                                        <div class="col-md-8 col-sm-8 col-xs-12">--%>
                                    <%--                                            <asp:FileUpload runat="server" ID="fileUploadEditPicture" />--%>
                                    <%--                                        </div>--%>
                                    <%--                                    </div>--%>
                                    <button onclick="setHfEdit();" id="EditNews" runat="server" type="button" class="btn btn-primary" onserverclick="EditNews_OnServerClick">ویرایش خبر</button>
                                    <button id="btnCancelNews" runat="server" type="button" class="btn" onserverclick="btnCancelNews_OnServerClick">لغو ویرایش</button>
                                    <button id="btnDeleteNews" runat="server" type="button" class="btn" onserverclick="btnDeleteNews_OnServerClick">حذف</button>
                                </section>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">
    <script src="/admin/vendors/jquery.tagsinput/src/jquery.tagsinput.js"></script>
    <script>
        function setHfNew() {
            $('#cpBodyMiddle_hfNewsContent').val($('#cpBodyMiddle_txtNewsContent').text());
            var tag = "";
            jQuery.each($('#tags_1_tagsinput .tag span'), function () {
                tag += $(this).text() + ",";
            });
            $('#cpBodyMiddle_hfNewsTag').val(tag.replace("  ,", ","));

            var newsCategoryList = "";
            jQuery.each($('.js-selected-tag'), function () {
                newsCategoryList += $(this).attr('id') + ",";
            });
            $('#cpBodyMiddle_hfNewsCategoryList').val(newsCategoryList.replace("  ,", ","));
            console.log(newsCategoryList);


        }
        function setHfEdit() {
            $('#cpBodyMiddle_hfNewsEditContent').val($('#cpBodyMiddle_txtNewsEditContent').text());

        }
        $(document).ready(function () {
            $('.clt .js-select-tag').on('click', function () {
                $(this).toggleClass('js-selected-tag');
            });
        });
    </script>
</asp:Content>
