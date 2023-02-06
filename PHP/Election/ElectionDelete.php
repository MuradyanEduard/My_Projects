<?php
session_start();
if(isset($_SESSION["Permission"]))
{
    if($_SESSION["Permission"] != 1)
    {
        header("Location: http://localhost/dashboard/Election/");
        exit;
    }
}else{
    header("Location: http://localhost/dashboard/Election/");
    exit;
}

    $servername = "localhost";
    $dbname = "test";
    $username = "root";
    $password = "";   

        //DROP EVENT IF EXISTS `qv1Event`
    try {
        $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);

        $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            
        $sql = "DELETE FROM election WHERE idElection=".$_GET['id'];

        $conn->exec($sql);
         $_SESSION['regInfo']  = "Քվեարկությունը հեռացված է";

    } catch(PDOException $e) {
        $_SESSION['regInfo']  = $e->getMessage();
    }

    $conn = null;

    header("Location: http://localhost/dashboard/Election/MainForm.php");
    exit;
    

?>