$(document).ready(function () {
    ShowProductData();
    ShowProductImage()
});

function RoleDropDown() {
    debugger
    $.ajax({
        type: "Get",
        url: "/Category/GetCategoryList",
        contentType: "application/json",
        success: function (data) {
            $("#CategoryId").html("");
            $("#CategoryId").append("<option value=''>" + "Select Category Name" + "</option > ")
            for (var i = 0; i < data.legth; i++) {
                $("#CategoryId").append("<option value=" + data[i].categoryId + ">" + data[i].categoryName + "</option")
            }
        }
    });
}

// Show Product

function ShowProductImage() {
    debugger
    $.ajax({
        url: '/Product/GetProduct',
        type: 'Get',
        dataType: 'json',
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            debugger;
            var object = '';
            object += '<div class="row">'

            $.each(data, function (index, item) {
                object += ' <div class="col-3">';
                object += ' <div class="card mb-3">';
                object += ' <div class="card-header" style="background-color:#b5ebe2;">';
                object += ' <h4>';
                object += ' <label style="font-size:23px; color:steelblue;">' + item.productName + '</label>';
                object += ' </h4>';
                object += ' </div>';
                object += '<img src="/Images/Products/' + item.photo + '"alt="Card Image" class="card-img-tops" style="height:250px;">';
                object += '<div class="card-header" style="background-color:#b5ebe2;color:white">';
                object += ' <div class="d-flex justify-content-between align-items-center">';
                object += ' <div class="btn-group"> ';
                object += ' <label  style="font-size:20px; color:#a51313"><b>Price : ' + item.price + '</b></label> ';
                object += ' </div> ';
                object += '<a herf="#" class="btn btn-sm btn-warning" onclick="OrderProduct(' + item.productId + ')">Order</a> <a herf="#" class="btn btn-sm btn-success pull-right" onclick="Detail(' + item.productId + ')">Detail</i></a> ';
                object += ' </div> ';
                object += ' </div>';
                object += ' </div>';
                object += ' </div>';
            });
            $('#ProductImage').html(object);
            object += '</div>'
        },
        error: function () {
            alert("Data con not get");
        }
    })
}

// --------- Get Product Detail -----

function Detail(ProductId) {
    debugger
    $.ajax({
        url: '/Product/GetProductById?ProductId=' + ProductId,
        type: 'Get',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        success: function (response) {
            $('#ProductDetail').modal('show');
            $('#ProductId').val(response.productId);
            $('#CategoryId').val(response.categoryId);
            $('#ProductName').val(response.productName);
            $('#PhotoPath').val(response.photoPath);
            $('#Price').val(response.price);
            $('#AddProduct').css('display', 'none');
            $('#UpdateProduct').css('display', 'block');
        },
        error: function () {
            alert("Record can not find");
        }

    });
}


// Show Product List 

function ShowProductData() {
    debugger
    $.ajax({
        url: '/Product/GetProduct',
        type: 'Get',
        dataType: 'json',
        /*contentType: 'application/x-www-form-urlencoded; charset=UTF-8',*/
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            debugger;
            var object = '';
            $.each(data, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.productId + '</td>';
                object += '<td>' + item.categoryName + '</td>';
                object += '<td>' + item.productName + '</td>';
                object += '<td><img src="/Images/Products/' + item.photo + '"height="40" width="50"></td>';
                object += '<td>' + item.price + '</td>';
                object += '<td><a herf="#" class="btn btn-primary" onclick="Edit(' + item.productId + ')"><i class="far fa-edit"></i></a> || <a herf="#" class="btn btn-danger" onclick="Delete(' + item.productId + ')"><i class="fas fa-trash-alt"></i></a> || <a herf="#" class="btn btn-warning" onclick="OrderProduct(' + item.productId + ')">OrderProduct</a></td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data con not get");
        }
    })
}

$('#btnAddProduct').click(function () {
    $('#ProductModel').modal('show');
});


