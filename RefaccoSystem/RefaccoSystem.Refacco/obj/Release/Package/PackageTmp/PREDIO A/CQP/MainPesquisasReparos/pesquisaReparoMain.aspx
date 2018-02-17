<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="pesquisaReparoMain.aspx.cs" Inherits="RefaccoSystem.Refacco.MainPesquisasReparos.pesquisaReparoMain" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ConteinerPesquisa">
         <h4>Pesquisa por C/N</h4><br />
        <div id="boxPesquisa">
             <div class="form-inline">
                <div class="form-group">
                    <label for="cn" class="control-label col-md-2">C/N:</label>
                    <div class="col-md-10">
                        <asp:TextBox ID="txtcn" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-10">
                        <asp:LinkButton ID="btnPesquisar" runat="server" CssClass="btn btn-primary" OnClick="btnPesquisar_Click">
                            <span class="glyphicon glyphicon-search"> Pesquisa</span>
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </div>
        <hr />
        <div id="Grvpesquisa">
            <asp:GridView ID="GridView1" runat="server" CssClass="grd">

            </asp:GridView>
        </div>
    </div>
</asp:Content>
