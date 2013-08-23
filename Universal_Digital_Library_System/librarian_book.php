<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />

	<title>Elementia - Home</title>
	<style type="text/css">
    pr
    { 
    word-spacing: 30px
    }</style>
    <style type="text/css">
k.leftmargin {margin-left: 6.3cm}
</style>
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
			<p class='headline'></p>
		</div>
	</div>
		<div class="wrap_fullwidth" id='second_header'>welcome
       <?php
		session_start();
		$userid=$_SESSION['userid'];
		echo $userid;
		?>
   	<div class='center'>
		<h1>Universal Digital Library System</h1>
    
			<ul id="nav">
            <li   class='current'><a href="librarian_book.php">Books</a></li>
				
				<li><a href="admin_profile.php">Profile</a>
                <ul>
					<li><a href="librarian_password.php">Change Password</a></li>
				</ul>
                </li>
               <li ><a href="librarian_history.php">History</a></li>
                <li><a href="librarian_aboutus.html">About Us</a></li>
                <li><a href="librarian_contact.php">Contact</a></li>
                <li><a href="index_fadeslide.html">Log Out</a></li>
                </ul>
		</div>
	
	<!-- end second_header -->
	</div>
	
	
	
	
	<div class="wrap_fullwidth" id='feature_background'>	
		
		<!-- ###################################################################### -->
		<div class='center' id="feature_wrap">
		<!-- ###################################################################### -->
			<div id="featured" class='fadeslider'>
			<div id="templatemo_menu">
                
    <ul>
                <li>
              
                <pr>
               <k class="leftmargin">  
                <a href="librarian_book.php" class="current"><big><b>Title</b></big></a>
                <a href="librarian_author.php"><big><b>Author</b></big></a>
                <a href="librarian_bookid.php"><big><b>Book_Id</b></big></a>
                <a href="librarian_shelfno.php"><big><b>Shelf_No</b></big></a>
                <a href="librarian_status.php"><big><b>Status</b></big></a>
                </k>
                </pr>
                <br /><br/>
                <center>
<form action="librarian_title_result.php" method="post">
Enter Query
&nbsp&nbsp;
<input type="text" name="query" size="40" />
<input type="submit" value="Submit" />
</form>
</center>
</li>
 </ul>
</div>
<div class='content_fullwidth'>

</br></br></br></br></br></br>
                 	    <div class='content_one_third portfolio_item' size='10'>
					    <div class='item_data rounded' size='10'>
				    	<h2>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspBOOKS</h2>
						<div class='entry'><a href="add_books.php">
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        Add Books</a>	
                        <div class='entry'><a href="remove_books.php">
                        &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                        Remove Books</a>
                        </div>
						</div>
                        </div>
                        </div>
					
 	                  <div class='content_one_third portfolio_item'>
					   <div class='item_data rounded'>
					   <h2>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspUSERS</h2>
					   <div class='entry'><a href="add_user.php">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspAdd User</a>
                       <div class='entry'><a href="remove_user.php">&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspRemove User</a>
                       </div>	
					   </div>
				       </div
                       ></div>
                       
 	                   <div class='content_one_third portfolio_item'>
					   <div class='item_data rounded'>
					   <h2>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbspSEARCH</h2>
					   <div class='entry'>
                       &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                     
                       <div class='entry'><a href="search_user.php">
                       &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                       Search User</a>
                       </div>	
					   </div>
				       </div>
                       </div> 
                       </div>
				</div>
				<span class='bottom_right_rounded_corner '></span>
				<span class='bottom_left_rounded_corner '></span>
				<span class='top_right_rounded_corner '></span>
				<span class='top_left_rounded_corner '></span>
					
				
		<!-- ###################################################################### -->
		</div><!-- end featuredwrap -->
		<!-- ###################################################################### -->
		
	<!-- end feature_area -->
	</div></div>
	
	<div class="wrap_fullwidth small_margin" id='main'>
		
	  <div class='center'>
	
		
		
		
		
		<div class='content_fullwidth'>
		  <!-- end  #content_fullwidth -->
		</div>
		
		
		<div class='content_fullwidth'>
		  <!-- end  #content_fullwidth -->
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