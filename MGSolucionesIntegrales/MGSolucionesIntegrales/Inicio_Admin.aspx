<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Inicio_Admin.aspx.cs" Inherits="Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C1').classList.add('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <%--<div id="banner-wrapper">
            <div class="container">

                <div id="banner">
                    <h2>Put something cool here!</h2>
                    <span>And put something almost as cool here, but a bit longer ...</span>
                </div>

            </div>
        </div>--%>
    <br />
        <div id="main">
            <div class="container">
                <h2 style="text-transform: none; font-weight: bold">Inicio Administrador</h2>
            </div>
        </div>
</asp:Content>

