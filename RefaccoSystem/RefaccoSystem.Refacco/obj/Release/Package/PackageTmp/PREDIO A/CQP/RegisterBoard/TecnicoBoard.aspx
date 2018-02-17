<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TecnicoBoard.aspx.cs" Inherits="RefaccoSystem.Refacco.RegisterBoard.TecnicoBoard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Button ID="btnTEste" runat="server" Text="teste" OnClick="btnTEste_Click" />
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField HeaderText="">
                <ItemTemplate>
                    <asp:CheckBox ID="ckBox" runat="server" CssClass="checkbox-primary checkbox-info" OnCheckedChanged="ckBox_CheckedChanged" AutoPostBack="true" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="#" HeaderStyle-CssClass="gdv">
                <ItemTemplate>
                    <asp:Label ID="lblCodigo" Visible="true" runat="server" Text='<%#Eval("EntradaId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Data" HeaderStyle-CssClass="gdv">
                <ItemTemplate>
                    <asp:Label ID="lbldata" runat="server" Text='<%#Eval("DateRepair","{0:yyyy/MM/dd}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Model" HeaderStyle-CssClass="gdv">
                <ItemTemplate>
                    <asp:Label ID="lblModel" runat="server" Text='<%#Eval("Model") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sintomas" HeaderStyle-CssClass="gdv">
                <ItemTemplate>
                    <asp:Label ID="lblSintomas" runat="server" Text='<%#Eval("Sintomas") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="CN" HeaderStyle-CssClass="gdv">
                <ItemTemplate>
                    <asp:Label ID="lblCN" runat="server" Text='<%#Eval("CN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="UN" HeaderStyle-CssClass="gdv">
                <ItemTemplate>
                    <asp:Label ID="lblUN" runat="server" Text='<%#Eval("UN") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Line" HeaderStyle-CssClass="gdv">
                <ItemTemplate>
                    <asp:Label ID="lblLine" runat="server" Text='<%#Eval("Line") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div class="form-group">
       Código:<asp:Label ID="lblCodigoEnvio" runat="server"></asp:Label>
    </div>
    <asp:Label ID="lblCod" runat="server"></asp:Label>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <h4 class="modal-title" id="exampleModalLabel">New message</h4>
                </div>
                <div class="modal-body">

                    <div class="form-group">
                        <label for="recipient-name" class="control-label">Recipient:</label>
                        <input type="text" class="form-control" id="recipient-name">
                    </div>
                    <div class="form-group">
                        <label for="message-text" class="control-label">Message:</label>
                        <textarea class="form-control" id="message-text"></textarea>
                    </div>

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>
                    <button type="button" class="btn btn-primary">Send message</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
