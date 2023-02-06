<?php


class Product
{
    private $id;
    private $name;
    private $count;
    private $price;

    public function __construct($id, $name, $count, $price)
    {
        $this->id = $id;
        $this->name = $name;
        $this->count = $count;
        $this->price = $price;
    }

    function get_id()
    {
        return $this->id;
    }

    function get_name()
    {
        return $this->name;
    }

    function get_count()
    {
        return $this->count;
    }

    function set_count($count)
    {
        $this->count = $count;
    }

    function get_price()
    {
        return $this->price;
    }

    function set_price($price)
    {
        $this->price = $price;
    }
}