<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportRepair.aspx.cs" Inherits="RefaccoSystem.Refacco.Reports.ReportRepair" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="conteiner">
        <div id="ChartConteiner">
             <canvas id="myChart"></canvas>
        </div>
            
    </div>
    <script src="../Scripts/Chart.js"></script>
    //======================= INICIO GRAFICO LINHAS =====================================================================
        <script>
            var ctx = document.getElementById("myChart").getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ["Janeiro", "Fevereiro", "Marco", "Abriu", "Maio", "Junho"],
                    datasets: [{
                        label: 'Repair',
                        data: [12, 19, 3, 5, 2, 3],
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255,99,132,1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });
        </script>

    //======================= FUNÇÃO GERA GRÁFICOS =====================================================================
    <script>
            //function gerarGraficos() {
            //    var ctx = document.getElementById("myChart").getContext("2d");
            //    var myChart = new Chart(ctx, {
            //        type: 'bar',
            //        data: dataBar,
            //        options: optionsBar
            //    });

            //}

            //window.onload = gerarGraficos;

            //gerarGraficos();

            $.jax({
                type: 'POST',
                url:'Charts.cs'
            });
    </script>
      
</asp:Content>
