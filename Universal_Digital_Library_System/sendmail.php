<?php
//mail ticket
 include("mail.php");
 
$to		= $_POST["email"];
$from 	= 'bhaskar.iiita@gmail.com';
$subject	= $_POST["yourname"];


//echo $to;
	 	 $headers = array ('From' => $from,
  'To' => $to,
  'Subject' => $subject); 
  $body=$_POST["message"];
//echo $headers;	

	$host = "ssl://smtp.gmail.com"; 
        $port = "465"; 
        $username = "singhalnayan91@gmail.com"; 
        $password = "jupitersaturn"; 

	 
	 
 $smtp = Mail::factory('smtp', 
          array ('host' => $host, 
            'port' => $port, 
            'auth' => true, 
            'username' => $username, 
            'password' => $password)); 
 
$mail = $smtp->send($to, $headers, $body); 
 
        if (PEAR::isError($mail)) { 
          echo("<p>" . $mail->getMessage() . "</p>"); 
         } else { 
          header("Location:http://localhost/elementia/elementia/water/contact.php");
         } 
?> 