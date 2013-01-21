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

//send email confirmation
require_once('../mail/email.php');
$m = new email();
$m->addMail($email);
$m->addParams('c',$code);
$m->addParams('p',$pass);


//try {
	echo $m->sendMail();
//} catch (Exception $e) {
//	echo $code;
//}



?>
