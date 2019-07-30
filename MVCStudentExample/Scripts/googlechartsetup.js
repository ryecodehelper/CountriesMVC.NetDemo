// Load Charts and the corechart package.
google.charts.load('current', { 'packages': ['corechart', 'table'] });

// Draw the pie chart for Sarah's pizza when Charts is loaded.
google.charts.setOnLoadCallback(drawBarChart);

// Draw the pie chart for the Anthony's pizza when Charts is loaded.
google.charts.setOnLoadCallback(drawPieChart);

google.charts.setOnLoadCallback(drawTable);

// Callback that draws the pie chart for Sarah's pizza.
function drawBarChart() {
    var jsonData = $.ajax({
        url: "Home/BarChart",
        dataType: "json",
        async: false,
        cache: false
    }).responseText;
    // Create our data table out of JSON data loaded from server.
    //var data = new google.visualization.DataTable(jsonData);
    // Create the data table for Sarah's pizza.
    var test = JSON.parse(jsonData);
    var result = [];
    result.push(["Place", "Population", { role: "style" }]);

    for (var i in test)
        result.push([test[i].Name, test[i].Population, '#'+(Math.random()*0xFFFFFF<<0).toString(16)]);


    var data = google.visualization.arrayToDataTable(result);

    //var data = google.visualization.arrayToDataTable([
    //     ["Element", "Density", { role: "style" }],
    //     ["Copper", 8.94, "#b87333"],
    //     ["Silver", 10.49, "silver"],
    //     ["Gold", 19.30, "gold"],
    //     ["Platinum", 21.45, "color: #e5e4e2"]
    //]);

    var view = new google.visualization.DataView(data);
    view.setColumns([0, 1,
                     {
                         calc: "stringify",
                         sourceColumn: 1,
                         type: "string",
                         role: "annotation"
                     },
                     2]);

    var options = {
        title: "Top 10 Population",
        //width: 600,
        height: 600,
        bar: { groupWidth: "95%" },
        legend: { position: "none" },
    };
    var chart = new google.visualization.BarChart(document.getElementById("bar_chart"));
    chart.draw(view, options);
}

function drawPieChart() {
    var jsonData = $.ajax({
        url: "Home/PieChart",
        dataType: "json",
        async: false,
        cache: false
    }).responseText;

    var test = JSON.parse(jsonData);
    var result = [];

    for (var i in test)
        result.push([test[i].Name, test[i].Population]);


    var data = new google.visualization.DataTable();

    data.addColumn('string', 'Name');
    data.addColumn('number', 'Population');
    data.addRows(result);

    var options = {
        title: 'Top 10 Population',
        height: 600
    };

    var chart = new google.visualization.PieChart(document.getElementById('pie_chart'));
    chart.draw(data, options);
}

function drawTable() {
    var jsonData = $.ajax({
        url: "Home/TableChart",
        dataType: "json",
        async: false,
        cache: false
    }).responseText;

    var test = JSON.parse(jsonData);
    var result = [];
    for (var i in test) {
        result.push([test[i].name, test[i].count]);
    }
    var data = new google.visualization.DataTable();
    data.addColumn('string', 'Name');
    data.addColumn('number', 'Population');
    data.addRows(result);

    var table = new google.visualization.Table(document.getElementById('table_chart'));

    table.draw(data, { showRowNumber: true, width: '100%', height: '100%' });
}