<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="RefaccoSystem.Refacco.Admin.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Àrea administrativa</h2>
    <br />
    <div id="controles">
        <div class="conteiner">
            <img src="../Img/painel.png" alt="painel" />
            <h4>Cpanel</h4>
            <hr />
            <button id="btnModelos" runat="server" class="btn btn-primary btn-lg" data-toggle="modal" data-target="#ModalNovoModelo" data-whatever="@mdo">New Model</button>
            <button id="btnSintomas" runat="server" class="btn btn-success btn-lg" data-toggle="modal" data-target="#ModalNovoSintomas" data-whatever="@mdo">New Simptoms</button>
            <button id="btnBlock" runat="server" class="btn btn-info btn-lg" data-toggle="modal" data-target="#ModalNovoBlock" data-whatever="@mdo">New Block</button>
            <button id="btnPlanta" runat="server" class="btn btn-warning btn-lg" onclick="Alert()">New Plant</button><br />
            <hr />
            <h4>Controles de Usuários</h4>

            <asp:LinkButton ID="lkbUsuario" runat="server" PostBackUrl="~/Account/Register.aspx" CssClass="btn btn-primary btn-lg">
                <span class="glyphicon glyphicon-user"> User Register</span>
            </asp:LinkButton>
            <asp:LinkButton ID="lkbResetarSenha" runat="server" PostBackUrl="~/Account/ResetPassword.aspx" CssClass="btn btn-info btn-lg">
                <span class="glyphicon glyphicon-user"> Reset password</span>
            </asp:LinkButton>
           <%-- <button id="btnResetar" runat="server" class="btn btn-success btn-lg">Resetar Senha</button>--%>
            
        </div>
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
    </div>
    <!--Pagina de Registro de Modelos-->
    <div id="ModalModelo">
        <div class="modal fade" id="ModalNovoModelo" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="exampleModalLabel">Novo Modelo</h4>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="control-label">Modelo:</label>
                            <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                       </div>
                    <div class="modal-footer">
                        <div class="btn btn-primary glyphicon glyphicon-floppy-saved">
                            <asp:Button ID="btnRegistrarModelo" runat="server" CssClass="btn btn-primary" Text="Salvar" BackColor="Transparent" BorderWidth="0" OnClick="btnRegistrarModelo_Click" />
                        </div>
                        <div class="btn btn-default glyphicon glyphicon-folder-close">
                            <asp:Button runat="server" Text="Sair" class="btn btn-default" data-dismiss="modal" BackColor="Transparent" BorderWidth="0"/>
                        </div>
                        
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!--FIM DA PAGINA REGISTRO DE MODELOS-->
     <!--Pagina de Registro de Sintomas-->
     <div id="ModalSintomas">
        <div class="modal fade" id="ModalNovoSintomas" tabindex="-1" role="dialog" aria-labelledby="ModelSintomas">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="Sintomas">Novo Sintomas</h4>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="control-label">Codigo:</label>
                            <asp:TextBox ID="txtCodSintomas" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label for="recipient-name" class="control-label">Sintomas:</label>
                            <asp:TextBox ID="txtSintomas" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                       </div>
                    <div class="modal-footer">
                        <div class="btn btn-primary glyphicon glyphicon-floppy-saved">
                            <asp:Button ID="btnRegistroSintomas" runat="server" CssClass="btn btn-primary" Text="Salvar" BackColor="Transparent" BorderWidth="0" OnClick="btnRegistroSintomas_Click" />
                        </div>
                        <div class="btn btn-default glyphicon glyphicon-folder-close">
                            <asp:Button runat="server" Text="Sair" class="btn btn-default" data-dismiss="modal" BackColor="Transparent" BorderWidth="0"/>
                        </div>
                        
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
     <!--FIM DA PAGINA REGISTRO DE SINTOMAS-->

     <!--Pagina de Registro de Block-->
     <div id="ModalBlock">
        <div class="modal fade" id="ModalNovoBlock" tabindex="-1" role="dialog" aria-labelledby="ModelBlock">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="block">Registro de nova Block</h4>
                    </div>
                    <div class="modal-body">

                        <div class="form-group">
                            <label for="recipient-name" class="control-label">Block:</label>
                            <asp:TextBox ID="txtBlock" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                       </div>
                    <div class="modal-footer">
                        <div class="btn btn-primary glyphicon glyphicon-floppy-saved">
                            <asp:Button ID="btnRegistrarBlock" runat="server" CssClass="btn btn-primary" Text="Salvar" BackColor="Transparent" BorderWidth="0" OnClick="btnRegistrarBlock_Click" />
                        </div>
                        <div class="btn btn-default glyphicon glyphicon-folder-close">
                            <asp:Button runat="server" Text="Sair" class="btn btn-default" data-dismiss="modal" BackColor="Transparent" BorderWidth="0"/>
                        </div>
                        
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
     <!--FIM DA PAGINA REGISTRO DE BLOCK-->
    <script>
        function Alert()
        {
            alert("Planta já existe no sistema, caso precise add mais alguma planta entre em contato com o administrador!");
        }
    </script>
</asp:Content>
