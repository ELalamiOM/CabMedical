<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RendezVous_Add.aspx.cs" Inherits="CabMedical.RendezVous_Add" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <%--<div class="mb-3" >
                <label>Nom</label>
                <asp:TextBox ID="TextBox_Nom_User" runat="server" class="form-control" />
            </div>--%>
            <div class="mb-3">
                <label>Nom et Prenom</label>
                <asp:TextBox ID="TextBox_Nom_Prenom_User" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label>Date de Rendez-vous</label>
                <%--<asp:Calendar ID="Cale_RendezVousUser" class="form-control" runat="server"  />--%>
                <asp:TextBox ID="Cale_RendezVousUser" class="form-control" runat="server" TextMode="Date"  />
            </div>
            <div class="mb-3">
                <label>Age</label>
                <asp:TextBox ID="TextBox_AgeUser"  class="form-control" runat="server" />
            </div>   
            <div class="mb-3">
                <label>Tel</label>
                <asp:TextBox ID="TextBox_Telephone_User"  class="form-control" runat="server" />
            </div>
            <div class="mb-3">
                <label>Email</label>
                <asp:TextBox ID="TextBox_Email_User"  class="form-control" runat="server" />
            </div>
            <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Ajouter RendezVous" OnClick="Button1_Click" />
        </div>

    </form>
    </body>
</html>
