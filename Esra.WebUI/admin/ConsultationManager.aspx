<%@ Page Title="" Language="C#" MasterPageFile="~/admin/a-first.Master" AutoEventWireup="true" CodeBehind="ConsultationManager.aspx.cs" Inherits="Esra.WebUI.admin.ConsultationManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpMeta" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpHead" runat="server">
    <!-- Datatables -->
    <link href="/admin/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css" rel="stylesheet">
    <link href="/admin/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css" rel="stylesheet">
    <style>
        th {
            text-align: right;
        }

        .hiddencol {
            display: none;
        }
    </style>
    <link href="/COMPONENT/jQuery.filer-master/css/jquery.filer.css" rel="stylesheet">
    <link href="/COMPONENT/jQuery.filer-master/css/themes/jquery.filer-dragdropbox-theme.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpBodyTop" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpBodyMiddle" runat="server">
    <div class="">
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>مشاوره<small>مدیریت سوال های پرسیده شده در ماژول مشاوره</small>
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
                        <p>برای پاسخ گویی فیلد های زیر را پر کنید</p>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                اطلاعات سوال کننده
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <asp:Label type="text" class="form-control col-md-7 col-xs-12" runat="server" ID="lblSenderInfo" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                سوال
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">
                                <asp:Label type="text" class="form-control col-md-7 col-xs-12" runat="server" ID="lblQuestion" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2 col-sm-2 col-xs-2">
                                نظر مشاور
                            </label>
                            <div class="col-md-12 col-sm-12 col-xs-12">

                                <asp:TextBox TextMode="MultiLine" type="text" Rows="15" class="form-control col-md-7 col-xs-12" runat="server" ID="txtAnswer" />
                            </div>
                        </div>


                        <button class="btn btn-primary js-btn-finish" clientidmode="Static" id="btnAddAnswer" runat="server" type="button" onserverclick="btnAddAnswer_OnServerClick">ثبت مشاوره</button>
                        <button class="btn" clientidmode="Static" runat="server" type="button" id="btnCancelAddAnswer" onserverclick="btnCancelAddAnswer_OnServerClick">انصراف</button>
                        <asp:HiddenField runat="server" ID="hfselectedQuestionForAnswer" Value="0" />

                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <div class="x_panel">
                    <div class="x_title">
                        <h2>فرم ویرایش اطلاعات<small>اطلاعات همه مشاوره ها</small>
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
                            ClientIDMode="Static"
                            ID="gvConsultationList"
                            runat="server"
                            AutoGenerateColumns="false"
                            DataKeyNames="id"
                            CssClass="table table-striped table-bordered dataTable no-footer bulk_action"
                            OnRowEditing="gvConsultationList_OnRowEditing">
                            <Columns>
                                <asp:BoundField DataField="ID" ShowHeader="False" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol" />
                                <asp:BoundField DataField="senderFullName" HeaderText="نام سوال کننده" />
                                <asp:BoundField DataField="senderEmail" HeaderText="ایمیل" />
                                <asp:BoundField DataField="senderMobile" HeaderText="موبایل" />
                                <asp:BoundField DataField="CreateDateTime" HeaderText="تاریخ سوال پرسیدن" />

                                <asp:CommandField ShowEditButton="true" EditText="جواب" HeaderText="عملیات" />

                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="cpBodyBottom" runat="server">

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
        function setFileName() {
            $(document).ready(function () {

                $('#txtFileName').val(imageIdes);
            });
        }
        // My Custom
        $(document).ready(function () {


            var b = $("#gvConsultationList");
            if (b.html().trim() !== "")
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
                            "sSearchPlaceholder": "مثلا نام سوال کننده",
                            "sInfo": "نمایش _START_ تا _END_ از _TOTAL_ رکورد",
                            "sInfoFiltered": "(فیلتر شده از مجموع _MAX_ رکورد)",
                            "sInfoEmpty": "نمایش 0 از 0 رکورد",
                            "sZeroRecords": "رکوردی بر اساس جستجوی انجام شده وجود ندارد"
                        }
                    });
                }
            $('#sidebar-menu > div > ul > li.active > ul').slideDown();
            $(document).delegate("a:contains('حذف')", 'click', function () {
                if (confirm('آیا مطمئن هستید می خواهید این ردیف را پاک کنید؟')) {
                    return true;
                } else {
                    return false;
                }
            });
        });

    </script>

</asp:Content>
