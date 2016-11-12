<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VentasForm.aspx.cs" Inherits="GC_Tickets_Web.Registros.VentasForm" %>

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
                <h1 class="page-header">Ventas </h1>
            </div>
        </div>
    </div>

    <%--VentaId--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="VentaIdLabel" For="VentaIdTexBox" runat="server" Font-Bold="True" Text="Venta Id:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="VentaIdTextBox" runat="server" CssClass="form-control" placeholder="Venta Id" MaxLength="4"></asp:TextBox>
        </div>
        <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" Text="Buscar" />
    </div>
    <br />

    <%--UsuarioId--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="UsuarioIdLabel" For="UsuarioIdTexBox" runat="server" Font-Bold="True" Text="Usuario Id:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="UsuarioIdTextBox" runat="server" CssClass="form-control" placeholder="Usuario Id" MaxLength="4" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <br />

    <%--Fecha--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="FechaLabel" For="FechaTexBox" runat="server" Font-Bold="True" Text="Fecha:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="FechaTextBox" runat="server" CssClass="form-control" placeholder="Fecha" MaxLength="12" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--EventoId--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="EventoIdLabel" For="EventoDropDownList" runat="server" Font-Bold="True" Text="Evento:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:DropDownList ID="EventoDropDownList" runat="server"></asp:DropDownList>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--EventoId--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="TicketLabel" For="TicketDropDownList" runat="server" Font-Bold="True" Text="Ticket:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:DropDownList ID="TicketDropDownList" runat="server"></asp:DropDownList>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Cantidad--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="CantidadLabel" For="CantidadTexBox" runat="server" Font-Bold="True" Text="Cantidad:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="CantidadTextBox" runat="server" CssClass="form-control" placeholder="Cantidad" MaxLength="7"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Total--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="TotalLabel" For="TotalTexBox" runat="server" Font-Bold="True" Text="Total:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="TotalTextBox" runat="server" CssClass="form-control" placeholder="Total" MaxLength="7" ReadOnly="True"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--BotonAgregar--%>
    <div class="container">
        <asp:Button ID="AgregarButton" runat="server" class="btn btn-info btn-block" Text="Agregar" />
    </div>
    <br />
    <br />
    <br />

    <%--Gridview--%>
    <div class="form-group">
        <div class="text-center">
            <div class="table table-responsive col-md-12">
                <asp:GridView ID="VentasGridView" runat="server" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="EventoId" HeaderText="Evento Id" SortExpression="EventoId"></asp:BoundField>
                        <asp:BoundField DataField="Ticket" HeaderText="Ticket" SortExpression="Ticket"></asp:BoundField>
                        <asp:BoundField DataField="Cantidad" HeaderText="Cantidad" SortExpression="Cantidad"></asp:BoundField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />

    <%--Buttons--%>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" />
                <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton" />
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" />
            </div>
        </div>
    </div>
</asp:Content>
