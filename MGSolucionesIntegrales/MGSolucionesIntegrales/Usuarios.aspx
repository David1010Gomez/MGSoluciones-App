<%@ Page Title="" Language="C#" MasterPageFile="~/Administrador.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="Content/Solicitud.css?1.1.3" rel="stylesheet" />
    <script>
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C3').classList.add('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');

        function Limpiar_Campos() {
            window.location.href = 'Usuarios.aspx';
        }
        function editar(obj) {
            $('#<%=Cedula.ClientID%>').val(obj);
            $('#<%=Accion.ClientID%>').val('ACTUALIZAR');
            var x = document.getElementById('<%=Cargar_Usuario.ClientID%>');
            x.click();
        }
        function Bucar_Rol()
        {
            var x = document.getElementById('<%=Lista_Roles.ClientID%>');
            x.click();
        }
        function Bucar_Estados() {
            var x = document.getElementById('<%=Lista_Estado.ClientID%>');
            x.click();
        }
        function Bucar_Disponibilidad() {
            var x = document.getElementById('<%=Lista_Disponible.ClientID%>');
            x.click();
        }
    </script>


    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="8u 12u(mobile)">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold">Usuarios</h2>
                        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black"
                            AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;"
                            AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="CEDULA" HeaderText="Cédula" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                <asp:BoundField DataField="CARGO" HeaderText="Cargo" />
                                <asp:BoundField DataField="ID_ROL" HeaderText="Id_Rol" />
                                <asp:BoundField DataField="ESTADO" HeaderText="Estado" />
                                <asp:BoundField DataField="DISPONIBLE" HeaderText="Disponibilidad" />
                                <asp:BoundField DataField="ULTIMA_ACTUALIZACION" HeaderText="Ultima Actualizacion" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar("<%# Eval("CEDULA") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("CEDULA") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Existen Usuarios</EmptyDataTemplate>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="center" />
                            <RowStyle BackColor="White" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </section>
                </div>
                <div class="4u 12u(mobile)" style="text-align: justify;">
                    <section class="right-content">
                        <h3 style="text-transform: none; font-weight: bold">Creación/Modificación de Usuarios</h3>
                        <a onclick="Limpiar_Campos();" style="margin-left: 80%; text-decoration: none; cursor: pointer;">Limpiar</a>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Cédula:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Cedula_Usuario" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Nombre:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Nombre_Usuario" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Contraseña:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Contrasena_Usuario" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Cargo:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Cargo_Usuario" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Rol:</asp:Label>
                                    </td>
                                    <td>
                                        <div runat="server" id="Div_Agrega_Rol" style="float: right; margin-right: 5px; display:block;">
                                            <a href="#" id="Nuevo_Tecnico" onclick="Bucar_Rol();" ><i class="fa fa-plus-circle"></i></a>
                                        </div>
                                        <%--<asp:TextBox CssClass="inp_form" ID="" runat="server"></asp:TextBox>--%>
                                        <asp:DropDownList ID="Rol_Usuario" CssClass="Lista_Tecnicos" runat="server" style="width:85%;">
                                            </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Estado:</asp:Label>
                                        
                                    </td>
                                    <td>
                                        <div runat="server" id="Div_Agrega_Estado" style="float: right; margin-right: 5px; display:block;">
                                            <a href="#" id="Nuevo_Estado" onclick="Bucar_Estados();" ><i class="fa fa-plus-circle"></i></a>
                                        </div>
                                        <%--<asp:TextBox CssClass="inp_form" ID="Estado_Usuario" runat="server"></asp:TextBox>--%>
                                        <asp:DropDownList ID="Estado_Usuario" CssClass="Lista_Tecnicos" runat="server" style="width:85%;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Disponible:</asp:Label>
                                        
                                    </td>
                                    <td>
                                        <div runat="server" id="Div_Agrega_Disponibilidad" style="float: right; margin-right: 5px; display:block;">
                                            <a href="#" id="Nuevo_Disponibilidad" onclick="Bucar_Disponibilidad();" ><i class="fa fa-plus-circle"></i></a>
                                        </div>
                                        <%--<asp:TextBox CssClass="inp_form" ID="Disponible_Usuario" runat="server"></asp:TextBox>--%>
                                        <asp:DropDownList ID="Disponible_Usuario" CssClass="Lista_Tecnicos" runat="server" style="width:85%;">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <div class="controls" style="float: right;">
                                            <asp:Button runat="server" CssClass="button" ID="Guarda_Usuario" Text="Guardar" Style="text-transform: none;" OnClick="Guarda_Usuario_Click"/>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:TextBox runat="server" type="text" style="display:none;" ID="Accion">INSERTAR</asp:TextBox>
                        <asp:TextBox runat="server" type="text" style="display:none;" ID="Cedula">0</asp:TextBox>
                        <asp:Button runat="server" style="display:none;" ID="Cargar_Usuario" OnClick="Cargar_Usuario_Click"/>
                        <asp:Button runat="server" style="display:none;" ID="Lista_Roles" OnClick="Lista_Roles_Click"/>
                        <asp:Button runat="server" style="display:none;" ID="Lista_Estado" OnClick="Lista_Estado_Click"/>
                        <asp:Button runat="server" style="display:none;" ID="Lista_Disponible" OnClick="Lista_Disponible_Click"/>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

