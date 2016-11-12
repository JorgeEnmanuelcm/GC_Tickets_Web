<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UsuariosForm.aspx.cs" Inherits="GC_Tickets_Web.Registros.UsuariosForm" %>

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
                <h1 class="page-header">Usuarios </h1>
            </div>
        </div>
    </div>

    <div class="text-center">
        <div class="col-md-12">
            <div data-ng-app="" data-ng-init="firstName=''">
                <h1>HI {{ firstName }}!</h1>
                <div class="col-md-12">
                    <asp:Label ID="NickLabel" runat="server" Font-Bold="True" max="5" Text="Your Nickname here:"></asp:Label>
                </div>
                <input id="Jinput" runat="server" type="text" value="" data-ng-model="firstName" maxlength="32" />
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--UsuarioId--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="UsuarioIdLabel" For="UsuarioIdTexBox" runat="server" Font-Bold="True" Text="Usuario Id:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="UsuarioIdTextBox" runat="server" CssClass="form-control" placeholder="Usuario Id" MaxLength="4"></asp:TextBox>
        </div>
        <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-info" Text="Buscar" OnClick="BuscarButton_Click" />
    </div>
    <br />

    <%--Nombres--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="NombresLabel" For="NombresTexBox" runat="server" Font-Bold="True" Text="Nombres: "></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="NombresTextBox" runat="server" type="text" CssClass="form-control" placeholder="Nombres" MaxLength="18"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Apellidos--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="ApellidosLabel" For="ApellidosTexBox" runat="server" Font-Bold="True" Text="Apellidos:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ApellidosTextBox" runat="server" CssClass="form-control" placeholder="Apellidos" MaxLength="18"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Telefono--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="TelefonoLabel" For="TelefonoTexBox" runat="server" Font-Bold="True" Text="Telefono:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="TelefonoTextBox" runat="server" CssClass="form-control" placeholder="Telefono" MaxLength="15"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Email--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="EmailLabel" For="EmailTexBox" runat="server" Font-Bold="True" Text="Email:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="EmailTextBox" runat="server" CssClass="form-control" placeholder="Email" MaxLength="32"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Direccion--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="DireccionLabel" For="DireccionTexBox" runat="server" Font-Bold="True" Text="Direccion:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="DireccionTextBox" runat="server" CssClass="form-control" placeholder="Direccion" MaxLength="31"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--NombreUsuario--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="NombreUsuarioLabel" For="NombreUsuarioTexBox" runat="server" Font-Bold="True" Text="Nombre Usuario:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Nombre Usuario" MaxLength="12"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--Contraseña--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="ContraseniaLabel" For="ContraseniaTexBox" runat="server" Font-Bold="True" Text="Contraseña:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ContraseniaTextBox" TextMode="Password" runat="server" CssClass="form-control" placeholder="Contraseña" MaxLength="32"></asp:TextBox>
        </div>
    </div>
    <br />
    <br />
    <br />

    <%--ConfirmarContraseña--%>
    <div class="form-group">
        <div class="col-md-12">
            <asp:Label ID="ConfContraseniaLabel" For="ConfContraseniaTexBox" runat="server" Font-Bold="True" Text="Confirmar Contraseña:"></asp:Label>
        </div>
        <div class="col-md-6 col-xs-8">
            <asp:TextBox ID="ConfContraseniaTexBox" TextMode="Password" runat="server" CssClass="form-control" placeholder="Confirmar Contraseña" MaxLength="32"></asp:TextBox>
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
