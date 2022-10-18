function loadData()
{
    $.ajax({
        type: "POST",
        url: serviceURL,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: {},
        headers: {
            "__RequestVerificationToken": formForgeryToken
        },
        success: crimeDataSuccessFunc,
        error: crimeDataErrorFunc
    });
}


function dataLoaded(data)
{


}
