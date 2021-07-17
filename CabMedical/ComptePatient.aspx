<%@ Page Title="" Language="C#" MasterPageFile="~/Secretaires.Master" AutoEventWireup="true" CodeBehind="ComptePatient.aspx.cs" Inherits="CabMedical.ComptePatient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>xxxxxx</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>
    <script src='https://kit.fontawesome.com/a076d05399.js' crossorigin='anonymous'></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <div class="container">
                <div class="mb-3">
                <label> Code Patient</label>
                <asp:TextBox ID="TextBox_Code_Patient" runat="server" class="form-control" Disabled="true" />
            </div>
            <div class="mb-3">
                <label> Nom et Prenom</label>
                <asp:TextBox ID="TextBox_Nom_Prenom_Patient" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label>email</label>
                <asp:TextBox ID="TextBox_Email_Patient" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label>Adresse</label>
                <asp:TextBox ID="TextBox_Adresse_Patient" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label>Sexe</label>
                <%--<asp:TextBox ID="TextBox_Sexe_Patient" runat="server" class="form-control" />--%>
                <asp:DropDownList ID="DropDownList_Sexe_Patient" runat="server" class="form-control">
                    <asp:ListItem Text="Homme" Value="Homme"></asp:ListItem>
                    <asp:ListItem Text="Femme" Value="Femme"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label>Situation Familiale</label>
                <%--<asp:TextBox ID="TextBox_SituationFamiliale" runat="server" class="form-control" />--%>
                <asp:DropDownList ID="DropDownList_SituationFamiliale" runat="server" class="form-control">
                    <asp:ListItem Text="marié" Value="marié"></asp:ListItem>
                    <asp:ListItem Text="pacsé" Value="pacsé"></asp:ListItem>
                    <asp:ListItem Text="divorcé" Value="divorcé"></asp:ListItem>
                    <asp:ListItem Text="séparé" Value="séparé"></asp:ListItem>
                    <asp:ListItem Text="célibataire" Value="célibataire"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label>Date Naissance</label>
                <asp:TextBox ID="TextBox_DateNaissance" runat="server" class="form-control" TextMode="Date" />
            </div>
            <div class="mb-3">
                <label>Lieu de Naissance</label>
                <asp:TextBox ID="TextBox_Lieu_Naissance" runat="server" class="form-control" />
            </div>
            <div class="mb-3">
                <label>Telephone</label>
                <asp:TextBox ID="TextBox_Tel_Patient" runat="server" class="form-control" />
            </div>
            <asp:Button ID="Button_Ajouter_Patient" runat="server" class="btn btn-primary" Text="Ajouter" OnClick="Button_Ajouter_Patient_Click" />
            <asp:Button ID="Button_Modifier_Patient" runat="server" class="btn btn-primary" Text="Modifier" OnClick="Button_Modifier_Patient_Click" />
        </div>
    <br />
    <div class="container">
            <asp:GridView ID="GridView_Patient" runat="server" class="container" OnRowDeleting="GridView_Patient_RowDeleting" OnSelectedIndexChanging="GridView_Patient_SelectedIndexChanging" AutoGenerateSelectButton="True" >
                <Columns>
                    <asp:CommandField DeleteText="Supprimer" ShowDeleteButton="True" />
                </Columns>
                
            </asp:GridView>
        </div>

</asp:Content>
