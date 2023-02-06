<?php


class Controller
{
    public $totalPrice;
    public $allProducts;

    public function __construct()
    {
        $this->totalPrice = 0;

        if (isset($_SESSION["productList"])) {
            foreach ($_SESSION["productList"] as $value) {
                $this->totalPrice += $value->get_price();
            }
        }

        $model = new ModelProduct();
        $this->allProducts = $model->get_all_products();
    }

    public function get_total_price()
    {
        return $this->totalPrice;
    }

    public function get_product_list()
    {
        return $this->allProducts;
    }

}