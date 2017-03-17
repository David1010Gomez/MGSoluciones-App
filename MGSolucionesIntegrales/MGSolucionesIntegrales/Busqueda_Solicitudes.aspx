<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Busqueda_Solicitudes.aspx.cs" Inherits="Busqueda_Solicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C2').classList.add('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <link href="Content/Busqueda_Solicitudes.css" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u" style="text-align: justify;">
                    <section class="right-content">
                        <h2 style="text-transform: none; font-weight: bold">Formulario para la Consulta de Solicitudes</h2>
                        <%--<p>Seleccione segun desee consultar:</p>--%>
                        <hr />
                        <asp:Panel runat="server" Style="padding: 10px; overflow: hidden;">
                            
                                <table>
                                    <tr>
                                        <td style="width: 180px;">
                                            <asp:Label CssClass="Texto" runat="server">Seleccione un rango de fechas </asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <input class="input" type="text" placeholder="Fecha 1" />
                                        </td>
                                        <td>
                                            <input class="input" type="text" placeholder="Fecha 2" />
                                        </td>
                                    </tr>
                                </table>
                            
                            <table >
                                <tr>
                                    <td >
                                        <asp:Label CssClass="Texto" runat="server">Digite Exp.: </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input class="input" type="text" placeholder="Exp." />
                                    </td>
                                </tr>
                            </table>
                            <table >
                                <tr>
                                    <td >
                                        <asp:Label CssClass="Texto" runat="server">Cédula del coordinador </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <input class="input" type="text" placeholder="Cedula Coordinador" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </section>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

