<%@ Page Title="" Language="C#" MasterPageFile="~/Medecins.Master" AutoEventWireup="true" CodeBehind="OrdonnanceData.aspx.cs" Inherits="CabMedical.OrdonnanceData" %>
<%@ Register assembly="CrystalDecisions.Web, Version=13.0.4000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>
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
            <asp:GridView ID="GridView_Ordonnance" runat="server" class="container" OnRowDeleting="GridView_Ordonnance_RowDeleting" AutoGenerateSelectButton="True" OnSelectedIndexChanging="GridView_Ordonnance_SelectedIndexChanging" >
                <Columns>
                    <asp:CommandField DeleteText="supprimer " ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
    </div>
        <div class="container">
        <div class="mb-3">
            <label>Numero  Ordonnance :</label>
            <asp:TextBox ID="Textox_Numero_Ordonnance" runat="server" class="form-control" Width="1000px" Disabled="true" />
        </div>
        <div class="mb-3">
            <label>Date Ordonnance :</label>
            <asp:TextBox ID="TextBox_Date_Ordonnance" runat="server" class="form-control" Width="1000px" TextMode="Date" />
        </div>
        <div class="mb-3">
            <label>Ville  :</label>
            <asp:TextBox ID="TextBox_Ville" runat="server" class="form-control" Width="1000px" />
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
        <div class="mb-3">
            <label>Consultation   :</label>
            <asp:TextBox ID="TextBox_Consultation" runat="server" class="form-control"></asp:TextBox>
        </div>
        <asp:Button ID="Button_Actualiser" runat="server" class="btn btn-primary" Text="Actualiser" OnClick="Button_Actualiser_Click"  />
        <asp:Button ID="Btn_Modifier" runat="server" class="btn btn-primary" Text="Modifier" OnClick="Btn_Modifier_Click" />    
    </div>
    <div class="container">
        <div class="mb-3">
            <label>Numero  Ordonnance  :</label>
            <asp:TextBox ID="TextBox_Num_Ordonnance" runat="server" class="form-control" Width="1000px"  />
        </div>
        <asp:Button ID="Button_Imprimer" runat="server" class="btn btn-primary" Text="Imprimer" OnClick="Button_Imprimer_Click" />        
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" />
        
    </div>
</asp:Content>
