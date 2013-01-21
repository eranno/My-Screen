<?php
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
		$mail_it = file_get_contents($url);
		return $mail_it;
	}
}
?>
