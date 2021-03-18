<?php
session_start();
$dsn = "mysql:host=localhost;dbname=cubemumu";
$dbh = new pdo($dsn,'root','');
$dbh ->exec("set character set utf8");

$p1= $_POST['p1'];
$p2 =$_POST['p2'];
$winner =$_POST['winner'];
$time =$_POST['time'];


$myData=mysqli_connect( "localhost" ,"root" ,"" );
mysqli_query($myData,"set names utf8") ;
mysqli_select_db($myData ,"cubemumu" );

$query = "INSERT INTO `2p_game` (`2P_p1`,`2P_p2`,`2P_winner`,`2P_time`) VALUES ('".$p1."','".$p2."','".$winner."','".$time."')";
$result = mysqli_query($myData,$query)or die("<br>SQL error!<br/>");


?>