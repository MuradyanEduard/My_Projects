<?php

class ModelProduct
{

    public function __construct()
    {

    }

    public function add_product()
    {
        $sql = "INSERT INTO products (name, description, price) VALUES (?,?,?)";
        $stmt = Database::get_instance()->get_connection()->prepare($sql);
        $stmt->execute([$_POST['name'], $_POST['desc'], $_POST['price']]);
    }

    public function get_all_products()
    {
        $stm = Database::get_instance()->get_connection()->query("SELECT * FROM products");
        return $stm->fetchAll();
    }

    public function add_productList()
    {
        $stm = Database::get_instance()->get_connection()->query("SELECT * FROM products WHERE products.id = " . $_POST['productId']);
        $res = $stm->fetch();

        $product = new Product($res['id'], $res['name'], $_POST['productCount'], $res['price']);

        if (!isset($_SESSION["productList"])) {
            $_SESSION["productList"] = array();
        }

        $cond = false;

        foreach ($_SESSION["productList"] as $key => $value) {
            if ($value->get_id() == $res['id']) {
                $_SESSION["productList"][$key]->set_count($_SESSION["productList"][$key]->get_count() + $_POST['productCount']);
                $_SESSION["productList"][$key]->set_price($_SESSION["productList"][$key]->get_count() * $res['price']);
                $cond = true;
                break;
            }
        }

        if (!$cond) {
            $product->set_price(intval($_POST['productCount']) * intval($res['price']));
            array_push($_SESSION["productList"], $product);
        }
    }
}