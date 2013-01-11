<?php
/***
file: get_image.php
get image code

input: fid, serial (inner id)
output:
code - success
1 - no input \ no email \ no password \ ...
2 - bad email \ password
***/


//settings
include('../inc/settings.php');

//error - no email
if ( !$_POST || !isset($_POST['email']) || !isset($_POST['password']) || !isset($_POST['serial']) || !isset($_POST['fid']) )
	exit('1');


//varify email and password
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);
$pass 	= $_POST['password'];
$serial	= $_POST['serial'];
$fid	= $_POST['fid'];


//connect to db
require('../inc/conn.php');

//add the new image
$sql = "SELECT i.`rsa`
	FROM `images` as i
		INNER JOIN `users` u1
		ON u1.email = '$email' AND BINARY u1.`pass`='$pass'
		INNER JOIN `permissions` p
		ON p.`image`=i.`id` AND p.`user`=u1.`id`
		INNER JOIN `users` u2
		ON u2.`id` = '$fid'
	WHERE i.`serial`='$serial' AND i.`owner`=u2.`id`
	";
$result = mysql_query($sql);
if (!$result) exit('2');

//get result
$row = mysql_fetch_row($result);

//if no results
if (!$row)
	echo '2';

//output code
else
	echo $row[0];

//close db
mysql_close($link);


//-----------------------------------------------------------------

?>
