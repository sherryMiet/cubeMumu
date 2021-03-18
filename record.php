<?php
session_start();
$dsn = "mysql:host=localhost;dbname=cubemumu";
$dbh = new pdo($dsn,'root','');
$dbh ->exec("set character set utf8");

$id = $_POST['id'];
$time =$_POST['time'];
$count =$_POST['count'];
$size =$_POST['size'];
$level =$_POST['level'];
$a = 0;
$myData=mysqli_connect( "localhost" ,"root" ,"" );
mysqli_query($myData,"set names utf8") ;
mysqli_select_db($myData ,"cubemumu" );

$query = "INSERT INTO `game` (`Mid`,`Gtime`,`Gchange`,`Glevel`,`Gsize`) VALUES ('".$id."','".$time."','".$count."','".$level."','".$size."')";
$result = mysqli_query($myData,$query)or die("<br>SQL error!<br/>");


?>