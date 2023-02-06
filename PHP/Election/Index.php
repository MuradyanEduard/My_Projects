<?php
session_start();
if(isset($_SESSION['NickName']))
{
   header("Location: http://localhost/dashboard/Election/MainForm.php");
   exit;
}

?>

<!DOCTYPE html>
<html>
<head>
    <link rel="stylesheet" href="styles.css">
</head>   
<body>
    <div id="outer">
        <div id="inner">
            <form id = "frmJoin" action="MainForm.php" method="post">
                <label for="nick">Nickname:</label>
                <input type="text" id="nick" placeholder="Nickname" name="nick"><br>
                <label for="pass">Password :</label>
                <input type="password" id="pass" placeholder="Password" name="pass"><br>
                <input type="submit" value="Sign in">
            </form> 
        </div>
      </div>

</body>
</html>