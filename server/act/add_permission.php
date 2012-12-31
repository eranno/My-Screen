<?php
/***
file: add_contact.php
add contact member

input: email, freind-email \ id
output:
0 - success
1 - no input \ no email \ no password \ no freind (email\id)
2 - bad email \ password
***/


//settings
include('../inc/settings.php');

//error - no email
if ( !$_POST || !isset($_POST['email']) || !isset($_POST['password']) || !isset($_POST['serial']) || !(isset($_POST['femail']) || isset($_POST['fid'])) )
	exit('1');


//varify email and password
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);
$pass 	= $_POST['password'];
$femail	= strtolower($_POST['femail']);
$fid	= $_POST['fid'];
$serial	= $_POST['serial'];


//connect to db
require('../inc/conn.php');

//contacts - maybe give it as an option
//no contact needed
$sql = "INSERT INTO `permissions` (`image`, `user`)
		SELECT i.`id`, u2.`id`
		FROM `users` as u1
			INNER JOIN `users` u2
			ON u2.`email`='$femail'
			INNER JOIN `images` i
			ON i.`owner`=u2.`id` AND i.`serial`='$serial'
		WHERE u1.email = '$email' AND BINARY u1.`pass`='$pass'
		";
//contact is needed
$sql = "INSERT INTO `permissions` (`image`, `user`)
		SELECT i.`id`, u2.`id`
		FROM `users` as u1
			INNER JOIN `users` u2
			ON u2.`email`='$femail'
			INNER JOIN `contacts` c
			ON c.`user`=u1.`id` AND c.`friend`=u2.`id`
			INNER JOIN `images` i
			ON i.`owner`=u2.`id` AND i.`serial`='$serial'
		WHERE u1.email = '$email' AND BINARY u1.`pass`='$pass'
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
