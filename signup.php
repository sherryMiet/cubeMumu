<?php
session_start();
$dsn = "mysql:host=localhost;dbname=cubemumu";
$dbh = new pdo($dsn,'root','');
$dbh ->exec("set character set utf8");

$accounting = $_POST['accounting'];
$name =$_POST['name'];
$age =$_POST['age'];
$a = 0;
$myData=mysqli_connect( "localhost" ,"root" ,"" );
mysqli_query($myData,"set names utf8") ;
mysqli_select_db($myData ,"cubemumu" );

$sql = "SELECT * FROM member where  Maccounting='".$accounting."'";
$result = mysqli_query($myData,$sql)or die (mysqli_error($myData));
if($data = mysqli_fetch_array($result)){
echo 'error';	
$a = 1;
}

if($a == 0 )
{	
$query = "INSERT INTO `member` (`Mname`,`Mage`,`Maccounting`) VALUES ('".$name."','".$age."','".$accounting."')";
$result = mysqli_query($myData,$query)or die("<br>SQL error!<br/>");
$sql = "SELECT Mid FROM member where  Maccounting='".$accounting."'";
$result = mysqli_query($myData,$sql)or die (mysqli_error($myData));
if($data = mysqli_fetch_array($result)){
 
 $_SESSION['id'] = $data['Mid'];

 echo $_SESSION['id'];
}
}



?>