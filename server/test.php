<?php




require_once('./simpletest/autorun.php');
require_once('./act/server.php');

class TestOfLogging extends UnitTestCase {
	function testFirstLogMessagesCreatesFileIfNonexistent() {
		//@unlink(dirname(__FILE__) . '/../temp/test.log');
		//$log = new Log(dirname(__FILE__) . '/../temp/test.log');
		//$log->message('Should write this to a file');
		//$this->assertTrue(file_exists(dirname(__FILE__) . '/../temp/test.log'));
		
		
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
			$this->assertEqual('', $s->action());
			$this->assertEqual(7, $s->action());
		}
		catch ( Exception $e)
		{
			//die($e->getMessage());
			echo 'Caught exception: ',  $e->getMessage(), "\n";
		}
		
		
	}
}

/*
 class TestOfServer extends UnitTestCase {
    function testServer() {
      $this->assertTrue(add(1,1) == 2);
      $this->assertTrue(add(2,2) == 4);
      $this->assertTrue(add(1,1,1) == 3);
    }
    * */
?>
