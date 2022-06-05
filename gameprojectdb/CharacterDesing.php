<?php
     
$connection = mysqli_connect('localhost', 'root', '', 'gameprojectdb');


    if(isset($_POST["newplayerName"])){
        $name = mysqli_real_escape_string($connection, $_POST["newplayerName"]);
        $lastname = mysqli_real_escape_string($connection, $_POST["newplayerLastName"]);
        $age = mysqli_real_escape_string($connection, $_POST["newplayerAge"]);
        $nation = mysqli_real_escape_string($connection, $_POST["newplayerNation"]);
        $club = mysqli_real_escape_string($connection, $_POST["newplayerClub"]);

    
        if($name != "" && $lastname != ""){
        //Check is the username has not taken
            if(mysqli_num_rows(mysqli_query($connection, "SELECT * FROM players WHERE name = '$name'")) == 0){
                mysqli_query($connection, "INSERT INTO players (name, lastname, age, nation, club) VALUES ('$name', '$lastname', '$age', '$nation', '$club')");
                
                echo "Regitering new player";
            }else{
                echo "This name is not available. Please use another name.";
            }       
        }else{
            echo "Both fields are required.";
        }
    }else if(isset($_POST["loginplayerName"])){
        $name = mysqli_real_escape_string($connection, $_POST["loginplayerName"]);
        $lastname = mysqli_real_escape_string($connection, $_POST["loginplayerLastName"]);
        $age = mysqli_real_escape_string($connection, $_POST["loginplayerAge"]);
        $nation = mysqli_real_escape_string($connection, $_POST["loginplayerNation"]);
        $club = mysqli_real_escape_string($connection, $_POST["loginplayerClub"]);
        


        if($username != "" && $password != ""){
        //Check are entered username and password matched
            $sql = "SELECT * FROM players WHERE name = '$name' AND lastname = '$lastname'";
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