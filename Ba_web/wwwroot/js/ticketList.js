var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/ticket",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "20%" },
            { "data": "addedAt", "width": "20%" },
            { "data": "type", "width": "10%" },
            { "data": "description", "width": "30%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                               <a href="/Tickets/Edit?id=${data}" class="btn btn-success text-white" style="cursor:pointer; width:70px;">
                                    Edit
                                </a>
                                &nbsp;
                                <a class="btn btn-danger text-white" style="cursor:pointer; width:70px;" onclick=Delete('/api/ticket?id='+${data})>
                                    Delete
                                </a>
                            </div>`;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}
    function Delete(url) {
        swal({
            title: "Are you sure?",
            text: "Once deleted, you will not be able to recover",
            icon: "warning",
            dangerMode: true,
            buttons:true
        }).then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "DELETE",
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            dataTable.ajax.reload();
                        } else {
                            toastr.error(data.message);
                        }
                    }
                });
            }
        });
    }
