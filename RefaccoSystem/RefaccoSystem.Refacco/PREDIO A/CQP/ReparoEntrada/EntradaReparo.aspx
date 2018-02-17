<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntradaReparo.aspx.cs" Inherits="RefaccoSystem.Refacco.ReparoEntrada.EntradaReparo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Conteiner">

        <div class="Conteudo">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="form-horizontal formulario">
                        <h2>Rework Input</h2>
                        <asp:Label ID="lblData" runat="server"></asp:Label>
                        <br />
                        <div id="tagCn">

                            <div class="form-group">
                                <label class="control-label col-md-2" for="cn">C/N:</label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtCN" runat="server" CssClass="form-control" OnTextChanged="txtCN_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCN"
                                        CssClass="text-danger" ErrorMessage="O campo C/N é exigido." />
                                </div>
                            </div>
                        </div>
                        <br />
                       
                         <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Modelo:</label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlModelo" runat="server" Width="40%" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>




                        <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Linha:</label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlBlock" runat="server" Width="40%" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Cod Falha:</label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlCodFalhas" runat="server" Width="40%" CssClass="form-control" OnTextChanged="ddlCodFalhas_TextChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        
                        <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Sintoma:</label>
                            <div class="col-md-10">
                                <asp:TextBox ID="txtSintomas" runat="server" Enabled="false" Width="40%" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2" for="massa">Defeito em Massa:</label>
                            <div class="col-md-10">
                              <asp:CheckBox ID="ckbMassa" runat="server" />
                            </div>
                           
                        </div>

                        <div class="form-group">

                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>

</asp:Content>
