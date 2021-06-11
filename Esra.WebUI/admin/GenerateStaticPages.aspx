<%@ Page Title="" Language="C#" MasterPageFile="~/admin/a-first.Master" AutoEventWireup="true" CodeBehind="GenerateStaticPages.aspx.cs" ValidateRequest="false" Inherits="Esra.WebUI.admin.GenerateStaticPages" %>

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
    <style>
        th {
            text-align: right;
        }

        table {
            cursor: default;
        }

        .hiddencol {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">

    <div class="">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>ساخت صفحات ثابت<small>صفحات ثابت سایت</small>
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
                        <p>اطلاعات صفحات ثابت سایت را در فرم زیر وارد کنید و در نهایت کلید ثبت را بزنید.</p>


                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                عنوان صفحه
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">

                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtPageTitle" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                نویسنده
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">

                                <input type="text" class="form-control col-md-7 col-xs-12" runat="server" id="txtPageAuther" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                انتخاب قالب صفحه
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">

                                <select class="form-control" id="slct_master" runat="server">
                                    <option value="0">انتخاب کنید</option>
                                    <option value="1">قالب اصلی سایت</option>
                                    
                                </select>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                محتوای صفحه
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">

                                <CKEditor:CKEditorControl ID="txtPageContent" runat="server" ClientIDMode="Static" />
                                
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                ریشه است؟
                            </label>
                            <label class="chbox col-md-12 col-sm-12 col-xs-12">
                                <input type="checkbox" class="js-switch" id="is_Root" runat="server" />
                            </label>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                انتخاب ریشه
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <select class="form-control" id="slct_Root" runat="server">
                                    <option value="0">انتخاب کنید</option>
                                    <option value="1">ریشه یک</option>
                                    <option value="2">ریشه دو</option>
                                    <option value="3">ریشه سه</option>
                                </select>
                            </div>
                        </div>
                        <button id="AddStaticPage" onserverclick="AddStaticPage_OnServerClick" runat="server" type="button" class="btn btn-primary js-btn-finish">اضافه کردن صفحه</button>
                        <button id="EditStaticPage" onserverclick="EditStaticPages_OnServerClick" runat="server" type="button" class="btn btn-primary" clientidmode="Static">ویرایش صفحه</button>
                        <button id="cancelEditing" onserverclick="cancelEditing_OnServerClick" runat="server" type="button" class="btn" clientidmode="Static">لغو ویرایش</button>
                        <asp:HiddenField runat="server" ID="hfselectedPageForEdit" Value="0" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>ویرایش صفحات ثابت<small>صفحات ثابت سایت</small>
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
                            ID="gvStaticPagesInfo"
                            runat="server"
                            AutoGenerateColumns="false"
                            DataKeyNames="id"
                            CssClass="table table-striped table-bordered dataTable no-footer bulk_action"
                            OnRowDeleting="gvStaticPagesInfo_RowDeleting"
                            OnRowEditing="gvStaticPagesInfo_RowEditing"
                            AllowPaging="true">
                            <Columns>
                                <asp:BoundField DataField="id" ShowHeader="False" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                               
                                <asp:BoundField DataField="Title" HeaderText="نام صفحه"  HtmlEncode="False"/>
                                <asp:BoundField DataField="Auther" HeaderText="نویسنده" />
                                <asp:BoundField DataField="Date" HeaderText="تاریخ ثبت" />

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
    <script src="/ckeditor/ckeditor.js"></script>

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

    <script>
        CKEDITOR.replace('txtPageContent', {
            language: 'fa',
            font_defaultLabel: 'IRANSansBold',
            font_names: 'IRANSansBold',
            height: 750
        });
        $(document).ready(function () {
            var b = $("#cpBodyMiddle_gvStaticPagesInfo");
            if ("undefined" != typeof $.fn.DataTable) {
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
                        "sSearchPlaceholder": "مثلا نام صفحه",
                        "sInfo": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
                        "sInfoFiltered": "(فیلتر شده از مجموع _MAX_ رکورد)",
                        "sInfoEmpty": "نمایش 0 از 0 رکورد",
                        "sZeroRecords": "رکوردی بر اساس جستجوی انجام شده وجود ندارد"
                    }
                });
            }
            $('#cpBodyMiddle_is_Root').on('click', function () {
                if ($(this).is(':checked'))
                    $('#cpBodyMiddle_slct_Root').parent().parent().slideUp();
                else
                    $('#cpBodyMiddle_slct_Root').parent().parent().slideDown();
            });
            if ($('#cpBodyMiddle_is_Root').is(':checked'))
                $('#cpBodyMiddle_slct_Root').parent().parent().slideUp();
            else
                $('#cpBodyMiddle_slct_Root').parent().parent().slideDown();
            $(document).delegate("a:contains('حذف')", 'click', function () {
                if (confirm('آیا مطمئن هستید می خواهید این صفحه را پاک کنید؟')) {
                    return true;
                } else {
                    return false;
                }
            });
        });
    </script>
</asp:Content>
