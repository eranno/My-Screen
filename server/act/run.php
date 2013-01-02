<?php
require_once('server.php');


$json = '{	
	"login":
	{
		"id":"1",
		"email":"eran@gmail.com",
		"password":"1234"
	},
	"add_contacts":
	{
		"0":"ilan@gmail.com",
		"1":"krantz@gmail.com"
	},
	"add_images":
	{
		"duygkiu76576445twdtg":"0111010100101010",
		"trdcfujhkhgfuy3465457":"1101011101010111"
	},
	"add_permissions":
	{
		"user":"ilan@gmail.com",
		"images":
		{
			"0":"duygkiu76576445twdtg",
			"1":"trdcfujhkhgfuy3465457"
		}
	},
	"add_permissions":{
		"user":"krantz@gmail.com",
		"images":
		{
			"0":"duygkiu76576445twdtg",
			"1":"trdcfujhkhgfuy3465457"
		}
	},
	"remove_contacts":
	{
		"0":"ilan@gmail.com",
		"1":"krantz@gmail.com"
	},
	"remove_images":
	{
		"0":"duygkiu76576445twdtg",
		"1":"trdcfujhkhgfuy3465457"
	},
	"remove_permissions":
	{
		"user":"ilan@gmail.com",
		"images":
		{
			"0":"duygkiu76576445twdtg",
			"1":"trdcfujhkhgfuy3465457"
		}
	},
	"remove_permissions":{
		"user":"krantz@gmail.com",
		"images":
		{
			"0":"duygkiu76576445twdtg",
			"1":"trdcfujhkhgfuy3465457"
		}
	}
}';




try
{
	$s = new server($json);
	$s->action();

}
catch ( Exception $e)
{
	//die($e->getMessage());
	echo 'Caught exception: ',  $e->getMessage(), "\n";
}



?>
