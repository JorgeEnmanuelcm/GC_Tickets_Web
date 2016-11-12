<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="GC_Tickets_Web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
    <%--Login--%>
    <link href="/Css/Login.css" rel="stylesheet" />
    <script src="/Js/Login.js"></script>

    <div class="container">
        <div class="row">
            <div class="col-md-6 col-md-offset-3">
                <div class="panel panel-login">
                    <div class="panel-heading">
                        <div class="row">
                            <div class="col-xs-6">
                                <a class="active" id="login-form-link">Login</a>
                            </div>
                        </div>
                        <hr />
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-12">
                                <form id="login-form" action="/Default.aspx" method="post" role="form" style="display: block;">
                                    <div class="form-group">
                                        <asp:TextBox ID="UsuarioTextBox" runat="server" TabIndex="1" class="form-control" placeholder="Username" value="" MaxLength="12"></asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="ContraseniaTextBox" runat="server" TabIndex="2" class="form-control" placeholder="Password" MaxLength="32"></asp:TextBox>
                                    </div>
                                    <div class="form-group text-center">
                                        <asp:CheckBox ID="RecordarCheckBox" runat="server" TabIndex="3" class="" />
                                        <label for="RecordarCheckBox">Remember Me</label>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-sm-6 col-sm-offset-3">
                                                <asp:Button ID="LoginButton" runat="server" TabIndex="4" class="form-control btn btn-login" Text="Iniciar Sesion" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="text-center">
                                                    <a href="/Registros/UsuariosForm.aspx" tabindex="5" class="forgot-password">Register</a><br />
                                                    <br />
                                                    <a href="/Default.aspx" tabindex="6" class="forgot-password">Forgot Password?</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <br />
    <br />
    <br />
    <br />
    <br />
    <br />
</asp:Content>
