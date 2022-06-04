<?php
 
$connection = mysqli_connect('localhost', 'root', '', 'gameprojectdb');
 
 
if(isset($_POST["newAccountUsername"])){
    $username = mysqli_real_escape_string($connection, $_POST["newAccountUsername"]);
    $password = mysqli_real_escape_string($connection, $_POST["newAccountPassword"]);
    //Check are they empty?
    if($username != "" && $password != ""){
        //Check is the username has not taken
        if(mysqli_num_rows(mysqli_query($connection, "SELECT * FROM users WHERE username = '$username'")) == 0){
            mysqli_query($connection, "INSERT INTO users (username, password) VALUES ('$username', '$password')");
            echo "Regitering new account: Username ''" . $username . "';" and "password: ''" . $username . "';";
        }else{
            echo "This Username is not available. Please use another username.";
        }       
    }else{
        echo "Both fields are required.";
    }
}else if(isset($_POST["loginUsername"])){
    $username = mysqli_real_escape_string($connection, $_POST["loginUsername"]);
    $password = mysqli_real_escape_string($connection, $_POST["loginPassword"]);
    if($username != "" && $password != ""){
        //Check are entered username and password matched
        $sql = "SELECT * FROM users WHERE username = '$username' AND password = '$password'";
        if(mysqli_num_rows(mysqli_query($connection, $sql)) > 0){
            echo 1; //success
        }else{
            echo 0; //fail
        }
    }else{
        echo "Both fields are required.";
    }
}else{
    echo "Unity Login Logout and Register";
}
?>






