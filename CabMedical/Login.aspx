<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CabMedical.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
    <!--end::Web font -->
    <!--begin::Base Styles -->
    <link href="assets/vendors/base/vendors.bundle.css" rel="stylesheet" type="text/css" />
    <link href="assets/demo/default/base/style.bundle.css" rel="stylesheet" type="text/css" />
    <!--end::Base Styles -->
    <script src="https://ajax.googleapis.com/ajax/libs/webfont/1.6.16/webfont.js"></script>
    <!-- end:: Page -->
    <!--begin::Base Scripts -->
    <script src="assets/vendors/base/vendors.bundle.js" type="text/javascript"></script>
    <script src="assets/demo/default/base/scripts.bundle.js" type="text/javascript"></script>
    <!--end::Base Scripts -->
    <!--begin::Page Snippets -->
    <script src="assets/snippets/pages/user/login.js" type="text/javascript"></script>
</head>
<body>

    <div style="float: right;" class="carousel-inner" role="listbox">
        <img src="image/Image-Login1.jpg" style="float: right; max-width: 50%;" />
    </div>

    <form id="form1" runat="server">
        <div style="position: fixed; top: 80px; left: 10px;">
            <div>
                <img src="../Image/logo1.png" style="max-width: 50%;">
            </div>
            <div class="form-group m-form__group">
                <label>Login</label>
                <asp:TextBox ID="TextBox_Login" runat="server" MaxLength="50" class="form-control m-input" />
            </div>
            <div class="mb-3">
                <label>Mot de Passe</label>
                <asp:TextBox ID="TextBox_MDP" runat="server" TextMode="Password" MaxLength="50" class="form-control m-input" />
            </div>
            <asp:Button ID="Button_Login" runat="server" Text="Login" OnClick="Button_Login_Click" class="btn btn-primary m-btn m-btn--pill m-btn--custom m-btn--air m-login__btn m-login__btn--primary" />
        </div>
    </form>
</body>
</html>
