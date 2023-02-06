<!DOCTYPE html>
<html>
<head>
<style>
input[type=text], input[type=password],input[type=submit],input[type=number] {
    width: 40%;
    padding: 15px;
    display: inline-block;
    border: none;
    background: #f1f1f1;
    font-size: large;
    border: 1px solid black;
  }
  
  input[type=text]:focus, input[type=password]:focus {
    background-color: #ddd;
    outline: none;
    font-size: large;
  }

  form{
    font-size: large;
    height: 50%;
    padding:20px;
    position: absolute;
    left:0;
    right: 0;
    top: 0;
    bottom: 0;
  }

  form *{
      margin:10px;
  }

  
</style>
</head>   
    <body>
        <form id = "frmJoin" method="post" onsubmit="return Validation()" action = "Registration.php">
            <label for="fname">Nickname:</label>
            <input type="text" id="fname" placeholder="Nickname" name="fname" pattern=".{4,}" required title="4 characters minimum!"><br>
            <label for="lname">Password :</label>
            <input type="password" id="pass" placeholder="Password" name="pass" pattern=".{8,}" required title="8 characters minimum!"><br>
            <input  type="checkbox" onclick="myFunction()">Show Password<br>
            <label for="prm">Permision:</label>
            <input type="number" id="prm" name="perm" placeholder="user 0,admin 1" step="1" min="0" max="1" pattern=".{1,}" required title="Select permission!"><br>
            <input type="submit" name="submit" value="Register">
        </form> 
    </body>
</html>

<script>
function myFunction() {
  var x = document.getElementById("pass");
  if (x.type === "password") {
    x.type = "text";
  } else {
    x.type = "password";
  }
}
</script>

<?php

    if(isset($_POST['submit'])){

        $nick = $_POST['fname'];
        $pass = $_POST['pass'];
        $perm = $_POST['perm'];

        $servername = "localhost";
        $dbname = "test";
        $username = "root";
        $password = "";

        try {
            $pdo = new PDO('mysql:host='.$servername.';dbname='.$dbname, $username, $password);
            //print "Connected successfully!";
        } catch (PDOException $e) {
            print "Error!: " . $e->getMessage() . "<br/>";
            die();
        }


        $data = [
            $nick,$pass, $perm,
        ];

        $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        
        $stmt = $pdo->prepare("INSERT INTO user (NickName, Pass, Permission) VALUES (?,?,?)");
        try {
            $pdo->beginTransaction();
            $stmt->execute($data);

            $pdo->commit();

            $err = $pdo->errorInfo();

        }catch (Exception $e){
            if ($e->errorInfo[1] == 1062) {
                echo '<script>alert("Այսպիսի NickName գոյություն ունի!")</script>';
            }
            $pdo->rollback();
            //throw $e;
        }


       // $conn->commit();

        /*if ($conn->query($sql) === TRUE) {
        echo "New record created successfully";
        } else {
        echo "Error: " . $sql . "<br>" . $conn->error;
        }

        
        $stmt = $conn->query("SELECT * FROM user");
        
        while ($row = $stmt->fetch()) {
        echo $row['NickName']."<br />\n";
        }*/
    }


      

        // Check connection
        /*if ($conn->connect_error) {
        die("Connection failed: " . $conn->connect_error);
        }
        echo "Connected successfully";*/
    
?>