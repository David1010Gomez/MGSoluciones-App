<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador.master" AutoEventWireup="true" CodeFile="Configuracion_Coordinador.aspx.cs" Inherits="Configuracion_Coordinador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C4').classList.add('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
    </script>
    <link href="Content/Busqueda_Coordinador.css?1.0.1" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold;">CONFIGURACIÓN DE CUENTA</h2>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Cédula:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Nombre:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Cedula"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Nombre"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Contraseña Antigua:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Nueva Contraseña:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Repita Nueva Contraseña:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Contraseña"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Nueva_Contraseña1"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Nueva_Contraseña2"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

