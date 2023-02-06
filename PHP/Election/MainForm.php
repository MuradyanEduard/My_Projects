<?php
    
    session_start();

    $servername = "localhost";
    $dbname = "test";
    $username = "root";
    $password = "";    
    
    if(isset($_POST["nick"]) && isset($_POST["pass"]))
    {
    
        try {
            $pdo = new PDO('mysql:host='.$servername.';dbname='.$dbname, $username, $password);
            //print "Connected successfully!";
        } catch (PDOException $e) {
            print "Error!: " . $e->getMessage() . "<br/>";
            die();
        }
            
        $pdo->query("SET GLOBAL event_scheduler=\"ON\"");
        
        try {
            $pdo = new PDO('mysql:host='.$servername.';dbname='.$dbname, $username, $password);
        } catch (PDOException $e) {
            print "Error!: " . $e->getMessage() . "<br/>";
            die();
        }

        try {
            $pdo = new PDO('mysql:host='.$servername.';dbname='.$dbname, $username, $password);
            //print "Connected successfully!";
        } catch (PDOException $e) {
            print "Error!: " . $e->getMessage() . "<br/>";
            die();
        }
        $str = "SELECT * FROM user where NickName = '".$_POST['nick']."' and Pass = '".$_POST['pass']."'";
        $str = preg_replace('/[^\x20-\x7E]/', '', $str);

        try{
            $data = $pdo->query($str)->fetchAll();
        }catch(PDOException $e){            
            header("Location: http://localhost/dashboard/Election/index.php");
            exit;  
        }
        
        foreach ($data as $row) {
           
            $_SESSION["IdUser"] = $row['IdUser'];
            $_SESSION["NickName"] = $row['NickName'];            
            $_SESSION["Pass"] = $row['Pass'];
            $_SESSION["Permission"] = $row['Permission'];
        }
    }
    
    if(!isset($_SESSION["NickName"])){
        header("Location: http://localhost/dashboard/Election/index.php");
        exit;
    }



    echo "<script> var UserInfo = {id: ".$_SESSION["IdUser"].",NickName: '".$_SESSION["NickName"]."',Pass: '".$_SESSION['Pass']."',Permission: ".$_SESSION['Permission']."} </script>";


   try {
       $pdo = new PDO('mysql:host='.$servername.';dbname='.$dbname, $username, $password);
       //print "Connected successfully!";
   } catch (PDOException $e) {
       print "Error!: " . $e->getMessage() . "<br/>";
       die();
   }

   $data = $pdo->query("SELECT election.DeadTime FROM `election` WHERE Active=1")->fetchAll();

   echo '<script>var deadTime=[];';
   // and somewhere later:
   foreach ($data as $row) {
       echo 'deadTime.push("'.$row['DeadTime'].'");';
   }

   echo '</script>';

  if(isset($_SESSION['regInfo'])){
      echo "<script>alert(\"".$_SESSION['regInfo']."\")</script>";
      unset($_SESSION['regInfo']);
  }
  

?>


<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="stylesMF.css">
    <script src="MyJs.js"></script>
</head>   
<script>

</script>
<body onload="Init()">
    <div id="outer">
        <div id="header">
            <div> <label>Բարի գալուստ, <b><?php echo $_SESSION["NickName"]; ?></b> </label></div>
            <div class = "clmns" onclick="javascript:SelectionBar()"> Ընթացիկ</div>
            <div class = "clmns" onclick="javascript:ArchiveBar()">Արխիվ</div>
            <a  id = "elq"  href = "http://localhost/dashboard/Election/logout.php"><div class = "clmns" >Ելք</div></a>            
        </div>
        <div id="inner">
            <div id = "linkHeader"></div>
            <div id = "body">
            </div> 
            <div id = "footer"></div>  
        </div>
    </div> 
</body>
</html>