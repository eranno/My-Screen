<?php
$json = '{	
			"login":
			{
				"id":"1",
				"password":"1234"
			},
			"add_contacts":
			{
				"ilan@gmail.com",
				"krantz@gmail.com"
			},
			"add_images":
			{
				"duygkiu76576445twdtg",
				"trdcfujhkhgfuy3465457"
			},
			"add_permissions":
			{
				"user":"ilan@gmail.com",
				"images":
				{
					"duygkiu76576445twdtg",
					"trdcfujhkhgfuy3465457"
				}
			},
			"add_permissions":{
				"user":"krantz@gmail.com",
				"images":
				{
					"duygkiu76576445twdtg",
					"trdcfujhkhgfuy3465457"
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
	private	$email;
	private $pass;

	//action arrays
	private $sql;
	private $mail;

	//possible actions
	private $act = array(
		"login" 			=> 0,
		"add_contacts" 		=> 0,
		"add_images" 		=> 0,
		"add_permissions" 	=> 0,
		"change_password" 	=> 0,
		"remove_contact" 	=> 0,
		"remove_image" 		=> 0,
		"remove_permission" => 0
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
		$this->mail = array();
    }

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
		$this->email 	= $arr["email"];
		$this->pass 	= $arr["password"];
		return 0;
    }

	public function login($arr)
    {
		$this->sql[] = "UPDATE `users` u
				SET u.`t_last`='$this->now', u.`ip`='$this->ip'
				WHERE u.`email`='$this->email' AND BINARY u.`pass`='$this->pass'";
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
	
	public function remove_contact($arr)
    {
		return 0;
    }
	
	public function remove_image($arr)
    {
		return 0;
    }
	
	public function remove_permission($arr)
    {
		return 0;
    }
}
?>
