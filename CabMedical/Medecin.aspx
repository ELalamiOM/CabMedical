<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Medecin.aspx.cs" Inherits="CabMedical.Medecin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                <asp:TextBox ID="TextBox_Prenom" runat="server" class="form-control" placeholder="Prenom" Width="1115px" />
            </div>
            <div class="mb-3">
                <label>Telephone</label>
                <asp:TextBox ID="TextBox_Tel" runat="server" class="form-control" placeholder="Telephone" Width="1115px" />
            </div>
            <div class="mb-3">
                <label>Login</label>
                <asp:TextBox ID="TextBox_Login" runat="server" class="form-control" placeholder="Login" Width="1115px" />
            </div>
             <div class="mb-3">
                <label>Mot de Passe</label>
                <asp:TextBox ID="TextBox_MDP" runat="server" class="form-control" placeholder="Mot de Passe" Width="1115px" />
            </div>
            <asp:Button ID="Button_Ajouter" runat="server" class="btn btn-primary" Text="Ajouter"  />
        </div>
    </form>
</body>
</html>
