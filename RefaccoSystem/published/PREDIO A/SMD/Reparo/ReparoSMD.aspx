<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReparoSMD.aspx.cs" Inherits="RefaccoSystem.Refacco.PREDIO_A.SMD.Reparo.ReparoSMD" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ConteinerListaParaReparo">
        <div class="informationUser">


            <h3 id="Logado" runat="server" style="color: #808080"></h3>


        </div>
        <div id="GridParaReparo">
            <p class="text-danger">
                <asp:Literal ID="ErrorMessage" runat="server"></asp:Literal>
            </p>

            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                     <div class="form-inline">
                        <asp:Panel ID="Panel7" runat="server">
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

                            <asp:TemplateField HeaderText="Id">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("EntradaId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Data">
                                <ItemTemplate>
                                    <asp:Label ID="lblData" runat="server" Text='<%#Eval("DateRepair","{0:yyyy/MM/dd}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Hora">
                                <ItemTemplate>
                                    <asp:Label ID="lblHora" runat="server" Text='<%#Eval("HoraRepair") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatusFinal" runat="server" Text='<%#Eval("StatusFinal") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tempo de analise">
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeTecnico" runat="server" Text='<%#Eval("TimeTecnico") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Tempo em reparo">
                                <ItemTemplate>
                                    <asp:Label ID="lblTimeRepair" runat="server" Text='<%#Eval("TimeRepair") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ação">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnRegister" runat="server" CssClass="btn btn-primary" OnClick="btnRegister_Click">
                               <span class="glyphicon glyphicon-floppy-saved"> </span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>

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
                                        <asp:Label ID="lblCodigo" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblStatusFinally" runat="server" Visible="true"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel1" runat="server">
                                            <label for="un">UN:</label>
                                            <asp:TextBox ID="txtUn" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Panel>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel2" runat="server">
                                            <label for="un">Defeito Causa:</label>
                                            <asp:DropDownList ID="ddlDefectCause" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel4" runat="server">
                                            <label for="un">Location:</label>
                                            <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control" OnTextChanged="ddlLocation_TextChanged"></asp:DropDownList>
                                        </asp:Panel>

                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel5" runat="server">
                                            <label for="un">Part-Number:</label>
                                            <asp:TextBox ID="txtPartNumber" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Panel>

                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel3" runat="server">
                                            <label for="un">Lote:</label>
                                            <asp:TextBox ID="txtLote" runat="server" CssClass="form-control"></asp:TextBox>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                    <ContentTemplate>
                                        <asp:Panel ID="Panel6" runat="server">
                                            <label for="un">Ação:</label>
                                            <asp:DropDownList ID="ddlAction" runat="server" CssClass="form-control"></asp:DropDownList>
                                        </asp:Panel>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <label for="status">Status:</label>
                                        <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control" OnTextChanged="ddlStatus_TextChanged" AutoPostBack="true">
                                            <asp:ListItem Text="SELECIONE STATUS" Value="0"></asp:ListItem>
                                            <asp:ListItem Text="PASS/TERMINATE" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="SCRAP/TERMINATE" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="TRANSFER TO REPAIR" Value="4"></asp:ListItem>
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <label for="un">Enviar Reparo:</label>
                                        <asp:DropDownList ID="ddlSendRepair" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnSalvar" runat="server" class="btn btn-success" OnClick="btnSalvar_Click">
                                 <span class="glyphicon glyphicon-pencil"> Registro</span>
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
            $('#myModal').modal('show');
        }
    </script>
</asp:Content>
