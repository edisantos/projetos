<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DashboardOverview.aspx.cs" Inherits="RefaccoSystem.Refacco.Reports.DashboardOverview" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="conteinerGeralChart">
        <h1>Overview dashboard</h1>
      <div id="chart1">
        <canvas id="myChart"></canvas>
    </div>
        <div id="chart2">
        <canvas id="myChart2"></canvas>
    </div>
          <div id="chart3">
        <canvas id="myChart3"></canvas>
    </div>
          <div id="chart4">
        <canvas id="myChart4"></canvas>
    </div>
    </div>
    <script src="/refacco/Scripts/Chart.js"></script>
 <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.4.0/Chart.min.js"></script>   
    <!--======================= GRAFICO 1 =============================-->
        <script>
            var ctx = document.getElementById("myChart").getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: ["Janeiro", "Fevereiro", "Marco", "Abril", "Maio", "Junho"],
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
                            },
                            title: {
                                display: true,
                                fontSize: 20,
                                text: "RELATORIO MENSAL",

                            },
                            labels: {
                                fontStyle:"bold"
                            }
                        }]
                    }
                }
            });
        </script>
     <!--======================= GRAFICO 2 =============================-->
    <script>
            var ctx = document.getElementById("myChart2").getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: ["Janeiro", "Fevereiro", "Marco", "Abril", "Maio", "Junho"],
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
                            },
                            title: {
                                display: true,
                                fontSize: 20,
                                text: "RELATORIO MENSAL",

                            },
                            labels: {
                                fontStyle: "bold"
                            }
                        }]
                    }
                }
            });
        </script>
    <!--======================= GRAFICO 3 =============================-->
    <script>
            var ctx = document.getElementById("myChart3").getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'polarArea',
                data: {
                    labels: ["Janeiro", "Fevereiro", "Marco", "Abril", "Maio", "Junho"],
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
                            },
                            title: {
                                display: true,
                                fontSize: 20,
                                text: "RELATORIO MENSAL",

                            },
                            labels: {
                                fontStyle: "bold"
                            }
                        }]
                    }
                }
            });
        </script>
    <!--======================= GRAFICO 4 =============================-->
    <script>
            var ctx = document.getElementById('myChart4').getContext('2d');
            //type, data e options
            var chart = new Chart(ctx, {
                type: 'line',
                data: {
                    labels: ["Jan", "Fev", "Mar"],
                    datasets: [{
                        label: "RELATORIOS DE RAPARO A",
                        data: [15, 10, 30],
                        borderWidth: 6,
                        borderColor: 'rgba(77,166,23,0.85)',
                        backgroundColor: 'transparent',
                    },
                    {
                        label: "RELATORIOS DE RAPARO B",
                        data: [5, 15, 35],
                        borderWidth: 6,
                        borderColor: 'rgba(77,166,23,0.90)',
                        backgroundColor: 'transparent',
                    },

                    ]
                },
                options: {
                    title: {
                        display: true,
                        fontSize: 20,
                        text: "RELATORIOS MENSAL"
                    },
                    labels: {
                        fontStyle: "bold",
                    }
                }
            });
    </script>
</asp:Content>
