$("input[data-bootstrap-switch]").each(function () {
    $(this).bootstrapSwitch('state', $(this).prop('checked'));
})
function LoadData(id) {
    $.ajax({
        url: '/Home/GetData?type=' + id,
        type: 'POST',
        dataType: 'json',
        success: function (data) {
            var dataObject_plotly = [];
            for (var i = 0; i < data.Object.length; i++) {
                var x = [];
                var y = [];
                var z = [];
                for (var j = 0; j < data.Object[i].length; j++) {
                    x.push(data.Object[i][j].x);
                    y.push(data.Object[i][j].y);
                }
                // chart 
                var _objplotly = {
                    type: 'lines',
                    name: data.Object[i][0].title,
                    x: x,
                    y: y,
                    hovertemplate: '<span><span>Actual</span>: %{y}' +
                        '<br><span>Forecast: </span> ' + data.Object[i][0].z + '<br></span>' +
                        "<extra></extra>"
                }
                dataObject_plotly.push(_objplotly);
            }
            var layout = {
                title: 'Quebec',
                yaxis: {
                    ticksuffix: '%',
                    range: [0, 100],
                    dtick: 25
                },
                hovermode: "closest",
                hoverlabel: { bgcolor: "black" },
                xaxis: {
                    nticks: 6,
                    range: [0, 4],
                    dtick: 1
                }
            };
            Plotly.newPlot('chartContainer', dataObject_plotly, layout, { modeBarButtonsToRemove: ['zoom2d', 'pan2d', 'select2d', 'lasso2d', 'zoomIn2d', 'zoomOut2d', 'resetScale2d', 'toImage'] });

            var layout = {
                title: 'Ontario',
                yaxis: {
                    ticksuffix: '%',
                    range: [0, 100],
                    dtick: 25
                },
                hovermode: "closest",
                hoverlabel: { bgcolor: "black" },
                xaxis: {
                    nticks: 6,
                    range: [0, 4],
                    dtick: 1
                }
            };
            Plotly.newPlot('chartContainer_v2', dataObject_plotly, layout, { modeBarButtonsToRemove: ['zoom2d', 'pan2d', 'select2d', 'lasso2d', 'zoomIn2d', 'zoomOut2d', 'resetScale2d', 'toImage'] });

            var layout_atlantic = {
                title: 'Atlantic',
                yaxis: {
                    ticksuffix: '%',
                    range: [0, 100],
                    dtick: 25
                },
                hovermode: "closest",
                hoverlabel: { bgcolor: "black" },
                xaxis: {
                    nticks: 6,
                    range: [0, 4],
                    dtick: 1
                }
            };
            Plotly.newPlot('chartContainer_atlantic', dataObject_plotly, layout_atlantic, { modeBarButtonsToRemove: ['zoom2d', 'pan2d', 'select2d', 'lasso2d', 'zoomIn2d', 'zoomOut2d', 'resetScale2d', 'toImage'] });

            var layout_overall = {
                title: 'Overall average',
                yaxis: {
                    ticksuffix: '%',
                    range: [0, 100],
                    dtick: 25
                },
                hovermode: "closest",
                hoverlabel: { bgcolor: "black" },
                xaxis: {
                    nticks: 6,
                    range: [0, 4],
                    dtick: 1
                }
            };
            Plotly.newPlot('chartContainer_overall', dataObject_plotly, layout_overall, { modeBarButtonsToRemove: ['zoom2d', 'pan2d', 'select2d', 'lasso2d', 'zoomIn2d', 'zoomOut2d', 'resetScale2d', 'toImage'] });
            // chart về 3
            var chart_v3 = new CanvasJS.Chart("chartContainer_v3", {
                axisX: {
                    lineThickness: 0,
                    tickLength: 0,
                    labelFormatter: function (e) {
                        return "";
                    }
                },
                axisY: {
                    lineThickness: 0,
                    tickLength: 0,
                    labelFormatter: function (e) {
                        return "";
                    }
                },
                toolTip: {
                    content: ""
                },
                data: [{
                    type: "line",
                    markerSize: 0,
                    showInLegend: false,
                    dataPoints: [
                        { x: 10, y: 85.4 },
                        { x: 20, y: 40.7 },
                        { x: 30, y: 78.9 },
                        { x: 40, y: 34.9 },
                        { x: 50, y: 67.9 }
                    ]
                }]
            });
            chart_v3.render();
            // chart v4
            var chart_v4 = new CanvasJS.Chart("chartContainer_v4", {
                axisX: {
                    lineThickness: 0,
                    tickLength: 0,
                    labelFormatter: function (e) {
                        return "";
                    }
                },
                axisY: {
                    lineThickness: 0,
                    tickLength: 0,
                    labelFormatter: function (e) {
                        return "";
                    }
                },
                toolTip: {
                    content: ""
                },
                data: [{
                    type: "line",
                    markerSize: 0,
                    showInLegend: false,
                    dataPoints: [
                        { x: 10, y: 85.4 },
                        { x: 20, y: 40.7 },
                        { x: 30, y: 78.9 },
                        { x: 40, y: 34.9 },
                        { x: 50, y: 67.9 }
                    ]
                }]
            });
            chart_v4.render();
            function toggleDataSeries(e) {
                if (typeof (e.dataSeries.visible) === "undefined" || e.dataSeries.visible) {
                    e.dataSeries.visible = false;
                } else {
                    e.dataSeries.visible = true;
                }
                e.chart.render();
            }
        },
        error: function (request, error) {
            // alert("Request: " + JSON.stringify(request));
        }
    });
}
LoadData("1");
$("#txtTitle").html("Quebec");
function changeSelect() {
    var value = $("#txtSelect").val();
    if (value === "1") {
        $("#txtTitle").html("Quebec");
        LoadData("1");
    }
    else {
        $("#txtTitle").html("Ontario");
        LoadData("2");
    }
    LoadDataSLA();
}
$("#txtTitleAuto").html("Auto-update data");
$("#txtYes").addClass("yes");
function changeYes() {
    var value = $('input[name="txtYesOrNo"]:checked');
    if (value.length > 0) {
        $("#txtTitleAuto").html("Auto-update data");
        $("#divAuto").removeClass("hidden");
        $("#txtYes").html("Yes");
        $("#txtYes").removeClass("no");
        $("#txtYes").addClass("yes");
    }
    else {
        $("#txtTitleAuto").html("&nbsp;");
        $("#divAuto").addClass("hidden");
        $("#txtYes").html("No");
        $("#txtYes").removeClass("yes");
        $("#txtYes").addClass("no");
    }
}

