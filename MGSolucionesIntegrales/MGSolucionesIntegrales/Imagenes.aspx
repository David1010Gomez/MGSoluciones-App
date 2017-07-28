<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico.master" AutoEventWireup="true" CodeFile="Imagenes.aspx.cs" Inherits="Imagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C2').classList.add('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
    </script>
</asp:Content>

