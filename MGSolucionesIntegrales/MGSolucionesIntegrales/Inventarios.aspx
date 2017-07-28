<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Inventarios.aspx.cs" Inherits="Inventarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="Content/Solicitud.css?1.1.5" rel="stylesheet" />
    <script>
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C5').classList.add('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');

        function Limpiar_Campos() {
            window.location.href = 'Inventarios.aspx';
        }
        function editar(obj) {
            $('#<%=Id_Material.ClientID%>').val(obj);
            $('#<%=Accion.ClientID%>').val('UPDATE');
            var x = document.getElementById('<%=Cargar_Material.ClientID%>');
            x.click();
        }
        function editar2(obj) {
            $('#<%=Id_Servicio.ClientID%>').val(obj);
            $('#<%=Accion_Servicio.ClientID%>').val('UPDATE');
            
            var x = document.getElementById('<%=Tipo_Servicio.ClientID%>');
            x.click();
        }
        function Cambia_Estado() {
            if (!document.getElementById('<%=EstadoEliminar.ClientID%>').checked) {
                $('#<%=Accion_Servicio.ClientID%>').val('UPDATE');
            }
            else {
                $('#<%=Accion_Servicio.ClientID%>').val('DELETE');
            }
        }
    </script>

    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="3u 12u(mobile)" style="margin-top: 50px;">
                    <section class="right-content">
                        <h3 style="text-transform: none; font-weight: bold; text-align: center;" >Creación/Modificación de Inventarios</h3>
                        <a onclick="Limpiar_Campos();" style="margin-left: 80%; text-decoration: none; cursor: pointer;">Limpiar</a>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Material:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Material_Inv" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Cantidad:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Cantidad_Inv" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Precio:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Precio_Inv" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                
                            </table>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <div class="controls" style="float: right;">
                                            <asp:Button runat="server" CssClass="button" ID="Guarda_Material" Text="Guardar" Style="text-transform: none;" OnClick="Guarda_Material_Click"/>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>



                    </section>
                </div>
                <div class="6u 12u(mobile) important(mobile)" style="text-align: justify;">
                    <section class="middle-content">
                        <h2 style="text-transform: none; font-weight: bold; text-align:center;">Tabla de Inventarios</h2>

                        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" AllowPaging="true"
                            OnPageIndexChanging="GridView1_PageIndexChanging" Style="border-collapse: collapse; width: 100%; text-align: center;" >
                            <Columns>

                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="MATERIAL" HeaderText="Material" />
                                <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                                <asp:BoundField DataField="PRECIO_UNIDAD" HeaderText="Precio Unitario" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar("<%# Eval("ID") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No existen Materiales</EmptyDataTemplate>
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
                    </section>
                </div>
                <div class="3u 12u(mobile)" style="margin-top: 50px;">
                    <section class="right-content">
                        <h3 style="text-transform: none; font-weight: bold; text-align: center;">Creación/Modificación de Servicios</h3>
                        <a onclick="Limpiar_Campos();" style="margin-left: 80%; text-decoration: none; cursor: pointer;">Limpiar</a>
                        <div class="Div_Table">
                            <table>
                                
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Servicio:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Servicio" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                
                                <tr>
                                    <td runat="server" id="Eliminar" style="display:none">
                                        <asp:Label runat="server" Style="font-size: 11pt;">Eliminar:</asp:Label>
                                        <%--<asp:Label ID="lblCerrarCaso" Style="display: none; font-size: 11pt;" runat="server">Desea cerrar el caso?</asp:Label>--%>
                                        <asp:CheckBox ID="EstadoEliminar" runat="server" />
                                    </td>
                                </tr>
                                                               
                            </table>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <div class="controls" style="float: right;">
                                            <asp:Button runat="server" CssClass="button" ID="Guarda_Servicio" Text="Guardar" Style="text-transform: none;" OnClick="Guarda_Servicio_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <asp:GridView ID="GridView2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid"
                            BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" AllowPaging="true"
                            OnPageIndexChanging="GridView2_PageIndexChanging" Style="border-collapse: collapse; width: 100%; text-align: center;" >
                            <Columns>

                                <asp:BoundField DataField="ID_SERVICIO" HeaderText="Id" />
                                <asp:BoundField DataField="SERVICIO" HeaderText="Servicio" />
                                
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar2("<%# Eval("ID_SERVICIO") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID_SERVICIO") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No existen Servicios</EmptyDataTemplate>
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

                    </section>
                </div>
            </div>
            <asp:TextBox runat="server" type="text" style="display:none;" ID="Accion">INSERTAR</asp:TextBox>
            <asp:TextBox runat="server" type="text" style="display:none;" ID="Id_Material">0</asp:TextBox>
            <asp:TextBox runat="server" type="text" style="display:none;" ID="Accion_Servicio">INSERTAR</asp:TextBox>
            <asp:TextBox runat="server" type="text" style="display:none;" ID="Id_Servicio">0</asp:TextBox>
            <asp:Button runat="server" style="display:none;" ID="Cargar_Material" OnClick="Cargar_Material_Click"/>
            <asp:Button runat="server" style="display:none;" ID="Tipo_Servicio" OnClick="Tipo_Servicio_Click"/>
        </div>
    </div>


</asp:Content>
