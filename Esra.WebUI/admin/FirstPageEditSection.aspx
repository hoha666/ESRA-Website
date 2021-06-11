<%@ Page Title="" Language="C#" MasterPageFile="~/admin/a-first.Master" AutoEventWireup="true" CodeBehind="FirstPageEditSection.aspx.cs" Inherits="Esra.WebUI.admin.FirstPageEditSection"  %>

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
                        <h2>اضافه کردن بخش جدید به صفحه اصلی<small>در قسمت سه گانه</small>
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
                        <p>اطلاعات بخش مربوطه را به صورت دقیق در فرم زیر وارد کنید و در نهایت کلید "اضافه کردن بخش" را بزنید.</p>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                عنوان بخش
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewTitle" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                عنوان مطلب
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewTitle2" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                توضیحات
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <div id="txtNewDescrip" class="editor-wrapper" contenteditable="true" runat="server"></div>
                                <asp:HiddenField ID="hfNewDescrip" runat="server" Value="0" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                لینک ادامه مطلب
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtNewContinueLink" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                عکس
                            </label>
                            <div class="col-md-8 col-sm-8 col-xs-12">
                                <asp:FileUpload ID="FileUploadNewImgUrl" runat="server" />
                            </div>
                        </div>
                        <button id="AddPageSection" runat="server" onserverclick="AddPageSection_OnServerClick" type="button" class="btn btn-primary" onclick="setHfNewDescrip();">اضافه کردن بخش</button>

                    </div>
                </div>
            </div>
            <div class="col-md-6 col-sm-6 col-xs-6">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>ویرایش بخش های صفحه اصلی<small>در قسمت سه گانه</small>
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
                                    <p>بخش مورد نظر را از لیست انتخاب کنید</p>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            عنوان بخش
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <asp:DropDownList class="form-control" ID="ddlPageEditSection" AutoPostBack="True" runat="server" OnSelectedIndexChanged="ddlPageEditSection_OnSelectedIndexChanged">
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
                                            عنوان بخش
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtEditTitle" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            عنوان مطلب
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtEditTitle2" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            توضیحات
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <div runat="server" id="txtEditDescrip" class="editor-wrapper" contenteditable="true"></div>
                                            <asp:HiddenField ID="hfEditDescrip" runat="server" Value="0" />

                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            لینک ادامه مطلب
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtEditContinueLink" />
                                        </div>
                                    </div>
<%--                                    <div class="form-group">--%>
<%--                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">--%>
<%--                                            عکس--%>
<%--                                        </label>--%>
<%--                                        <div class="col-md-8 col-sm-8 col-xs-12">--%>
<%--                                            <asp:FileUpload ID="FileUploadEditImgUrl" runat="server" />--%>
<%--                                        </div>--%>
<%--                                    </div>--%>
                                    <button id="EditPageSection" runat="server" onserverclick="EditPageSection_OnServerClick" type="button" class="btn btn-primary" onclick="setHfEditDescrip();">ویرایش بخش</button>
                                    <button id="btnCancelEditing" runat="server" onserverclick="btnCancelEditing_OnServerClick" type="button" class="btn">لغو ویرایش</button>
                                    <button id="btnDeleteEditing" runat="server" onserverclick="btnDeleteEditing_OnServerClick" type="button" class="btn">حذف</button>
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
    <script>
        function setHfNewDescrip() { $('#cpBodyMiddle_hfNewDescrip').val($('#cpBodyMiddle_txtNewDescrip').html()) }
        function setHfEditDescrip() { $('#cpBodyMiddle_hfEditDescrip').val($('#cpBodyMiddle_txtEditDescrip').html()) }

        $(document).ready(function() {
            $('#sidebar-menu > div > ul > li.active > ul').slideDown();
            $(document).delegate("a:contains('حذف')", 'click', function () {
                if (confirm('آیا مطمئن هستید می خواهید این بخش را پاک کنید؟')) {
                    return true;
                } else {
                    return false;
                }
            });
        });
    </script>
</asp:Content>
