<?php
/***
file: general.php
receive email address and sign it up to service.

input: json
0 - success
1 - no input \ no email
2 - email exists
***/


//settings
include('../inc/settings.php');

//error - no email
if (!$_POST || !isset($_POST['j'])) 
	exit('1');

//get data from json
$json = json_decode($_POST['j']);



?>