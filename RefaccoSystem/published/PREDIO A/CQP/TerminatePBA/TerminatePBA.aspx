<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TerminatePBA.aspx.cs" Inherits="RefaccoSystem.Refacco.TerminatePBA.TerminatePBA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ConteinerGrid">
        <div class="informationUser">


            <h3 id="Logado" runat="server" style="color: #808080"></h3>

            <div class="alert alert-info" role="alert">
                <h3><span class="glyphicon glyphicon-hand-down">REPARO FINALIZADO</span></h3>
            </div>
        </div>
        <div id="GridParaReparo">
            <nav class="navbar navbar-light bg-faded">
                <div class="form-inline">
                    <asp:LinkButton class="btn btn-outline-success" runat="server" data-toggle="modal" data-target="#myModal">
                        <span class="glyphicon glyphicon-plus"> Finalizar Processo</span>
                    </asp:LinkButton>
                   
                </div>
            </nav>
            <p class="text-danger">
                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
            </p>

            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                     <div class="form-inline">
                        <asp:Panel ID="Panel1" runat="server">
                            <div class="form-group has-success has-feedback">
                                <asp:TextBox ID="txtSeach" runat="server" CssClass="form-control" aria-describedby="inputSuccess2Status" AutoPostBack="true" OnTextChanged="txtSeach_TextChanged"></asp:TextBox>
                            </div>
                            <div class="form-group has-success has-feedback">
                                <asp:LinkButton ID="btnSearch" runat="server" CssClass="form-control" OnClick="btnSearch_Click">
                                <span class="glyphicon glyphicon-search"></span>
                                </asp:LinkButton>
                            </div>
                        </asp:Panel>

                    </div>
                    <br />
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped gdv" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CkbHeader" runat="server" AutoPostBack="true" OnCheckedChanged="CkbHeader_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CkbInsert" runat="server" AutoPostBack="true" OnCheckedChanged="CkbInsert_CheckedChanged" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblCodigo" runat="server" Text='<%#Eval("EntradaId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data">
                                <ItemTemplate>
                                    <asp:Label ID="lblData" runat="server" Text='<%#Eval("DateRepair","{0:yyyy/MM/dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="PartNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblPartNumber" runat="server" Text='<%#Eval("PartNumber") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Modelo">
                                <ItemTemplate>
                                    <asp:Label ID="lblModelo" runat="server" Text='<%#Eval("Model") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sintoma">
                                <ItemTemplate>
                                    <asp:Label ID="lblSintomas" runat="server" Text='<%#Eval("Sintomas") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="C/N">
                                <ItemTemplate>
                                    <asp:Label ID="lblSeria" runat="server" Text='<%#Eval("CN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="UN">
                                <ItemTemplate>
                                    <asp:Label ID="lblUN" runat="server" Text='<%#Eval("UN") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Causa">
                                <ItemTemplate>
                                    <asp:Label ID="lblCausa" runat="server" Text='<%#Eval("Causa") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                    <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Location") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Defeito">
                                <ItemTemplate>
                                    <asp:Label ID="lblDefect" runat="server" Text='<%#Eval("Defeito") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ação">
                                <ItemTemplate>
                                    <asp:Label ID="lblAction" runat="server" Text='<%#Eval("Action") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Panel ID="PanelMsg" runat="server">
                <div class="alert alert-danger" role="alert">
                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMsgError" runat="server"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </asp:Panel>
        </div>
        <div id="modalListaDeReparo">

            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Formulário de Reparo</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="lblCod" runat="server"></asp:Label>
                                        <asp:Label ID="lblStatusFinal" runat="server" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                              <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel2" runat="server">
                                            <label for="status">Status Terminate:</label>
                                            <asp:DropDownList ID="ddlStatusFeedback" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="SELECIONE O STATUS" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="TERMINATE" Value="1"></asp:ListItem>
                                                <asp:ListItem Text="RETURN REPAIR" Value="2"></asp:ListItem>
                                            </asp:DropDownList>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <label for="descr">Description:</label>
                                        <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" CssClass="form-control" Height="40px"></asp:TextBox>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnSalvar" runat="server" class="btn btn-success" OnClick="btnSalvar_Click">
                                 <span class="glyphicon glyphicon-pencil"> Registrar</span>
                            </asp:LinkButton>
                            <button type="button" class="btn btn-default" data-dismiss="modal">Fechar</button>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function openModal() {
            $("#myModal").modal('show');
        }
    </script>
</asp:Content>
