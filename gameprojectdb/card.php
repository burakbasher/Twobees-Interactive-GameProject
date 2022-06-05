<?php

$connection = mysqli_connect('localhost', 'root', '', 'gameprojectdb');

$sql = "SELECT name, lastname, nation, club FROM players ORDER BY id DESC";



$result = mysqli_query($connection, $sql);

if($result)
{
	

	while($row = mysqli_fetch_assoc($result))
	{
		echo $row["name"] . "," . $row["lastname"] . "," . $row["nation"] . "," . $row["club"] . "*";
	}
}
else{
	echo "Error";
}

?>