

    /*$('#dataTable').DataTable({
        "language": {
            "url": "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Vietnamese.json"
        }
    });*/
$('#dataTable').DataTable({
       
    searching: false,
    lengthChange: true,
    info: false,
    paging: true,
    retrieve: true,
});

$('#datepicker').datepicker({
    uiLibrary: 'bootstrap4'
});
