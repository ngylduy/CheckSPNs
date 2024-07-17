/*
 * Author: Abdullah A Almsaeed
 * Date: 4 Jan 2014
 * Description:
 *      This is a demo file used only for the main dashboard (index.html)
 **/

/* global moment:false, Chart:false, Sparkline:false */

$(function () {
  'use strict'

  // Make the dashboard widgets sortable Using jquery UI
  $('.connectedSortable').sortable({
    placeholder: 'sort-highlight',
    connectWith: '.connectedSortable',
    handle: '.card-header, .nav-tabs',
    forcePlaceholderSize: true,
    zIndex: 999999
  })
  $('.connectedSortable .card-header').css('cursor', 'move')

  // jQuery UI sortable for the todo list
  $('.todo-list').sortable({
    placeholder: 'sort-highlight',
    handle: '.handle',
    forcePlaceholderSize: true,
    zIndex: 999999
  })

  // bootstrap WYSIHTML5 - text editor
  $('.textarea').summernote()



    // Sales graph chart
    var salesGraphChartCanvas = document.getElementById('line-chart')
    if (salesGraphChartCanvas.getContext) {
        salesGraphChartCanvas = salesGraphChartCanvas.getContext('2d');
    }
    var salesGraphChart; // Store the chart instance for later updating

    var reportDate = [];
    var reportCount = [];

    // Date conversion function (no changes needed)
    function convertDate(dateString) {
        var date = new Date(dateString);
        var formattedDate =
            (date.getDate() < 10 ? '0' + date.getDate() : date.getDate()) + '/' +
            (date.getMonth() + 1 < 10 ? '0' + (date.getMonth() + 1) : (date.getMonth() + 1)) + '/' +
            date.getFullYear();

        return formattedDate;
    }

    // Initial data fetch and chart creation (moved to a function)
    function fetchDataAndCreateChart(fromDate, toDate) {
        var urlApi = "https://localhost:5000/api/Stats/stat-report-by-time?from=" + fromDate + "&to=" + toDate;
        console.log(urlApi);

        reportDate = [];
        reportCount = [];

        $.get(urlApi, function (data, status) {
            if (data.isSuccess) {
                data.value.forEach(function (item) {
                    reportDate.push(convertDate(item.reportDate));
                    reportCount.push(item.count);
                });

                // Update or create the chart
                if (salesGraphChart) {
                    salesGraphChart.data.labels = reportDate;
                    salesGraphChart.data.datasets[0].data = reportCount;
                    salesGraphChart.update();
                } else {
                    var salesGraphChartData = {
                        labels: reportDate,
                        datasets: [
                            {
                                label: 'Reports',
                                fill: false,
                                borderWidth: 3,
                                lineTension: 0,
                                spanGaps: true,
                                borderColor: '#efefef',
                                pointRadius: 4,
                                pointHoverRadius: 7,
                                pointColor: '#efefef',
                                pointBackgroundColor: '#efefef',
                                data: reportCount
                            }
                        ]
                    };
                    var salesGraphChartOptions = {
                        maintainAspectRatio: false,
                        responsive: true,
                        legend: {
                            display: false
                        },
                        scales: {
                            xAxes: [{
                                ticks: {
                                    fontColor: '#efefef'
                                },
                                gridLines: {
                                    display: false,
                                    color: '#efefef',
                                    drawBorder: false
                                }
                            }],
                            yAxes: [{
                                ticks: {
                                    stepSize: 5000,
                                    fontColor: '#efefef'
                                },
                                gridLines: {
                                    display: true,
                                    color: '#efefef',
                                    drawBorder: false
                                }
                            }]
                        }
                    };
                    salesGraphChart = new Chart(salesGraphChartCanvas, {
                        type: 'line',
                        data: salesGraphChartData,
                        options: salesGraphChartOptions
                    });
                }
            }
        });
    }
    // Initial chart creation with default date range
    fetchDataAndCreateChart(moment().subtract(6, 'days').format('YYYY/MM/DD'), moment().add(1, 'days').format('YYYY/MM/DD'));

  $('.daterange').daterangepicker({
    ranges: {
      'Last 7 Days': [moment().subtract(6, 'days'), moment().add(1, 'day')],
      'Last 30 Days': [moment().subtract(29, 'days'), moment().add(1, 'days')],
      'This Month': [moment().startOf('month'), moment().endOf('month')],
      'Last Month': [moment().subtract(1, 'month').startOf('month'), moment().subtract(1, 'month').endOf('month')]
    },
    showCustomRangeLabel: false,
    startDate: moment().subtract(6, 'days'),
      endDate: moment().add(1, 'days')
  }, function (start, end) {
      fetchDataAndCreateChart(start.format('YYYY/MM/DD'), end.format('YYYY/MM/DD'));
  })

  /* jQueryKnob */
  $('.knob').knob()

  // The Calender
  $('#calendar').datetimepicker({
    format: 'L',
    inline: true
  })

  // SLIMSCROLL FOR CHAT WIDGET
  $('#chat-box').overlayScrollbars({
    height: '250px'
  })

  /* Chart.js Charts */
  // Sales chart
  var salesChartCanvas = document.getElementById('revenue-chart-canvas').getContext('2d')
  // $('#revenue-chart').get(0).getContext('2d');

  var salesChartData = {
    labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
    datasets: [
      {
        label: 'Digital Goods',
        backgroundColor: 'rgba(60,141,188,0.9)',
        borderColor: 'rgba(60,141,188,0.8)',
        pointRadius: false,
        pointColor: '#3b8bba',
        pointStrokeColor: 'rgba(60,141,188,1)',
        pointHighlightFill: '#fff',
        pointHighlightStroke: 'rgba(60,141,188,1)',
        data: [28, 48, 40, 19, 86, 27, 90]
      },
      {
        label: 'Electronics',
        backgroundColor: 'rgba(210, 214, 222, 1)',
        borderColor: 'rgba(210, 214, 222, 1)',
        pointRadius: false,
        pointColor: 'rgba(210, 214, 222, 1)',
        pointStrokeColor: '#c1c7d1',
        pointHighlightFill: '#fff',
        pointHighlightStroke: 'rgba(220,220,220,1)',
        data: [65, 59, 80, 81, 56, 55, 40]
      }
    ]
  }

  var salesChartOptions = {
    maintainAspectRatio: false,
    responsive: true,
    legend: {
      display: false
    },
    scales: {
      xAxes: [{
        gridLines: {
          display: false
        }
      }],
      yAxes: [{
        gridLines: {
          display: false
        }
      }]
    }
  }

  // This will get the first returned node in the jQuery collection.
  // eslint-disable-next-line no-unused-vars
  var salesChart = new Chart(salesChartCanvas, { // lgtm[js/unused-local-variable]
    type: 'line',
    data: salesChartData,
    options: salesChartOptions
  })

  // Donut Chart
  var pieChartCanvas = $('#phonenumber-status-chart-canvas').get(0).getContext('2d')
  var pieData = {
    labels: [
      'Negative',
      'Positive',
      'Neutral'
    ],
    datasets: [
      {
        data: phoneNumberStatPercent,
        backgroundColor: ['#f56954', '#00a65a', '#f39c12']
      }
    ]
  }
  var pieOptions = {
    legend: {
      display: true
    },
    maintainAspectRatio: false,
    responsive: true
  }
  // Create pie or douhnut chart
  // You can switch between pie and douhnut using the method below.
  // eslint-disable-next-line no-unused-vars
  var pieChart = new Chart(pieChartCanvas, { // lgtm[js/unused-local-variable]
    type: 'doughnut',
    data: pieData,
    options: pieOptions
  })

    var reportDateOfWeek = ["Thứ 2", "Thứ 3", "Thứ 4", "THứ 5", "Thứ 6", "Thứ 7", "Chủ nhật"];

    var reportLastWeekCount = [0, 0, 0, 0, 0, 0, 0];  // Array for last week's counts
    var reportThisWeekCount = [0, 0, 0, 0, 0, 0, 0]; // Array for this week's counts


    var fromLastWeek = moment().subtract(1, 'weeks').startOf('week').format('YYYY/MM/DD');
    var toLastWeek = moment().subtract(1, 'weeks').endOf('week').format('YYYY/MM/DD');
    var fromThisWeek = moment().startOf('week').format('YYYY/MM/DD');
    var toThisWeek = moment().endOf('week').format('YYYY/MM/DD');

    var urlApiLastWeek = "https://localhost:5000/api/Stats/stat-report-by-time?from=" + fromLastWeek + "&to=" + toLastWeek;
    var urlApiThisWeek = "https://localhost:5000/api/Stats/stat-report-by-time?from=" + fromThisWeek + "&to=" + toThisWeek;

    $.get(urlApiLastWeek, function (data, status) {
        if (data.isSuccess) {
            data.value.forEach(function (item) {
                var dayIndex = moment(item.reportDate).day(); // Adjust for Vietnamese week start (Monday=0)
                if (dayIndex >= 0 && dayIndex < 7) { // Ensure valid day index
                    reportLastWeekCount[dayIndex] = item.count;
                }
            });

            // Update the chart (see below)
            updateChart();
        }
    });

    // Fetch and process data for this week
    $.get(urlApiThisWeek, function (data, status) {
        if (data.isSuccess) {
            data.value.forEach(function (item) {
                var dayIndex = moment(item.reportDate).day(); // Adjust for Vietnamese week start (Monday=0)
                if (dayIndex >= 0 && dayIndex < 7) { // Ensure valid day index
                    reportThisWeekCount[dayIndex] = item.count;
                }
            });

            // Update the chart (see below)
            updateChart();
        }
    });

    //$.get(urlApiLastWeek, function (data, status) {
    //    if (data.isSuccess) {
    //        data.value.forEach(function (item) {
    //            reportLastWeekCount.push(item.count);
    //        });
    //    }
    //});

    //$.get(urlApiThisWeek, function (data, status) {
    //    if (data.isSuccess) {
    //        data.value.forEach(function (item) {
    //            reportThisWeekCount.push(item.count);
    //        });
    //    }
    //});

    var ticksStyle = {
        fontColor: '#495057',
        fontStyle: 'bold'
    }
    var $visitorsChart = $('#visitors-chart')
    // eslint-disable-next-line no-unused-vars
    var visitorsChart = new Chart($visitorsChart, {
        data: {
            labels: reportDateOfWeek,
            datasets: [{
                type: 'line',
                data: reportThisWeekCount,
                backgroundColor: 'transparent',
                borderColor: '#007bff',
                pointBorderColor: '#007bff',
                pointBackgroundColor: '#007bff',
                fill: false
                // pointHoverBackgroundColor: '#007bff',
                // pointHoverBorderColor    : '#007bff'
            },
            {
                type: 'line',
                data: reportLastWeekCount,
                backgroundColor: 'tansparent',
                borderColor: '#ced4da',
                pointBorderColor: '#ced4da',
                pointBackgroundColor: '#ced4da',
                fill: false
                // pointHoverBackgroundColor: '#ced4da',
                // pointHoverBorderColor    : '#ced4da'
            }]
        },
        options: {
            maintainAspectRatio: false,
            tooltips: {
                mode: 'index',
                intersect: true
            },
            hover: {
                mode: 'index',
                intersect: true
            },
            legend: {
                display: false
            },
            scales: {
                yAxes: [{
                    // display: false,
                    gridLines: {
                        display: true,
                        lineWidth: '4px',
                        color: 'rgba(0, 0, 0, .2)',
                        zeroLineColor: 'transparent'
                    },
                    ticks: $.extend({
                        beginAtZero: true,
                    }, ticksStyle)
                }],
                xAxes: [{
                    display: true,
                    gridLines: {
                        display: false
                    },
                    ticks: ticksStyle
                }]
            }
        }
    })
    function updateChart() {
        if (visitorsChart) {
            visitorsChart.data.datasets[0].data = reportThisWeekCount;
            visitorsChart.data.datasets[1].data = reportLastWeekCount;
            visitorsChart.update();
        }
    }

})