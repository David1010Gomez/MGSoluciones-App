<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C3').classList.add('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <div id="main">
        <div class="container">
                <h2 style="text-transform: none; font-weight: bold">Administracion de Usuarios</h2>
        </div>
    </div>
</asp:Content>

