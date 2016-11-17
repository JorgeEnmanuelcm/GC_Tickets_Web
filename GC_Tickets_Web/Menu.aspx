<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="GC_Tickets_Web.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <!-- Page Head -->
    <div class="row">
        <div class="text-center">
            <div class="col-md-12">
                <h1 class="page-header">Eventos </h1>
            </div>
        </div>
    </div>

    <%--Menu de eventos  --%>
    <div class="text-center">
        <asp:DataList ID="MenuDataList" runat="server" RepeatColumns="4" RepeatDirection="Horizontal" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" GridLines="Both">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <ItemStyle BackColor="White" />
            <ItemTemplate>
                <table class="auto-style2">
                    <tr>
                        <td>
                            <h3><%# Eval("NombreEvento")  %></h3>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img alt="" height="200" width="200" src='<%# Eval("Imagen") %>' />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="FechaEventoLabel" runat="server" Text="Fecha del evento"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h2><%# Eval("FechaEvento")  %></h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LugarEventoLabel" runat="server" Text="Lugar del evento"></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <h2><%# Eval("LugarEvento")  %></h2>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <li>
                                <a href="/Registros/VentasForm.aspx" class="btn btn-success">Comprar<i class="fa fa-ticket"></i></a>
                            </li>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <SelectedItemStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        </asp:DataList>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
