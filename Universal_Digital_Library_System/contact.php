<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

	<title>Elementia - Basic Page</title>
	
	<!-- ########## CSS Files ########## -->	

	<!-- Framework CSS -->
	<link rel="stylesheet" href="css/kriframework.css" type="text/css" media="screen" />
	<!-- lightbox CSS -->
	<link rel="stylesheet" href="js/prettyPhoto/css/prettyPhoto.css" type="text/css" media="screen" charset="utf-8" />	
	<!-- Screen CSS -->
	<link rel="stylesheet" href="css/style.css" type="text/css" media="screen" />	
	
	<!-- Stylesheets for each skin -->
	<link rel="stylesheet" href="css/style1.css" type="text/css" media="screen" />
	
	<!--
	<link rel="stylesheet" href="css/style2.css" type="text/css" media="screen" />
	<link rel="stylesheet" href="css/style3.css" type="text/css" media="screen" />
	<link rel="stylesheet" href="css/style4.css" type="text/css" media="screen" />
	-->
	
	<!-- ########## end css ########## -->	<!-- JAVASCRIPT GOES HERE -->	
	<script type='text/javascript' src='js/jquery.js'></script>
	<script type='text/javascript' src='js/cufon.js'></script>
	<script type='text/javascript' src='js/geosans.js'></script>
	<script type='text/javascript' src="js/prettyPhoto/js/jquery.prettyPhoto.js"  charset="utf-8"></script>	
	<script type='text/javascript' src='js/custom.js'></script>

</head>
<body id='top' >

	<div class="wrap_fullwidth" id='head'>
	
		<div class='center'>
			<p class='headline'> <span></span><span></span></p>
			
			<form action="#" id="searchform" method="get">
				<div></div>
			</form><!-- end searchform-->
		</div>
	
	<!-- end header -->
	</div>
	
	
	<div class="wrap_fullwidth" id='second_header'>
	
		<div class='center'>
		
			<h1>Universal Digital Libarary</h1>
		
			<ul id="nav">
				<li><a href="index_fadeslide.html">Home</a>
				<li><a href="book.php">Books</a></li>
				<li><a >Sign In</a>
                <ul>
					<li><a href="admin_login.php">Admin</a></li>
					<li><a href="student_login.php">Student</a></li>
					<li><a href="professor_login.php">Professor</a></li>
					<li><a href="worker_login.php">Worker</a></li>
				</ul>
                </li>
                <li><a href="aboutus.html">About Us</a></li>
                <li class="current"><a href="contact.php">Contact</a></li>
			
			</ul>
		<!-- end center -->
		</div>
	
	<!-- end second_header -->
	</div>
	
	
	
	</li>
		
	<div class="wrap_fullwidth small_margin" id='main'>
		
		<div class='center'>

			<div class='content_two_third' id='content_wrap'>
	
				<div class='content_two_third entry'>
				
					<h1>Contact Us</h1>
					
					<div class="entry_content">
					<p>
						We are open to your suggestions or any query regarding the content of the website.You can contact us personally or can mail about the same.      <br /><br />
    <table  align="center">
      <tr><td width="20%"><b>  Nayan Singhal </b></td><td width="20%"><b>Keshav Maheshwari</b></td></tr>
      <tr><td width="20%">Email:<a href="mail to: singhalnayan19@gmail.com">singhalnayan19@gmail.com</a></td><td width="20%">Email:<a href="mail to :kshav1908@gmail.com">kshav1908@gmail.com </a></td></tr>
      <tr><td width="20%" >Mob: +918853472529</td><td width="20%"> Mob: +919795862386</td></tr>
      </table><br /><table align="center">          
        
						</p>
                        	
						<form action="sendmail.php" method="post" >
						<fieldset><h3><span>Send us mail</span></h3>
						
						<p class="" ><input name="yourname" class="text_input is_empty" type="text" id="name" size="20" value=''/><label for="name">Your Name*</label>
						</p>
						<p class="" ><input name="email" class="text_input is_email" type="text" id="email" size="20" value='' /><label for="email">E-Mail*</label></p>

						<label for="message" class="blocklabel">Your Message*</label>
						<p class=""><textarea name="message" class="text_area is_empty" cols="40" rows="7" id="message" ></textarea></p>
						
						
						<p>
						<input type="hidden" id="myemail" name="myemail" value="office@Elementia.net" />
						<input type="hidden" id="myblogname" name="myblogname" value="Elementia.net" />
						
						<input name="Send" type="submit" value="Send" class="button" id="send" size="16"/></p>
												</fieldset>
						
						</form> 
							
					<!-- end entry_content -->
					</div>	
						
				<!-- end entry -->		
				</div>
				
				
			<!-- end content_wrap -->		
			</div>

		  <!-- end center -->
		</div>
	
	<!-- end main -->
	</div>
	
	
	<div class="wrap_fullwidth" id='breadcrumb_wrap'>
	
		<div class='center'>
		
			
			
			<ul class="social_bookmarks">
				
				
				<li class="twitter"><a href="#" class="">Twitter</a></li>
				<li class="flickr"><a href="#" class="">flickr</a></li>
				<li class="skype"><a href="#" class="">Skype</a></li>
			</ul>
		
		<!-- end center -->
		</div>
	
	<!-- end breadcrumb_wrap -->
	</div>
	
	
	<div class="wrap_fullwidth " id='footer'>
	
	
	<!-- end footer -->
	</div>
	<div class="wrap_fullwidth" id='footer_bottom'>
	
		<div class='center'>
			<span class='copyright'>All content Copyright &copy; 2013 Nayan Singhal</span>
			<a class='scrollTop ' href='#top'>top</a>
		<!-- end center -->
		</div>
	
	<!-- end footer -->
	</div>
	
</body>
</html>