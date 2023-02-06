<!doctype html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport"
          content="width=device-width, user-scalable=no, initial-scale=1.0, maximum-scale=1.0, minimum-scale=1.0">
    <meta http-equiv="X-UA-Compatible" content="ie=edge">
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css"
          integrity="sha384-WskhaSGFgHYWDcbwN70/dfYBj47jz9qbsMId/iRN3ewGhXQFZCSftd1LZCfmhktB" crossorigin="anonymous">
    <link rel="stylesheet" href="../views/css/style.css">
    <link rel="stylesheet" href="views/css/style.css">
    <title>php_mvc_mysql</title>
</head>
<body>


<div class="container errors">
    <p> <?php if (isset($_SESSION['error_message'])) { ?> <?= $_SESSION['error_message'] ?><?php } ?></p></div>
<div class="container">
    <div class="row">
        <div class="container_header col-12">
            <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <button class="navbar-toggler" type="button" data-toggle="collapse"
                        data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent"
                        aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item active ">
                            <a class="nav-link" href="http://localhost/PHP/php_mvc_mysql/index.php">Products</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="http://localhost/PHP/php_mvc_mysql/index.php/ProductRegister">Add
                                Product</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="http://localhost/PHP/php_mvc_mysql/index.php/OrderList">All
                                Order List</a>
                        </li>
                    </ul>
                </div>
            </nav>
        </div>
        <!--aldsnkasndkasnd -->
        <?php
        require_once('views/' . $view);
        ?>
    </div>
</div>
</div>


<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel"
     aria-hidden="true">
    <div class="modal-dialog modal-sm" role="document">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Buy Products</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <form action="index.php/OrderList" method="post" onsubmit="return confirm('Are you sure?')">
                    <label for="buyProductName">Name</label><br>
                    <input type="text" name="buyProductName" value="<?= $_SESSION["Name"] ?>" required><br>
                    <label for="buyProductSname">Surname</label><br>
                    <input type="text" name="buyProductSname" value="<?= $_SESSION["Sname"] ?>" required><br>
                    <label for="buyProductEmail">Email</label><br>
                    <input type="text" name="buyProductEmail" value="<?= $_SESSION["Email"] ?>" required><br>
                    <input type="submit" value="Buy Product"
                           style="background: cyan; width: 100%; height: 35px; margin-top: 10px; outline: none!important; cursor:pointer; border: none; color: white; border-radius: 8px;">
                </form>
            </div>
        </div>
    </div>
</div>

<script>
    $('#myModal').on('shown.bs.modal', function () {
        $('#myInput').trigger('focus')
    })
</script>
<script src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.11.0/umd/popper.min.js"
        integrity="sha384-b/U6ypiBEHpOf/4+1nzFpr53nxSS+GLCkfwBdFNTxtclqqenISfwAzpKaMNFNmj4"
        crossorigin="anonymous"></script>
<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta/js/bootstrap.min.js"
        integrity="sha384-h0AbiXch4ZDo7tp9hKZ4TsHbi047NrKGLO3SEJAg45jXxnGIfYzk4Si90RDIqNm1"
        crossorigin="anonymous"></script>
<script src="views/script/script.js"></script>
</body>
</html>

