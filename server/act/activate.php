<?php
/***
file: signup.php
receive email address and sign it up to service.

input: email, activation code
output: send activation to this email
0 - success
1 - no input \ no email
2 - email exists
***/


//settings
include('../inc/settings.php');

//error - no email
if (!isset($_GET['c']) || !isset($_GET['email'])) 
	exit('1');

//add user
//-----------------------------------------------------------------
$email 	= strtolower($_GET['email']);
$code 	= strtolower($_GET['c']);
$ip 	= $_SERVER['REMOTE_ADDR']; if ($ip=='') $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];

//connect to db
require('../inc/conn.php');

$sql = "UPDATE `users` u
		SET u.`active`='1'
		WHERE u.`email`='$email' AND BINARY u.`code`='$code'";
mysql_query($sql);

//if success
if (mysql_affected_rows() == 1)
	echo '0';
else
	echo '2';

//close db
mysql_close($link);

//send mail
$headers = "From: do-not-reply@myscreen.cu.cc\r\n" .
	"Reply-To: $email\r\n" .
	'X-Mailer: PHP/' . phpversion();

$subject = "MyScreen account is active";
$message =	"Welcome to My Screen" .
		"\n\n You may login now!";
mail($email, $subject, $message, $headers);


//-----------------------------------------------------------------

function randomPassword($len) {
    $alphabet = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUWXYZ0123456789";
    $pass = array(); //remember to declare $pass as an array
    for ($i = 0; $i < $len; $i++) {
        $n = rand(0, 59);
        $pass[$i] = $alphabet[$n];
    }
    return implode($pass); //turn the array into a string
}
?>
