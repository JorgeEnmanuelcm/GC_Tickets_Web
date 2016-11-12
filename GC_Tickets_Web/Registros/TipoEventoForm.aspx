<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TipoEventoForm.aspx.cs" Inherits="GC_Tickets_Web.Registros.TipoEventoForm" %>
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
                <h1 class="page-header">Tipos de Eventos </h1>
            </div>
        </div>
    </div>

    <%--TipoEventoId--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="TipoEventoIdLabel" For="TipoEventoIdTexBox" runat="server" Font-Bold="True" Text="Tipo Evento Id:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="TipoEventoIdTextBox" runat="server" CssClass="form-control" placeholder="Tipo Evento Id" MaxLength="4"></asp:TextBox>
        </div>
        <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
    </div>
    <br />

    <%--Descripcion--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="DescripcionLabel" For="DescripcionTexBox" runat="server" Font-Bold="True" Text="Descripcion: "></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="DescripcionTextBox" runat="server" CssClass="form-control" placeholder="Descripcion" MaxLength="26"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Buttons--%>
    <div class="panel-footer">
        <div class="text-center">
            <div class="form-group" style="display: inline-block">
                <asp:Button Text="Nuevo" class="btn btn-warning btn-sm" runat="server" ID="NuevoButton" OnClick="NuevoButton_Click" />
                <asp:Button Text="Guardar" class="btn btn-success btn-sm" runat="server" ID="GuardarButton" OnClick="GuardarButton_Click" />
                <asp:Button Text="Eliminar" class="btn btn-danger btn-sm" runat="server" ID="EliminarButton" OnClick="EliminarButton_Click" />
            </div>
        </div>
    </div>

</asp:Content>
