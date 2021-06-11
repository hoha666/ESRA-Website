<%@ Page Title="" Language="C#" MasterPageFile="~/admin/a-first.Master" AutoEventWireup="true" CodeBehind="PcGameInput.aspx.cs" Inherits="Esra.WebUI.admin.PcGameInput" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.6.2, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <style>
        th {
            text-align: right;
        }

        .modal-header .close {
            margin-top: 3px;
        }

        .modal-body {
            direction: rtl;
        }

        .close {
            float: left;
        }

        .chbox {
            margin-left: 20px;
            margin-bottom: 10px;
        }

        .form-group label {
            padding-top: 7px;
        }

        hr {
            margin-top: 5px;
            margin-bottom: 5px;
        }

        table {
            cursor: default;
        }

        .hiddencol {
            display: none;
        }

        .gameLogo {
            width: 124px;
            height: 90px;
            border-radius: 3px;
        }

        #cpBodyMiddle_pnl_OldPic > .imgContainer:nth-child(1) {
            margin-right: 0px;
        }

        .imgContainer {
            display: inline-block;
            margin: 10px;
            position: relative;
        }

            .imgContainer div {
                position: absolute;
                top: 10px;
                right: 0;
                width: 100%;
            }

                .imgContainer div span {
                    color: white;
                    background: rgb(0, 0, 0); /* fallback color */
                    background: rgba(0, 0, 0, 0.7);
                    padding: 0px 7px;
                    float: right;
                    cursor: pointer;
                }

                    .imgContainer div span:nth-child(2) {
                        float: left;
                        margin-top: 2px;
                        clear: both;
                        direction: ltr;
                        text-align: left;
                        cursor: default;
                        font-size: 9px;
                        -ms-opacity: 0.5;
                        opacity: 0.5;
                        max-width: 122px;
                    }
    </style>
    <link href="/COMPONENT/jQuery.filer-master/css/jquery.filer.css" rel="stylesheet">
    <link href="/COMPONENT/jQuery.filer-master/css/themes/jquery.filer-dragdropbox-theme.css" rel="stylesheet">

    <!-- Datatables -->
    <link href="/admin/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">

    <div class="">
        <img src="/IMG/loading.gif" style="margin: 0 auto; display: block;" class="js-loading" />
        <div class="row js-show-and-edit-form" style="display: none;">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>فرم ورود اطلاعات<small>اطلاعات بازی های PC و کنسولی</small>
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
                        <!-- Smart Wizard -->
                        <p>اطلاعات بازی را مرحله به مرحله در فرم زیر وارد کنید و در نهایت کلید ثبت را بزنید.</p>
                        <div id="wizard" class="form_wizard wizard_horizontal">
                            <ul class="wizard_steps">
                                <li>
                                    <a href="#step-1">
                                        <span class="step_no">1</span>
                                        <span class="step_descr">مرحله اول<br />
                                            <small>اطلاعات کامل</small>
                                        </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#step-2">
                                        <span class="step_no">2</span>
                                        <span class="step_descr">مرحله دوم<br />
                                            <small>افزودن نسخه</small>
                                        </span>
                                    </a>
                                </li>
                                <li>
                                    <a href="#step-3">
                                        <span class="step_no">3</span>
                                        <span class="step_descr">مرحله سوم<br />
                                            <small>تعیین سبک</small>
                                        </span>
                                    </a>
                                </li>
                            </ul>
                            <div id="step-1">
                                <h2 class="StepTitle">مرحله اول</h2>
                                <form class="form-horizontal form-label-left">
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            نام بازی
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtGameName" onkeyup="check_availability()" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            نام دوم بازی
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtGameNameSecond" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            شرکت سازنده
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtComponyCreated" />
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                            سال نشر
                                        </label>
                                        <div class="col-md-8 col-sm-8 col-xs-12">
                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtYearPublished" />
                                        </div>
                                    </div>
                                    <%--                                    <div class="form-group">--%>
                                    <%--                                        <label class="control-label col-md-3 col-sm-3 col-xs-6">--%>
                                    <%--                                            شرکت سازنده--%>
                                    <%--                                        </label>--%>
                                    <%--                                        <div class="col-md-8 col-sm-8 col-xs-12">--%>
                                    <%--                                            <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtInternalPublisher" />--%>
                                    <%--                                        </div>--%>
                                    <%--                                    </div>--%>
                                </form>
                            </div>
                            <div id="step-2">
                                <h2 class="StepTitle">مرحله دوم</h2>
                                <button type="button" class="btn btn-primary js-openVersionDialog" data-toggle="modal" data-target=".bs-example-modal-lg">افزودن نسخه</button>
                                <div class="modal fade bs-example-modal-lg" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog modal-lg">
                                        <div class="modal-content">
                                            <div class="modal-body">
                                                <h4 class="modal-title">اطلاعات اصلی</h4>
                                                <br />
                                                <div class="form-group">
                                                    <label class="control-label col-md-3 col-sm-3 col-xs-4">
                                                        پلتفرم نسخه
                                                    </label>
                                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                                        <select class="form-control" id="platform_ver" runat="server">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-md-3 col-sm-3 col-xs-4">
                                                        نوع سورس
                                                    </label>
                                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                                        <select class="form-control" id="source_type" runat="server">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                                        وضعیت رده بنده
                                                    </label>
                                                    <div class="col-md-4 col-sm-4 col-xs-11">
                                                        <select class="form-control" id="rating_status" runat="server">
                                                            <option value="1">دارای رده بندی</option>
                                                            <option value="2">دارای رده بندی با شرط ویرایش موارد اعلام شده</option>
                                                            <option value="3">ممنوع شده</option>
                                                        </select>
                                                    </div>
                                                    <label class="chbox col-md-4 col-sm-4 col-xs-6">
                                                        <input type="checkbox" class="js-switch" id="is_sourse_avalable" runat="server" />سورس موجود است
                                                    </label>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-md-3 col-sm-3 col-xs-4">
                                                        رده سنی
                                                    </label>
                                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                                        <select class="form-control" id="age_rang" runat="server">
                                                        </select>
                                                    </div>
                                                </div>
                                                <hr />
                                                <h4 class="modal-title">محتوای مجرمانه</h4>
                                                <br />
                                                <section id="criminal_content" runat="server"></section>

                                                <hr />
                                                <h4 class="modal-title">دسته بندی</h4>
                                                <br />
                                                <section id="classification" runat="server">
                                                </section>
                                                <hr />
                                                <h4 class="modal-title">اطلاعات تکمیلی</h4>
                                                <br />
                                                <div class="form-group">
                                                    <label class="control-label col-md-2 col-sm-2 col-xs-7">
                                                        کیفیت
                                                    </label>
                                                    <div class="col-md-3 col-sm-3 col-xs-8">
                                                        <select class="form-control" id="quality" runat="server">
                                                            <option value="1">خوب</option>
                                                            <option value="2">ضعیف</option>
                                                        </select>
                                                    </div>
                                                    <label class="control-label col-md-2 col-sm-2 col-xs-4">
                                                        وجود نقص
                                                    </label>
                                                    <div class="col-md-5 col-sm-5 col-xs-8">
                                                        <select class="form-control" id="deficiency" runat="server">
                                                            <option value="0">ندارد</option>
                                                            <option value="1">دارد</option>
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-md-2 col-sm-2 col-xs-4">
                                                        توضیح نقص
                                                    </label>
                                                    <div class="col-md-10 col-sm-10 col-xs-12">
                                                        <textarea type="text" class="form-control" runat="server" id="txtDeficiencyNote"></textarea>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-primary js-add-version js-add-new-item" data-toggle="modal">ثبت</button>
                                                <button type="button" class="btn btn-default" data-dismiss="modal">لغو</button>

                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table class="table table-striped jambo_table bulk_action">
                                        <thead>
                                            <tr class="headings">
                                                <th class="column-title">پلتفرم</th>
                                                <th class="column-title">سورس</th>
                                                <th class="column-title">وضعیت</th>
                                                <th class="column-title">سورس</th>
                                                <th class="column-title">رده سنی</th>
                                                <th class="column-title">محتوا</th>
                                                <th class="column-title">دسته بندی</th>
                                                <th class="column-title">کیفیت</th>
                                                <th class="column-title">نقص</th>
                                                <th class="column-title no-link last">
                                                    <span class="nobr">عملیات</span>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody class="js-version-list"></tbody>
                                    </table>
                                </div>
                            </div>
                            <div id="step-3">
                                <h2 class="StepTitle">مرحله سوم</h2>
                                <button type="button" class="btn btn-primary js-openGenreDialog" data-toggle="modal" data-target=".bs-example-modal-lg2">افزودن سبک</button>
                                <div class="modal fade bs-example-modal-lg2" tabindex="-1" role="dialog" aria-hidden="true">
                                    <div class="modal-dialog modal-lg">
                                        <div class="modal-content">
                                            <div class="modal-body">
                                                <h4 class="modal-title">انتخاب سبک</h4>
                                                <br />
                                                <div class="form-group">
                                                    <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                                        سبک اصلی
                                                    </label>
                                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                                        <select class="form-control" id="slct_genres" runat="server">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group">
                                                    <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                                        زیر سبک
                                                    </label>
                                                    <div class="col-md-9 col-sm-9 col-xs-12">
                                                        <select class="form-control" id="slct_genres_sub" runat="server"></select>
                                                    </div>
                                                </div>
                                                <div class="clearfix"></div>
                                            </div>
                                            <div class="modal-footer">
                                                <button type="button" class="btn btn-primary js-add-Genres">ثبت</button>
                                                <button type="button" class="btn btn-default" data-dismiss="modal">لغو</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="table-responsive">
                                    <table class="table table-striped jambo_table bulk_action">
                                        <thead>
                                            <tr class="headings">
                                                <th class="column-title">سبک اصلی</th>
                                                <th class="column-title">زیر سبک</th>
                                                <th class="column-title no-link last">
                                                    <span class="nobr">عملیات</span>
                                                </th>
                                            </tr>
                                        </thead>
                                        <tbody class="js-genre-list"></tbody>
                                    </table>
                                </div>

                            </div>

                        </div>
                        <button class="btn btn-primary" clientidmode="Static" id="EditMobileGameInput" onclick="setFileName();return false;" runat="server" type="button" onserverclick="EditMobileGameInput_OnServerClick">ویرایش بازی</button>
                        <button id="cancelEditing" runat="server" type="button" class="btn" clientidmode="Static" onserverclick="cancelEditing_OnServerClick">لغو ویرایش</button>
                        <asp:HiddenField runat="server" ID="hfselectedGameForEdit" Value="0" />
                        <asp:TextBox runat="server" ID="txtPicName" Style="display: none;" ClientIDMode="Static"></asp:TextBox>
                        <!-- End SmartWizard Content -->
                        <div class="modal  bs-example-modal-versionSubmited" tabindex="-1" role="dialog" aria-hidden="true">
                            <div class="modal-dialog modal-sm">
                                <div class="modal-content">
                                    <div class="modal-body">
                                        <h4 class="modal-title">ثبت ورژن بازی</h4>
                                        <hr />
                                        اطلاعات با موفقیت ثبت شد.
                                        <br />
                                        <div class="clearfix"></div>
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" data-dismiss="modal" class="btn btn-primary">باشه</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row js-load-data-for-edit" style="display: none;">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>فرم ویرایش اطلاعات<small>اطلاعات بازی های PC و کنسولی</small>
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
                        <asp:GridView
                            ID="gvMobileGameInput"
                            runat="server"
                            AutoGenerateColumns="false"
                            DataKeyNames="id"
                            CssClass="table table-striped table-bordered dataTable no-footer bulk_action"
                            OnRowDeleting="gvMobileGameInput_RowDeleting"
                            OnRowEditing="gvMobileGameInput_RowEditing">
                            <Columns>
                                <asp:BoundField DataField="id" ShowHeader="False" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                <asp:BoundField DataField="name" HeaderText="نام بازی" />
                                <asp:BoundField DataField="platformsTitle" HeaderText="پلتفرم ها" />
                                <asp:BoundField DataField="genresTitle" HeaderText="ژانر ها" />

                                <asp:CommandField ShowEditButton="true" EditText="ویرایش" HeaderText="عملیات" />
                                <asp:CommandField ShowDeleteButton="true" DeleteText="حذف" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">
    <script src="/admin/vendors/jQuery-Smart-Wizard/js/jquery.smartWizard.js"></script>
    <script src="/COMPONENT/jQuery.filer-master/js/jquery.filer.min.js" type="text/javascript"></script>
    <script src="/COMPONENT/jQuery.filer-master/examples/dragdrop/js/custom.js" type="text/javascript"></script>

    <!-- Datatables -->
    <script src="/admin/vendors/datatables.net/js/jquery.dataTables.js"></script>
    <script src="/admin/vendors/datatables.net-bs/js/dataTables.bootstrap.min.js"></script>
    <script src="/admin/vendors/datatables.net-buttons/js/dataTables.buttons.min.js"></script>
    <script src="/admin/vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js"></script>
    <script src="/admin/vendors/datatables.net-buttons/js/buttons.flash.min.js"></script>
    <script src="/admin/vendors/datatables.net-buttons/js/buttons.html5.min.js"></script>
    <script src="/admin/vendors/datatables.net-buttons/js/buttons.print.min.js"></script>
    <script src="/admin/vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js"></script>
    <script src="/admin/vendors/datatables.net-keytable/js/dataTables.keyTable.min.js"></script>
    <script src="/admin/vendors/datatables.net-responsive/js/dataTables.responsive.min.js"></script>
    <script src="/admin/vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js"></script>
    <script src="/admin/vendors/datatables.net-scroller/js/dataTables.scroller.min.js"></script>
    <script src="/admin/vendors/jszip/dist/jszip.min.js"></script>
    <script src="/admin/vendors/pdfmake/build/pdfmake.min.js"></script>
    <script src="/admin/vendors/pdfmake/build/vfs_fonts.js"></script>

    <%-- ReSharper disable once Es6Feature --%>
    <script>
        // My Custom
        $(document).ready(function () {
            var gameId = "", txtGameName, txtGameNameSecond, txtComponyCreated, txtYearPublished, txtInternalPublisher, esraSummary, currentVerEditId = "0",
                currentGenEditId = "0";
            function addGameDetails() {
                txtGameName = $("#cpBodyMiddle_txtGameName").val();
                txtGameNameSecond = $("#cpBodyMiddle_txtGameNameSecond").val();
                txtComponyCreated = $("#cpBodyMiddle_txtComponyCreated").val();
                txtYearPublished = $("#cpBodyMiddle_txtYearPublished").val();
                //txtInternalPublisher = $("#cpBodyMiddle_txtInternalPublisher").val();
                esraSummary = "";

            }
            function numNotOccur(arr, target) {
                var count = $.grep(arr, function (elem) {
                    return elem !== target;
                }).length; // Returns 2
                return count;
            }

            $(".js-openVersionDialog").click(function () {
                currentVerEditId = "0";
                $(".js-add-version").html("ثبت");


                var cc = $('#cpBodyMiddle_criminal_content input');
                $.each(cc, function (index, criminal) {
                    if ($(criminal).prop('checked')) {
                        cc[index].click();
                    }
                });
                var pp = $('#cpBodyMiddle_classification input');
                $.each(pp, function (index, classification) {
                    if ($(classification).prop('checked')) {
                        pp[index].click();
                    }
                });
            });
            $(".js-openGenreDialog").click(function () {
                currentGenEditId = "0";
                $(".js-add-Genres").html("ثبت");

                $('#cpBodyMiddle_slct_genres option[value=' + 0 + ']').prop('selected', 'selected');
                $('#cpBodyMiddle_slct_genres_sub option[value=' + 0 + ']').prop('selected', 'selected');
            });
            function showVersionForEdit(vr, editId) {
                currentVerEditId = editId !== "0" ? editId : "0";
                if (currentVerEditId !== "0") $(".js-add-version").html("ویرایش");

                $('#cpBodyMiddle_platform_ver option[value=' + vr.platformVer + ']').prop('selected', 'selected');
                $('#cpBodyMiddle_source_type option[value=' + vr.sourceType + ']').prop('selected', 'selected');
                $('#cpBodyMiddle_rating_status option[value=' + vr.ratingStatus + ']').prop('selected', 'selected');
                if (vr.isSourseAvalable == "1") {
                    if (!$('#cpBodyMiddle_is_sourse_avalable').prop('checked'))
                        $('#cpBodyMiddle_is_sourse_avalable').click();
                } else {
                    if ($('#cpBodyMiddle_is_sourse_avalable').prop('checked'))
                        $('#cpBodyMiddle_is_sourse_avalable').click();
                }
                $('#cpBodyMiddle_age_rang option[value=' + vr.ageRan + ']').prop('selected', 'selected');
                var cc = $('#cpBodyMiddle_criminal_content input');
                $.each(cc, function (index, criminal) {
                    if ($(criminal).prop('checked')) {
                        cc[index].click();
                    }
                });
                $.each(vr.criminalContent, function (index, criminal) {
                    if (criminal !== "0") {
                        cc[index].click();
                    }
                });
                var pp = $('#cpBodyMiddle_classification input');
                $.each(pp, function (index, classification) {
                    if ($(classification).prop('checked')) {
                        pp[index].click();
                    }
                });
                $.each(vr.classification, function (index, classification) {
                    if (classification !== "0") {
                        pp[index].click();
                    }
                });
                $('#cpBodyMiddle_quality').find("option:contains('" + vr.quality + "')").prop('selected', 'selected');
                $('#cpBodyMiddle_deficiency option[value=' + vr.deficiency + ']').prop('selected', 'selected');
                if (vr.deficiency == "1")
                    $('#cpBodyMiddle_txtDeficiencyNote').val(vr.deficiencyNote);
                else
                    $('#cpBodyMiddle_txtDeficiencyNote').val("");
            }
            function showGenreForEdit(ge, editId) {
                currentGenEditId = editId !== "0" ? editId : "0";
                if (currentGenEditId !== "0") $(".js-add-Genres").html("ویرایش");

                $('#cpBodyMiddle_slct_genres option[value=' + ge.main + ']').prop('selected', 'selected');
                $('#cpBodyMiddle_slct_genres_sub option[value=' + ge.sub + ']').prop('selected', 'selected');
            };
            function printVersion(vr) {
                var tmp = "";
                tmp = currentVerEditId !== "0" ? '<tr style=\"background-color: #fff8a5;\" id="' + vr.id + '">' : '<tr id="' + vr.id + '">';

                tmp += ('<td>' + $('#cpBodyMiddle_platform_ver').find("[value=" + vr.platformVer + "]").text() + '</td>');
                tmp += ('<td>' + $('#cpBodyMiddle_source_type').find("[value=" + vr.sourceType + "]").text() + '</td>');
                tmp += ('<td>' + $('#cpBodyMiddle_rating_status').find("[value=" + vr.ratingStatus + "]").text() + '</td>');
                tmp += ('<td>' + ((vr.isSourseAvalable == "1") ? "بله" : "خیر") + '</td>');
                tmp += ('<td>' + $('#cpBodyMiddle_age_rang').find("[value=" + vr.ageRan + "]").text() + '</td>');
                tmp += ('<td>' + '<div class="js-popup" data-content="' + getUiContent("#cpBodyMiddle_criminal_content", "label", vr.criminalContent) + '">' + (numNotOccur(vr.criminalContent, "0") > 0 ? 'مشاهده' : 'ندارد') + '</div>' + '</td>');
                tmp += ('<td>' + '<div class="js-popup" data-content="' + getUiContent("#cpBodyMiddle_classification", "label", vr.classification) + '">' + (numNotOccur(vr.classification, "0") > 0 ? 'مشاهده' : 'ندارد') + '</div>' + '</td>');
                tmp += ('<td>' + $('#cpBodyMiddle_quality').find("option:contains('" + vr.quality + "')").text() + '</td>');
                tmp += ('<td>' + '<div class="js-popup" data-content="' + (vr.deficiency == "1" ? vr.deficiencyNote : "") + '">' + (vr.deficiency == "1" ? 'مشاهده' : 'ندارد') + '</div>' + '</td>');
                tmp += ('<td class=" last"><a class=\"deleteRow\" href="#">حذف</a>&nbsp&nbsp&nbsp&nbsp<a class=\"editRow\" href="#">ویرایش</a></td></tr>');


                if (currentVerEditId === "0")
                    $(".js-version-list").append(tmp);
                else {
                    $(".js-version-list tr#" + currentVerEditId).replaceWith(tmp);
                }
                popup();
                $('.js-version-list  #' + vr.id + ' .deleteRow').on("click", function () {
                    var s = $(this);
                    s.parent().parent().fadeOut(function () {
                        s.parent().parent().remove();
                    });
                    allVersionInfo.forEach(function (version, index) { if (version.id === vr.id) allVersionInfo.splice(index, 1) });
                });
                $('.js-version-list  #' + vr.id + ' .editRow').on("click", function () {
                    var id = $(this).parent().parent().attr("id");
                    $(".js-openVersionDialog").click();
                    allVersionInfo.forEach(function (version, index) {
                        if (version.id === id) {
                            showVersionForEdit(version, id);
                        }
                    });
                });
                $(".js-add-version").next().click();

            }
            function printGenre(ge) {

                var tmp = "";
                tmp = currentGenEditId !== "0" ? '<tr style=\"background-color: #fff8a5;\" id="' + ge.id + '">' : '<tr id="' + ge.id + '">';

                tmp += ('<td>' + $('#cpBodyMiddle_slct_genres').find("[value=" + ge.main + "]").text() + '</td>');
                tmp += ('<td>' + $('#cpBodyMiddle_slct_genres_sub').find("[value=" + ge.sub + "]").text() + '</td>');
                tmp += ('<td class=" last"><a class=\"deleteRow\" href="#">حذف</a>&nbsp&nbsp&nbsp&nbsp<a class=\"editRow\" href="#">ویرایش</a></td></tr>');

                if (currentGenEditId === "0")
                    $(".js-genre-list").append(tmp);
                else {
                    $(".js-genre-list tr#" + currentGenEditId).replaceWith(tmp);
                }

                $('.js-genre-list #' + ge.id + ' .deleteRow').on("click", function () {
                    var s = $(this);
                    s.parent().parent().fadeOut(function () {
                        s.parent().parent().remove();
                    });
                    allgenreInfo.forEach(function (genre, index) { if (genre.id === ge.id) allgenreInfo.splice(index, 1) });

                });
                $('.js-genre-list #' + ge.id + ' .editRow').on("click", function () {
                    var id = $(this).parent().parent().attr("id");
                    $(".js-openGenreDialog").click();
                    allgenreInfo.forEach(function (genre, index) {
                        if (genre.id === id) {
                            showGenreForEdit(genre, id);
                        }
                    });

                });
                //$(".js-add-Genres").next().click();
            }
            function addVersion() {
                if (currentVerEditId !== "0") {
                    allVersionInfo.forEach(function (version, index) { if (version.id === currentVerEditId) allVersionInfo.splice(index, 1) });
                }

                var criminalContentOption = new Array(), classification = new Array(), isSourseAvalable = "0";
                if ($('#cpBodyMiddle_is_sourse_avalable').prop('checked') === true) isSourseAvalable = "1";
                $('#cpBodyMiddle_criminal_content').find('input').each(function () {
                    if ($(this).prop('checked') === true) criminalContentOption.push($(this).attr('id'));
                    else criminalContentOption.push('0');
                });
                $('#cpBodyMiddle_classification').find('input').each(function () {
                    if ($(this).prop('checked') === true) classification.push($(this).attr('id'));
                    else classification.push('0');
                });
                var vr = new window.Version();
                vr.id = window.makeid(10);
                vr.platformVer = $('#cpBodyMiddle_platform_ver').find(":selected").val();
                vr.sourceType = $('#cpBodyMiddle_source_type').find(":selected").val();
                vr.ratingStatus = $('#cpBodyMiddle_rating_status').find(":selected").val();
                vr.isSourseAvalable = isSourseAvalable;
                vr.ageRan = $('#cpBodyMiddle_age_rang').find(":selected").val();
                vr.criminalContent = criminalContentOption;
                vr.classification = classification;
                vr.quality = $('#cpBodyMiddle_quality').find(":selected").val() === "1" ? "خوب" : "ضعیف";
                vr.deficiency = $('#cpBodyMiddle_deficiency').find(":selected").val();
                vr.deficiencyNote = vr.deficiency > 0 ? $('#cpBodyMiddle_txtDeficiencyNote').val() : '';
                allVersionInfo.push(vr);
                printVersion(vr);


            }
            function addGenres() {
                if (currentGenEditId !== "0") {
                    allgenreInfo.forEach(function (genre, index) { if (genre.id === currentGenEditId) allgenreInfo.splice(index, 1) });
                }

                var ge = new window.Genre();
                ge.id = window.makeid(10);
                ge.main = $('#cpBodyMiddle_slct_genres').find(":selected").val();;
                ge.sub = $('#cpBodyMiddle_slct_genres_sub').find(":selected").val();;
                allgenreInfo.push(ge);
                printGenre(ge);
            }
            $(".js-add-version").on("click", function () { addVersion(); });
            $(".js-add-Genres").on("click", function () { addGenres(); });
            $(".buttonFinish,#EditMobileGameInput").on("click", function () {
                addGameDetails();
                var gn = new window.GameInfo();
                gn.gameId = gameId;
                gn.gName = txtGameName;
                gn.gName2 = txtGameNameSecond;
                gn.componyCreated = txtComponyCreated;
                gn.yearPublished = txtYearPublished;
                //gn.internalPublisher = txtInternalPublisher;
                gn.esra_summary = esraSummary;
                gn.versions = allVersionInfo;
                gn.genres = allgenreInfo;
                gn.img = gameId == "" ? imageIdes : $('#txtPicName').val().split(',');
                $.ajax({
                    type: 'POST',
                    url: 'processRequest.aspx/AddGame',//processRequest.aspx/AddGame
                    contentType: 'application/json; charset=utf-8',
                    data: JSON.stringify({ gameInfo: gn }),
                    success: function (reponse) {
                        alert(gameId == "" ? "بازی با موفقیت ثبت شد" : "بازی با موفقیت ویرایش شد ");
                        window.location.href = "PcGameInput.aspx?mode=pc";
                    },
                    error: function (error) { console.log(error); }
                });
            });
            $(".js-show-and-edit-form").fadeIn(500, function () {
                $(".dataTables_scrollHeadInner,.table").css('width', '100%');
                $(".js-load-data-for-edit").fadeIn(500, function () {
                    $('.js-loading').slideUp();
                });
            });

            function loadGameData() {
                var gn = window.gnTemp;
                if (typeof (gn) !== "undefined") {
                    $('.buttonFinish').css('display', 'none');
                    $.each(gn.versions, function (i, area) {
                        allVersionInfo.push(area);
                        printVersion(area);
                    });
                    $.each(gn.genres, function (i, area) {
                        allgenreInfo.push(area);
                        printGenre(area);
                    });
                    gameId = gn.gameId;
                }
            }
            loadGameData();
            $('#sidebar-menu > div > ul > li.active > ul').slideDown();
            function hidTag() {
                var targetTag = $('#cpBodyMiddle_criminal_content');//محتوای مجرمانه
                targetTag.css('display', 'none');
                targetTag.next().css('display', 'none');
                targetTag.prev().css('display', 'none');
                targetTag.prev().prev().css('display', 'none');
                targetTag.prev().prev().prev().css('display', 'none');

                targetTag = $('#cpBodyMiddle_deficiency').parent();//نقص بازی
                targetTag.css('display', 'none');
                targetTag.prev().css('display', 'none');

                targetTag = $('#cpBodyMiddle_txtDeficiencyNote').parent();//توضیح نقص بازی
                targetTag.css('display', 'none');
                targetTag.prev().css('display', 'none');
            }
            if (getParameterByName("mode") == "pc") {
                hidTag();

                var targetTag = $('#cpBodyMiddle_classification');//دسته بندی
                targetTag.css('display', 'none');
                targetTag.next().css('display', 'none');
                targetTag.next().next().css('display', 'none');
                targetTag.next().next().next().css('display', 'none');
                targetTag.next().next().next().next().css('display', 'none');

                targetTag.prev().css('display', 'none');
                targetTag.prev().prev().css('display', 'none');
                targetTag.prev().prev().prev().css('display', 'none');
                $('#cpBodyMiddle_source_type option[value=' + 2 + ']').prop('selected', 'selected');


            }

        });
        var allGameInfo = new Array();
        var allVersionInfo = new Array();
        var allgenreInfo = new Array();
        function GameInfo() {
            this.gameId = "";
            this.gName = "";
            this.gName2 = "";
            this.componyCreated = "";
            this.yearPublished = "";
            this.internalPublisher = "";
            this.esra_summary = "";
            this.versions = [];
            this.genres = [];
            this.img = [];
        }
        function Version() {
            this.id = 0;
            this.platformVer = 0;
            this.sourceType = 0;
            this.ratingStatus = 0;
            this.isSourseAvalable = 0;
            this.ageRan = 0;
            this.criminalContent = [];
            this.classification = [];
            this.quality = 0;
            this.deficiency = 0;
            this.deficiencyNote = "";

        }
        function Genre() {
            this.id = 0;
            this.main = 0;
            this.sub = 0;
        }
        function popup() {
            $('.js-popup').popup({
                position: 'right center'
            });
        }
        function getUiContent(parent, child, arrayIndex) {
            var templ = "";
            $(parent).find(child).each(function (index) {
                if (arrayIndex[index] > "0") templ += $(this).text() + ' - ';
            });
            return templ;
        }
        var b = $("#cpBodyMiddle_gvMobileGameInput");
        if (typeof b.html() !== "undefined") {
            if (b.html().trim() !== "") {
                if ("undefined" !== typeof $.fn.DataTable) {
                    $(b).dataTable({
                        dom: "Bfrtip",
                        buttons: [
                            {
                                extend: "copy",
                                className: "btn-sm"
                            }, {
                                extend: "csv",
                                className: "btn-sm"
                            }, {
                                extend: "excel",
                                className: "btn-sm"
                            }, {
                                extend: "pdfHtml5",
                                className: "btn-sm"
                            }, {
                                extend: "print",
                                className: "btn-sm"
                            }
                        ],
                        responsive: true,
                        keys: false,
                        deferRender: true,
                        scrollY: 500,
                        scrollCollapse: true,
                        scroller: false,
                        fixedHeader: true,
                        order: [
                            [1, "asc"]
                        ],
                        columnDefs: [
                            {
                                orderable: true,
                                targets: [0]
                            }
                        ],
                        "language": {
                            "search": "اعمال فیلتر  _INPUT_ در جدول",
                            "sSearchPlaceholder": "مثلا نام بازی",
                            "sInfo": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
                            "sInfoFiltered": "(فیلتر شده از مجموع _MAX_ رکورد)",
                            "sInfoEmpty": "نمایش 0 از 0 رکورد",
                            "sZeroRecords": "رکوردی بر اساس جستجوی انجام شده وجود ندارد"
                        }
                    });
                }
            }
            $(document).delegate("a:contains('حذف')", 'click', function () {
                if (confirm('آیا مطمئن هستید می خواهید این بازی را پاک کنید؟')) {
                    return true;
                } else {
                    return false;
                }
            });
        }
        function setFileName() {
            $(document).ready(function () {
                $('#txtPicName').val($('#txtPicName').val() + ',' + imageIdes);
            });
        }
        function check_availability() {
            var game = $('#cpBodyMiddle_txtGameName');
            var gameName = game.val();
            $.ajax({
                type: 'POST',
                url: 'processRequest.aspx/check_availability',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ gameName: gameName }),
                success: function (reponse) {
                    if (reponse.d == "0") game.css('border', '2px solid green').css('text-decoration', 'none');
                    if (reponse.d == "1") game.css('border', '2px solid red').css('text-decoration', 'line-through');
                    if (reponse.d == "2") game.css('border', '2px solid orangered').css('text-decoration', 'line-through');
                },
                error: function (error) {
                }
            });
        }

    </script>
</asp:Content>
