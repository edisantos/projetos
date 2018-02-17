<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SearchMain.aspx.cs" Inherits="RefaccoSystem.Refacco.PREDIO_A.MAIN.SEARCH.SearchMain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="containerSearchMAIN">
        
        <div id="menuSearch">
            <p>Pesquisa</p>
            <hr />
            <div id="Formdate">
                <div class="form-group">
                    <label for="data">Data</label>
                    <asp:TextBox ID="txtdate1" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">

                    <asp:TextBox ID="txtdate2" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <hr />
                <div class="form-group">
                    <label for="cn">CN</label>
                    <asp:TextBox ID="txtCN" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="cn">Cod</label>
                    <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <hr />
                <div class="form-group">
                    <asp:LinkButton ID="btnSubmit" runat="server" CssClass="btn btn-success" OnClick="btnSubmit_Click">
                        <span class="glyphicon glyphicon-search"> Pesquisa</span>
                    </asp:LinkButton>
                </div>
            </div>
        </div>
        <div id="conteudoSearch">
            <div id="GridMain">
                <h3>TOP 10</h3>
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-striped gdv" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblData" runat="server" Text='<%#Eval("Data","{0:yyy/MM/dd}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Hora">
                                    <ItemTemplate>
                                        <asp:Label ID="lblhora" runat="server" Text='<%#Eval("Hora") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("CodFirebird") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="CN">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCN" runat="server" Text='<%#Eval("CN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="UN">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUN" runat="server" Text='<%#Eval("UN") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Modelo">
                                    <ItemTemplate>
                                        <asp:Label ID="lblModel" runat="server" Text='<%#Eval("Model") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Sintoma">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSintomas" runat="server" Text='<%#Eval("Sintomas") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%-- <asp:TemplateField HeaderText="PartNumber">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPartnumber" runat="server" Text='<%#Eval("PartNumber") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                 <asp:TemplateField HeaderText="RpairMan">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRepairMan" runat="server" Text='<%#Eval("UserName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
            <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </div>

    </div>
    <link href="../../../Content/jquery-ui.css" rel="stylesheet" />
    <%--<script src="../../../Scripts/jquery-1.10.2.js"></script>
    <script src="../../../Scripts/bootstrap.min.js"></script>--%>
    <script src="../../../Scripts/jquery-ui.js"></script>

    <script>
        $(document).ready(function () {
            $("#MainContent_txtdate1").datepicker({ dateFormat: 'yy/mm/dd' });
            $("#MainContent_txtdate2").datepicker({ dateFormat: 'yy/mm/dd' });
        });
    </script>
</asp:Content>
