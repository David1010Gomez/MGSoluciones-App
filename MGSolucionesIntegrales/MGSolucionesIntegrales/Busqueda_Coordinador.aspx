<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador.master" AutoEventWireup="true" CodeFile="Busqueda_Coordinador.aspx.cs" Inherits="Busqueda_Coordinador" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        document.getElementById('C3').classList.add('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <script>
        function Fijar_Tecnico()
        {
            var control = document.getElementById("<%=Lista_Tecnicos.ClientID%>");
            var Tecnico = control.options[control.selectedIndex].text;
            $('#<%=Nombre_Tecnico.ClientID%>').val(Tecnico)
            var x = document.getElementById('<%=Busqueda.ClientID%>');
            x.click();
        }
    </script>
    <link href="Content/Busqueda_Coordinador.css?1.0.2" rel="stylesheet" />
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script src="assets/js/jquery.datetimepicker.full.js"></script>
    <link href="Content/jquery.datetimepicker.css" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold;">BÚSQUEDA DE CASOS</h2>
                        <div class="Div_Table">
                            <table>
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
                                <%--<tr>
                                    <td>
                                        <asp:Label runat="server">Fecha Inicial:</asp:Label>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:Label runat="server">Fecha Final:</asp:Label>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:Label runat="server">Exp:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server"></asp:Label>
                                    </td>
                                </tr>--%>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Fecha_Inicial" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" OnTextChanged="Fecha_Inicial_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td >
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Fecha_Final" CssClass="inp_form" placeholder="Fecha Final" runat="server" OnTextChanged="Fecha_Final_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Exp"  CssClass="inp_form" runat="server" placeholder="Exp" AutoPostBack="true" OnTextChanged="Exp_TextChanged"></asp:TextBox>
                                    </td>
                                    <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                    <td>
                                         <asp:DropDownList ID="Lista_Tecnicos" CssClass="Lista_Tecnicos"  style="width: 125%;"  runat="server" >
                                            
                                        </asp:DropDownList>
                                    </td>
                                    </ContentTemplate></asp:UpdatePanel>
                                    <asp:TextBox runat="server" ID="Nombre_Tecnico" style="display:none;"></asp:TextBox>
                                    <asp:Button ID="Busqueda" runat="server" style="display:none;" OnClick="Busqueda_Click"/>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="FECHA_INGRESO" HeaderText="Fecha de Ingreso" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Numero EXP" />
                                <asp:BoundField DataField="POLIZA" HeaderText="Poliza" />
                                <asp:BoundField DataField="ASEGURADO" HeaderText="Asegurado" />
                                <asp:BoundField DataField="CONTACTO" HeaderText="Contacto" />
                                <asp:BoundField DataField="FACT" HeaderText="Fact." />
                                <asp:BoundField DataField="TECNICO" HeaderText="Técnico" />
                                <asp:BoundField DataField="CEDULA_TECNICO" HeaderText="Cédula del Técnico" />
                                <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
                                <asp:BoundField DataField="ESTADO_CASO" HeaderText="Estado Caso" />
                                <asp:BoundField DataField="CEDULA_USUARIO_CREACION" HeaderText="Cedula Usuario Creacion" />
                                <asp:BoundField DataField="FECHA_CIERRE" HeaderText="Fecha de Cierre" />
                                <asp:BoundField DataField="CEDULA_USUARIO_CIERRE" HeaderText="Cédula Usuario Cierre" />
                                <asp:BoundField DataField="USUARIO_ULTIMA_ACTUALIZACION" HeaderText="Usuario Ultima Actualización" />
                                <asp:BoundField DataField="FECHA_NOTA" HeaderText="Fecha Nota" />
                                <asp:BoundField DataField="OBSERVACIONES" HeaderText="Observaciones" />
                                <asp:BoundField DataField="CEDULA_USUARIO_INSERTO_NOTA" HeaderText="Cédula Usuario Inserto Nota" />
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
                        <script>
                        $('#<%=Fecha_Inicial.ClientID%>').datetimepicker({
                            format: 'Y-m-d',
                            minDate: '2016/09/01',
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
                        <br />
                        <br />
                        <asp:Button runat="server" ID="Desacarga_Base" CssClass="button" Text="Descargar" OnClick="Desacarga_Base_Click" Style="text-transform: none; float:right;" />
                        <br />

                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

