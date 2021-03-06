﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Coordinador.master" AutoEventWireup="true" CodeFile="Busqueda_Coordinador.aspx.cs" Inherits="Busqueda_Coordinador" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script>
        document.getElementById('C3').classList.add('current-page-item');
        document.getElementById('C2').classList.remove('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
    </script>
    <script type="text/javascript">
        function justNumbers(e) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if ((keynum == 8) || (keynum == 46))
                return true;

            return /\d/.test(String.fromCharCode(keynum));
        }

    </script>
    <script>
        function Fijar_Tecnico() {
            <%--var control = document.getElementById("<%=Lista_Tecnicos.ClientID%>");
            var Tecnico = control.options[control.selectedIndex].text;
            $('#<%=Nombre_Tecnico.ClientID%>').val(Tecnico)
            var x = document.getElementById('<%=Busqueda.ClientID%>');
            x.click();--%>
        }
        function editar(obj, obj2) {
            if (obj2 != 'CERRADO') {
                $("#<%=Id.ClientID%>").val(obj);
                $("#<%=Estado_Caso.ClientID%>").val(obj2);
                var x = document.getElementById('<%=Redirecciona.ClientID%>');
                x.click();

            }
            else { alert('Los casos cerrados no se pueden editar'); }
        }
        function Fijar_Tecnico3() {
            var control = document.getElementById("<%=Lista_Tecnicos_Materiales.ClientID%>");
            var Tecnico = control.options[control.selectedIndex].text;
            $('#<%=Nombre_Tecnico_Materiales.ClientID%>').val(Tecnico)
            var x = document.getElementById('<%=Busqueda_Materiales.ClientID%>');
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
                        <h2 style="text-transform: none; font-weight: bold;">Búsqueda de Casos</h2>
                        <br />
                        <br />
                        <h3 style="text-transform: none; font-weight: bold">Consulta General de Solicitudes</h3>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td colspan="2" style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Busqueda por rango de fechas:</p>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <p class="comments">Búsqueda por Exp:</p>
                                    </td>
                                    <%--                                    <td>
                                        <p class="comments">Búsqueda por Técnico:</p>
                                    </td>--%>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Fecha_Inicial" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" OnTextChanged="Fecha_Inicial_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Fecha_Final" CssClass="inp_form" placeholder="Fecha Final" runat="server" OnTextChanged="Fecha_Final_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td style="border-right: 3px solid #f9f9f9;">
                                        <asp:TextBox ID="Exp" CssClass="inp_form" runat="server" placeholder="Exp" AutoPostBack="true" OnTextChanged="Exp_TextChanged" onkeypress="return justNumbers(event);" MaxLength="9"></asp:TextBox>
                                    </td>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <%--<td>
                                         <asp:DropDownList ID="Lista_Tecnicos" CssClass="Lista_Tecnicos"  style="width: 125%;"  runat="server" >
                                        </asp:DropDownList>
                                    </td>--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <asp:TextBox runat="server" ID="Nombre_Tecnico" Style="display: none;"></asp:TextBox>
                                    <asp:Button ID="Busqueda" runat="server" Style="display: none;" OnClick="Busqueda_Click" />
                                </tr>
                            </table>
                        </div>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px"
                            CellPadding="4" ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging"
                            Style="border-collapse: collapse; width: 100%; text-align: center;">
                            <Columns>
                                <asp:BoundField DataField="ID" HeaderText="Id" />
                                <asp:BoundField DataField="FECHA_INGRESO" HeaderText="Fecha de Ingreso" />
                                <asp:BoundField DataField="NUM_EXP" HeaderText="Numero EXP" />
                                <asp:BoundField DataField="POLIZA" HeaderText="Poliza" />
                                <asp:BoundField DataField="ASEGURADO" HeaderText="Asegurado" />
                                <asp:BoundField DataField="CONTACTO" HeaderText="Contacto" />
                                <asp:BoundField DataField="FACT" HeaderText="Fact." />
                                <asp:BoundField DataField="DIRECCION" HeaderText="Dirección" />
                                <asp:BoundField DataField="ESTADO_CASO" HeaderText="Estado Caso" />
                                <asp:BoundField DataField="NOMBRE_USUARIO_CREACION" HeaderText="Nombre Usuario Creacion" />
                                <asp:BoundField DataField="FECHA_CIERRE" HeaderText="Fecha de Cierre" />
                                <asp:BoundField DataField="NOMBRE_USUARIO_CIERRE" HeaderText="Nombre Usuario Cierre" />
                                <asp:BoundField DataField="NOMBRE_USUARIO_ULTIMA_ACTUALIZACION" HeaderText="Usuario Ultima Actualización" />
                                <asp:BoundField DataField="VALOR_TRABAJO" HeaderText="Valor Trabajo" />
                                <asp:BoundField DataField="VALOR_TOTAL" HeaderText="Valor Total" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Editar">
                                    <ItemTemplate>
                                        <a href='javascript:editar("<%# Eval("ID") %>", "<%# Eval("ESTADO_CASO") %>");'>
                                            <img class="c1" id='imageningreso_<%# Eval("ID") %>' alt="" src="images/edit.png" />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
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
                        <asp:Label runat="server" ID="TotalFilas" Style="float: right;"></asp:Label>
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
                        <asp:TextBox runat="server" type="text" Style="display: none;" ID="ID_CASO">0</asp:TextBox>
                        <br />
                        <br />
                        <asp:Button runat="server" ID="Desacarga_Base" CssClass="button" Text="Descargar" OnClick="Desacarga_Base_Click" Style="text-transform: none; float: right;" />
                        <br />
                        <br />
                        <br />
                        <br />
                        <br />
                        <asp:TextBox runat="server" ID="Id" Style="display: none;"></asp:TextBox>
                        <asp:TextBox runat="server" ID="Estado_Caso" Style="display: none;"></asp:TextBox>
                        <asp:Button runat="server" ID="Redirecciona" Style="display: none" OnClick="Redirecciona_Click" />

                        <div class="8u 12u(mobile)">
                            <section>
                                <h3 style="text-transform: none; font-weight: bold">Consulta Notas Solicitudes</h3>
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
                                                <asp:TextBox ID="Fecha_Inicial_Notas" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" OnTextChanged="Fecha_Inicial_Notas_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td style="border-right: 3px solid #f9f9f9;">
                                                <asp:TextBox ID="Fecha_Final_Notas" CssClass="inp_form" placeholder="Fecha Final" runat="server" OnTextChanged="Fecha_Final_Notas_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td style="border-right: 3px solid #f9f9f9;">
                                                <asp:TextBox ID="Exp_Notas" CssClass="inp_form" runat="server" placeholder="Exp" OnTextChanged="Exp_Notas_TextChanged" AutoPostBack="true" onkeypress="return justNumbers(event);" MaxLength="9"></asp:TextBox>
                                            </td>

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
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Usuario" />
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
                                <asp:Label runat="server" ID="TotalFilas2" Style="float: right;"></asp:Label>
                                <br />
                                <br />
                                <asp:Button runat="server" ID="Desacarga_Base_Notas" CssClass="button" Text="Descargar" OnClick="Desacarga_Base_Notas_Click" Style="text-transform: none; float: right;" />
                                <br />
                                <br />
                            </section>
                        </div>
                        <br />
                        <br />
                        <div class="8u 12u(mobile)" style="">
                            <section>
                                <h3 style="text-transform: none; font-weight: bold">Consulta Materiales Solicitudes</h3>
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
                                                <asp:TextBox ID="Fecha_Inicial_Materiales" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" OnTextChanged="Fecha_Inicial_Materiales_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td style="border-right: 3px solid #f9f9f9;">
                                                <asp:TextBox ID="Fecha_Final_Materiales" CssClass="inp_form" placeholder="Fecha Final" runat="server" OnTextChanged="Fecha_Final_Materiales_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td style="border-right: 3px solid #f9f9f9;">
                                                <asp:TextBox ID="Exp_Materiales" CssClass="inp_form" runat="server" placeholder="Exp" OnTextChanged="Exp_Materiales_TextChanged" AutoPostBack="true" onkeypress="return justNumbers(event);" MaxLength="9"></asp:TextBox>
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
                                    OnPageIndexChanging="GridView3_PageIndexChanging" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" ForeColor="Black"
                                    AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                                    <Columns>
                                        <asp:BoundField DataField="MATERIAL" HeaderText="Material" />
                                        <asp:BoundField DataField="CANTIDAD" HeaderText="Cantidad" />
                                        <asp:BoundField DataField="CEDULA_TECNICO" HeaderText="Cedula" />
                                        <asp:BoundField DataField="NOMBRE" HeaderText="Nombre Técnico" />
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
                                <asp:Label runat="server" ID="TotalFilas3" Style="float: right;"></asp:Label>
                                <br />
                                <br />
                                <asp:Button runat="server" ID="Desacarga_Base_Materiales" CssClass="button" Text="Descargar" OnClick="Desacarga_Base_Materiales_Click" Style="text-transform: none; float: right;" />
                            </section>
                        </div>
                        <br />
                        <br />
                        <br />
                        <br />
                        <div class="8u 12u(mobile)" style="">
                            <section>
                                <h3 style="text-transform: none; font-weight: bold">Consulta Tecnicos Solicitudes</h3>
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
                                                <asp:TextBox ID="Fecha_Inicial_Tecnicos" CssClass="inp_form" placeholder="Fecha Inicial" runat="server" OnTextChanged="Fecha_Inicial_Tecnicos_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td style="border-right: 3px solid #f9f9f9;">
                                                <asp:TextBox ID="Fecha_Final_Tecnicos" CssClass="inp_form" placeholder="Fecha Final" runat="server" OnTextChanged="Fecha_Final_Tecnicos_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            </td>
                                            <td style="border-right: 3px solid #f9f9f9;">
                                                <asp:TextBox ID="Exp_Tecnicos" CssClass="inp_form" runat="server" placeholder="Exp" AutoPostBack="true" OnTextChanged="Exp_Tecnicos_TextChanged" onkeypress="return justNumbers(event);" MaxLength="9"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    <script>
                                        $('#<%=Fecha_Inicial_Tecnicos.ClientID%>').datetimepicker({
                                            format: 'Y-m-d',
                                            minDate: '2017/06/01',
                                            maxDate: '+0d',
                                            timepicker: false
                                        });

                                        $('#<%=Fecha_Final_Tecnicos.ClientID%>').datetimepicker({
                                            format: 'Y-m-d',
                                            onShow: function (ct) {
                                                this.setOptions({
                                                    minDate: $('#<%=Fecha_Inicial_Tecnicos.ClientID%>').val() ? $('#<%=Fecha_Inicial_Tecnicos.ClientID%>').val() : false
                                        })
                                    },
                                    maxDate: '+0d',
                                    timepicker: false
                                });
                                    </script>
                                </div>
                                <br />
                                <asp:GridView ID="GridView4" runat="server" BackColor="#CCCCCC" BorderColor="#999999" AllowPaging="true"
                                    OnPageIndexChanging="GridView4_PageIndexChanging" BorderStyle="Solid" BorderWidth="3px" CellPadding="4"
                                    ForeColor="Black" AutoGenerateColumns="False" CellSpacing="2" Style="border-collapse: collapse; width: 100%; text-align: center;">
                                    <Columns>
                                        <%--<asp:BoundField DataField="FECHA_INGRESO" HeaderText="Fecha de Ingreso" />--%>
                                        <asp:BoundField DataField="NUM_EXP" HeaderText="Exp." />
                                        <asp:BoundField DataField="CEDULA_TECNICO" HeaderText="Cedula" />
                                        <asp:BoundField DataField="NOMBRE_TECNICO" HeaderText="Nombre Técnico" />
                                        <asp:BoundField DataField="SERVICIO" HeaderText="Servicio" />
                                        <asp:BoundField DataField="FECHA_TURNO" HeaderText="Fecha Turno." />
                                        <asp:BoundField DataField="LIQUIDADO" HeaderText="Liquidado" />
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
                                <asp:Label runat="server" ID="TotalFilas4" Style="float: right;"></asp:Label>
                                <br />
                                <br />
                                <asp:Button runat="server" ID="Descraga_Base_Tecnicos" CssClass="button" OnClick="Descraga_Base_Tecnicos_Click" Text="Descargar" Style="text-transform: none; float: right;" />
                            </section>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

