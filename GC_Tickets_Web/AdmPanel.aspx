<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdmPanel.aspx.cs" Inherits="GC_Tickets_Web.AdmPanel" %>

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
                <h1 class="page-header">Adm Panel </h1>
            </div>
        </div>
    </div>

    <%--Square Options--%>
    <%--Usuarios--%>
    <div class="text-center">
        <div class="container">
            <div class="row">
                <h3>Usuarios <span class="label label-default"></span></h3>
                <div class="col-lg-12">
                    <p>
                        <a href="/Registros/UsuariosForm.aspx" class="btn btn-sq-lg btn-primary">
                            <i class="fa fa-users fa-5x"></i>
                            <br />
                            Registro Usuarios
                            <br />
                        </a>
                        <a href="/Consultas/UsuariosCForm.aspx" class="btn btn-sq-lg btn-success">
                            <i class="fa fa-users fa-5x"></i>
                            <br />
                            Consulta Usuarios
                            <br />
                        </a>
                        <a href="#" class="btn btn-sq-lg btn-warning">
                            <i class="fa fa-users fa-5x"></i>
                            <br />
                            Reporte Usuarios
                            <br />
                        </a>
                    </p>
                </div>
            </div>
        </div>
        <br />
        <br />

        <%--Tipo de Eventos--%>
        <div class="container">
            <div class="row">
                <h3>Tipos de Eventos <span class="label label-default"></span></h3>
                <div class="col-lg-12">
                    <p>
                        <a href="/Registros/TipoEventoForm.aspx" class="btn btn-sq-lg btn-primary">
                            <i class="fa fa-align-left fa-5x"></i>
                            <br />
                            Registro Tipos de
                            <br />
                            Eventos
                        </a>
                        <a href="/Consultas/TipoEventoCForm.aspx" class="btn btn-sq-lg btn-success">
                            <i class="fa fa-align-left fa-5x"></i>
                            <br />
                            Consulta Tipos de
                            <br />
                            Eventos
                        </a>
                        <a href="#" class="btn btn-sq-lg btn-warning">
                            <i class="fa fa-align-left fa-5x"></i>
                            <br />
                            Reporte Tipos de
                            <br />
                            Eventos
                        </a>
                    </p>
                </div>
            </div>
        </div>
        <br />
        <br />

        <%--Eventos--%>
        <div class="container">
            <div class="row">
                <h3>Eventos <span class="label label-default"></span></h3>
                <div class="col-lg-12">
                    <p>
                        <a href="/Registros/EventosForm.aspx" class="btn btn-sq-lg btn-primary">
                            <i class="fa fa-hand-peace-o fa-5x"></i>
                            <br />
                            Registro Eventos
                            <br />
                        </a>
                        <a href="/Consultas/EventosCForm.aspx" class="btn btn-sq-lg btn-success">
                            <i class="fa fa-hand-peace-o fa-5x"></i>
                            <br />
                            Consulta Eventos
                            <br />
                        </a>
                        <a href="#" class="btn btn-sq-lg btn-warning">
                            <i class="fa fa-hand-peace-o fa-5x"></i>
                            <br />
                            Reporte Eventos
                            <br />
                        </a>
                    </p>
                </div>
            </div>
        </div>
        <br />
        <br />

        <%--Ventas--%>
        <div class="container">
            <div class="row">
                <h3>Ventas <span class="label label-default"></span></h3>
                <div class="col-lg-12">
                    <p>
                        <a href="/Registros/VentasForm.aspx" class="btn btn-sq-lg btn-primary">
                            <i class="fa fa-money fa-5x"></i>
                            <br />
                            Registro Ventas
                            <br />
                        </a>
                        <a href="/Consultas/VentasCForm.aspx" class="btn btn-sq-lg btn-success">
                            <i class="fa fa-money fa-5x"></i>
                            <br />
                            Consulta Ventas
                            <br />
                        </a>
                        <a href="#" class="btn btn-sq-lg btn-warning">
                            <i class="fa fa-money fa-5x"></i>
                            <br />
                            Reporte Ventas
                            <br />
                        </a>
                    </p>
                </div>
            </div>
        </div>
        <br />
        <br />
    </div>
</asp:Content>
