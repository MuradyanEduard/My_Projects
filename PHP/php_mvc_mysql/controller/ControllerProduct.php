<?php

class ControllerProduct extends Controller
{

    public function __construct()
    {
        parent::__construct();
    }

    public function get_data()
    {
        $instance = Database::get_instance();
        $conn = $instance->get_connection();

        if (isset($_POST['name']) && isset($_POST['desc']) && isset($_POST['price'])) {
            $model = new ModelProduct();
            $model->add_product();
            header('Location: index.php');
            die();
        }

        if (isset($_POST['productCount'])) {
            $model = new ModelProduct();
            $model->add_productList();
            header('Location: index.php');
            die();
        }

        if (isset($_POST['deleteProduct'])) {

            foreach ($_SESSION["productList"] as $key => $value) {
                if ($value->get_id() == $_POST['prodId']) {
                    unset($_SESSION["productList"][$key]);
                    break;
                }
            }

            header('Location: index.php');
            die();
        }
    }

}