<?php
$nomUs = 0;

foreach ($users as $value) {
    $nomUs++;
    ?>

    <div style="width: 100%;border-bottom: 1px solid;margin:40px 100px;">
        <p><b>User<?= $nomUs ?> Info</b></p>
        <table class="table">
            <thead class="thead-dark">
            <tr>
                <th scope="col">First Name</th>
                <th scope="col">Last Name</th>
                <th scope="col">Email</th>
                <th scope="col">Summary</th>
                <th scope="col">Order Date</th>
            </tr>
            </thead>
            <tbody>
            <tr>
                <th><?= $value['first_name'] ?></th>
                <td><?= $value['last_name'] ?></td>
                <td><?= $value['email'] ?></td>
                <td><?= $value['summary'] ?></td>
                <td><?= $value['order_date'] ?></td>
            </tr>
            </tbody>
        </table>

        <p><b>Orders Info</b></p>
        <table class="table">
            <thead class="thead-dark">
            <tr>
                <th scope="col">N</th>
                <th scope="col">Name</th>
                <th scope="col">Description</th>
                <th scope="col">Price</th>
                <th scope="col">Count</th>
            </tr>
            </thead>
            <tbody>
            <?php
            $nomOrd = 1;
            foreach ($orders[$nomUs - 1] as $val) {
                ?>
                <tr>
                    <th scope="row"><?= $nomOrd++ ?></th>
                    <td><?= $val['name'] ?></td>
                    <td><?= $val['description'] ?></td>
                    <td><?= $val['price'] ?></td>
                    <td><?= $val['qty'] ?></td>
                </tr>
                <?Php
            }
            ?>
            </tbody>
        </table>
    </div>
    <?php
}

