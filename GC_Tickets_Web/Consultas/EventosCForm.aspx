<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EventosCForm.aspx.cs" Inherits="GC_Tickets_Web.Consultas.EventosCForm" %>

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
                <h1 class="page-header">Consulta Eventos </h1>
            </div>
        </div>
    </div>

    <%--FiltroFecha--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="FechaLabel" For="FechaCheckBox" runat="server" Font-Bold="True" Text="Filtro por Fechas:"></asp:Label>
        <asp:CheckBox ID="FechaCheckBox" runat="server" class="input-sm" />
        </div>
         <div class="col-md-12">
            <asp:Label ID="DesdeLabel" For="DesdeTextBox" runat="server" Font-Bold="True" Text="Desde:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="DesdeTextBox" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>
        </div>
        <br />
        <br />
        <div class="col-md-12">
            <asp:Label ID="HastaLabel" For="HastaTextBox" runat="server" Font-Bold="True" Text="Hasta:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="HastaTextBox" runat="server" CssClass="form-control" MaxLength="12"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Componentes--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="BuscarLabel" For="BuscarTexBox" runat="server" Font-Bold="True" Text="Buscar por:"></asp:Label>
        </div>
        <div class="col-md-2 col-sm-2 col-xs-3">
            <asp:DropDownList ID="CamposDropDownList" runat="server" class="btn btn-primary dropdown-toggle">
                <asp:ListItem>EventoId</asp:ListItem>
                <asp:ListItem>NombreEvento</asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="BuscarTextBox" runat="server" CssClass="form-control" placeholder="Buscar" MaxLength="16"></asp:TextBox>
        </div>
        <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
    </div>
    <br />
    <br />
    <br />

    <%--Gridview--%>
    <div class="form-group">
        <div class="table table-responsive col-md-12">
            <asp:GridView ID="ConsultaGridView" runat="server" class="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="true">
                <Columns>
                    <asp:HyperLinkField
                        DataNavigateUrlFields="EventoId"
                        DataNavigateUrlFormatString="/Registros/EventosForm.aspx?ID={0}"
                        Text="Editar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
