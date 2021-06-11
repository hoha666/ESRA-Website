<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Esra.WebUI.admin.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <title>اسرا - ورود به پنل مدیریت</title>
    <link href="../CSS/font.css" rel="stylesheet"/>
    <link href="vendors/bootstrap/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="vendors/font-awesome/css/font-awesome.min.css" rel="stylesheet">
    <link href="vendors/nprogress/nprogress.css" rel="stylesheet">
    <link href="vendors/animate.css/animate.min.css" rel="stylesheet">

    <link href="build/css/custom.min.css" rel="stylesheet">
</head>
<body class="login">
<%--<form id="form1" runat="server"></form>--%>
<div>
    <a class="hiddenanchor" id="signup"></a>
    <a class="hiddenanchor" id="signin"></a>
    <div class="login_wrapper">
        <div class="animate form login_form">
            <section class="login_content">
                <form runat="server">
                    <h1>فرم ورود</h1>
                    <div>
                        <asp:TextBox runat="server" ID="txt_user_name" type="text" class="form-control" placeholder="نام کاربری" required=""/>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txt_password" type="password" class="form-control" placeholder="رمز عبور" required=""/>
                    </div>
                    <div>
                        <asp:Button ID="btn_login" OnClick="btn_login_OnClick" runat="server" class="btn btn-default submit" href="index.html" Text="ورود"></asp:Button>
                        <a class="reset_pass" href="#">رمز عبور خود را فراموش کرده اید؟</a>
                    </div>
                    <div class="clearfix"></div>
                    <div class="separator">
                        <p class="change_link">
                            حساب کاربری ندارید؟
                            <a href="#signup" class="to_register">عضویت در سامانه</a>
                        </p>
                        <div class="clearfix"></div>
                        <br/>
                        <div>
                            <h1>سامانه اسرا</h1>
                            <p>
                                تمام حقوق مادی و معنوی این وب سایت مربوط به بنیاد ملی بازی های رایانه ای می باشد
                            </p>
                        </div>
                    </div>
                </form>
            </section>
        </div>
        <div id="register" class="animate form registration_form">
            <section class="login_content">
                <form>
                    <h1>عضویت در سامانه</h1>
                    <div>
                        <input type="text" class="form-control" placeholder="نام کاربری" required=""/>
                    </div>
                    <div>
                        <input type="email" class="form-control" placeholder="ایمیل" required=""/>
                    </div>
                    <div>
                        <input type="password" class="form-control" placeholder="رمز عبور" required=""/>
                    </div>
                    <div>
                        <a class="btn btn-default submit" href="index.html">ثبت</a>
                    </div>
                    <div class="clearfix"></div>
                    <div class="separator">
                        <p class="change_link">
                            قبلا ثبت نام کرده اید؟
                            <a href="#signin" class="to_register">ورود</a>
                        </p>
                        <div class="clearfix"></div>
                        <br/>
                        <div>
                            <h1>سامانه اسرا</h1>
                            <p>
                                تمام حقوق مادی و معنوی این وب سایت مربوط به بنیاد ملی بازی های رایانه ای می باشد
                            </p>
                        </div>
                    </div>
                </form>
            </section>
        </div>
    </div>
</div>
</body>
</html>