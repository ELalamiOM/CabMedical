<%@ Page Title="" Language="C#" MasterPageFile="~/Secretaires.Master" AutoEventWireup="true" CodeBehind="AccueilSecretaire.aspx.cs" Inherits="CabMedical.AccueilSecretaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Accueil</h1>
       <div class="container">
            <asp:GridView ID="GridView_RendezVousAddParUser" runat="server" class="container" OnRowDeleting="GridView_RendezVousAddParUser_RowDeleting" >
                <Columns>
                    <asp:CommandField DeleteText="Refuser" ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
        </div>

        <div class="container">
            <div class="mb-3">
                <label>Expéditeur :</label>
                <asp:TextBox ID="tbExpéditeur" runat="server" class="form-control" Width="1000px"  Disabled="true"/>
            </div>
            <div class="mb-3">
                <label>Destinataire :</label>
                <asp:TextBox ID="tbDestinataire" runat="server" class="form-control" Width="1000px" />
            </div>
            <div class="mb-3">
                <label>Objet :</label>
                <asp:TextBox ID="tb_Object" runat="server" class="form-control" Width="1000px" />
            </div>
            <div class="mb-3">
                <label>Message :</label><br />
                <asp:TextBox ID="tb_Message" TextMode="multiline" Columns="50" Rows="5" runat="server" Height="118px" Width="1000px" />
            </div>
            <div class="mb-3">
                <asp:Label ID="lblErreur" runat="server" />
            </div>
            <div>
                <asp:Button Text="Accepter et Envoyer" runat="server" OnClick="Unnamed1_Click" />
            </div>
        </div>
  
</asp:Content>
