<%@ Page Title="" Language="C#" MasterPageFile="~/Secretaires.Master" AutoEventWireup="true" CodeBehind="RendezVous_Secretaire.aspx.cs" Inherits="CabMedical.RendezVous_Secretaire" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Rendez-vous</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <p class="h1">Rendez-vous</p>
        <div class="mb-3">
            <label>Code Rendez-vous</label>
            <asp:TextBox ID="TextBox_Code_RV" runat="server" class="form-control" Disabled="true"  />
        </div>
        <div class="mb-3">
            <label>Date Rendez-vous</label>
            <asp:TextBox ID="TextBox_Date_Rendezvous" runat="server" class="form-control" TextMode="Date" />
        </div>
        <div class="mb-3">
            <label>Heure Rendez-vous</label>
            <asp:TextBox ID="TextBox_Heure_Rendezvous" runat="server" class="form-control" TextMode="Time" />
        </div>
        <div class="mb-3">
            <label>Nom Prenom de Patient</label>
            <asp:DropDownList ID="DropDownList_Nom_Prenom" runat="server" class="form-control"></asp:DropDownList> 
        </div> 
        <div class="mb-3"> 
            <label>Nom Medecin</label>
            <asp:DropDownList ID="DropDownList_Med" runat="server" class="form-control"></asp:DropDownList>
        </div>
        <div class="mb-3">
            <label>Nom Secretaire</label>
            <asp:TextBox ID="TextBox_Sec" runat="server" class="form-control" Disabled="true" ></asp:TextBox>           
        </div>
        <asp:Button ID="Button_Ajouter" runat="server" class="btn btn-primary" Text="Ajouter" OnClick="Button_Ajouter_Click"  />  
        <br />
        <asp:Button ID="Button_Modifier" runat="server" class="btn btn-primary" Text="Modifier" OnClick="Button_Modifier_Click" />
        <asp:Label ID="LabelText" ></asp:Label>
    </div>
     <br />
    <div class="container">
            <asp:GridView ID="GridView_RendezVous" runat="server" class="container" OnRowDeleting="GridView_RendezVous_RowDeleting" OnSelectedIndexChanged="GridView_RendezVous_SelectedIndexChanged" AutoGenerateSelectButton="True" OnSelectedIndexChanging="GridView_RendezVous_SelectedIndexChanging"  >
                <Columns>                 
                    <asp:CommandField DeleteText="Supprimer" ShowDeleteButton="true"  />
                </Columns>
            </asp:GridView>
        </div>
</asp:Content>
