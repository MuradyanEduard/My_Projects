var tm = null;

function Init(){
    SelectionBar();
}


function SelectionBar(){
    ClearBlocks();
    ShowActiveElections();
}

function ShowActiveElections() {
    if(UserInfo.Permission == 1){
        var btnCreate = document.createElement("button");
        btnCreate.setAttribute("onclick","javascript:ElectionCreateForm();");
        btnCreate.innerHTML = "Ստեղծել";
        btnCreate.style.float="right";
        btnCreate.style.marginBottom="10px";
        document.getElementById("linkHeader").appendChild(btnCreate);
    }

    UseDatabaseInfo("ElectionSelect.php?table=election&active=1");

    SetTimers(deadTime);

}

function SelectedElInfo(tmNom,nom){
    ClearBlocks();
    
    var getBack = document.createElement("a");
    getBack.innerHTML = "Վերադառնալ ցանկին";
    getBack.href = "javascript:SelectionBar()";
    getBack.id = "getBack";
    document.getElementById('linkHeader').appendChild(getBack);

    UseDatabaseInfo("ElectionSelect.php?id="+nom);
    SetTimers([deadTime[tmNom]]);
 
}

function TarberakCount(){
    var element = document.getElementById("tarberak");
    var count = parseInt(document.getElementById("idTrbCount").value);

    element.innerHTML = "";

    for(var i=0;i<count;i++){
       var innerRow = document.createElement("div");
       innerRow.class = "innerRow";

       var lbl = document.createElement("label");
       lbl.innerHTML = "Տարբերակ " + (i + 1) ;

       var trb = document.createElement("input");
       trb.name = "trb" + (i+1);
       trb.type = "text";
       trb.required  = "true";
       innerRow.appendChild(lbl);
       innerRow.appendChild(trb);
       element.appendChild(innerRow);    
    }   

}



function ArchiveBar(){
    ClearBlocks();
    UseDatabaseInfo("ElectionSelect.php?table=election&active=0");
}

function WatchSelection(nom){
    ClearBlocks();    
    UseDatabaseInfo("ElectionSelect.php?id="+nom+"&active="+0);
}


function ElectionCreateForm(){
    ClearBlocks();

    var getBack = document.createElement("a");
    getBack.innerHTML = "Վերադառնալ ցանկին";
    getBack.href = "javascript:SelectionBar()";
    getBack.id = "getBack";
    document.getElementById('linkHeader').appendChild(getBack);

    document.getElementById("body").innerHTML = ' <form id="usrform" onsubmit="return confirm(\'դուք վստա՞հ եք\');" method="post" action="ElectionCreate.php"> <div class="innerTable"> <div class="innerRow" style="border:0px;"> <div class="innerCell">Քվեարկության անվանումը.</div><div class="innerCell"> <input type="text" id="idElName"  required placeholder="Անվանումը" name="ElName"><br></div></div><div class="innerRow" style="border:0px;"> <div class="innerCell">Քվեարկության կարգը.</div><div class="innerCell"> <select id="idElType" name="ElType"> <option value="Opened">Բաց</option> <option value="Closed">Փակ</option> </select><br></div></div><div class="innerRow" style="border:0px;"> <div class="innerCell"> Նկարագրություն.</div><div class="innerCell"> <textarea id="idDesctiption" name="Desctiption" style=" resize: none;" placeholder="Նկարագրություն ..." rows="4" cols="50"   required ></textarea><br></div></div><div class="innerRow" style="border:0px;"> <div class="innerCell">Ժամանակ (րոպե).</div><div class="innerCell"> <input type="number" id="idTime" name="Time" step="1" min="1" value="5" style="width:80px;"><br></div></div><div class="innerRow" style="border:0px;"> <div class="innerCell">Տարբերակների քանակ.</div><div class="innerCell"> <input type="number" onchange="javascript:TarberakCount()" id="idTrbCount" name="TrbCount" step="1" min="2" value="3" style="width:80px;" ><br></div></div><div id="tarberak" style="width:150%;"> </div></div><input type="submit" name="submit" value="Ստեղծել" style="float: right;margin:25px;"> </div></form> ';

    TarberakCount();
}

var voteVar = 0;

function ClearBlocks(){
    if(tm!=null)
    {
        clearInterval(tm);
        tm=null;
    }

    //document.getElementById("header").innerHTML = "";
    document.getElementById("linkHeader").innerHTML = "";
    document.getElementById("body").innerHTML = "";
    document.getElementById("footer").innerHTML = "";
}

function UseDatabaseInfo(DbAttributes){

    var xhttp;
    xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function() {
        if (this.readyState == 4 && this.status == 200) {
          document.getElementById("body").innerHTML = this.responseText;
        }
      };
    xhttp.open("GET", DbAttributes, true);
    xhttp.send();
}

function SetTimers(timerArray){
    if(tm!=null)
    {
        clearInterval(tm);
        tm=null;
    }



    var cond = true;
    tm = setInterval(function() {
    
    var StartTime = new Date().toLocaleString("en-US", {timeZone: "Asia/Yerevan"});
    StartTime = new Date(StartTime);//Date.parse(StartTime);

    for(var i = 0;i<timerArray.length;i++)
    {
        
        document.getElementById("timer"+i).innerHTML ="";

        var DeadTime = new Date(timerArray[i]);            

        var mDeadTime = DeadTime.getTime() / 1000;
        var mStartTime = StartTime.getTime() / 1000;

        var distance =  mDeadTime - mStartTime;

        // Time calculations for days, hours, minutes and seconds
        var days = Math.floor(distance / (3600*24));
        var hours = Math.floor(distance % (3600*24) / 3600);
        var minutes = Math.floor(distance % 3600 / 60);
        var seconds = Math.floor(distance % 60);

        if (distance < 0) {
            document.getElementById("timer"+i).innerHTML += "EXPIRED <br>";
            location.reload();
        }
        else{
            cond  = false;
            document.getElementById("timer"+i).innerHTML += days + "d " + hours + "h "
            + minutes + "m " + seconds + "s <br>";
        }
    }

    if (cond) {
        clearInterval(tm);

        if(deadTime.length==0){
            document.getElementById("body").innerHTML = '<div style="height:1px;margin:auto;text-align:center;left:0;top:0;bottom:0;right:0;position:absolute;"><p><b>Ընթացիկ քվեարկություններ չկան!</b></p><div>'
        }

    }

    }, 1000);
}