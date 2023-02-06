<?php

class ModelUser
{

    public function __construct()
    {

    }

    public function AddUser($user_name, $user_sname, $user_email)
    {
        $sql = "INSERT INTO users (first_name, last_name, email) VALUES (?,?,?)";
        $stmt = Database::get_instance()->get_connection()->prepare($sql);
        $stmt->execute([$user_name, $user_sname, $user_email]);
    }
}