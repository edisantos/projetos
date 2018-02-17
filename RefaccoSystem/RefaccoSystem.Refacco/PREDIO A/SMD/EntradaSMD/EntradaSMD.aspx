<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntradaSMD.aspx.cs" Inherits="RefaccoSystem.Refacco.PREDIO_A.SMD.EntradaSMD.EntradaSMD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="Conteiner">

        <div class="Conteudo">
            
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>

                    <div class="form-horizontal formulario">
                        <h3>SMD REPARO</h3>
                        <asp:Label ID="lblData" runat="server"></asp:Label>
                        <br />
                        <div id="tagCn">

                            <div class="form-group">
                                <label class="control-label col-md-2" for="cn">C/N:</label>
                                <div class="col-md-10">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtCN" runat="server" CssClass="form-control" OnTextChanged="txtCN_TextChanged" AutoPostBack="true"></asp:TextBox>
                                            <asp:RequiredFieldValidator runat="server" ControlToValidate="txtCN"
                                                CssClass="text-danger" ErrorMessage="O campo C/N é exigido." />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>

                                </div>
                            </div>
                        </div>
                        <br />
                       
                        <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Model:</label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlModelo" runat="server" Width="40%" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Line:</label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlBlock" runat="server" Width="40%" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Revisora:</label>
                            <div class="col-md-10">
                                <asp:DropDownList ID="ddlRevisadora" runat="server" Width="40%" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2" for="cn">Fail:</label>
                            <div class="col-md-10">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:DropDownList ID="ddlFalhas" runat="server" Width="40%" CssClass="form-control" AutoPostBack="true" OnTextChanged="ddlFalhas_TextChanged"></asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

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
                        <div class="form-group">

                            <asp:Label ID="lblCodPai" runat="server" Visible="false"></asp:Label>
                        </div>

                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

    </div>
</asp:Content>
