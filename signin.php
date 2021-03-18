
<?php

$myData=mysqli_connect( "localhost" ,"root" ,"" );
if ( mysqli_connect_errno())
{
    echo "eron";
    return;
}


mysqli_query($myData,"set names utf8") ;
mysqli_select_db($myData ,"cubemumu" );


$accounting = $_POST['accounting'];

$sql = "SELECT Mid FROM member where Maccounting='".$accounting."' ";
$result = mysqli_query($myData,$sql)or die("<br>SQL error!<br/>");
if($data = mysqli_fetch_array($result)){
 
    $_SESSION['id'] = $data['Mid'];
   
    echo $_SESSION['id'];
   }
else{
    echo 'error';
}
?>