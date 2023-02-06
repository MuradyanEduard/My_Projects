<?php
require_once('config/Database.php');
require_once('config/Product.php');

session_start();

require_once "model/ModelProduct.php";
require_once "model/ModelOrders.php";
require_once "model/ModelOrderProducts.php";
require_once "model/ModelUser.php";

require_once "controller/Controller.php";
require_once "controller/ControllerProduct.php";
require_once "controller/ControllerProductsOrders.php";

require_once 'config/Validations.php';