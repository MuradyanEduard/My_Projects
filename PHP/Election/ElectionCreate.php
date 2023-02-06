<?php
    session_start();

    if(!isset($_SESSION["Permission"]))
    {
        header("Location: http://localhost/dashboard/Election/index.php");
        exit;
    }


    if(isset($_POST['submit'])){
        if(isset($_POST['eid'])){

            if(!isset($_SESSION['IdUser']))
            {
                header("Location: http://localhost/dashboard/Election/");
                exit;
            }
            
            $pdo = GetConnection("localhost","test","root","");
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            $str = "SELECT election.ElType,election.Active FROM election  where IdElection = ".$_POST['eid'];
            $data = $pdo->query($str)->fetch();

            if($data['Active'] == 0){
                $_SESSION['regInfo'] = "Քվեարկության ժամանակը լռացել է";
                header("Location: http://localhost/dashboard/Election/MainForm.php");
                exit;
            }

            if($data['ElType'] == 0){
                //bac
                $pdo = GetConnection("localhost","test","root","");
                $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                $stmt = $pdo->prepare("INSERT INTO votelist (IdElection, IdUser, VotedVariant) VALUES (?,?,?)");
               
                $pieces = explode("|", $_POST['group1']);
                $data = [ $_POST['eid'],$_SESSION['IdUser'],$pieces[1]];
    
                 try {
                    $pdo->beginTransaction();
                    $stmt->execute($data);
                
                    $pdo->commit();
                
                    $err = $pdo->errorInfo();      
                    $_SESSION['regInfo'] = "Դուք ընտրել եք տարբերակ ".$pieces[0]." տարբերակը!";
                    echo "Դուք ընտրել եք տարբերակ ".$pieces[0]." տարբերակը!";
    
                }catch (Exception $e){
                    if ($e->errorInfo[1] == 1062) {
                        $_SESSION['regInfo'] = "Դուք արդեն կատարել եք քվեարկությունը!";
                    }else{
                        $_SESSION['regInfo'] = $e;
                    }
                        $pdo->rollback();
                }
            }else{
                //pak
                $pdo = GetConnection("localhost","test","root","");
                $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                $stmt = $pdo->prepare("INSERT INTO votelist (IdElection, IdUser, VotedVariant) VALUES (?,?,?)");
               
                $data = [ $_POST['eid'],$_SESSION['IdUser'],-1];
    
                 try {
                    $pdo->beginTransaction();
                    $stmt->execute($data);
                
                    $pdo->commit();
                
                    $err = $pdo->errorInfo();      
                    $_SESSION['regInfo'] = "Ձեր քվեարկությունը ընդունված է!";
                    echo "Ձեր քվեարկությունը ընդունված է";
    
                }catch (Exception $e){
                    if ($e->errorInfo[1] == 1062) {
                        $_SESSION['regInfo'] = "Դուք արդեն կատարել եք քվեարկությունը!";
                        exit;
                    }else{
                        $_SESSION['regInfo'] = $e;
                    }
                        $pdo->rollback();
                }

                $pdo = GetConnection("localhost","test","root","");
                $str = "SELECT closed.VoteCount FROM closed where IdElection = ".$_POST['eid'];
                $data = $pdo->query($str)->fetch();

                $pieces = explode("|", $_POST['group1']);
                $nom = $pieces[1];
                $pieces = explode("|", $data['VoteCount']);
                $pieces[$nom-1] = (int)($pieces[$nom-1])+1;
                $str="";

                for($i=0;$i< count($pieces);$i++){
                    $str = $str.$pieces[$i]."|";
                }
                $str = substr($str,0,-1);

                $pdo = GetConnection("localhost","test","root","");
                $stmt = $pdo->prepare("UPDATE closed SET VoteCount = '".$str."' where IdElection = ".$_POST['eid']);
                $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                $data = [$_POST['eid'],$str];

                echo "UPDATE closed VoteCount = '".$str."' where IdElection = ".$_POST['eid'];
                try {
                    $pdo->beginTransaction();
                    $stmt->execute($data);
                    $pdo->commit();
                    $err = $pdo->errorInfo();      
                }catch (Exception $e){
                    echo $e;
                }
            }
 
        }else{
            if($_SESSION["Permission"] != 1){
                header("Location: http://localhost/dashboard/Election/");
                exit;
            }

            date_default_timezone_set('Asia/Yerevan'); // CDT
           
            $info = getdate();
            $date = $info['mday'];
            $month = $info['mon'];
            $year = $info['year'];
            $hour = $info['hours'];
            $min = $info['minutes'];
            $sec = $info['seconds'];
           
            $current_date = "$year-$month-$date $hour:$min:$sec";
           
            $startTime = new DateTime($current_date);
           
            $elName = $_POST['ElName'];
            $elType = $_POST['ElType'];
            $elDesc = $_POST['Desctiption'];
            $elTime = (int)$_POST['Time'];
            $qanak = (int)$_POST['TrbCount'];
           
            $deadTime = new DateTime($current_date);
            $deadTime -> add(new DateInterval('PT' . $elTime . 'M'));
             
            $variants = "";
           
            for($i = 0; $i < $qanak; $i++){
                $variants = $variants."|".$_POST['trb'.($i+1)];
            }

            $variants = substr($variants, 1);
           
            if($elType == "Closed")
                $elType = 1;
            else 
                $elType = 0;
           
            $startTime=$startTime->format('Y-m-d H:i:s');
            $deadTime=$deadTime->format('Y-m-d H:i:s');
           
            $pdo = GetConnection("localhost","test","root","");
            $pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
                   
            $stmt = $pdo->prepare("INSERT INTO election (ElName, ElType, ElDescription,StartTime,DeadTime,ElVariants,Active) VALUES (?,?,?,?,?,?,?)");
                       
            $data = [ $elName,$elType, $elDesc,$startTime,$deadTime,$variants,1 ];

            try {
                $pdo->beginTransaction();
                $stmt->execute($data);
            
                $pdo->commit();
            
                $err = $pdo->errorInfo();      

                $_SESSION['regInfo'] = "Քվեարկությունը գրանցված է!";

            }catch (Exception $e){
                if ($e->errorInfo[1] == 1062) {
                    $_SESSION['regInfo'] = "Այսպիսի անունով քվեարկություն գոյություն ունի!";
                }
                    $pdo->rollback();
            }
            
            $pdo = GetConnection("localhost","test","root","");                
            $pdo->query("CREATE EVENT ".$elName."Event ON SCHEDULE AT CURRENT_TIMESTAMP + INTERVAL ".$elTime." MINUTE
                DO UPDATE `election`  SET Active = 0 WHERE ElName = '".$elName."'");
              
            if($elType == 1){
                $pdo = GetConnection("localhost","test","root","");
                $str = "SELECT election.IdElection FROM election ORDER BY IdElection DESC LIMIT 1";
                $data = $pdo->query($str)->fetch();
                $id = $data['IdElection'];
                
                $pdo = GetConnection("localhost","test","root","");    
                $stmt = $pdo->prepare("INSERT INTO closed (IdElection, VoteCount) VALUES (?,?)");
                $variants="";
                for($i = 0; $i < $qanak; $i++){
                    $variants = $variants."|0";
                }

                $variants = substr($variants, 1);
                $data = [$id,$variants];
                
                echo $id."".$variants;
                try {
                    $pdo->beginTransaction();
                    $stmt->execute($data);
                
                    $pdo->commit();
                
                    $err = $pdo->errorInfo();      
    
                    $_SESSION['regInfo'] = "Քվեարկությունը գրանցված է!";
    
                }catch (Exception $e){
                    if ($e->errorInfo[1] == 1062) {
                        $_SESSION['regInfo'] = "Այսպիսի անունով քվեարկություն գոյություն ունի!";
                    }
                        $pdo->rollback();
                }
            }

        }
    }

header("Location: http://localhost/dashboard/Election/MainForm.php");
exit;

function GetConnection($servername, $dbname, $username,$password)
{
    try {
        $con = new PDO('mysql:host='.$servername.';dbname='.$dbname, $username, $password);
    } catch (PDOException $e) {
        print "Error!: " . $e->getMessage() . "<br/>";
        die();
    }

    return $con;
}

?>