(function () {
    Index = function (urls, data) {
        $(document).on("click", "#submitFile", function (event) {
            submitFile();
        });

        function init() {
            initResultTable();
        }

        function submitFile() {
            var fileReader = new FileReader();
            var blob = document.getElementById("inputFile").files[0];
            if (blob !== undefined) {
                fileReader.readAsDataURL(blob);
                fileReader.onload = function () {
                    var file = fileReader.result;
                    var strings = file.split(",");
                    $.ajax({
                        type: "POST",
                        url: urls.ProcessFile,
                        data: {
                            file: strings[1]
                        },
                        async: true,
                        success: function (result) {
                            $("#resultTableContainer").html(result);
                            initResultTable();
                        }
                    });
                };
                fileReader.onerror = function (error) {
                    console.log("Error: ", error);
                };
            }
        }

        function initResultTable() {
            $("#resultTable").DataTable({
                "columnDefs": [
                    {
                        "targets": [0],
                        "visible": false
                    }
                ],
                "order": [[0, "desc"]]
            });
        }

        init();
    }
}());