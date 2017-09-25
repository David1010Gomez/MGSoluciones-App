<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador.master" AutoEventWireup="true" CodeFile="Solicitud.aspx.cs" Inherits="Solicitud" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script src="assets/js/jquery.datetimepicker.full.js"></script>
    <link href="Content/jquery.datetimepicker.css" rel="stylesheet" />
    <script src="Scripts/Solicitud.js?1.0.4"></script>
    <link href="Content/Solicitud.css?1.1.1" rel="stylesheet" />
    <script type="text/javascript">
        function justNumbers(e) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if ((keynum == 8) || (keynum == 46))
                return true;

            return /\d/.test(String.fromCharCode(keynum));
        }

    </script>
    <script type="text/javascript">
        setTimeout(function () { $('#<%=UserGestion.ClientID%>').css('display','none'); }, 5000);
        function editar(obj) {
            $('#<%=ID_CASO.ClientID%>').val(obj);
            var x = document.getElementById('<%=Cargar_Caso_Abierto.ClientID%>');
            x.click();
            $('#Nuevo_Tecnico').css('display', 'none');
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
            $('#Nuevo_Tecnico').css('display', 'block');
        }
        function editarListaMateriales(Id, Cantidad, Id_Material, PrecioUnit, PrecioTotal) {
            document.getElementById("<%=Div_Actualiza.ClientID%>").style.display = "block";
            document.getElementById("<%=GridView4.ClientID%>").style.display = "none";
            $("#<%=Act_Id.ClientID%>").val(Id);
                
            $("#<%=Act_Cantidad.ClientID%>").val(Cantidad);
            $("#<%=Act_Id_Material.ClientID%>").val(Id_Material);
            $("#<%=Act_CantidadInicial.ClientID%>").val(Cantidad);
            $("#<%=Act_Precio_Unitario.ClientID%>").val(PrecioUnit);
            $("#<%=Act_Precio_Total.ClientID%>").val(PrecioTotal);
            
        }
        function Oculta_Div_Actualiza()
        {
            document.getElementById("<%=Div_Actualiza.ClientID%>").style.display = "none";
            var x = document.getElementById("<%=Actualiza_Tabla_Materiales_Solicitud.ClientID%>");
            x.click();
            
        }
        function Bucar_Tecni() {
            var x = document.getElementById('<%=Cargar_Tecnicos.ClientID%>');
            x.click();
        }
        function Bucar_Tecni2() {
            $('#<%=Accion_Tecnico.ClientID%>').val('INSERTAR');
            $('#<%=Fecha_Agendamiento.ClientID%>').val('');
            
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
    function Limpiar_Campos()
    {
        var x = document.getElementById('<%=Desliberar_Caso.ClientID%>');
        x.click();        
    }
    function Aplaza()
    {
        var x = document.getElementById('<%=AplazaCaso.ClientID%>');
        x.click();
    }
    function Actualiza_Total(Valor)
    {
        $('#<%=txtValorTotal.ClientID%>').val(Valor);
        $('#<%=txtValorTotal2.ClientID%>').val(Valor);
    }
    function Liberar_Tecnico()
    {
        
        if ($('#<%=Accion_Trabajo.ClientID%>').val() == "FINALIZADO" || $('#<%=Accion_Trabajo.ClientID%>').val() == "APLAZADO") {
            $("#Lib_Des").css("color", "#e20404");
            $('#<%=Accion_Trabajo.ClientID%>').val('EN TRABAJO');
        }
        else {
            if ($('#<%=Accion_Trabajo.ClientID%>').val() == "EN TRABAJO") {
                $("#Lib_Des").css("color", "#5d93a2");
                $('#<%=Accion_Trabajo.ClientID%>').val('FINALIZADO');
            }
        }
    }
        function Liberar_Casos()
    {
        var x = document.getElementById('<%=Liberar_Casos.ClientID%>');
        x.click();        
    }
    </script>

    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="3u 12u(mobile)" style="margin-top: 50px;">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold">Casos Asignados</h3>
                        <asp:GridView ID="GridView2" AllowPaging="true" OnPageIndexChanging="GridView2_PageIndexChanging" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" 
                            AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;" OnRowDataBound="GridView2_RowDataBound">
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
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <%--<asp:Literal ID="ltltotal" runat="server" Text='<%# Eval("TRABAJO") %>' Visible="false"/>--%>
                                        <asp:TextBox runat="server" ID="Trabajo" Text='<%# Eval("TRABAJO") %>' style="display:none"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Existen Casos Asignados</EmptyDataTemplate>
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
                <div class="6u 12u(mobile) important(mobile)" style="text-align: justify;">
                    <section class="middle-content">
                        <h2 style="text-transform: none; font-weight: bold;">Solicitud</h2>
                        <asp:Label runat="server" ID="UserGestion" style="color:darkred; font-weight:bold; text-align:left;"></asp:Label>
                        <a onclick="Limpiar_Campos();" style="margin-left: 90%; text-decoration: none; cursor: pointer;">Limpiar</a>
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
                                        <asp:TextBox CssClass="inp_form" ID="Exp" runat="server" onkeypress="return justNumbers(event);" MaxLength="9"></asp:TextBox>
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
                                        <div runat="server" id="Div_Agrega_Tecnicos" style="float: right; margin-right: 5px; display:block;">
                                            <a href="#" id="Nuevo_Tecnico" onclick="Bucar_Tecni2();" ><i class="fa fa-plus-circle"></i></a>
                                        </div>
                                        <div runat="server" id="Div_Libera_Tecnico" style="float: right; margin-right: 5px; display:block;">
                                            <a href="#" id="Lib_Des" onclick="Liberar_Tecnico();" ><i class="fa fa-users"></i></a>
                                        </div>
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
                                            <asp:DropDownList ID="Lista_Tecnicos" CssClass="Lista_Tecnicos" runat="server" OnSelectedIndexChanged="Lista_Tecnicos_SelectedIndexChanged" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:Label runat="server">Direccion:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server">Tipo de Servicio:</asp:Label>
                                        <div runat="server" id="Div_Agrega_Servicio" style="float: right; margin-right: 5px; display:none;">
                                            <a href="#" id="Nuevo_Servicio" onclick="Bucar_Tecni2();" ><i class="fa fa-plus-circle"></i></a>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:TextBox CssClass="inp_form" ID="Direccion" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="Lista_Servicios" CssClass="Lista_Tecnicos" runat="server" AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblFecha_Agendamiento" runat="server" Style="display: none">Fecha de Agendamiento:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblValorTrabajo" runat="server" Style="display: none">Valor del trabajo:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="inp_form" ID="Fecha_Agendamiento" placeholder="Seleccion Fecha" runat="server" Style="display: none"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form"  ID="Valor_Trabajo" runat="server" Style="display: none" OnTextChanged="Valor_Trabajo_TextChanged"  AutoPostBack="true">0</asp:TextBox>
                                    </td>
                                    <td style="text-align: center; vertical-align: middle;">
                                        <asp:Label ID="Aplaza_Caso" runat="server" Style="font-weight: bold; display:none; cursor:pointer" onclick="Aplaza();"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblValorTotal" runat="server" Style="display: none">Valor Total:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblRelacionado" runat="server" Style="display: none">Relacionado:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAcabados" runat="server" Style="display: none">Técnico Acabados:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox CssClass="inp_form"  ID="txtValorTotal" runat="server" Style="display: none" ReadOnly="true">0</asp:TextBox>
                                        <asp:TextBox CssClass="inp_form"  ID="txtValorTotal2" runat="server" Style="display: none">0</asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form"  ID="Relacionado" runat="server" Style="display: none"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox CssClass="inp_form"  ID="Acabados" runat="server" Style="display: none" ></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                            <script>
                                $.datetimepicker.setLocale('es');
                                $('#<%=Fecha_Agendamiento.ClientID%>').datetimepicker({
                                    lang: 'es',
                                    format: 'd-m-Y H:00',
                                    minDate: '0',
                                    timepicker: true,
                                    allowTimes: [
                                        '04:00',
                                            '05:00',
                                            '06:00',
                                           '07:00',
                                           '08:00',
                                           '09:00',
                                           '10:00',
                                           '11:00',
                                           '12:00',
                                           '13:00',
                                           '14:00',
                                           '15:00',
                                           '16:00',
                                           '17:00',
                                           '18:00',
                                           '19:00',
                                            '20:00',
                                            '21:00',
                                            '22:00',
                                            '23:00',
                                            '00:00',
                                            '01:00',
                                            '02:00',
                                            '03:00'
                                    ]
                                    
                                    //onShow: function (ct) {
                                    //    this.setOptions({
                                    //        minDate: $('#Fecha_Inicial').val() ? $('#Fecha_Inicial').val() : false
                                    //    })
                                    //}
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
                                        <asp:TextBox CssClass="inp_form_Observ" TextMode="MultiLine" ID="Observaciones" runat="server" autocomplete="off" style="text-transform: uppercase;" MaxLength="10"></asp:TextBox>
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
                                            <asp:Button ID="Guardar_Datos" runat="server" CssClass="button" Text="Guardar" Style="text-transform: none;" OnClick="Guardar_Datos_Click" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                            
                        </div>
                        <br />
                        <a onclick="Liberar_Casos();" style="margin-left: 43%; text-decoration: none; cursor: pointer;">Liberar Casos</a>
                        <br /><br />
                        <div runat="server" id="Div_Historial" class="Div_Table" style="display:none;">
                            <asp:GridView ID="GridView5" AllowPaging="True" OnPageIndexChanging="GridView5_PageIndexChanging" runat="server" BackColor="#CCCCCC" BorderColor="#999999" 
                                BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; 
                                text-align: center;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="FECHA_NOTA" HeaderText="Fecha de Nota" />
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Usuario" />
                                <asp:BoundField DataField="OBSERVACIONES" HeaderText="Observaciones" />
                            </Columns>
                            <EmptyDataTemplate>No Existe Historial</EmptyDataTemplate>
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
                        </div>
                    </section>
                    
                </div>
                <div class="3u 12u(mobile)" style="margin-top: 50px;">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold">Casos Abiertos</h3>
                        <asp:GridView ID="GridView1" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                            ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
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
                            <EmptyDataTemplate>No Existen casos Abiertos</EmptyDataTemplate>
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
                        <br /><br />
                        <h3 style="text-transform: none; color: #007294; text-decoration: underline;"> Citas</h3>
                        <asp:GridView ID="GridView6" AllowPaging="true" OnPageIndexChanging="GridView6_PageIndexChanging" runat="server" 
                            BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                            ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                            <Columns>
                                <%--<asp:BoundField DataField="ID" HeaderText="Id" />--%>
                                <asp:BoundField DataField="NOMBRE" HeaderText="Nombre" />
                                <asp:BoundField DataField="FECHA_TURNO" HeaderText="Fecha Turno" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Exp." />
                                <%--<asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar("<%# Eval("ID") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <EmptyDataTemplate>No Existen Citas</EmptyDataTemplate>
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
                <div class="12u">
                    <section>
                        <h3 style="text-transform: none; font-weight: bold; text-align: center">Casos Agendados</h3>
                        <asp:GridView ID="GridView3" AllowPaging="true" OnPageIndexChanging="GridView3_PageIndexChanging" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" 
                            ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;" OnRowDataBound="GridView2_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Exp." />
                                <asp:BoundField DataField="POLIZA" HeaderText="Poliza" />
                                <asp:BoundField DataField="ASEGURADO" HeaderText="Asegurado" />
                                <asp:BoundField DataField="CONTACTO" HeaderText="Contacto" />
                                <asp:BoundField DataField="FACT" HeaderText="Fact." />
                                <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
                                <asp:BoundField DataField="ESTADO_CASO" HeaderText="Estado del Caso" />
                                <%--<asp:BoundField DataField="CEDULA_USUARIO_CREACION" HeaderText="Usuario Creacion" />
                                <asp:BoundField DataField="USUARIO_ULTIMA_ACTUALIZACION" HeaderText="Usuario Ultima Actualizacion" />--%>
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar3("<%# Eval("ID") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" ">
                                    <ItemTemplate>
                                        <%--<asp:Literal ID="ltltotal" runat="server" Text='<%# Eval("TRABAJO") %>' Visible="false"/>--%>
                                        <asp:TextBox runat="server" ID="Trabajo" Text='<%# Eval("TRABAJO") %>' style="display:none"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EmptyDataTemplate>No Existen casos Agendados</EmptyDataTemplate>
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

            </div>
        </div>
    </div>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="ID_CASO">0</asp:TextBox>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="ID_TURNO">0</asp:TextBox>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="Estado_Caso_Creacion">ABIERTO</asp:TextBox>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="Accion">INSERTAR</asp:TextBox>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="Accion_Tecnico">INSERTAR</asp:TextBox>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="Accion_Trabajo"></asp:TextBox>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="Estado_Usuario_Inicial"></asp:TextBox>
    <asp:TextBox runat="server" type="text" style="display:none;" ID="Estado_Caso_Actual">ABIERTO</asp:TextBox>
    <asp:Button runat="server" style="display:none;" ID="Cargar_Caso_Abierto" OnClick="Cargar_Caso_Abierto_Click" />
    <asp:Button runat="server" style="display:none;" ID="Cargar_Caso_Asignado" OnClick="Cargar_Caso_Asignado_Click" />
    <asp:Button runat="server" style="display:none;" ID="Cargar_Caso_Agendado" OnClick="Cargar_Caso_Agendado_Click" />
    <asp:Button runat="server" style="display:none;" ID="Cargar_Tecnicos" OnClick="Cargar_Tecnicos_Click" /> 
    <asp:Button runat="server" style="display:none;" ID="AplazaCaso" OnClick="AplazaCaso_Click"  />
    <asp:Button runat="server" style="display:none;" ID="Desliberar_Caso" OnClick="Desliberar_Caso_Click"/>
    <asp:Button runat="server" style="display:none;" ID="Liberar_Casos" OnClick="Liberar_Casos_Click"/>

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
                                <asp:Label runat="server" class="comments">Costo por unidad: </asp:Label>
                            </td>
                            <td>
                                <asp:Label runat="server" class="comments">Cantidad: </asp:Label>
                            </td>
                            <%--<td></td>--%>
                        </tr>
                        <tr>
                            <td style="width: 50%;">
                                <asp:DropDownList ID="Select_Materiales" CssClass="Lista_Tecnicos" runat="server" OnSelectedIndexChanged="Select_Materiales_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td>
                                <asp:TextBox ID="Costo_Unidad" ReadOnly="true" CssClass="inp_form" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:TextBox ID="CantidadMaterial" CssClass="inp_form" runat="server" onkeypress="return justNumbers(event);"></asp:TextBox>
                                <i id="Ok" class="fa fa-check" style="margin-left: -20px; position: absolute; margin-top: 5px; display: none" runat="server"></i>
                                <i id="Error" class="fa fa-times" style="right: 10px; position: relative; margin-top: -22px; display: inline-block; float: right; display: none" runat="server"></i>
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
                    <div id="Div_Grid4" runat="server">
                    <asp:GridView ID="GridView4" runat="server" AllowPaging="true" OnPageIndexChanging="GridView4_PageIndexChanging" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" 
                        BorderWidth="3px" CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="ID" />
                            <asp:BoundField DataField="ID_SOLICITUD" HeaderText="ID SOLICITUD" />
                            <asp:BoundField DataField="ID_MATERIAL" HeaderText="ID MATERIAL" />
                            <asp:BoundField DataField="MATERIAL" HeaderText="MATERIAL" />
                            <asp:BoundField DataField="CANTIDAD" HeaderText="CANTIDAD" />
                            <asp:BoundField DataField="PRECIO_UNIDAD" HeaderText="PRECIO UNITARIO" />
                            <asp:BoundField DataField="PRECIO_TOTAL" HeaderText="PRECIO TOTAL" />
                            <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                <ItemTemplate>
                                    <a href='javascript:editarListaMateriales("<%# Eval("ID") %>", "<%# Eval("CANTIDAD") %>", "<%# Eval("ID_MATERIAL")%>", "<%# Eval("PRECIO_UNIDAD")%>", "<%# Eval("PRECIO_TOTAL")%>");'>
                                        <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataTemplate>No Existe Material para esta Solicitud</EmptyDataTemplate>
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
                        </div>
                    <asp:TextBox ID="MaterialDisponible" runat="server" Style="display: none;"></asp:TextBox>
                    <div id="Div_Actualiza" runat="server" style="display:none" >
                        <small onclick="Oculta_Div_Actualiza()" style="float: right; margin-right: 10px; text-decoration: underline; color: #008dad; cursor: pointer;">Cancelar</small>
                        <table class="tablas">
                            <tr>
                                <td>
                                    <asp:Label runat="server">Id</asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server">Id Material</asp:Label>
                                </td>
                                <%--<td>
                                    <asp:Label runat="server">Material</asp:Label>
                                </td>--%>
                                <td>
                                    <asp:Label runat="server">Precio Unitario</asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server">Cantidad</asp:Label>
                                </td>
                                <td>
                                    <asp:Label runat="server">Precio Total</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox ID="Act_Id" runat="server" disabled="true" CssClass="inp_form"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="Act_Id_Material" runat="server" disabled="true" CssClass="inp_form"></asp:TextBox>
                                </td>
                                <%--<td>
                                    <asp:TextBox ID="Act_Material" runat="server" disabled="true" CssClass="inp_form"></asp:TextBox>
                                </td>--%>
                                <td>
                                    <asp:TextBox ID="Act_Precio_Unitario" runat="server" disabled="true" CssClass="inp_form"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="Act_Cantidad" runat="server" CssClass="inp_form" onkeypress="return justNumbers(event);" MaxLength="9"></asp:TextBox>
                                    <i id="Ok2" class="fa fa-check" style="right: 10px; position: relative; margin-top: -22px; display: inline-block; float: right; display: none" runat="server"></i>
                                    <i id="Error2" class="fa fa-times" style="right: 10px; position: relative; margin-top: -22px; display: inline-block; float: right; display: none" runat="server"></i>
                                </td>
                                <td>
                                    <asp:TextBox ID="Act_Precio_Total" runat="server" disabled="true" CssClass="inp_form"></asp:TextBox>
                                </td>
                                <td style="text-align: center">
                                <asp:Button ID="Actualiza_Registro_Inventario" runat="server" OnClick="Actualiza_Registro_Inventario_Click" CssClass="button" Text="Actualiza Registro" Style="text-transform: none; font-size: 0.9em; padding: 7px;" />
                            </td>
                            </tr>
                        </table>

                    </div>
                    <asp:Button runat="server" ID="Actualiza_Tabla_Materiales_Solicitud" OnClick="Actualiza_Tabla_Materiales_Solicitud_Click1" style="display:none;" />
                    <asp:TextBox ID="Act_CantidadInicial" runat="server" style="display:none"></asp:TextBox>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

