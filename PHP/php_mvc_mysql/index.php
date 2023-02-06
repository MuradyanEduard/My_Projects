<?php

require_once('route/Autoload.php');

$controller = '';
$view = '';

$allProducts = [];
$users = [];
$orders = [];

$totalPrice = 0;

Database::get_instance()->get_connection();

$path = explode('/', $_SERVER['REQUEST_URI']);
$controller_type = $path[array_key_last($path)];

if (!isset($_SESSION['error_message'])) {
    $controller_type = "index.php";
}

if ($controller_type == 'index.php' || $controller_type == '') {
    $controller = new ControllerProduct();
    $controller->get_data();
    $view = 'productMain.php';
} else if ($controller_type == 'ProductRegister') {
    $controller = new ControllerProduct();
    $controller->get_data();
    $view = 'productEdit.php';

} else if ($controller_type == 'OrderList') {
    $controller = new ControllerProductsOrders();
    $controller->get_data();
    $users = $controller->get_users();
    $orders = $controller->get_orders();
    $view = 'orderList.php';
} else {
    header("HTTP/1.0 404 Not Found");
    exit;
}

$allProducts = $controller->get_product_list();
$totalPrice = $controller->get_total_price();


require_once('views/pattern.php');

if (isset($_SESSION['error_message'])) {
    unset($_SESSION['error_message']);
}

