<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProcessRepair.aspx.cs" Inherits="RefaccoSystem.Refacco.ProcessRepair.ProcessRepair" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Registro de Reparo</h3>
    <div id="ConteinerProcessRepair">
        <div id="continerCn">
            <div class="form-inline">
                 <asp:Panel ID="PnlDefaultButton" runat="server" DefaultButton="lkbSearch">
                <div class="form-group">
                    <%--<label for="sn">Entre com a C/N</label>--%>
                   
                   <asp:TextBox ID="txtCn" runat="server" CssClass="form-control" placeholder="Entre com a C/N ou Cod"></asp:TextBox>
                    
                   
                    <asp:Label ID="lblCodEntrada" runat="server" Visible="false"></asp:Label>
                </div>
                <div class="form-group">
                    <asp:LinkButton ID="lkbSearch" runat="server" CssClass="btn btn-primary" OnClick="lkbSearch_Click">
                        <span class="glyphicon glyphicon-search"> Search</span>
                    </asp:LinkButton>

                </div>
               
              </asp:Panel>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Panel ID="Panel1" runat="server">
                <div class="alert alert-danger" role="alert">
                    <asp:Label ID="lblMsgError" runat="server"></asp:Label>
                </div>
            </asp:Panel>

        </div>
        <br />
        <div class="form-group">
            <label for="massa">Defeito em Massa:</label>

            <asp:CheckBox ID="ckbMassa" runat="server" />
        </div>
        <hr />
        <div class="form-inline">
            <div class="form-group">
                <label for="produto">Produto</label>
                <asp:DropDownList ID="ddlProduto" runat="server" CssClass="form-control"></asp:DropDownList>
                <%--<asp:RequiredFieldValidator runat="server" ControlToValidate="ddlProduto" InitialValue="0"
                     CssClass="text-danger" ErrorMessage="Campo Produto é Obrigatório." />--%>
            </div>
            <div class="form-group">
                <label for="unit">Unit ID</label>
                <asp:DropDownList ID="ddlUnitId" runat="server" CssClass="form-control" OnTextChanged="ddlUnitId_TextChanged"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="unit">UN</label>
                <asp:TextBox ID="txtUn" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="InpeProcess">Insp. Processo</label>
                <asp:DropDownList ID="ddlInpsProcess" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>

            <div class="form-group">
                <label for="model">Modelo</label>
                <asp:TextBox ID="txtModels" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>

            <div class="form-group">
                <label for="sintomas">Sintoma</label>
                <asp:TextBox ID="txtSimtomas" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            </div>
        </div>
        <hr />

        <div class="form-inline">


            <div class="form-group">
                <label for="codBlocks">Linha</label>
                <asp:TextBox ID="txtBlocks" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="codDefectCause">Defeito Causa</label>
                <asp:DropDownList ID="ddlDefectCause" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="location">Location</label>
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="defectimput">Defeito Input</label>
                <asp:DropDownList ID="ddlDefectImput" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="lote">Lote</label>
                <asp:TextBox ID="txtLote" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="Partnumber">PartNumber</label>
                <asp:TextBox ID="txtPartNumber" runat="server" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="action">Ação</label>
                <asp:DropDownList ID="ddlAction" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="form-group">
                <label for="status">status</label>
                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <hr />
        <div class="form-horizontal">
            <div class="form-group">
                <label for="comentario">Comentario</label>
                <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="form-group">
                <asp:LinkButton ID="btnRegistrar" runat="server" CssClass="btn btn-success" OnClick="btnRegistrar_Click">
                    <span class="glyphicon glyphicon-floppy-saved"> Registrar</span>
                </asp:LinkButton>
            </div>
        </div>
        <hr />
        <div id="grid">
            <h4 runat="server" id="titleLista">Lista de reparos</h4>
            <div class="alert alert-warning">
                <label id="lblCount" runat="server" style="margin-left: 80%;"></label>
            </div>



            <asp:GridView ID="GrdLista" runat="server" CssClass="table table-bordered grd" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Data">
                        <ItemTemplate>
                            <asp:Label ID="lbldata" runat="server" Text='<%#Eval("Data","{0:yyyy/MM/dd}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Hora">
                        <ItemTemplate>
                            <asp:Label ID="lblhora" runat="server" Text='<%#Eval("Hora") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cod">
                        <ItemTemplate>
                            <asp:Label ID="lblCod" runat="server" Text='<%#Eval("CodFirebird") %>'></asp:Label>
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
                    <asp:TemplateField HeaderText="Linha">
                        <ItemTemplate>
                            <asp:Label ID="lblBlock" runat="server" Text='<%#Eval("Line") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Un">
                        <ItemTemplate>
                            <asp:Label ID="lblUN" runat="server" Text='<%#Eval("UN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CN">
                        <ItemTemplate>
                            <asp:Label ID="lblCN" runat="server" Text='<%#Eval("CN") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Usuário Entrada">
                        <ItemTemplate>
                            <asp:Label ID="lblUserEntrada" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
