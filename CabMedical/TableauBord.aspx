<%@ Page Title="" Language="C#" MasterPageFile="~/Medecins.Master" AutoEventWireup="true" CodeBehind="TableauBord.aspx.cs" Inherits="CabMedical.TableauBord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js" integrity="sha384-IQsoLXl5PILFhosVNubq5LC7Qb9DXgDA9i+tQ8Zj3iwWAwPtgFTxbJ8NT4GN1R8p" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.min.js" integrity="sha384-cVKIPhGWiC2Al4u+LWgxfKTRIcfu0JTxR+EQDz/bgldoEyl4H0zUF0QKbrJ0EcQF" crossorigin="anonymous"></script>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.0/jquery.min.js"></script>
    <link rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/themes/smoothness/jquery-ui.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jqueryui/1.12.1/jquery-ui.min.js"></script>

    <script src="ChartJS.js"></script>

     
</asp:Content>

             <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




  
    <div class="container">
  <div class="row">
    <div class="col">
            <asp:Literal ID="ltChart" runat="server" ></asp:Literal>
    </div>
<%--    <div class="col"> 
        <asp:Literal ID="ltChart1" runat="server" ></asp:Literal></div>--%>
  </div>
</div>

  <%--<script type="text/javascript">
        $('#DSurvey').datepicker({
            //todayHighlight: true,
            orientation: "bottom left",
            format: "mm/yyyy",
            startView: "months",
            minViewMode: "months"
        });
  </script>
  --%>

                  <script>
                      $(function () {
                          $('#DSurvey').datetimepicker({
                              //todayHighlight: true,
                              orientation: "bottom left",
                              format: "mm/yyyy",
                              startView: "months",
                              minViewMode: "months"
                          });
                      });
                  </script>

</asp:Content>
