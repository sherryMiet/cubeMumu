
<?php

$myData=mysqli_connect( "localhost" ,"root" ,"" );
if ( mysqli_connect_errno())
{
    echo "eron";
    return;
}


mysqli_query($myData,"set names utf8") ;
mysqli_select_db($myData ,"cubemumu" );


$id =$_POST['id'];
$size =$_POST['size'];
$sql = "select Glevel from game where Mid='".$id."' and Gsize='".$size."' order by Glevel desc limit 1 ";
$result = mysqli_query($myData,$sql)or die("<br>SQL error!<br/>");
if($data = mysqli_fetch_array($result)){
    echo $data['Glevel'];
   }
else{
    echo '0';
}
?>