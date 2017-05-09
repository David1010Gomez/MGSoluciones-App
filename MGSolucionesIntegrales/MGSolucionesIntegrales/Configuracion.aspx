<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Configuracion.aspx.cs" Inherits="Configuracion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.add('current-page-item');
    </script>
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u">
                    <h2 style="text-transform: none; font-weight: bold">CONFIGURACIÓN DE CUENTA</h2>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