$("#AddProduct").click(function (e) {
    debugger;
    e.preventDefault();
    var fdata = new FormData();

    var fileInput = $('#PhotoPath')[0];
    var file = fileInput.files[0];
    fdata.append("PhotoPath", file);

    $("form input[type='text']").each(function (x, y) {
        fdata.append($(y).attr("name"), $(y).val());
    });
    var value = $('select#CategoryId option:selected').val();
    fdata.append("CategoryId", value)

    $.ajax({
        url: '/Product/AddProduct',
        type: 'Post',
        contentType: false,
        processData: false,
        data: fdata,
        success: function () {
            swal({
                title: 'Product Added Successfuly',
                text: '',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#DD6B55',
                confirmButtonText: 'Yes!'
            })

            ClearTextBox();
            ShowProductData();
            HideModelPopup();
        },
        error: function () {
            alert("Record can not Added !");
        }
    });
});

// ------- Get Edit ------------

function Edit(ProductId) {
    debugger
    $.ajax({
        url: '/Product/GetProductById?ProductId=' + ProductId,
        type: 'Get',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        success: function (response) {
            $('#ProductModel').modal('show');
            $('#ProductId').val(response.productId);
            $('#CategoryId').val(response.categoryId);
            $('#ProductName').val(response.productName);
            $('#PhotoPath').val(response.photoPath);
            $('#Price').val(response.price);
            $('#AddProduct').css('display', 'none');
            $('#UpdateProduct').css('display', 'block');
        },
        error: function () {
            alert("Record can not find");
        }

    });
}

$("#UpdateProduct").click(function (e) {
    debugger;
    e.preventDefault();
    var fdata = new FormData();

    var fileInput = $('#PhotoPath')[0];
    var file = fileInput.files[0];
    fdata.append("PhotoPath", file);

    $("form input[type='text']").each(function (x, y) {
        fdata.append($(y).attr("name"), $(y).val());
    });

    $.ajax({
        url: '/Product/UpdateProduct',
        type: 'Post',
        contentType: false,
        processData: false,
        data: fdata,
        success: function () {
            swal({
                title: 'Product Updated Successfuly',
                text: '',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#DD6B55',
                confirmButtonText: 'Yes!'
            })

            ClearTextBox();
            ShowProductData();
            HideModelPopup();
        },
        error: function () {
            alert("Record can not Updated !");
        }
    });
});

function Delete(ProductId) {
    debugger
    if (confirm('Are you sure, You want to delete this record ?')) {
        $.ajax({
            url: '/Product/DeleteProduct?ProductId=' + ProductId,
            success: function () {
                swal({
                    title: 'Data Deleted Successfuly',
                    text: '',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#DD6B55',
                    confirmButtonText: 'Yes!'
                })

                ShowProductData();
            },
            error: function () {
                alert("Record can not Deleted");
            }
        });
    }
}


// Show Order Model

function OrderProduct(ProductId) {
    debugger
    $.ajax({
        url: '/Product/GetEditProduct?ProductId=' + ProductId,
        type: 'Get',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        success: function (response) {
            $('#OrderModel').modal('show');
            $('#ProductId').val(response.productId);

            $('#AddProduct').css('display', 'none');
            $('#AddOrder').css('display', 'block');
        },
        error: function () {
            alert("Record can not find");
        }

    });
}

$("#AddOrder").click(function (e) {
    debugger;
    e.preventDefault();
    var fdata = new FormData();

    $("form input[type='text']").each(function (x, y) {
        fdata.append($(y).attr("name"), $(y).val());
    });

    $.ajax({
        url: '/Order/OrderProduct',
        type: 'Post',
        contentType: false,
        processData: false,
        data: fdata,
        success: function () {
            swal({
                title: 'Product Added Successfuly',
                text: '',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#DD6B55',
                confirmButtonText: 'Yes!'
            })

            ClearTextBox();
            ShowProductData();
            HideModelPopup();
        },
        error: function () {
            alert("Record can not Added !");
        }
    });
});