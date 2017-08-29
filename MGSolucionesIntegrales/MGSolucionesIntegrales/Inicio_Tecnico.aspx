<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico.master" AutoEventWireup="true" CodeFile="Inicio_Tecnico.aspx.cs" Inherits="Inicio_Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C1').classList.add('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <br />
    <div id="main">
            <div class="container">
                <h2 style="text-transform: none; font-weight: bold">Inicio Tecnico</h2>
            </div>
        </div>
</asp:Content>

