<?php
/***
file: signup.php
receive email address and sign it up to service.

input: email, password
output: send activation to this email
0 - success
1 - no input \ no email
2 - email exists
***/


//settings
include('../inc/settings.php');

//error - no email
if (!$_POST || !isset($_POST['email']) || !isset($_POST['password'])) 
	exit('1');

//add user
//-----------------------------------------------------------------
$email 	= strtolower($_POST['email']);
$pass	= $_POST['password'];
$ip 	= $_SERVER['REMOTE_ADDR']; if ($ip=='') $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];

//generate the activation code
$code = md5('kranza'.$now.$email.'oki doki');

//connect to db
require('../inc/conn.php');

//add the new user
$sql = "INSERT INTO `users` (`pass`, `email`, `code`, `t_join`, `t_last`, `ip`, `active`)
		VALUES ('$pass', '$email', '$code', '$now', '$now', '$ip', '0')";
mysql_query($sql) or die('2');
//mysql_errno() == 1062 //Duplicate email
//if (mysql_errno() == 1062)

//close db
mysql_close($link);

//send mail
$headers = "From: do-not-reply@myscreen.cu.cc\r\n" .
	"Reply-To: $email\r\n" .
	'X-Mailer: PHP/' . phpversion();

$subject = "MyScreen - account activation";
$message =	"Welcome to My Screen" .
			"\n\n press on this <a href='http://myscreen.cu.cc/active.php?c=$code&mail=$mail'>link</a> to activate your account" .
			"\n or go to http://myscreen.cu.cc/activate.php and copy this code: $code" .
			"\n\n\n by the way, your password is: $pass" .
			"\n don't forget it.";
mail($email, $subject, $message, $headers);

echo '0';	//success


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