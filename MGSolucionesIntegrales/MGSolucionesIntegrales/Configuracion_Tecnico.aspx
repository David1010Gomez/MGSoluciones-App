<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico.master" AutoEventWireup="true" CodeFile="Configuracion_Tecnico.aspx.cs" Inherits="Configuracion_Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C4').classList.add('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
    </script>
    <link href="Content/Busqueda_Coordinador.css?1.0.1" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold;">Configuración de Cuenta</h2>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Cédula:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Nombre:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Cargo:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label CssClass="comments" runat="server">Disponibilidad:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Cedula" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Nombre" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Cargo" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox runat="server" CssClass="inp_form" ID="Disponibilidad" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <input runat="server" id="Contra_Actual" type="hidden"  />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <h3 style="text-transform: none; font-weight: bold">Cambio de Contraseña</h3>
                            <table>
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
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <div class="controls" style="float: right;">
                                            <asp:Button runat="server" CssClass="button" ID="Actualiza" Text="Guardar" Style="text-transform: none;" OnClick="Actualiza_Click" />
                                        </div>
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

