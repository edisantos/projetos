<%@ Page Title="Registre-se" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="RefaccoSystem.Refacco.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   <%-- <h2><%: Title %>.</h2>--%>
   

    <div class="form-horizontal ContainerNovoUsuario">
        <h4>Criar uma nova conta</h4>
        <img src="../Img/NewUser.png" alt="user" width="20%" />
        <hr />
         <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
        </p>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">User</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="O campo e-mail é exigido." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Senha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="O campo de senha é obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirmar senha</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="O campo para confirmar senha é obrigatório." />
                <asp:CompareValidator runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="A senha e a senha de confirmação não coincidem." />
            </div>
        </div>
        <div class="form-group">
            <label for="Planta" class="col-md-2 control-label">Planta</label>
            <div class="col-md-10">
                <asp:DropDownList runat="server" ID="ddlPlanta" CssClass="form-control" Width="40%" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlPlanta"
                    CssClass="text-danger" ErrorMessage="O campo Planta é obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <label for="turno" class="col-md-2 control-label">Turno</label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlTurno" runat="server" CssClass="form-control" Width="40%">
                    <asp:ListItem Text="SELECT SHIFT" Value="0"></asp:ListItem>
                     <asp:ListItem Text="1°T" Value="1"></asp:ListItem>   
                    <asp:ListItem Text="2°T" Value="2"></asp:ListItem>
                    <asp:ListItem Text="3°T" Value="3"></asp:ListItem>
                    <asp:ListItem Text="ADM" Value="4"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTurno"
                    CssClass="text-danger" ErrorMessage="O campo Turno é obrigatório." />
            </div>
        </div>
         <div class="form-group">
            <label for="funcao" class="col-md-2 control-label">Função</label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlFunction" runat="server" CssClass="form-control" Width="40%">
                    <asp:ListItem Text="SELECT FUNCTION" Value="0"></asp:ListItem>
                     <asp:ListItem Text="TECNICO" Value="1"></asp:ListItem>   
                    <asp:ListItem Text="REPARADOR" Value="2"></asp:ListItem>
                   <asp:ListItem Text="ADM" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTurno"
                    CssClass="text-danger" ErrorMessage="O campo Turno é obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <label for="predio" class="col-md-2 control-label">Predio</label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlPredio" runat="server" CssClass="form-control" Width="40%">
                    <asp:ListItem Text="SELECT Building" Value="0"></asp:ListItem>
                     <asp:ListItem Text="A" Value="1"></asp:ListItem>   
                    <asp:ListItem Text="B" Value="2"></asp:ListItem>
                   <asp:ListItem Text="ADM" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTurno"
                    CssClass="text-danger" ErrorMessage="O campo Turno é obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <label for="predio" class="col-md-2 control-label">Área</label>
            <div class="col-md-10">
                <asp:DropDownList ID="ddlArea" runat="server" CssClass="form-control" Width="40%">
                    <asp:ListItem Text="SELECIONE A AREA" Value="0"></asp:ListItem>
                     <asp:ListItem Text="HHP-MAIN" Value="1"></asp:ListItem>   
                    <asp:ListItem Text="HHP-OQC" Value="2"></asp:ListItem>
                   <asp:ListItem Text="HHP-SMD" Value="3"></asp:ListItem>
                    <asp:ListItem Text="NPC-MAIN" Value="3"></asp:ListItem>
                    <asp:ListItem Text="NPC-REPAIR" Value="3"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="ddlTurno"
                    CssClass="text-danger" ErrorMessage="O campo Turno é obrigatório." />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <%--<asp:Button runat="server" OnClick="CreateUser_Click" Text="Registre-se" CssClass="btn btn-primary"/>--%>
                <asp:LinkButton runat="server" OnClick="CreateUser_Click" CssClass="btn btn-primary">
                <span class="glyphicon glyphicon-plus"> Registrar</span>
                </asp:LinkButton>
                
            </div>
        </div>
        <div class="alrt alert-success" role="alert">
            <p class="text-success">
           <asp:Literal runat="server" ID="StatusMessage" />
        </p>
        </div>
    </div>
</asp:Content>
