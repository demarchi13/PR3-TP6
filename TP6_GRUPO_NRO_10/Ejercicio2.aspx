<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ejercicio2.aspx.cs" Inherits="TP6_GRUPO_NRO_10.Ejercicio2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 46px;
            font-size: x-large;
        }
        .auto-style4 {
            width: 46px;
            height: 26px;
        }
        .auto-style5 {
            height: 26px;
        }
        .auto-style6 {
            width: 46px;
            height: 25px;
        }
        .auto-style7 {
            height: 25px;
        }
        .auto-style8 {
            width: 269px;
        }
        .auto-style9 {
            height: 25px;
            width: 269px;
        }
        .auto-style11 {
            height: 26px;
            width: 269px;
        }
        .auto-style12 {
            width: 46px;
            height: 24px;
        }
        .auto-style13 {
            height: 24px;
            width: 269px;
        }
        .auto-style14 {
            height: 24px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style3"><strong>Inicio</strong></td>
                    <td class="auto-style8">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style6"></td>
                    <td class="auto-style9">
                        <asp:HyperLink ID="hypSeleccionarProd" runat="server" NavigateUrl="~/SeleccionarProductos.aspx">Seleccionar Productos</asp:HyperLink>
                    </td>
                    <td class="auto-style7"></td>
                </tr>
                <tr>
                    <td class="auto-style12"></td>
                    <td class="auto-style13">
                        <asp:LinkButton ID="lnkEliminar" runat="server" OnClick="lnkEliminar_Click">Eliminar productos seleccionados</asp:LinkButton>
                    </td>
                    <td class="auto-style14">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                </tr>
                <tr>
                    <td class="auto-style4"></td>
                    <td class="auto-style11">
                        <asp:HyperLink ID="hypMostrarProd" runat="server" NavigateUrl="~/MostrarProductos.aspx">Mostrar Productos</asp:HyperLink>
                    </td>
                    <td class="auto-style5"></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
