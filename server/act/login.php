<?php
/***
file: login.php
login validation

input: email, password
output: 
0 - success
1 - no input \ no email \ no pass
2 - bad name \ bad password
***/


//settings
include('../inc/settings.php');

//error - no email
if (!$_POST || !isset($_POST['email']) || !isset($_POST['password'])) 
	exit('1');

//varify email and password
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);
$pass	= $_POST['password'];
$ip 	= $_SERVER['REMOTE_ADDR']; if ($ip=='') $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];

//connect to db
require('../inc/conn.php');

$sql = "UPDATE `users` u
		SET u.`t_last`='$now', u.`ip`='$ip'
		WHERE u.`email`='$email' AND BINARY u.`pass`='$pass'";
mysql_query($sql);

//if success
if (mysql_affected_rows() == 1)
	echo '0';
else
	echo '2';

//close db
mysql_close($link);

//-----------------------------------------------------------------

?>
