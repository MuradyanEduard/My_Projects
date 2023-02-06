<?php

class ModelOrderProduct
{
    private $lats_id;

    public function __construct()
    {
        $this->last_id = Database::get_instance()->get_connection()->lastInsertId();
    }

    public function addOrderProduct($product_id, $count)
    {

        $sql = "INSERT INTO order_products (order_id, product_id, qty) VALUES (?,?,?)";
        $stmt = Database::get_instance()->get_connection()->prepare($sql);
        $stmt->execute([$this->last_id, $product_id, $count]);
    }

}