<?php
/***
file: remove_image.php
remove image

input: email, freind-email \ id
output:
0 - success
1 - no input \ no email \ no password \ no freind (email\id)
2 - bad email \ password
***/


//settings
include('../inc/settings.php');

//error - no email
if ( !$_POST || !isset($_POST['email']) || !isset($_POST['password']) || !isset($_POST['serial']) )
	exit('1');


//varify email and password
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);
$pass 	= $_POST['password'];
$serial	= $_POST['serial'];


//connect to db
require('../inc/conn.php');

//del the image & permissions
$sql = "DELETE i, p 
	FROM `images` i
		INNER JOIN `users` u
		ON u.`email`='$email'
		INNER JOIN `permissions` p
		ON p.`image`=i.`id`
	WHERE i.`serial`='$serial' AND i.`owner`=u.`id` AND BINARY u.`pass`='$pass'
	";
mysql_query($sql) or die('2');


//if success
if (mysql_affected_rows() > 0)
	echo '0';

//bad email/pass
else
	echo '2';

	
//close db
mysql_close($link);


//-----------------------------------------------------------------

?>
