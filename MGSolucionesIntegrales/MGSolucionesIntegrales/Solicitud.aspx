<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador.master" AutoEventWireup="true" CodeFile="Solicitud.aspx.cs" Inherits="Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C2').classList.add('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <link href="Content/Solicitud.css?1.0.2" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u" style="text-align: justify;">
                    <section class="right-content">
                        <h2 style="text-transform: none; font-weight: bold">Crear Solicitud</h2>
                        <%--<p>Seleccione segun desee consultar:</p>--%>
                        <div class="Div_Table">
                        <table>
                            <tr>
                                <td colspan="2">
                                    <asp:Label  runat="server">Exp:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server">Poliza:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:TextBox CssClass="inp_form" ID="Exp" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="inp_form" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label runat="server">Asegurado:</asp:Label>
                                </td>
                                
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox CssClass="inp_form" runat="server"></asp:TextBox>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server">Contacto:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server">Fact:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server">Tecnico:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox CssClass="inp_form" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="inp_form" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:DropDownList CssClass="Lista_Tecnicos" runat="server">
                                        <asp:ListItem>Opcion 1</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:Label runat="server">Direccion:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:TextBox CssClass="inp_form" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                            <br />
                            <br />
                        </div>
                    </section>
                    <section class="left-content">
                        <h2 style="text-transform: none; font-weight: bold">Casos para Asignar</h2>
                    </section>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

