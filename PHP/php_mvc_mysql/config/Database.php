<?php


class Database
{
    private static $instance = null;

    private $host = 'localhost';
    private $dbName = 'test';
    private $user = 'root';
    private $pass = '';

    public function __construct()
    {
        $this->conn = new PDO('mysql:host=' . $this->host . ';dbname=' . $this->dbName, $this->user, $this->pass);
    }

    public static function get_instance()
    {
        if (self::$instance == null) {
            self::$instance = new Database();
        }
        return self::$instance;
    }

    public function get_connection()
    {
        return $this->conn;
    }

}
