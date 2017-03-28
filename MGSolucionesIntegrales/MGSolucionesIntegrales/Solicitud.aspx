<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador.master" AutoEventWireup="true" CodeFile="Solicitud.aspx.cs" Inherits="Solicitud" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        document.getElementById('C2').classList.add('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <link href="Content/Solicitud.css?1.0.6" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="3u 12u(mobile)"  style="margin-top:50px;">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold"> Agendar Casos</h3>
                        <asp:GridView ID="GridView2" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Fila1" HeaderText="Fila 1" />
                                <asp:BoundField DataField="Fila2" HeaderText="Fila 2" />
                            </Columns>
                            <EmptyDataTemplate>No Existen casos para Agendar</EmptyDataTemplate>
                        </asp:GridView>
                    </section>


                </div>
                <div class="6u 12u(mobile) important(mobile)" style="text-align: justify;">
                    <section class="middle-content">
                        <h2 style="text-transform: none; font-weight: bold"> SOLICITUD</h2>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Exp:</asp:Label>
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
                            <table>
                                <tr>
                                    <td>
                                        <div id="Div_Materiales" runat="server" style="text-align: center;"><a href="#Materiales">Agregar Materiales</a></div>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label runat="server">Observaciones:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox CssClass="inp_form_Observ" TextMode="MultiLine" runat="server" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <div class="controls" style="float: right;">
                                            <asp:Button runat="server" CssClass="button" Text="Guardar" Style="text-transform: none;" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </section>
                </div>
                <div class="3u 12u(mobile)" style="margin-top:50px;">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold">Asignar Tecnico</h3>
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Fila1" HeaderText="Fila 1" />
                                <asp:BoundField DataField="Fila2" HeaderText="Fila 2" />
                            </Columns>
                            <EmptyDataTemplate>No Existen casos para asignar</EmptyDataTemplate>
                        </asp:GridView>
                    </section>
                </div>
                <div class="12u">
					    <section >
					    <h3 style="text-transform: none; font-weight: bold; text-align: center">Editar y Cerrar Casos</h3>
                            <asp:GridView ID="GridView3" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Fila1" HeaderText="Fila 1" />
                                <asp:BoundField DataField="Fila2" HeaderText="Fila 2" />
                            </Columns>
                            <EmptyDataTemplate>No Existen casos para asignar</EmptyDataTemplate>
                        </asp:GridView>
                    </section>
                </div>

            </div>
        </div>
    </div>

    <div class="modal-wrapper" id="Materiales">
        <div class="Materiales-contenedor">
            <a class="Materiales-cerrar" href="#">X</a>
            <h2 style="text-transform: none;">Materiales de Solicitud</h2>
            <hr />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <p class="comments">Marque los materiales a agregar: </p>

                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

