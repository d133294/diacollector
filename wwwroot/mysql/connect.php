<?php
$db = mysqli_connect("localhost","root","root","mysql");

// Check connection
if($db->connect_errno > 0){
    die('Unable to connect to database [' . $db->connect_error . ']');
}

$sql = <<<SQL
    SELECT User
    FROM user
SQL;

if(!$result = $db->query($sql)){
    die('There was an error running the query [' . $db->error . ']');
}

while($row = $result->fetch_assoc()){
    echo $row['User'] . '<br />';
}

mysqli_close($db);
?>