<?php
/*
return -1 in case of proxy server is unreachable
otherwise, return server response
*/

class email
{
	const proxy = 'http://my-screen.cu.cc/activation.php';
	private $mail;
	private $params;

	public function __construct()
	{

	}

	public function addMail($mail)
	{
		$this->mail = $mail;
	}

	public function addParams($key, $value)
	{
		$this->params .= "&$key=$value";
	}

	public function sendMail()
	{
		$url = email::proxy . '?m=' . $this->mail . $this->params;
		
		
		try {
			$mail_it = file_get_contents($url);
		} catch (Exception $e) {
			return -1;
		}
		
		return $mail_it;
	}
}
?>
