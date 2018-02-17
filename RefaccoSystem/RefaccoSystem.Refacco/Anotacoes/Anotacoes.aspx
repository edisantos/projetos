<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Anotacoes.aspx.cs" Inherits="RefaccoSystem.Refacco.Anotacoes.Anotacoes" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ConteinerAnotacao">
        <div id="boxAnotacao">
            <asp:LinkButton ID="bntNovo" runat="server" CssClass="btn btn-success" data-toggle="modal" data-target="#ModalComment">
                 <span class="glyphicon glyphicon-plus"> Novo</span>
            </asp:LinkButton>
            <div class="form-group">
                <asp:Label ID="lblMsg" runat="server" CssClass="label"></asp:Label>
            </div>
        </div>
        <div id="GridAnotacao">
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
        <div id="ModalComentario">
            <div class="modal fade" id="ModalComment" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Comentarios</h4>
                        </div>
                        <div class="modal-body">
                             <div class="form-group">
                               <label for="tipo">Tipo Processo</label>
                               <asp:TextBox ID="txtProcesso" runat="server" CssClass="form-control"></asp:TextBox>
                           </div>
                           <div class="form-group">
                               <label for="comment">Comentario</label>
                               <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                           </div>
                            <div class="form-group">
                               <label for="status">status</label>
                               <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                  
                                   <asp:ListItem Text="SELECT STATUS" Value="0"></asp:ListItem>
                                   <asp:ListItem Text="EM PROCESSO" Value="1"></asp:ListItem>
                                   <asp:ListItem Text="FINALIZADO" Value="2"></asp:ListItem>
                                   <asp:ListItem Text="EM ANALISE" Value="3"></asp:ListItem>
                               </asp:DropDownList>
                           </div>
                        </div>
                        <div class="modal-footer">
                             <asp:LinkButton ID="btnAdd" runat="server" class="btn btn-primary" OnClick="btnAdd_Click">
                                
                                 <span class="glyphicon glyphicon-floppy-saved"> Salvar</span>
                             </asp:LinkButton>
                            <button type="button" class="btn btn-default" data-dismiss="modal">
                                <span class="glyphicon glyphicon-level-up"> Sair</span>
                            </button>
                           
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>
