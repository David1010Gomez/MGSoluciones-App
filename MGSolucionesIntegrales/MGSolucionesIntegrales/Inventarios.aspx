<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Inventarios.aspx.cs" Inherits="Inventarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C5').classList.add('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
    </script>
</asp:Content>

