<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterBoard.aspx.cs" Inherits="RefaccoSystem.Refacco.RegisterBoard.RegisterBoard" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="ContainerRegisterBoard">


        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <div id="GridRigisterBoard">
            <%--<h3>Lista de Placas para relacionamento com o Técnico</h3>--%>
            <p class="text-danger">
                <asp:Literal runat="server" ID="ErrorMessage" />

            </p>
            <p class="text-success">
                <asp:Literal runat="server" ID="SuccessMessage" />

            </p>
            <div id="boxButton">

                <div class="alert alert-info" role="alert">
                    <span class="glyphicon glyphicon-info-sign"> Registro Técnico + placa</span>
                </div>
            </div>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="form-inline">
                        <%--<div class="form-group">
                            <asp:DropDownList ID="ddlTecnicoFilter" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>--%>
                        <div class="form-group">
                            <asp:LinkButton ID="btnRegTecMassa" runat="server" CssClass="btn btn-outline-success" data-toggle="modal" data-target="#myModal">
                        <span class="glyphicon glyphicon-plus"> Register All</span>
                            </asp:LinkButton>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblCodigoEnvio" runat="server"></asp:Label>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>

            <hr />
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">

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
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="ckeckBoxHeader" runat="server" AutoPostBack="true" OnCheckedChanged="ckeckBoxHeader_CheckedChanged" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="ckeckBoxInsert" runat="server" AutoPostBack="true" OnCheckedChanged="ckeckBoxInsert_CheckedChanged" />
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
                            <asp:TemplateField HeaderText="Modelo" HeaderStyle-CssClass="gdv">
                                <ItemTemplate>
                                    <asp:Label ID="lblModel" runat="server" Text='<%#Eval("Model") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Sintoma" HeaderStyle-CssClass="gdv">
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
                            <asp:TemplateField HeaderText="Linha" HeaderStyle-CssClass="gdv">
                                <ItemTemplate>
                                    <asp:Label ID="lblLine" runat="server" Text='<%#Eval("Line") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%-- <asp:TemplateField HeaderText="" HeaderStyle-CssClass="gdv">
                                <ItemTemplate>
                                    <asp:LinkButton ID="bntRegister" runat="server" CssClass="btn btn-success" OnClick="bntRegister_Click" data-toggle="tooltip" data-placement="top" title="Clique aqui para selecionar a C/N desejada">
                                    <span class="glyphicon glyphicon-file"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>

        </div>
    </div>
    <div id="ModalReparo">

        <div class="modal fade" tabindex="-1" role="dialog" id="myModal">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title">REGISTRO TÉCNICO + PLACA</h4>
                    </div>

                    <div class="modal-body">
                        <div class="form-group">
                            <asp:UpdatePanel ID="UpdaPanel1" runat="server">
                                <ContentTemplate>
                                    <asp:Label ID="lblID" runat="server"></asp:Label>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                        <div class="form-group">
                            <label for="tecnico" runat="server">Técnico Responsável</label>
                            <asp:DropDownList ID="ddlTec" runat="server" CssClass="form-control"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <asp:Panel ID="Panel3" runat="server">

                            </asp:Panel>
                        </div>
                    </div>
                    <div class="modal-footer">
                        <asp:LinkButton ID="btnSalve" runat="server" CssClass="btn btn-primary" OnClick="btnSalve_Click">
                                <span class="glyphicon glyphicon-floppy-saved"> Registrar</span>
                        </asp:LinkButton>
                        <button type="button" class="btn btn-default" data-dismiss="modal">
                            <span class="glyphicon glyphicon-level-up">Fechar</span>
                        </button>

                    </div>
                </div>
                <!-- /.modal-content -->
            </div>
            <!-- /.modal-dialog -->
        </div>


    </div>
    <script>
        function openModal() {
            $('#myModal').modal('show');
        }


    </script>
</asp:Content>
