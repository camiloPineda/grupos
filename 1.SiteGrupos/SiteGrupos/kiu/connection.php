<?php
$EchoToken = 1;
$TimeStamp = date("c");
$Target = "Testing";
$SequenceNmbr = 1;

error_reporting(E_ALL);

//Web Services URL List
$SERVERS = array('https://ssl00.kiusys.com/ws3/',
				'https://n10.kiusys.com/ws3/',
                'https://n30.kiusys.com/ws3/',
                'https://n40.kiusys.com/ws3/',
               'https://webservices-us.kiusys.com/ws3/');
                
//$SERVERS = array('http://webservices/pre/3.0/');
//$SERVERS = array('https://ssl03.kiusys.com/ws3/');
//$SERVERS = array('https://ssl00.kiusys.com/ws3/');

class connectionServer {
	function connectionServer($user, $password) {
		$this->user = $user;
		$this->password = $password;
		
		//open connection
		$this->ch = curl_init();
		
		//set number of POST vars, POST data
		curl_setopt($this->ch,CURLOPT_POST, 1);
		curl_setopt($this->ch, CURLOPT_RETURNTRANSFER, 1);
		curl_setopt($this->ch, CURLOPT_SSL_VERIFYHOST, 0);
		curl_setopt($this->ch, CURLOPT_SSL_VERIFYPEER, 0); 
		curl_setopt($this->ch, CURLOPT_HTTPHEADER, array(
			'Connection: Keep-Alive',
			'Keep-Alive: 300'
		));
			
		if (curl_errno($this->ch)) throw new Exception(curl_error($this->ch));
		
	}

	function CloseConnection() {
		//close connection
		curl_close($this->ch);
	}

	function SendMessage($xml) {
		global $SERVERS;
		
		$xml = str_replace('+', '%20', urlencode($xml));
		curl_setopt($this->ch, CURLOPT_POSTFIELDS, "user=" . $this->user . "&password=" . $this->password . "&request=$xml");

		//try each of the URLs listed in SERVERS until one works
		foreach ($SERVERS as $s) {
			//set the URL
			curl_setopt($this->ch,CURLOPT_URL, $s);
			
			//execute post
			$result = curl_exec($this->ch);

			//Get Info
			$info = curl_getinfo($this->ch);
			
			//Check response code is OK
			if ($info['http_code'] == 200) return $result;
			
		}
		
	}
}

?>
