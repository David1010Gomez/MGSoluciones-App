<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico.master" AutoEventWireup="true" CodeFile="Busqueda_Tecnico.aspx.cs" Inherits="Busqueda_Tecnico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C3').classList.add('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <link href="Content/Busqueda_Coordinador.css?1.0.3" rel="stylesheet" />
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script src="assets/js/jquery.datetimepicker.full.js"></script>
    <link href="Content/jquery.datetimepicker.css" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="8u 12u(mobile) important(mobile)">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold">Consulta Solicitudes</h2>
                        <div class="Div_Table">
                            <table style="width: 95%;">
                                <tr>
                                    <td colspan="2" style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Busqueda por rango de fechas:</p>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Búsqueda por Exp:</p>
                                    </td>
                                    <%--<td>
                                        <p class="comments">Búsqueda por técnico:</p>
                                    </td>--%>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:TextBox ID="Fecha_Inicial" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" AutoPostBack="true" OnTextChanged="Fecha_Inicial_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Fecha_Final" CssClass="inp_form" placeholder="Fecha Final" runat="server" AutoPostBack="true" OnTextChanged="Fecha_Final_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Exp" CssClass="inp_form" runat="server" placeholder="Exp" AutoPostBack="true" OnTextChanged="Exp_TextChanged"></asp:TextBox>
                                    </td>
                                   
                                </tr>
                            </table>
                            <script>
                                $('#<%=Fecha_Inicial.ClientID%>').datetimepicker({
                                    format: 'Y-m-d',
                                    minDate: '2017/06/01',
                                    maxDate: '+0d',
                                    timepicker: false
                                });

                                $('#<%=Fecha_Final.ClientID%>').datetimepicker({
                                    format: 'Y-m-d',
                                    onShow: function (ct) {
                                        this.setOptions({
                                            minDate: $('#<%=Fecha_Inicial.ClientID%>').val() ? $('#<%=Fecha_Inicial.ClientID%>').val() : false
                                    })
                                },
                                maxDate: '+0d',
                                timepicker: false
                            });
                            </script>
                        </div>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2"
                            Style="border-collapse: collapse; width: 100%; text-align: center;" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" >
                            <Columns>

                                <asp:BoundField DataField="FECHA_INGRESO" HeaderText="Fecha de Ingreso" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Numero EXP" />
                                <asp:BoundField DataField="POLIZA" HeaderText="Poliza" />
                                <asp:BoundField DataField="ASEGURADO" HeaderText="Asegurado" />
                                <asp:BoundField DataField="CONTACTO" HeaderText="Contacto" />
                                <asp:BoundField DataField="FACT" HeaderText="Fact." />
                                <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
                                <asp:BoundField DataField="ESTADO_CASO" HeaderText="Estado Caso" />
                                <%--<asp:BoundField DataField="CEDULA_USUARIO_CREACION" HeaderText="Cedula Usuario Creacion" />--%>
                                <%--<asp:BoundField DataField="FECHA_CIERRE" HeaderText="Fecha de Cierre" />
                                <asp:BoundField DataField="CEDULA_USUARIO_CIERRE" HeaderText="Cédula Usuario Cierre" />--%>
                                <%--<asp:BoundField DataField="USUARIO_ULTIMA_ACTUALIZACION" HeaderText="Usuario Ultima Actualización" />--%>
                                <asp:BoundField DataField="VALOR_TRABAJO" HeaderText="Valor Trabajo" />
                                <asp:BoundField DataField="VALOR_TOTAL" HeaderText="Valor Total" />
                                <%--<asp:BoundField DataField="CEDULA_TECNICO" HeaderText="Cédula Técnico" />--%>
                                <asp:BoundField DataField="NOMBRE_TECNICO" HeaderText="Nombre Tecnico" />
                                <asp:BoundField DataField="SERVICIO" HeaderText="Servicio" />
                                <asp:BoundField DataField="FECHA_TURNO" HeaderText="Fecha Turno" />
                                <%--<asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar("<%# Eval("ID") %>", "<%# Eval("ESTADO_CASO") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                            </Columns>
                            <EmptyDataTemplate>La Consulta No Arrojo Ningun Resultado</EmptyDataTemplate>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                        <br />
                        <asp:Button runat="server" ID="Desacarga_Base" CssClass="button" Text="Descargar" Style="text-transform: none; float: right;" OnClick="Desacarga_Base_Click" />
                        <br />
                        <br />
                    </section>
                </div>
                <div class="4u 12u(mobile)">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold">Consulta Materiales</h2>
                        <div class="Div_Table">
                            <table style="width: 95%;">
                                <tr>
                                    <td colspan="2" style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Busqueda por rango de fechas:</p>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Búsqueda por Exp:</p>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <asp:TextBox ID="Fecha_Inicial_Materiales" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" AutoPostBack="true" OnTextChanged="Fecha_Inicial_Materiales_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Fecha_Final_Materiales" CssClass="inp_form" placeholder="Fecha Final" runat="server" AutoPostBack="true" OnTextChanged="Fecha_Final_Materiales_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Exp_Materiales" CssClass="inp_form" runat="server" placeholder="Exp" AutoPostBack="true" OnTextChanged="Exp_Materiales_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <script>
                                $('#<%=Fecha_Inicial_Materiales.ClientID%>').datetimepicker({
                                    format: 'Y-m-d',
                                    minDate: '2017/06/01',
                                    maxDate: '+0d',
                                    timepicker: false
                                });

                                $('#<%=Fecha_Final_Materiales.ClientID%>').datetimepicker({
                                    format: 'Y-m-d',
                                    onShow: function (ct) {
                                        this.setOptions({
                                            minDate: $('#<%=Fecha_Inicial_Materiales.ClientID%>').val() ? $('#<%=Fecha_Inicial_Materiales.ClientID%>').val() : false
                                    })
                                },
                                maxDate: '+0d',
                                timepicker: false
                            });
                            </script>
                        </div>
                        <br />
                        <asp:GridView ID="GridView2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" AllowPaging="true"
                            BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False"
                            CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;" OnPageIndexChanging="GridView2_PageIndexChanging">
                            <Columns>
                                <%--<asp:BoundField DataField="ID_SOLICITUD" HeaderText="Id Solicitud" />--%>
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Num. EXP." />
                                <asp:BoundField DataField="MATERIAL" HeaderText="Material" />
                                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                                <asp:BoundField DataField="PRECIO_UNIDAD" HeaderText="Precio Unitario" />
                                <asp:BoundField DataField="PRECIO_TOTAL" HeaderText="Precio Total" />

                            </Columns>
                            <EmptyDataTemplate>La Consulta No Arrojo Ningun Resultado</EmptyDataTemplate>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>

                        <br />
                        <asp:Button runat="server" ID="Desacarga_Base_Materiales" CssClass="button" Text="Descargar"  Style="text-transform: none; float: right;" OnClick="Desacarga_Base_Materiales_Click" />
                    </section>
                </div>
            </div>
        </div>
    </div>

</asp:Content>

