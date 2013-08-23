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
	<?php
$con = mysql_connect("localhost","root","");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }
mysql_select_db("my_db", $con);
$res =$_POST["query"];
$result = mysql_query("SELECT * FROM book natural join book_detail where title like '%$res%' order by status ");
  echo "<center>"."<br/>"."<br/>";
  echo "<table border=3>";
  echo "<tr>"."<th>"."S.NO"."</th>"."<th>"."Book Id"."</th>"."<th>"."Title"."</th>"."<th>"."Edition"."</th>"."<th>"."Author"."</th>"."<th>"."Shelf No."."</th>"."<th>"."Status"."</th>"."</tr>";
  
 
  $count=1;
while($row = mysql_fetch_array($result))
  {
   echo "<tr>";
   echo "<td>".$count."</td>"."<td>".$row['book_id']."</td>"."<td>".$row['title']."</td>"."<td>".$row['edtion']."</td>"."<td>".$row['author']."</td>"."<td>". $row['shelf_no']."</td>"."<td>".$row['status' ]."</td>" ;
  //echo $count." ".$row['book_id']." ".$row['title']." ".$row['edtion']." ".$row['author']." ". $row['shelf_no']." ".$row['status' ] ;
  echo "</tr>";
  $count++;
  }
  echo "</table>";
  echo "</center>";
mysql_close($con);
?>
</div>
<div class='content_fullwidth'>

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
		
			<p class='breadcrumb'>
			<span class="breadcrumb_info">You are here:</span> 
			<a href="#">Home</a>
			<span> » </span><a href="#">About</a>
			<span> » </span><a href="#">Philosophy</a>
			<span> » </span><span class="current_crumb">We love what we do </span>
			<!-- end breadcrumb -->
			</p>
			
			<ul class="social_bookmarks">
				<li class="rss"><a href="#" class="">RSS</a></li>
				<li class="facebook"><a href="#" class="">Facebook</a></li>
				<li class="twitter"><a href="#" class="">Twitter</a></li>
				<li class="flickr"><a href="#" class="">flickr</a></li>
				<li class="skype"><a href="#" class="">Skype</a></li>
			</ul>
		
		<!-- end center -->
		</div>
	
	<!-- end breadcrumb_wrap -->
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
			<span class='copyright'>All content Copyright &copy; 2010 Nayan Singhal</span>
			<a class='scrollTop ' href='#top'>top</a>
		<!-- end center -->
		</div>
	
	<!-- end footer -->
	</div>
	
</body>
</html>