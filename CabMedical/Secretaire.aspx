<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secretaire.aspx.cs" Inherits="CabMedical.Secretaire" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>

    <style type="text/css">
        .auto-style1 {
            width: 90%;
            max-width: 1320px;
            margin-left: auto;
            margin-right: auto;
            padding-left: var(--bs-gutter-x, .75rem);
            padding-right: var(--bs-gutter-x, .75rem);
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <div class="mb-3">
                <label>Nom</label>
                <asp:TextBox ID="TextBox_Nom" runat="server" class="form-control" placeholder="Nom" Width="1115px" />
            </div>
            <div class="mb-3">
                <label>Prenom</label>
                <asp:TextBox ID="TextBox_Prenom" runat="server" class="form-control" placeholder="Prenom" Width="1120px" />
            </div>
            <div class="mb-3">
                <label>Login</label>
                <asp:TextBox ID="TextBox_Login" runat="server" class="form-control" placeholder="Ex:(SecNomexetera...)" Width="1116px" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox_Login" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox_Login" Display="Dynamic" ErrorMessage="Sec......" ValidationExpression="Sec\w{1,}"></asp:RegularExpressionValidator>
            </div>
            <div class="mb-3">
                <label>Mot de Passe</label>
                <asp:TextBox ID="TextBox_Passe" runat="server" class="form-control" placeholder="Nom" Width="1113px" />
            </div>
                <asp:Button ID="Button_Ajouter" runat="server" class="btn btn-primary" Text="Ajouter" OnClick="Button_Ajouter_Click" />
        </div>
    </form>
</body>
</html>
