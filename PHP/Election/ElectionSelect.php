<?php

    session_start();
    if(!isset($_SESSION["Permission"]))
    {
        header("Location: http://localhost/dashboard/Election/index.php");
        exit;
    }

    $pdo = GetConnection("localhost","test","root","");

    if(isset($_GET['table']) && isset($_GET['active'])){
        $str = "SELECT * FROM ".$_GET['table']." where Active = ".$_GET['active'];
        $data = $pdo->query($str)->fetchAll();
        
        if($_GET['active']==0){
            echo '<p style="padding:1em 3em;text-align:justify;">Այստեղ ներկայացված են արդեն ավարտված քվեարկությունների արդյունքները:</p>';
            echo '<div class="innerTable" style="width:80%;margin:auto;">';
                echo '<div style="border:0px;" class = "innerRow"><div class="innerCell"> Քվեարկության անվանումը</div> <div class="innerCell" style="text-align:right;padding:7px">Քվեարկության ավարտի ժամանակը</div></div>';
            
            foreach ($data as $row) {
                echo '<div style="border:0px;" class = "innerRow">';
                echo '<div class="innerCell" > <a href="javascript:WatchSelection('.$row['IdElection'].')">'.$row['ElName'].'</a></div> <div class="innerCell" style="text-align:right;padding:7px;"> '.$row['DeadTime'].'</div>';
                echo '</div>';

            }
            echo '</div>';
        }else{
            echo '<div class="innerTable">';
            $ElNom = 0;

            foreach ($data as $row) {

            if($row['ElType'] == 1)
                $elType = "Փակ";
            else 
                $elType = "Բաց";
            
                echo '<div class="innerRow" >';
                echo '<div class="innerCell" onClick = "SelectedElInfo(\''.$ElNom.'\',\''.$row['IdElection'].'\')""><p>' . $row['ElName'] . "</p></div>";
                echo '<div class="innerCell" onClick = "SelectedElInfo(\''.$ElNom.'\',\''.$row['IdElection'].'\')"" style="text-align: right;"><p><i> Քվեարկության կարգը <b>' . $elType . "</b></i></p>";                
                echo "<p><i>Մինչև ավարտը <b id='timer".$ElNom."'> </b></i></p></div>";
                if($_SESSION['Permission']==1){
                    echo '<div class="innerCell"><a class="button" style="position:absolute;padding: 10px;" href="ElectionDelete.php?id='.$row['IdElection'].'" onclick="return confirm(\'դուք վստա՞հ եք\');">X</a></div>';
                }
                echo "</div>";
                
                $ElNom = $ElNom + 1;
            }
            echo "</div>";
        }    
    }elseif (isset($_GET['id'])){

        if(isset($_GET['active'])){
            $str = 'SELECT election.ElName,election.ElType,election.DeadTime,election.ElVariants,election.ElDescription,votelist.VotedVariant,user.NickName FROM election INNER JOIN votelist ON election.IdElection = votelist.IdElection inner join user ON votelist.IdUser = user.IdUser where election.IdElection = '.$_GET['id'];
            
            $data = $pdo->query($str)->fetch();
            if($data==""){
                //Voch mek chi masnakce
                $pdo = GetConnection("localhost","test","root","");

                $str = "SELECT * FROM election where IdElection = ".$_GET['id'];
                $data = $pdo->query($str)->fetch();

                if($data['ElType'] == 1)
                    $elType = "Փակ";
                else 
                    $elType = "Բաց";

                echo '<div class="innerTable"><div class="innerRow">';
                echo '<div class="innerCell"><p>' . $data['ElName'] . "</p></div>";
                echo '<div class="innerCell" style="text-align: right;"><p><i> Քվեարկության կարգը <b>' . $elType . "</b></i></p>";
                echo "<p><i>Ընդունվել է. <b>".$data['DeadTime']."</b></i></p></div></div>";
                echo "</div>";
    
                echo '<p style="margin: 20px;text-align:justify;">'.$data['ElDescription'].'</p>';

                $pieces = explode("|", $data['ElVariants']);

                echo '<div style="width:50%;text-align:center;margin:auto; overflow: auto;">';
                echo '<div class="innerTable">';
                for($i=0;$i< count($pieces);$i++){
                    
                    echo '<div class="innerRow" style="padding:50px;border:0px"><div class="innerCell"><b>' .$pieces[$i] . "</b></div>";
                    echo '<div class="innerCell"></div><div class="innerCell"> Քանակը: 0</div></div>';
                }
                echo '</div>';
                echo '</div>';
                
                exit;
            }

            $pieces = explode("|", $data['ElVariants']);

            if($data['ElType'] == 1)
                $elType = "Փակ";
            else 
                $elType = "Բաց";

            echo '<div class="innerTable"><div class="innerRow">';
            echo '<div class="innerCell"><p>' . $data['ElName'] . "</p></div>";
            echo '<div class="innerCell" style="text-align: right;"><p><i> Քվեարկության կարգը <b>' . $elType . "</b></i></p>";
            echo "<p><i>Ընդունվել է. <b>".$data['DeadTime']."</b></i></p></div></div>";
            echo "</div>";

            echo '<p style="margin: 20px;text-align:justify;">'.$data['ElDescription'].'</p>';
            
            //1 pak
            $voteCount = array_fill(0, count($pieces), 0);
            $voteUsers = array_fill(0, count($pieces), "");
            if($data['ElType'] == 0){
                //bac
                $data = $pdo->query($str)->fetchAll();
                    
                foreach ($data as $row) {
                    $voteCount[$row['VotedVariant']-1]++;     
                    $voteUsers[$row['VotedVariant']-1] = $voteUsers[$row['VotedVariant']-1]."".$row['NickName'].", ";
                }

                echo '<div style="width:50%;text-align:center;margin:auto; overflow: auto;"><p>Քվեարկության արդյունքները</p>';   
                echo '<div class="innerTable">';
                for($i=0;$i< count($pieces);$i++){
                    
                    echo '<div class="innerRow" style="padding:50px;border:0px"><div class="innerCell"><b>' .$pieces[$i] . "</b></div>";
                    echo '<div class="innerCell">'.substr($voteUsers[$i],0,-2).'</div><div class="innerCell"> Քանակը: '. $voteCount[$i] .'</div></div>';
                }
                echo '</div>';
                echo '</div>';
            }else{
                //pak
                $pdo = GetConnection("localhost","test","root","");
                $str = 'SELECT election.ElVariants,closed.VoteCount FROM closed INNER JOIN election ON closed.IdElection = election.IdElection where election.IdElection =  '.$_GET['id'];            
                $data = $pdo->query($str)->fetch();
    
                $variants = explode("|", $data['ElVariants']);
                $qanak = explode("|", $data['VoteCount']);
                

                echo '<div style="width:50%;text-align:center;margin:auto; overflow: auto;"><p>Քվեարկության արդյունքները</p>';   
                echo '<div class="innerTable">';
                for($i=0;$i< count($pieces);$i++){
                    
                    echo '<div class="innerRow" style="padding:50px;border:0px"><div class="innerCell"><b>' .$variants[$i]. "</b></div>";
                    echo '<div class="innerCell"> Քանակը: '.$qanak[$i]. "</div></div>";
                }
                echo '</div>';
                echo '</div>';
            }
        }else{
            $str = "SELECT * FROM election where IdElection = ".$_GET['id'];
            $data = $pdo->query($str)->fetchAll();
                
            echo '<div class="innerTable">';
            $ElNom = 0;

            foreach ($data as $row) {

            if($row['ElType'] == 1)
                $elType = "Փակ";
            else 
                $elType = "Բաց";
            
                echo '<div class="innerRow">';
                echo '<div class="innerCell"><p>' . $row['ElName'] . "</p></div>";
                echo '<div class="innerCell" style="text-align: right;"><p><i> Քվեարկության կարգը <b>' . $elType . "</b></i></p>";
                echo "<p><i>Մինչև ավարտը <b id='timer".$ElNom."'> </b></i></p></div>";
                echo "</div>";
                echo "</div>";
                $ElNom = $ElNom + 1;

                $pieces = explode("|", $row['ElVariants']);

                echo '<p style="margin: 20px;text-align:justify;">'.$row['ElDescription'].'</p>';
                //vote condition
                $pdo = GetConnection("localhost","test","root","");

                $str = "SELECT * FROM votelist where IdElection = ".$row['IdElection']." and IdUser = ".$_SESSION['IdUser'];
                $qdata = $pdo->query($str)->fetchAll();

                foreach ($qdata as $qrow) {
                    if($row['ElType'] == 1)
                        echo "<p style = \"text-align: center;\">Ձեր ընտրությունը կատարված է</b></p>";
                    else
                        echo "<p style = \"text-align: center;\">Ձեր ընտրությունը <b>".$pieces[($qrow['VotedVariant']-1)]."</b></p>";

                    echo "<p style = \"text-align: center;\">Արդյունքները ավարտից հետո կպահվեն <a href=\"javascript:ArchiveBar()\">արխիվում</a></p>";
                    exit;
                }
                //

                if($_SESSION["Permission"] == 1){
                    echo '<form style = "margin:20px;" onsubmit="return confirm(\'դուք վստա՞հ եք\');" action="ElectionDelete.php">';

                    for($i=0;$i<count($pieces);$i++)
                    {
                        echo '<div style=\'padding:10px\'>';
                        echo '<input type = \'radio\' checked>';
                        echo '<label for=\'rb'.$i.'\'> '.$pieces[$i].'</input><br>';
                        echo '</div>';
                    }
                    echo '<input id = \'sbmBtn\' type=\'submit\' value = \'Հեռացնել\' style=\'float:right;font-size:large;padding:4px;\'>';
                }else{
                    echo '<form style = "margin:20px;" onsubmit="return confirm(\'դուք վստա՞հ եք\');" action="ElectionCreate.php" method = "post">';
                    echo '<input type="hidden" name="eid" value="'.$row['IdElection'].'"/>';

                    for($i=0;$i<count($pieces);$i++)
                    {
                        echo '<div style=\'padding:10px\'>';
                        echo '<input type = \'radio\' name = \'group1\' id=\'rb'.$i.'\' value=\''.$pieces[$i].'|'.($i+1).'\' required>';
                        echo '<label for=\'rb'.$i.'\'> '.$pieces[$i].'</input><br>';
                        echo '</div>';
                    }

                    echo '<input name = \'submit\' type=\'submit\' value = \'Քվեարկել\' style=\'float:right;font-size:large;padding:4px;\'>';
                }

                echo '</form>';
            }
            echo "</div>";
        }
    }

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