<%@ Page Title="" Language="C#" MasterPageFile="~/Medecins.Master" AutoEventWireup="true" CodeBehind="ConsultatioData.aspx.cs" Inherits="CabMedical.ConsultatioData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Data</h1>
    <div class="container">
            <asp:GridView ID="GridView_RendezVousAddParUser" runat="server" class="container" AutoGenerateSelectButton="True" OnRowDeleting="GridView_RendezVousAddParUser_RowDeleting" OnSelectedIndexChanging="GridView_RendezVousAddParUser_SelectedIndexChanging"  >
                <Columns>
                    <asp:CommandField DeleteText="Supprimer" ShowDeleteButton="True" />
                </Columns>             
            </asp:GridView>
     </div>
    <div class="container">
        <div class="mb-3">
            <label>Numero  Consultation :</label>
            <asp:TextBox ID="Textox_Numero_Consultation" runat="server" class="form-control" Width="1000px" Disabled="true" />
        </div>
        <div class="mb-3">
            <label>Date Consultation :</label>
            <asp:TextBox ID="TextBox_Date_Consulation" runat="server" class="form-control" Width="1000px" TextMode="Date" />
        </div>
        <div class="mb-3">
            <label>Prix  :</label>
            <asp:TextBox ID="TextBox_Prix" runat="server" class="form-control" Width="1000px" />
        </div>
        <div class="mb-3">
            <label>Description   :</label>
            <asp:TextBox ID="TextBox1_Description" runat="server" class="form-control" Width="1000px" />
        </div>
        <div class="mb-3">
            <label>Medecin   :</label>
            <asp:TextBox ID="TextBox_Medecin" runat="server" class="form-control" Width="1000px" Disabled="true" />
        </div>
        <div class="mb-3">
            <label>Patient   :</label>
            <asp:DropDownList ID="DropDownList_Patient" runat="server" class="form-control"></asp:DropDownList>
        </div>
        <asp:Button ID="Btn_Modifier" runat="server" class="btn btn-primary" Text="Modifier" OnClick="Btn_Modifier_Click" />
    </div>
</asp:Content>
