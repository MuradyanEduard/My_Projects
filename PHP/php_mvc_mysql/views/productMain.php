<div class="container_content col-12 col-sm-8">
    <div class="row">
        <?php
        foreach ($allProducts as $val) {
            ?>

            <div class="col-12 col-sm-6 col-md-5 col-lg-4 ">
                <div class="container_content_item ">
                    <h3><?= $val["name"] ?></h3>
                    <p style="min-height: 100px;overflow-y: auto"><?= $val["description"] ?>
                    <p>Price: <?= $val["price"] ?></p>
                    <div class="order_add_block">
                        <form action="index.php" method="post">
                            <input type="hidden" name="productId" value="<?= $val["id"] ?>">
                            <input type="number" class="col-md-4" style="margin-right: 15px;padding: 0px"
                                   name="productCount">
                            <input type="submit" class="btn btn-dark col-md-6" value="Add">
                        </form>
                    </div>
                </div>
            </div>

            <?php
        }

        ?>
    </div>
</div>
<div class="order_menu col-12 col-md-4">
    <div class="order_menu_content">
        <h2>Product List</h2><br>
        <div class="order_menu_content_products">
            <?php
            if (isset($_SESSION["productList"])) {
                foreach ($_SESSION["productList"] as $value) {
                    ?>
                    <div style="border-bottom: 1px solid;margin-bottom: 20px;">
                        <form action="index.php" method="post">
                            <input type="hidden" name="prodId" value="<?= $value->get_id() ?>">
                            <input name="deleteProduct" type="submit" class="btn btn-light dltButton" value="x">
                        </form>
                        <p> Name: <?= $value->get_name() ?> </p>
                        <p> Count: <?= $value->get_count() ?> </p>
                        <h3 style="text-align: right;display: block;"> Price: <?= $value->get_price() ?> </h3>
                    </div>
                    <?php
                }
            }
            ?>
        </div>
    </div>
    <div class="order_menu_footer">
        <h3 style="text-align: right">Total Price: <b style="font-size: 30px"
                                                      class="total_price"><?= $totalPrice ?></b></h3>
        <button <?php echo (($_SESSION["productList"] == [] && isset($_SESSION["productList"]))) ? ("hidden") : ("") ?>
                type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal"
                style="float: right">
            Buy Products
        </button>
    </div>
</div>
