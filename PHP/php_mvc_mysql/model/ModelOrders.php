<?php

class ModelOrder
{

    public function __construct()
    {
    }

    public function addOrder($total_price)
    {
        $last_id = Database::get_instance()->get_connection()->lastInsertId();
        echo $last_id . "<br>";
        $stmt = Database::get_instance()->get_connection()->prepare("INSERT INTO orders (user_id, summary) VALUES (?,?)");
        $stmt->execute([$last_id, $total_price]);
    }

    public function select_user_order()
    {
        $all_users = [];

        $stmUsers = Database::get_instance()->get_connection()->query("SELECT * FROM users");

        $res = $stmUsers->fetchAll();

        $nomUs = 1;
        foreach ($res as $value) {

            $stmOrder = Database::get_instance()->get_connection()->query("SELECT users.first_name,users.last_name,users.email,orders.summary,orders.order_date 
    FROM users INNER JOIN orders ON users.id = orders.user_id INNER JOIN order_products ON orders.id = order_products.order_id INNER JOIN products ON order_products.product_id = products.id
WHERE users.id = " . $value["id"]);
            $resUser = $stmOrder->fetchAll();

            foreach ($resUser as $val) {
                array_push($all_users, $val);
                break;
            }

        }

        return $all_users;
    }

    public function select_product_order()
    {
        $all_orders = [];

        $stmUsers = Database::get_instance()->get_connection()->query("SELECT * FROM users");

        $res = $stmUsers->fetchAll();

        $nomUs = 1;
        foreach ($res as $value) {

            $stmOrder = Database::get_instance()->get_connection()->query("SELECT products.name,products.description,products.price,order_products.qty 
FROM users INNER JOIN orders ON users.id = orders.user_id INNER JOIN order_products ON orders.id = order_products.order_id INNER JOIN products ON order_products.product_id = products.id
WHERE users.id = " . $value["id"]);
            $resOrder = $stmOrder->fetchAll();


            $arr = [];
            foreach ($resOrder as $val) {
                array_push($arr, $val);
            }

            array_push($all_orders, $arr);
        }

        return $all_orders;
    }

}