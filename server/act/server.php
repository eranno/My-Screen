<?php
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
		"0":"duygkiu76576445twdtg",
		"1":"trdcfujhkhgfuy3465457"
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


$s = new server($json);
$s->action();

class server
{
	//user extra info
	private $ip;
	private $now;

	//user inputs
	private $json;	//json input
	private	$id;
	private	$email;
	private $pass;

	//action arrays
	private $sql;
	private $mail;

	//possible actions
	private $act = array(
		"login" 			=> 0,	//zero is counter, for future use.
		"add_contacts" 			=> 0,
		"add_images" 			=> 0,
		"add_permissions" 		=> 0,
		"remove_contacts" 		=> 0,
		"remove_images" 		=> 0,
		"remove_permissions" 		=> 0
	);

    public function __construct($arr)
    {
		//set input
        $this->json = json_decode($arr);
		//http://stackoverflow.com/questions/6815520/cannot-use-object-of-type-stdclass-as-array

		//save extra info
		$this->ip 	= $_SERVER['REMOTE_ADDR']; if ($ip=='') $ip = $_SERVER['HTTP_X_FORWARDED_FOR'];
		$this->now 	= time(); //GMT 0

		//set arrays
		$this->sql 	= array();
		$this->mail	= array();
    }

	//call for all $act methods
	public function action()
    {
		foreach ($this->act as $key => &$value) {
			echo $key . "<br />";
			if ( array_key_exists($key, $this->json) ){
				$a = "\$this->$key(\$this->json->$key);";
				eval($a);
			}
		}
		
    }

	public function user($arr)
    {
		$this->id 		= $arr["id"];
		$this->email 	= $arr["email"];
		$this->pass 	= $arr["password"];
		return 0;
    }

	public function login($arr)
    {
		print_r($arr);
		$this->sql[] = "UPDATE `users` u
				SET u.`t_last`='$this->now', u.`ip`='$this->ip'
				WHERE u.`email`='$arr->email' AND BINARY u.`pass`='$arr->password'";
		print_r($this->sql);
		return 0;
    }

	public function add_contacts($arr)
    {
		return 0;
    }
	
	public function add_images($arr)
    {
		return 0;
    }
	
	public function add_permissions($arr)
    {
		return 0;
    }
	
	//Reminder:
	//when removing contact remove all of it's images permissions as well
	//
	public function remove_contacts($arr)
    {
		return 0;
    }
	
	public function remove_images($arr)
    {
		return 0;
    }
	
	public function remove_permissions($arr)
    {
		return 0;
    }
}
?>
