<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Inicio_Sesion.aspx.cs" Inherits="Inicio_Sesion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Content/fa_icons.css" rel="stylesheet" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <!--[if lte IE 8]><script src="assets/js/ie/html5shiv.js"></script><![endif]-->
    <%--<link rel="stylesheet" href="assets/css/main.css" />--%>
    <!--[if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]-->
    <title>MG Soluciones Integrales</title>
    <link href="Content/Inicio_Sesion.css?1.0.2" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="banner-wrapper">
        <div class="Container">
        <div class="Caja1">
            <div class="Datos1">
                INICIO DE SESIÓN
            </div>
        </div>
        <br />
        
        <div class="Caja2">
            <div class="Datos2">
                <table style="width:100%;">
                    <tr>
                        <%--<td style="width:180px;">
                            <asp:Label CssClass="Texto" runat="server">Cédula: </asp:Label>
                        </td>--%>
                        <td>
                            <input id="Cedula" runat="server" class="input" type="text" placeholder="Cédula"/><i class="fa fa-user" style="float: right; right: 15px; position: absolute; margin-top: 5px;"></i>
                        </td>
                    </tr>
                </table>
                <table style="margin-top:20px; width:100%;">
                    <tr>
                        <%--<td style="width:180px;">
                            <asp:Label CssClass="Texto" runat="server">Contraseña: </asp:Label>
                         </td>--%>
                        <td>
                            <input id="Contraseña" runat="server" class="input" type="password" placeholder="Contraseña"/><i class="fa fa-lock" style="float: right; right: 15px; position: absolute; margin-top: 5px;"></i>
                        </td>

                    </tr>
                </table>
                <br />
                <table style="width:100%;">
                    <tr>
                        <td>
                            <asp:Button runat="server" CssClass="btnInicio" Text="INGRESAR" OnClick="Ingresar_Click"/>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
            </div>
            </div>
    </form>
</body>
</html>
