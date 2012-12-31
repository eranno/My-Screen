<?php
/***
file: recover_password.php
send the password to email

input: email
output: send password to email
0 - success
1 - no input \ no email
2 - bad email
***/


//settings
include('../inc/settings.php');

//error - no email
if (!$_POST || !isset($_POST['email'])) 
	exit('1');


//varify email and password
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);

//connect to db
require('../inc/conn.php');

$sql = "SELECT pass
		FROM `users`
		WHERE `email`='$email'";
$result = mysql_query($sql);

//bad email
if (!$result) 
	exit('2');

$row = mysql_fetch_array($result,MYSQL_NUM);
$pass = $row[0];

//this shouldn't ever happen...
if ($pass=='') 
	exit('2');
	
//close db
mysql_close($link);


//send mail
$headers = "From: do-not-reply@myscreen.cu.cc\r\n" .
	"Reply-To: $email\r\n" .
	'X-Mailer: PHP/' . phpversion();

$subject = "myscreen - Password recovery";
$message = "your password is: ".$pass;

mail($email, $subject, $message, $headers);
echo '0';

//-----------------------------------------------------------------

?>
