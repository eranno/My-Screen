<?php
//fix time
$now 	= time(); //GMT 0

//user info
$ip 	= $_SERVER['REMOTE_ADDR']; if ($ip=='') $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
?>