function clickView(id) {
    if (id === "1") {
        $("#txtMinus").removeClass("today");
        $("#txtToday").addClass("today");
    }
    else {
        $("#txtToday").removeClass("today");
        $("#txtMinus").addClass("today");
    }
}
function LoadDataSLA() {
    var xValue = ['Ontario', 'Quebec', 'Atlantic'];

    var yValue = [85, 80, 90];
    var zValue = ['85%', '80%', '90%'];
    var data = [
        {
            x: xValue,
            y: yValue,
            type: 'bar',
            text: zValue,
        }
    ];
    var layout = {
        title: {
            text: 'SLA by Region',
            font: {
                family: 'Arial'
            },
            xanchor: 'center'
        },
        yaxis: {
            ticksuffix: '%',
            tickformatstops: [0, 100]
        },
        height: 400
    };
    Plotly.newPlot('myDiv', data, layout, { modeBarButtonsToRemove: ['zoom2d', 'pan2d', 'select2d', 'lasso2d', 'zoomIn2d', 'zoomOut2d', 'resetScale2d', 'toImage'] });


    var data2 = [{
        values: [80, 20],
        labels: ['Average', ''],
        name: '',
        hoverinfo: 'label+percent+name',
        hole: .8,
        type: 'pie'
    }];

    var layout2 = {
        title: {
            text: 'SLA under 2 mins',
            font: {
                family: 'Arial'
            },
            xanchor: 'center'
        },
        annotations: [
            {
                font: { size: 20 },
                showarrow: false,
                text: '97 % / 2mins',
                x: 0.5,
                y: 0.5
            }
        ],
        height: 400,
        // width: 600,
        showlegend: false
    };
    Plotly.newPlot('myDiv_pie', data2, layout2, { modeBarButtonsToRemove: ['zoom2d', 'pan2d', 'select2d', 'lasso2d', 'zoomIn2d', 'zoomOut2d', 'resetScale2d', 'toImage'] });
}
LoadDataSLA();

