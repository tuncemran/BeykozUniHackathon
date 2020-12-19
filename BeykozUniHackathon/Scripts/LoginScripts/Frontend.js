var LoginEvent = function () {
    // get username password
    var userName = document.getElementById("userName").value;
    var password = document.getElementById("password").value;
    
    if( userName == "" || password == ""){
        alert("Kullanıcı Adı veya Şifreyi girmemişsiniz");
    }
    else{
        LoginHandler(userName, password);
        document.getElementById("password").value = "";
    }
}

var PageOnLoad = function () {
    var navbar = document.getElementsByClassName("navbar")[0];
    navbar.style.display = "none";
}