<%@ Page Title="" Language="C#" MasterPageFile="~/Tecnico.master" AutoEventWireup="true" CodeFile="Imagenes.aspx.cs" Inherits="Imagenes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script>
        document.getElementById('C2').classList.add('current-page-item');
        document.getElementById('C4').classList.remove('current-page-item');
        document.getElementById('C1').classList.remove('current-page-item');
        document.getElementById('C3').classList.remove('current-page-item');
    </script>
    <link href="../Content/Busqueda_Coordinador.css?1.0.1" rel="stylesheet" />
    <script src="assets/js/jquery-1.11.1.js"></script>
    <script type="text/javascript">
        function justNumbers(e) {
            var keynum = window.event ? window.event.keyCode : e.which;
            if ((keynum == 8) || (keynum == 46))
                return true;

            return /\d/.test(String.fromCharCode(keynum));
        }

    </script>
    
    <div id="main">
        <div class="container">
            <div class="row main-row">
                <div class="12u">
                    <section>
                        <h2 style="text-transform: none; font-weight: bold;">Imágenes a Servidor</h2>
                        <%--<div class="Div_Table">--%>
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <p class="comments">Digite el número del Exp.:</p>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="Nom_EXP" onkeypress="return justNumbers(event);"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    <asp:FileUpload id="Carga_Archivos" runat="server" AllowMultiple="true" />
                                        </td>
                                </tr>
                            </table>
                        <br />
                        <br />
                        <asp:Button runat="server" ID="Sube_Archivos" CssClass="button" Text="Subir Imagenes" OnClick="Sube_Archivos_Click" Style="text-transform: none;" />
                        <%--</div>--%>
                    </section>
                    <asp:TextBox runat="server" ID="prueba"></asp:TextBox>
                </div>
            </div>
        </div>
    </div>


</asp:Content>

