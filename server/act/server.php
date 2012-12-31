<?php
$json = '{"login":{"name":"Eran","password":"1234"},"c":3,"d":4,"e":5}';
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
		"add_contact" => 0,
		"add_image" => 0,
		"add_permission" => 0,
		"change_password" => 0,
		"login" => 0,
		"recover_password" => 0,
		"remove_contact" => 0,
		"remove_image" => 0,
		"remove_permission" => 0,
		"signup" => 0
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
				//$a = "$this->\key(\$this->json[\"$key\"]);";
				$a = "\$this->$key(\$this->json->$key);";
				echo "-- $a<br /><br />";
				//eval("$this->key(\$this->json[\"$key\"]);");
				eval($a);
			}
		}
		
    }

/*
    public function intersect()
    {
		//foreach ($arr as $value) {
		//	$value = $value * 2;
		//}
		return array_intersect_key($json, $act);
    }

	public function action()
    {
		foreach ($arr as &$key => &$value) {
			//$value = $value * 2;
			switch ($key) {
				case "add_contact":
					echo "add_contact";
					add_contact($value);
					break;
				case "add_image":
					echo "add_image";
					add_image($value);
					break;
				case "add_permission":
					echo "add_permission";
					add_permission($value);
					break;
				case "change_password":
					echo "change_password";
					change_password($value);
					break;
				case "login":
					echo "login";
					login($value);
					break;
				case "recover_password":
					echo "recover_password";
					recover_password($value);
					break;
				case "remove_contact":
					echo "remove_contact";
					remove_contact($value);
					break;
				case "remove_image":
					echo "remove_image";
					remove_image($value);
					break;
				case "remove_permission":
					echo "remove_permission";
					remove_permission($value);
					break;
				case "signup":
					echo "signup";
					signup($value);
					break;
			}
		}
		
    }
*/

	public function user($arr)
    {
		$this->email 	= $arr["email"];
		$this->pass 	= $arr["password"];
		return 0;
    }

	public function add_contact($arr)
    {
		return 0;
    }
	
	public function add_image($arr)
    {
		return 0;
    }
	
	public function add_permission($arr)
    {
		return 0;
    }
	
	public function change_password($arr)
    {
		return 0;
    }
	
	public function login($arr)
    {
		$this->sql[] = "UPDATE `users` u
				SET u.`t_last`='$this->now', u.`ip`='$this->ip'
				WHERE u.`email`='$this->email' AND BINARY u.`pass`='$this->pass'";
		return 0;
    }
	
	public function recover_password($arr)
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
	
	public function signup($arr)
    {
		return 0;
    }
}
?>