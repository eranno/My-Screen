<?php
/***
file: change_password.php
password update

input: email, old_password, new_password
output:
0 - success
1 - no input \ no email \ no password
2 - bad email \ password
***/


//settings
include('../inc/settings.php');

//error - no email
if (!$_POST || !isset($_POST['email']) || !isset($_POST['old_password']) || !isset($_POST['new_password']))
	exit('0');


//varify email and password
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);
$p_old 	= $_POST['old_password'];
$p_new	= $_POST['new_password'];


//connect to db
require('../inc/conn.php');

$sql = "UPDATE `users` u
		SET u.`pass`='$p_new'
		WHERE u.`email`='$email' AND BINARY u.`pass`='$p_old'";
$result = mysql_query($sql);

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
