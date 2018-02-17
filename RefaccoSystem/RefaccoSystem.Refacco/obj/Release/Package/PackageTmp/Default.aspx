<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RefaccoSystem.Refacco._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <%-- <h2><%: Title %>.</h2>--%>
    <asp:Panel ID="Panel1" runat="server" DefaultButton="btnRegister">
    <div id="conteinerLogin">
        <div id="tituloLogin">
            <div class="wow slideInLeft" data-wow-duration="2s" data-wow-delay="5s"">
             <h1>REFACCO</h1>
            <p>Repair Factory Control  </p>
            </div>
          
        </div>
        <div class="row">
            <div class="col-md-8">
                <section id="loginForm">
                    <div class="form-horizontal formLogin">
                        <h4>Entre com seu login e senha.</h4>
                        <hr />
                        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                            <p class="text-danger">
                                <asp:Literal runat="server" ID="FailureText" />
                            </p>
                        </asp:PlaceHolder>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Usuário</asp:Label>
                            <div class="col-md-10">
                               
                                  
                                   <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="O campo Usuario é exigido." />
                              
                            
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Senha</asp:Label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="O campo de senha é obrigatório." />
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <div class="checkbox">
                                    <asp:CheckBox runat="server" ID="RememberMe" />
                                    <asp:Label runat="server" AssociatedControlID="RememberMe">Lembrar-me?</asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-offset-2 col-md-10">
                                <%--<asp:Button runat="server" OnClick="LogIn" Text="Logon" CssClass="btn btn-default" />--%>
                                <asp:LinkButton ID="btnRegister" runat="server" OnClick="LogIn" CssClass="btn btn-success">
                                    <span class="glyphicon glyphicon-user"> Entrar</span>
                                </asp:LinkButton>
                            </div>
                        </div>
                   
                    </div>
                    <p>
                       <%-- <asp:HyperLink runat="server" ID="RegisterHyperLink" ViewStateMode="Disabled">Registre-se como um novo usuário</asp:HyperLink>--%>
                    </p>
                    <p>
                        <%-- Ative quando tiver a confirmação de conta ativada para a funcionalidade de redefinição de senha
                    <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" ViewStateMode="Disabled">Esqueceu a senha?</asp:HyperLink>
                        --%>
                    </p>
                </section>
            </div>

            <%--<div class="col-md-4">
            <section id="socialLoginForm">
                <uc:OpenAuthProviders runat="server" ID="OpenAuthLogin" />
            </section>
        </div>--%>
        </div>
    </div>
    </asp:Panel>
    <script src="../Scripts/wow.min.js"></script>
              <script>
                  new WOW().init();
              </script>
</asp:Content>
