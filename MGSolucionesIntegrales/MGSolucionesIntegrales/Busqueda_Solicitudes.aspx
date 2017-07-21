<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Busqueda_Solicitudes.aspx.cs" Inherits="Busqueda_Solicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C2').classList.add('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');

        function Fijar_Tecnico() {
            var control = document.getElementById("<%=Lista_Tecnicos.ClientID%>");
            var Tecnico = control.options[control.selectedIndex].text;
            $('#<%=Nombre_Tecnico.ClientID%>').val(Tecnico)
            var x = document.getElementById('<%=Busqueda.ClientID%>');
            x.click();
        }
        <%--function Fijar_Tecnico2()
        {
            var control = document.getElementById("<%=Lista_Tecnicos.ClientID%>");
            var Tecnico = control.options[control.selectedIndex].text;
            $('#<%=Nombre_Tecnico.ClientID%>').val(Tecnico)
            var x = document.getElementById('<%=Busqueda.ClientID%>');
            x.click();
        }--%>
        function Fijar_Tecnico3() {
            var control = document.getElementById("<%=Lista_Tecnicos_Materiales.ClientID%>");
            var Tecnico = control.options[control.selectedIndex].text;
            $('#<%=Nombre_Tecnico_Materiales.ClientID%>').val(Tecnico)
            var x = document.getElementById('<%=Busqueda_Materiales.ClientID%>');
            x.click();
        }
        function editar(obj, obj2) {
            if (obj2 != 'CERRADO') {
                window.location.href = 'Solicitud.aspx?id_solicitud=' + obj + '&Estado_Caso=' + obj2;
            }
            else { alert('Los casos cerrados no se pueden editar'); }
        }
        function Cambia_Estado() {
            if (document.getElementById('<%=Reabrir.ClientID%>').checked) {
                $('#<%=Cambio_Estado.ClientID%>').val('AGENDADO');
            }
            else {
                $('#<%=Cambio_Estado.ClientID%>').val('');
            }
        }
    </script>
    <link href="Content/Busqueda_Coordinador.css?1.0.3" rel="stylesheet" />
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script src="assets/js/jquery.datetimepicker.full.js"></script>
    <link href="Content/jquery.datetimepicker.css" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="4u 12u(mobile)">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold">Consulta Notas Solicitudes</h2>
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
                                        <asp:TextBox ID="Fecha_Inicial_Notas" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" AutoPostBack="true" OnTextChanged="Fecha_Inicial_Notas_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Fecha_Final_Notas" CssClass="inp_form" placeholder="Fecha Final" runat="server" AutoPostBack="true" OnTextChanged="Fecha_Final_Notas_TextChanged"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Exp_Notas" CssClass="inp_form" runat="server" placeholder="Exp" AutoPostBack="true" OnTextChanged="Exp_Notas_TextChanged"></asp:TextBox>
                                    </td>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <%--<td>
                                         <asp:DropDownList ID="Lista_Tecnicos_Notas" CssClass="Lista_Tecnicos"  style="width: 125%;"  runat="server" >
                                            
                                        </asp:DropDownList>
                                    </td>--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <%--<asp:TextBox runat="server" ID="Nombre_Tecnico_Notas" style="display:none;"></asp:TextBox>--%>
                                    <%--<asp:Button ID="Busqueda_Notas" runat="server" OnClick="Busqueda_Notas_Click" style="display:none;"/>--%>
                                </tr>
                            </table>
                            <script>
                                $('#<%=Fecha_Inicial_Notas.ClientID%>').datetimepicker({
                                    format: 'Y-m-d',
                                    minDate: '2017/06/01',
                                    maxDate: '+0d',
                                    timepicker: false
                                });

                                $('#<%=Fecha_Final_Notas.ClientID%>').datetimepicker({
                                    format: 'Y-m-d',
                                    onShow: function (ct) {
                                        this.setOptions({
                                            minDate: $('#<%=Fecha_Inicial_Notas.ClientID%>').val() ? $('#<%=Fecha_Inicial_Notas.ClientID%>').val() : false
                                    })
                                },
                                maxDate: '+0d',
                                timepicker: false
                            });
                            </script>
                        </div>
                        <br />
                        <asp:GridView ID="GridView2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2"
                            Style="border-collapse: collapse; width: 100%; text-align: center;" AllowPaging="true" OnPageIndexChanging="GridView2_PageIndexChanging">
                            <Columns>

                                <asp:BoundField DataField="NUM_EXP" HeaderText="Num Exp." />
                                <asp:BoundField DataField="FECHA_NOTA" HeaderText="Fecha Nota" />
                                <asp:BoundField DataField="OBSERVACIONES" HeaderText="Observaciones" />

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
                        <asp:Button runat="server" ID="Desacarga_Base_Notas" CssClass="button" Text="Descargar" OnClick="Desacarga_Base_Notas_Click" Style="text-transform: none; float: right;" />
                        <br />
                        <br />
                    </section>
                    <section>
                        <h2 style="text-transform: none; font-weight: bold">Consulta Materiales Solicitudes</h2>
                        <div class="Div_Table">
                            <table style="width: 95%;">
                                <tr>
                                    <td colspan="2" style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Busqueda por rango de fechas:</p>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Búsqueda por Exp:</p>
                                    </td>
                                    <td>
                                        <p class="comments">Búsqueda por técnico:</p>
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
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <td>
                                                <asp:DropDownList ID="Lista_Tecnicos_Materiales" CssClass="Lista_Tecnicos" Style="width: 125%;" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:TextBox runat="server" ID="Nombre_Tecnico_Materiales" Style="display: none;"></asp:TextBox>
                                    <asp:Button ID="Busqueda_Materiales" runat="server" OnClick="Busqueda_Materiales_Click" Style="display: none;" />
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
                        <asp:GridView ID="GridView3" runat="server" BackColor="#CCCCCC" BorderColor="#999999" AllowPaging="true"
                            OnPageIndexChanging="GridView3_PageIndexChanging" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False"
                            CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                            <Columns>
                                <asp:BoundField DataField="MATERIAL" HeaderText="Material" />
                                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                                <asp:BoundField DataField="CEDULA_TECNICO" HeaderText="Cedula Técnico" />
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
                        <asp:Button runat="server" ID="Desacarga_Base_Materiales" CssClass="button" Text="Descargar" OnClick="Desacarga_Base_Materiales_Click" Style="text-transform: none; float: right;" />
                    </section>
                    <br />
                    <br />
                </div>
                <div class="8u 12u(mobile) important(mobile)" style="text-align: justify;">
                    <section class="right-content">
                        <h2 style="text-transform: none; font-weight: bold">Consulta General de Solicitudes</h2>
                        <div class="Div_Table">
                            <table style="width: 95%;">
                                <tr>
                                    <td colspan="2" style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Busqueda por rango de fechas:</p>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Búsqueda por Exp:</p>
                                    </td>
                                    <td>
                                        <p class="comments">Búsqueda por técnico:</p>
                                    </td>
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
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <td>
                                                <asp:DropDownList ID="Lista_Tecnicos" CssClass="Lista_Tecnicos" Style="width: 125%;" runat="server">
                                                </asp:DropDownList>
                                            </td>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:TextBox runat="server" ID="Nombre_Tecnico" Style="display: none;"></asp:TextBox>
                                    <asp:Button ID="Busqueda" runat="server" OnClick="Busqueda_Click" Style="display: none;" />
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
                            Style="border-collapse: collapse; width: 100%; text-align: center;" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                        <asp:Button runat="server" ID="Desacarga_Base" CssClass="button" Text="Descargar" OnClick="Desacarga_Base_Click" Style="text-transform: none; float: right;" />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <h3 style="text-transform: none; font-weight: bold">Re-Apertura de Casos</h3>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td>
                                        <p class="comments">Digite Exp:</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Exp_Reapertura_Casos" CssClass="inp_form" runat="server" placeholder="Exp"
                                            AutoPostBack="true" Width="50%" OnTextChanged="Exp_Reapertura_Casos_TextChanged"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div class="Div_Table" style=" background-color: rgba(0,0,0,0.4);">
                            <table style="width:100%" >
                                <tr>
                                    <td>
                                        <p class="comments">Id Solicitud:</p>
                                    </td>
                                    <td>
                                        <p class="comments">Numero Exp.:</p>
                                    </td>
                                    <td>
                                        <p class="comments">Estado Caso Actualmente:</p>
                                    </td>
                                    <td>
                                        <p class="comments">Re-Abrir:</p>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Id_Solicitud_ReAbrir" CssClass="inp_form" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="NumExpReaAbrir" CssClass="inp_form" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="EstadoReaAbrir" CssClass="inp_form" runat="server" ReadOnly="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="Reabrir" runat="server" Style="margin-left: 50%;" />
                                        <asp:TextBox runat="server" ID="Cambio_Estado" Style="display: none;"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <p class="comments">Notas:</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:TextBox ID="Notas_Reapertura" CssClass="inp_form_Observ" TextMode="MultiLine" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <asp:Button ID="Actualiza_Estado_caso" runat="server" CssClass="button" Text="Actualiza Estado" OnClick="Actualiza_Estado_caso_Click"
                             Style="text-transform: none; font-size: 0.9em; padding: 7px;" />
                    </section>

                </div>

            </div>
        </div>
    </div>

</asp:Content>

