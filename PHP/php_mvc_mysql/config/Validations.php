<?php
if (isset($_POST["productId"]) && isset($_POST["productCount"])) {

    if ($_POST["productCount"] == '') {
        $_SESSION['error_message'] = "Select count not!";
        header('Location: index.php');
        die();
    }

    if (CheckRegex('/[^0-9]/', $_POST["productCount"])) {
        $_SESSION['error_message'] = "Your product count should be positive number!";
        header('Location: index.php');
        die();
    }


}

if (isset($_POST['name']) && isset($_POST['desc']) && isset($_POST['price'])) {

    if ($_POST['name'] == '') {
        $_SESSION['error_message'] = "Write your name!";
        $_SESSION['error_message'] = "Your name contain invalid symbols!";
        header('Location: index.php');
        die();
    }

    if ($_POST['desc'] == '') {
        $_SESSION['error_message'] = "Write your description!";
        $_SESSION['error_message'] = "Your name contain invalid symbols!";
        header('Location: index.php');
        die();
    }

    if ($_POST['price'] == '') {
        $_SESSION['error_message'] = "Write your price!";
        $_SESSION['error_message'] = "Your name contain invalid symbols!";
        header('Location: index.php');
        die();
    }


    if (CheckRegex('/[<>\'"]/', $_POST['name'])) {
        $_SESSION['error_message'] = "Your name contain invalid symbols!";
        header('Location: index.php');
        die();

    }

    if (CheckRegex('/[<>\'"]/', $_POST['desc'])) {
        $_SESSION['error_message'] = "Your description contain invalid symbols!";
        header('Location: index.php');
        die();
    }

    if (CheckRegex('/[^0-9]/', $_POST['price'])) {
        $_SESSION['error_message'] = "Your price not a number!";
        header('Location: index.php');
        die();

    }

}

if (isset($_POST['buyProductName']) && isset($_POST['buyProductSname']) && isset($_POST['buyProductEmail'])) {

    if ($_POST['buyProductName'] == '') {
        $_SESSION['error_message'] = "Write your user name!";
        header('Location: index.php');
        die();
    }

    if ($_POST['buyProductSname'] == '') {
        $_SESSION['error_message'] = "Write your user surname!";
        header('Location: index.php');
        die();
    }

    if ($_POST['buyProductEmail'] == '') {
        $_SESSION['error_message'] = "Write your email!";
        header('Location: index.php');
        die();
    }


    if (!preg_match('/^[a-z]+@[a-z]+[.][a-z]+/', $_POST['buyProductEmail'])) {
        $_SESSION['error_message'] = "Email is wrong!";
        header('Location: index.php');
        die();
    }

}
//^[0-9]

//echo CheckRegex('/[^0-9]/', "1.1");

function CheckRegex($patern, $var)
{
    if (preg_match($patern, $var)) {
        return True;
    } else {
        return False;
    }
}
