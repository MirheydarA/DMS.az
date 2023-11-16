//$(function () {
//    var skipRow = 1;

//    $('#loadMore').on('click', function () {
//        $.ajax({
//            url: "/home/loadmore",
//            type: "GET",
//            data: {
//                skipRow: skipRow
//            },
//            contentType: "application/json",
//            success: function (Response) {
//                $('#services-container').append(Response);
//                skipRow++;
//            }
//        })
//    })
//})

$(function () {
    var skipRow = 1;

    $('#loadMore').on('click', function () {
        $.ajax({
            url: "/home/loadmore",
            type: "GET",
            data: {
                skipRow: skipRow
            },
            contentType: "application/json",
            success: function (response) {
                $('#services-container').append(response);

                // Check if there are more services
                //if (!response.hasMoreServices) {
                //    alert()
                //    $('#loadMore').hide();
                //}
                console.log(response.hasMoreServices)

                skipRow++;
            }
        });
    });
});
