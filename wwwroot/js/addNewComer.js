// This JS file now uses jQuery. Pls see here: https://jquery.com/
$(document).ready(function () {
    // see https://api.jquery.com/click/
    $("#add").click(function () {
        var newcomerName = $("#newcomer").val();
        $.ajax({
            url: 'api/Internship/',
            contentType: 'application/json',
            data: JSON.stringify({ "Name": `${newcomerName}` }),
            method: "POST",
            success: function (data) {
                // Remember string interpolation
               
                $("#newcomer").val("");
            },
            error: function (data) {
                alert(`Failed to add ${newcomerName}`);
            },
        });
    })
    $("#clear").click(function () {
        $("#newcomer").val("");
    })

    function refreshWeatherForecast() {
        $.ajax({
            url: `/WeatherForecast`,
            success: function (data) {
                let tommorow = data[0];
                let tommorowDate = formatDate(tommorow.date);
                $('#date').text(tommorowDate);
                $('#temperature').text(tommorow.temperatureC, 'C');
                $('#summary').text(tommorow.summary);
            },
            error: function (data) {
                alert(`Failed to load date`);
            },
        });
    }
    refreshWeatherForecast();
    setInterval(refreshWeatherForecast, 5000);
    function formatDate(jsonDate) {
        function join(t, a, s) {
            function format(m) {
                let f = new Intl.DateTimeFormat('en', m);
                return f.format(t);
            }
            return a.map(format).join(s);
        }
        let date = new Date(jsonDate);
        let a = [{ day: 'numeric' }, { month: 'short' }, { year: 'numeric' }];
        let s = join(date, a, '-');
        return s;
    }
});