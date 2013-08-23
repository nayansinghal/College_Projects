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
            <li ><a href="librarian_book.php">Books</a></li>
				
				<li class='current'><a href="admin_profile.php">Profile</a>
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
   <?php
			 echo "<img src='userimage/$userid.jpg' align=\"right\"/ height='130'>";  
    ?>            
<?php
$con = mysql_connect("localhost","root","");
if (!$con)
  {
  die('Could not connect: ' . mysql_error());
  }
mysql_select_db("my_db", $con);
$result = mysql_query("SELECT * FROM person   where person_id = '$userid'  ");
$rslt=mysql_query("SELECT * FROM issue  where person_id = '$userid' and return_date='0000-00-00' ");
$sum=0;
while($rw = mysql_fetch_array($rslt))
{
$a=strtotime($rw["issue_date"]);
$b=strtotime(date("y-m-d"));
$c=($b-$a)/86400;
if($c>10)
$sum+=(($c-10)*5);
}
echo "<br/>";
while($row = mysql_fetch_array($result))
  {
	  echo "<table frame=void >";
	  //echo "<col width=25%>";
	  echo "<tr>";
	  echo "<th width=30%>";
	  echo "User Id :"."<td width=40%>". $row["person_id"]."<br/>"."</td>";
	  echo "</tr>";
	  echo "<tr>";
	  echo "<th >";
	  echo "Name :". "<td>". $row["name"]."<br/>"."</td>";
	  echo "</tr>";
	  echo "<tr>";
	  echo "<th >";
	  echo "DOB :". "<td>". $row["dob"]."<br/>"."</td>";
	  echo "</tr>";
	  echo "<tr>";
	  echo "<th >";
	  echo "Sex :". "<td>". $row["sex"]."<br/>"."</td>";
	  echo "</tr>";
	  echo "<tr>";
	  echo "<th >";
	  echo "Add :". "<td>". $row["address"]."<br/>"."</td>";
	  echo "</tr>";
	   echo "<tr>";
	  echo "<th >";
	  echo "Fine :". "<td>". $sum."<br/>"."</td>";
	  echo "</tr>";
	  
	  echo "</table>";
  };
   $resu = mysql_query("SELECT book_id,title,author,publication,edtion,isbn FROM issue natural join book natural join book_detail where person_id = '$userid' and return_date='0000-00-00'  ");
  //$resu = mysql_query("SELECT book_id,title,author,publication,edtion,isbn FROM issue natural join book natural join book_detail where person_id = '$userid' and return_date= ='0000-00-00'");
  echo "<br/>"."<u>"."Books Issued "."</u>";
   echo "<table frame=void>";
   
  while($row = mysql_fetch_array($resu))
  {
	// echo "KK";
	  echo "<tr>";
	  echo "<td width=10%>";
	  echo $row["book_id"]."</td>";
	  echo "<td width=35%>";
	  echo  $row["title"]."</td>";
	  echo "<td width=30%>";
	  echo $row["author"]."</td>";
	  echo "<td>";
	  echo  $row["publication"]."</td>";
	  echo "<td>";
	  echo  $row["edtion"]."<br/>"."</td>";
	  echo "<tr>";
  };
  	  echo "</table>";

  mysql_close($con);
?>
</li>
 </ul>
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