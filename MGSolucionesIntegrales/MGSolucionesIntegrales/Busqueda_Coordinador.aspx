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
    <link href="Content/Busqueda_Coordinador.css?1.0.1" rel="stylesheet" />
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script src="assets/js/jquery.datetimepicker.full.js"></script>
    <link href="Content/jquery.datetimepicker.css" rel="stylesheet" />
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold;">Busqueda de casos</h2>
                        <div class="Div_Table">
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <p class="comments">Seleccione el rango de fechas:</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label runat="server">Fecha Inicial:</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label runat="server">Fecha Final:</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox ID="Fecha_Inicial" CssClass="inp_form" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Fecha_Final" CssClass="inp_form" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <asp:GridView ID="GridView1" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="Fila1" HeaderText="Fila 1" />
                                <asp:BoundField DataField="Fila2" HeaderText="Fila 2" />
                            </Columns>
                            <EmptyDataTemplate>No Existen casos para asignar</EmptyDataTemplate>
                        </asp:GridView>
                        <script>
                        $('#<%=Fecha_Inicial.ClientID%>').datetimepicker({
                            format: 'Y/m/d',
                            minDate: '2016/09/01',
                            maxDate: '+0d',
                            timepicker: false
                        });

                        $('#<%=Fecha_Final.ClientID%>').datetimepicker({
                            format: 'Y/m/d',
                            onShow: function (ct) {
                                this.setOptions({
                                    minDate: $('#<%=Fecha_Inicial.ClientID%>').val() ? $('#<%=Fecha_Inicial.ClientID%>').val() : false
                                })
                            },
                            maxDate: '+0d',
                            timepicker: false
                        });
                    </script>
                    </section>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

