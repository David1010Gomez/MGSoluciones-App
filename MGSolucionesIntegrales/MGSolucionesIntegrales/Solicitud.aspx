<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador.master" AutoEventWireup="true" CodeFile="Solicitud.aspx.cs" Inherits="Solicitud" %>

<script runat="server">

    protected void Cantidad_TextChanged(object sender, EventArgs e)
    {

    }
</script>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script src="assets/js/jquery.datetimepicker.full.js"></script>
    <link href="Content/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="Scripts/Solicitud.js?1.0.1"></script>
    <link href="Content/Solicitud.css?1.0.8" rel="stylesheet" />
    <script type="text/javascript">
        function editar(obj) {
            $('#<%=ID_CASO.ClientID%>').val(obj);
            var x = document.getElementById('<%=Cargar_Caso_Abierto.ClientID%>');
            x.click();
        }
        function editar2(obj) {
            $('#<%=ID_CASO.ClientID%>').val(obj);
            var x = document.getElementById('<%=Cargar_Caso_Asignado.ClientID%>');
            x.click();
        }
        function editar3(obj) {
            $('#<%=ID_CASO.ClientID%>').val(obj);
        var x = document.getElementById('<%=Cargar_Caso_Agendado.ClientID%>');
        x.click();
    }
    function Bucar_Tecni() {
        var x = document.getElementById('<%=Cargar_Tecnicos.ClientID%>');
        x.click();
    }
    function Cambia_Estado() {
        if (!document.getElementById('<%=CHCerrarCaso.ClientID%>').checked) {
            $('#<%=Accion.ClientID%>').val('CIERRE');
        }
        else {
            $('#<%=Accion.ClientID%>').val('CIERRE UPDATE');
        }
    }
    function Consulta_Cantidad() {

        $.ajax({
            type: "POST",
            url: 'Solicitud.aspx/BuscarNumAleatorio',
            dat: null,
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                var num = result.d;
                $('#Error').text('' + num);

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                var error = eval("(" + XMLHttpRequest.responseText + ")");
                alert(error.Message);
            }
        });

    }
    </script>

    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="3u 12u(mobile)" style="margin-top: 50px;">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold">Agendar Casos</h3>
                        <asp:GridView ID="GridView2" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Exp." />
                                <asp:BoundField DataField="POLIZA" HeaderText="Poliza" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar2("<%# Eval("ID") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Existen Casos Para Agendar</EmptyDataTemplate>
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
                <div class="6u 12u(mobile) important(mobile)" style="text-align: justify;">
                    <section class="middle-content">
                        <h2 style="text-transform: none; font-weight: bold">SOLICITUD</h2>
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
                                        <asp:TextBox CssClass="inp_form" ID="Poliza" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label runat="server">Asegurado:</asp:Label>
                                    </td>

                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox CssClass="inp_form" runat="server" ID="Asegurado"></asp:TextBox>
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
                                        <asp:TextBox CssClass="inp_form" runat="server" ID="Contacto"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" runat="server" ID="Fact"></asp:TextBox>
                                    </td>
                                    <td>
                                        <div id="Tecni" onclick="Carga_Tecni()">
                                            <asp:DropDownList ID="Lista_Tecnicos" CssClass="Lista_Tecnicos" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label runat="server">Direccion:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox CssClass="inp_form" ID="Direccion" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFecha_Agendamiento" runat="server" Style="display: none">Fecha de Agendamiento:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Fecha_Agendamiento" runat="server" Style="display: none"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <script>
                                $('#<%=Fecha_Agendamiento.ClientID%>').datetimepicker({
                                    format: 'Y/m/d',
                                    onShow: function (ct) {
                                        this.setOptions({
                                            minDate: $('#Fecha_Inicial').val() ? $('#Fecha_Inicial').val() : false
                                        })
                                    },
                                    maxDate: '+0d',
                                });
                            </script>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <div id="Div_Materiales" runat="server" style="text-align: center; display: none;"><a href="#Materiales">Agregar Materiales</a></div>
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
                                        <asp:TextBox CssClass="inp_form_Observ" TextMode="MultiLine" ID="Observaciones" runat="server" autocomplete="off"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblCerrarCaso" Style="display: none; font-size: 11pt;" runat="server">Desea cerrar el caso?</asp:Label>
                                        <asp:CheckBox ID="CHCerrarCaso" runat="server" Style="display: none;" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <table>
                                <tr>
                                    <td>
                                        <div class="controls" style="float: right;">
                                            <asp:Button runat="server" CssClass="button" Text="Guardar" Style="text-transform: none;" OnClick="Guardar_Datos_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </section>
                </div>
                <div class="3u 12u(mobile)" style="margin-top: 50px;">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold">Asignar Tecnico</h3>
                        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Exp." />
                                <asp:BoundField DataField="POLIZA" HeaderText="Poliza" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar("<%# Eval("ID") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Existen casos para asignar</EmptyDataTemplate>
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
                <div class="12u">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold; text-align: center">Editar y Cerrar Casos</h3>
                        <asp:GridView ID="GridView3" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Exp." />
                                <asp:BoundField DataField="POLIZA" HeaderText="Poliza" />
                                <asp:BoundField DataField="ASEGURADO" HeaderText="Asegurado" />
                                <asp:BoundField DataField="CONTACTO" HeaderText="Contacto" />
                                <asp:BoundField DataField="FACT" HeaderText="Fact." />
                                <asp:BoundField DataField="TECNICO" HeaderText="Tecnico" />
                                <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
                                <asp:BoundField DataField="ESTADO_CASO" HeaderText="Estado del Caso" />
                                <asp:BoundField DataField="CEDULA_USUARIO_CREACION" HeaderText="Usuario Creacion" />
                                <asp:BoundField DataField="USUARIO_ULTIMA_ACTUALIZACION" HeaderText="Usuario Ultima Actualizacion" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar3("<%# Eval("ID") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Existen casos para asignar</EmptyDataTemplate>
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
        </div>
    </div>
    <asp:TextBox runat="server" type="text" ID="ID_CASO">0</asp:TextBox>
    <asp:TextBox runat="server" type="text" ID="ID_TURNO">0</asp:TextBox>
    <asp:TextBox runat="server" type="text" ID="Estado_Caso_Creacion"> ABIERTO</asp:TextBox>
    <asp:TextBox runat="server" type="text" ID="Accion">INSERTAR</asp:TextBox>
    <asp:TextBox runat="server" type="text" ID="Accion_Tecnico">INSERTAR</asp:TextBox>
    <asp:Button runat="server" ID="Cargar_Caso_Abierto" OnClick="Cargar_Caso_Abierto_Click" />
    <asp:Button runat="server" ID="Cargar_Caso_Asignado" OnClick="Cargar_Caso_Asignado_Click" />
    <asp:Button runat="server" ID="Cargar_Caso_Agendado" OnClick="Cargar_Caso_Agendado_Click" />
    <asp:Button runat="server" ID="Cargar_Tecnicos" OnClick="Cargar_Tecnicos_Click" />


    <div class="modal-wrapper" id="Materiales">
        <div class="Materiales-contenedor" style="margin-top: 80px;">
            <a class="Materiales-cerrar" href="#">X</a>
            <h2 style="text-transform: none;">Materiales de Solicitud</h2>
            <hr />
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <table class="tablas">
                        <tr>
                            <td>
                                <asp:Label runat="server" class="comments">Material: </asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" class="comments">Cantidad: </asp:Label>
                            </td>
                            <%--<td></td>--%>
                        </tr>
                        <tr>
                            <td style="width: 50%;">
                                <asp:DropDownList ID="Select_Materiales" CssClass="Lista_Tecnicos" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="CantidadMaterial" CssClass="inp_form" runat="server"></asp:TextBox><i id="Ok" class="fa fa-check" style="margin-left: -20px; position: absolute; margin-top: 5px; display: none" runat="server"></i><i id="Error" class="fa fa-times" style="margin-left: -20px; position: absolute; margin-top: 5px; display: none" runat="server"></i>
                            </td>
                            <td style="text-align: center">
                                <asp:Button runat="server" CssClass="button" Text="Agregar Material" OnClick="Guarda_Material_Caso_Click" Style="text-transform: none; font-size: 0.9em; padding: 7px;" />
                            </td>
                        </tr>
                    </table>
                    <br />


                    <hr />
                    <br />
                    <asp:Label runat="server" class="comments">Modifique la siguiente tabla si desea Eliminar/Agregar cantidad de material a la solicitud: </asp:Label>
                    <br />
                    <br />
                    <asp:GridView ID="GridView4" runat="server" DataKeyNames="ID" OnPageIndexChanging="GridView4_PageIndexChanging" OnRowCancelingEdit="GridView4_RowCancelingEdit" 
                        OnRowDeleting="GridView4_RowDeleting" OnRowEditing="GridView4_RowEditing"
                        OnRowUpdating="GridView4_RowUpdating" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black"
                        AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;" AutoPostBack="true">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="ID_SOLICITUD" HeaderText="ID SOLICITUD" />
                            <asp:BoundField DataField="ID_MATERIAL" HeaderText="ID MATERIAL" />
                            <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" />
                            <asp:CommandField ShowEditButton="true" />
                            <asp:CommandField ShowDeleteButton="true" />

                        </Columns>
                        <EmptyDataTemplate>No Existen casos para asignar</EmptyDataTemplate>
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
                    <asp:TextBox ID="MaterialDisponible" runat="server" Style="display: none;"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

</asp:Content>

