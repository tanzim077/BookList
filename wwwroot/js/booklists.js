var dataTable
$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_Load').dataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {"data":"name","width":"30%"},
            {"data":"author","width":"30%"},
            { "data": "isbn", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center"> </div>
                    <a href >
                `
                }
            }
        ]
    })
}