var LoginHandler = function (username, password) {
    var params = {
        'Username': username,
        'Password': password
    };
    // element
    var spinner = document.getElementsByClassName("spinner")[0];
    $.ajax({
        type: "POST",
        url: "/Login/LoginEvent",
        data: params,
        dataType: 'json',
        timeout: 600000,
        beforeSend: function(){
            // spinner oynat
            spinner.style.display = "block";
        },
        success: function (response) {
            spinner.style.display = "none";
            console.log(response);
            if(response.Success){
                var aElement = document.createElement("a");
                aElement.href = "/Home";
                aElement.click();
            }else{
                console.log("başarısı");
            }
        },
        error: function (response) {
            spinner.style.display = "none";
            console.log(response);
        }
    });
}