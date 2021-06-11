<%@ Page Title="" Language="C#" MasterPageFile="~/admin/a-first.Master" AutoEventWireup="true" CodeBehind="GameIntroInput.aspx.cs" Inherits="Esra.WebUI.admin.GameIntroInput" ValidateRequest="false" EnableEventValidation="false" %>

<%@ Register TagPrefix="CKEditor" Namespace="CKEditor.NET" Assembly="CKEditor.NET, Version=3.6.6.2, Culture=neutral, PublicKeyToken=e379cdf2f8354999" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <!-- Datatables -->
    <link href="/admin/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet">
    <!-- iCheck -->
    <link href="/admin/vendors/iCheck/skins/flat/green.css" rel="stylesheet">
    <%-- semantic-UI form --%>
    <link href="/COMPONENT/Semantic/dist/components/form.css" rel="stylesheet" />
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

        .ui.textarea, .ui.form textarea {
            width: calc(100% - 27px);
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
                        max-width: 122px
                    }
    </style>
    <link href="/COMPONENT/jQuery.filer-master/css/jquery.filer.css" rel="stylesheet">
    <link href="/COMPONENT/jQuery.filer-master/css/themes/jquery.filer-dragdropbox-theme.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server"></asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">

    <div class="">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>فرم ورود اطلاعات<small>اطلاعات معرفی بازی</small>
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
                    <form class="ui form ">
                        <div class="x_content ui form">
                            <p>اطلاعات معرفی بازی را مرحله به مرحله در فرم زیر وارد کنید و در نهایت کلید ثبت را بزنید.</p>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    نام بازی
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12 field">
                                    <input clientidmode="Static" type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtGameName" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    شرکت سازنده
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12 field">
                                    <input clientidmode="Static" type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtPublisher" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    سبک بازی
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <%--            <select class="form-control" id="slct_genres" runat="server">--%>
                                    <%--            </select>--%>
                                    <asp:ListBox Rows="5" ID="slct_genres2" runat="server" SelectionMode="Multiple" CssClass="select2_multiple form-control"></asp:ListBox>

                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    پلتفرم
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <%--                                <select class="form-control" id="platform_ver" runat="server">--%>
                                    <%--                                </select>--%>
                                    <asp:ListBox Rows="5" ID="platform_ver2" runat="server" SelectionMode="Multiple" CssClass="select2_multiple form-control"></asp:ListBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    نوع سورس
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="source_type" runat="server">
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    سال نشر
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12 field">
                                    <input clientidmode="Static" type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtYearPublished" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    شرح مختصر
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12 field">
                                    <%--<asp:TextBox TextMode="MultiLine" ID="intro_short" CssClass="editor-wrapper form-control col-md-7 col-xs-12" runat="server" ClientIDMode="Static"></asp:TextBox>--%>
                                    <CKEditor:CKEditorControl ID="intro_short" runat="server" ClientIDMode="Static" />


                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    گیم پلی
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12 field">
                                    <%--<asp:TextBox TextMode="MultiLine" ID="intro_intro" CssClass="editor-wrapper form-control col-md-7 col-xs-12" runat="server" ClientIDMode="Static"></asp:TextBox>--%>
                                    <CKEditor:CKEditorControl ID="intro_intro" runat="server" ClientIDMode="Static" />


                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    توصیه به والدین
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12 field">
                                    <%--<asp:TextBox TextMode="MultiLine" ID="intro_gameplay" CssClass="editor-wrapper form-control col-md-7 col-xs-12" runat="server" ClientIDMode="Static"></asp:TextBox>--%>
                                    <CKEditor:CKEditorControl ID="intro_gameplay" runat="server" ClientIDMode="Static" />

                                </div>
                            </div>
                            <div class="form-group" style="display: none">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    امتیاز متقدین
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12 field">
                                    <input clientidmode="Static" type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtReviewersScore" />
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    لوگوی اسرا
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="slct_esra_grade" runat="server">
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    مهارت بازی
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="slct_esra_skill" runat="server">
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    ترس
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="slct_esra_fear" runat="server">
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    خشونت
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="slct_esra_violence" runat="server">
                                    </select>
                                </div>
                            </div>


                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    ناهنجاری اجتماعی
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="slct_esra_anomalies" runat="server">
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    دخانیات
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="slct_esra_drugs" runat="server">
                                    </select>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    یاس و نا امیدی
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">

                                    <select class="form-control" id="slct_esra_despair" runat="server">
                                    </select>
                                </div>
                            </div>

                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    عکس ها
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">
                                    <input type="file" name="files[]" id="filer_input2" multiple="multiple">
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="control-label col-md-3 col-sm-3 col-xs-6">
                                    عکس های قدیمی
                                </label>
                                <div class="col-md-8 col-sm-8 col-xs-12">
                                    <div runat="server" id="pnl_OldPic"></div>
                                </div>
                            </div>
                            <button id="AddGameIntroInfo" runat="server" type="button" class="btn btn-primary js-btn-finish submit">اضافه کردن بازی</button>
                            <button class="btn btn-primary" clientidmode="Static" id="EditGameIntroInfo" onclick="setFileName();" onserverclick="EditGameIntroInfo_OnServerClick" runat="server" type="button">ویرایش بازی</button>
                            <button id="cancelEditing" runat="server" type="button" class="btn" onserverclick="cancelEditing_OnServerClick" clientidmode="Static">لغو ویرایش</button>
                            <asp:HiddenField runat="server" ID="hfselectedGameForEdit" Value="0" />
                            <asp:TextBox runat="server" ID="txtPicName" Style="display: none;" ClientIDMode="Static"></asp:TextBox>

                        </div>
                    </form>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>فرم ویرایش اطلاعات<small>اطلاعات معرفی بازی</small>
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
                            ID="gvGameIntroInfo"
                            runat="server"
                            AutoGenerateColumns="false"
                            DataKeyNames="id"
                            CssClass="table table-striped table-bordered dataTable no-footer bulk_action"
                            OnRowDeleting="gvGameIntroInfo_RowDeleting"
                            OnRowEditing="gvGameIntroInfo_RowEditing">
                            <Columns>
                                <asp:BoundField DataField="id" ShowHeader="False" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                <asp:BoundField DataField="name" HeaderText="نام بازی" />
                                <asp:BoundField DataField="publisher" HeaderText="ناشر" />
                                <asp:BoundField DataField="reviewers_score" HeaderText="امتیاز" />

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
    <%-- semantic-UI form --%>
    <script src="/COMPONENT/Semantic/dist/components/form.js"></script>

    <script src="/COMPONENT/jQuery.filer-master/js/jquery.filer.min.js" type="text/javascript"></script>
    <script src="/COMPONENT/jQuery.filer-master/examples/dragdrop/js/custom.js" type="text/javascript"></script>


    <!-- Datatables -->
    <script src="/admin/vendors/datatables.net/js/jquery.dataTables.min.js"></script>
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
    <!-- iCheck -->
    <script src="/admin/vendors/iCheck/icheck.min.js"></script>

    <%-- ReSharper disable once Es6Feature --%>
    <script>
        var key1 = 0;
        var key2 = 0;
        // My Custom
        $(document).ready(function () {
            $(".js-btn-finish").on("click", function () {
                var gn = new window.GameIntroInfo();
                gn.gName = $("#txtGameName").val();
                gn.Publisher = $("#txtPublisher").val();
                if ($('#cpBodyMiddle_slct_genres2').val() !== null)
                    gn.GenreID = $('#cpBodyMiddle_slct_genres2').val().toString();
                if ($('#cpBodyMiddle_platform_ver2').val() !== null)
                    gn.platformID = $('#cpBodyMiddle_platform_ver2').val().toString();
                gn.sourceID = $('#cpBodyMiddle_source_type').find(":selected").val();
                gn.yearPublished = $("#txtYearPublished").val();
                gn.intro_short = CKEDITOR.instances['intro_short'].getData();
                gn.intro_intro = CKEDITOR.instances['intro_intro'].getData();
                gn.intro_gameplay = CKEDITOR.instances['intro_gameplay'].getData();
                gn.ReviewersScore = "0"; //$("#txtReviewersScore").val();
                gn.esra_grade = $('#cpBodyMiddle_slct_esra_grade').find(":selected").val();
                gn.esra_skill = $('#cpBodyMiddle_slct_esra_skill').find(":selected").val();
                gn.esra_violence = $('#cpBodyMiddle_slct_esra_violence').find(":selected").val();
                gn.esra_fear = $('#cpBodyMiddle_slct_esra_fear').find(":selected").val();
                gn.esra_drugs = $('#cpBodyMiddle_slct_esra_drugs').find(":selected").val();
                gn.esra_anomalies = $('#cpBodyMiddle_slct_esra_anomalies').find(":selected").val();
                gn.esra_despair = $('#cpBodyMiddle_slct_esra_despair').find(":selected").val();
                gn.img = imageIdes;

                
                debugger;
                $(".form").form({
                    a: { identifier: 'txtGameName', rules: [{ type: 'empty', prompt: 'نام بازی را وارد کنید' }] },
                    b: { identifier: 'txtPublisher', rules: [{ type: 'empty', prompt: 'نام شرکت را وارد کنید' }] },
                    c: { identifier: 'txtYearPublished', rules: [{ type: 'integer[1000..3000]', prompt: 'سال نشر را وارد کنید. بین 1000 تا 3000' }] },

                }, {
                    inline: true,
                    on: 'blur',
                    duration: 500,
                    onSuccess: function () {
                        key1++;
                        if (key1 <= 1)
                            $.ajax({
                                type: 'POST',
                                url: 'processRequest.aspx/AddGameIntroInfo',
                                contentType: 'application/json; charset=utf-8',
                                data: JSON.stringify({ gameIntroInfo: gn }),
                                success: function (reponse) {
                                    alert("بازی با موفقیت ثبت شد");
                                    location.reload();
                                },
                                error: function (error) { console.log(error); }
                            });
                    },
                    onFailure: function () {
                        key2++;
                        if (key2 <= 1)
                            alert("فرم را کامل پر کنید");
                    }
                });
                key2 = 0;

            });
            var b = $("#cpBodyMiddle_gvGameIntroInfo");
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
                            //                        ajax: "js/datatables/json/scroller-demo.json",
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
            }
        });
        var allGameInfo = new Array();

        function GameIntroInfo() {
            this.gName = "";
            this.Publisher = "";
            this.GenreID = "";
            this.platformID = "";
            this.sourceID = "";
            this.yearPublished = "";
            this.intro_short = "";
            this.intro_intro = "";
            this.intro_gameplay = "";
            this.ReviewersScore = "";
            this.esra_grade = "";
            this.esra_skill = "";
            this.esra_violence = "";
            this.esra_fear = "";
            this.esra_drugs = "";
            this.esra_anomalies = "";
            this.esra_despair = "";
            this.img = [];
        }
    </script>
    <script>
        $(document).ready(function () {
            $(".form").form();
            var areas = Array('intro_short', 'intro_intro', 'intro_gameplay');
            $.each(areas, function (i, area) {
                CKEDITOR.replace(area, {
                    language: 'fa',
                    font_defaultLabel: 'IRANSansBold',
                    font_names: 'IRANSansBold',
                    height: 200
                });
            });
        });
        $(document).delegate("a:contains('حذف')", 'click', function () {
            if (confirm('آیا مطمئن هستید می خواهید این بازی را پاک کنید؟')) {
                return true;
            } else {
                return false;
            }
        });
        function setFileName() {
            $(document).ready(function () {

                $('#txtPicName').val($('#txtPicName').val() + ',' + imageIdes);

            });
        }
    </script>
</asp:Content>
