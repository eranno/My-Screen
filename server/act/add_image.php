<?php
/***
file: add_image.php
add contact member

input: email, serial (inner id), rsa
output:
0 - success
1 - no input \ no email \ no password \ ...
2 - bad email \ password
***/


//settings
include('../inc/settings.php');

//error - no email
if ( !$_POST || !isset($_POST['email']) || !isset($_POST['password']) || !isset($_POST['serial']) || !isset($_POST['rsa']) )
	exit('1');


//varify email and password
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);
$pass 	= $_POST['password'];
$serial	= $_POST['serial'];
$rsa	= $_POST['rsa'];


//connect to db
require('../inc/conn.php');

//add the new contact
$sql = "INSERT INTO `images` (`serial`, `rsa`, `owner`)
		SELECT '$serial', '$rsa', u.`id`
		FROM `users` as u
		WHERE u.email = '$email' AND BINARY u.`pass`='$pass'
		";
mysql_query($sql) or die('2');


//if success
if (mysql_affected_rows() == 1)
	echo '0';

//bad email/pass
else
	echo '2';


//close db
mysql_close($link);


//-----------------------------------------------------------------

?>
