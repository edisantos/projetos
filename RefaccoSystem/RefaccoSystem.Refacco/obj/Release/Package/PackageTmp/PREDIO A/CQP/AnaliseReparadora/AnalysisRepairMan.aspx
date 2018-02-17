<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnalysisRepairMan.aspx.cs" Inherits="RefaccoSystem.Refacco.AnaliseReparadora.AnalysisRepairMan" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="ContainerRepairMan">
         <div class="informationUser">


            <h3 id="LogadoRepairMan" runat="server" style="color: #808080"></h3>


        </div>
          <p class="text-danger">
                <asp:Literal ID="ErrorMessageRepairMan" runat="server"></asp:Literal>
            </p>
        <div id="GridContainer">
            <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                <ContentTemplate>
                      <div class="form-inline">
                        <asp:Panel ID="Panel2" runat="server">
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
                            
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("RepairMainId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblEntradaId" runat="server" Text='<%#Eval("EntradaId") %>'></asp:Label>
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
                            <asp:TemplateField HeaderText="Time">
                                <ItemTemplate>
                                    <asp:Label ID="lblTime" runat="server" Text='<%#Eval("TimeRepair") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnRegister" runat="server" CssClass="btn btn-primary" OnClick="btnRegister_Click">
                               <span class="glyphicon glyphicon-floppy-saved"> Action</span>
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
                                        <asp:Label ID="lblCodigo" runat="server"></asp:Label>
                                        <asp:Label ID="lblEntrada" runat="server"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                            <asp:UpdatePanel ID="UpdaPanel2" runat="server">
                                <ContentTemplate>

                               <h3>Escolha as ações abaixo!</h3>
                            <%--<div class="form-group">
                                <label for="un">UN:</label>
                                <asp:Label ID="lblUn" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="cn">C/N:</label>
                                <asp:Label ID="lblCN" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="un">Defect Cause:</label>
                                 <asp:Label ID="lblCausa" runat="server"></asp:Label>
                            </div>
                            <div class="form-group">
                                
                                        <label for="un">Location:</label>
                                         <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                    

                            </div>
                            <div class="form-group">
                                
                                        <label for="un">Part-Number:</label>
                                        <asp:Label ID="lblPartNumber" runat="server"></asp:Label>
                                 
                            </div>
                            <div class="form-group">
                                <label for="un">Lot:</label>
                                <asp:Label ID="lblLote" runat="server"></asp:Label>
                            </div>--%>
                            <div class="form-group">
                                <label for="un">Action:</label>
                                <asp:DropDownList ID="ddlAction" runat="server" CssClass="form-control">
                                   <asp:ListItem Text="SELECIONE A AÇÂO" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="REPARO COMUM - OK" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="BGA - OK" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="SCRAP - PAD ARRANCADO" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="SCRAP ACESSO REPARO" Value="4"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="form-group">
                                <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                    <ContentTemplate>
                                        <label for="un">Send Repair:</label>
                                        <asp:DropDownList ID="ddlSendRepair" runat="server" CssClass="form-control">
                                            
                                            </asp:DropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnSalvar" runat="server" class="btn btn-success" OnClick="btnSalvar_Click">
                                 <span class="glyphicon glyphicon-pencil"> Register</span>
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
