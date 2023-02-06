<?php

class ControllerProductsOrders extends Controller
{
    private $all_users;
    private $all_orders;

    public function __construct()
    {
        parent::__construct();
        $this->all_users = [];
        $this->all_orders = [];
    }

    public function get_data()
    {
        $instance = Database::get_instance();
        $conn = $instance->get_connection();

        if (!isset($_SESSION['Name'])) {
            $_SESSION['Name'] = '';
        }
        if (!isset($_SESSION['Sname'])) {
            $_SESSION['Sname'] = '';
        }
        if (!isset($_SESSION['Email'])) {
            $_SESSION['Email'] = '';
        }

        if (isset($_POST["buyProductName"]) && isset($_POST["buyProductSname"]) && $_POST["buyProductEmail"]) {
            $_SESSION['Name'] = $_POST["buyProductName"];
            $_SESSION['Sname'] = $_POST["buyProductSname"];
            $_SESSION['Email'] = $_POST["buyProductEmail"];

            $model = new ModelUser();
            $model->AddUser($_POST["buyProductName"], $_POST["buyProductSname"], $_POST['buyProductEmail']);

            $model = new ModelOrder();
            $model->addOrder(parent::get_total_price());

            $model = new ModelOrderProduct();

            foreach ($_SESSION["productList"] as $key => $prodVal) {
                $model->addOrderProduct($prodVal->get_id(), $prodVal->get_count());
            }

            $_SESSION['productList'] = [];
            header('Location: index.php');
            die();
        }

        $model = new ModelOrder();
        $this->all_users = $model->select_user_order();
        $this->all_orders = $model->select_product_order();

    }


    public function get_users()
    {
        return $this->all_users;
    }

    public function get_orders()
    {
        return $this->all_orders;
    }

}