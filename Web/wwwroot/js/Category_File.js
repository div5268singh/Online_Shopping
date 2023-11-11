$(document).ready(function () {
    GetCategoryData();
});
function GetCategoryData() {
    $.ajax({
        url: '/Category/CategoryList',
        type: 'Get',
        dataType: 'json',
        success: function (response) {
            $('#dataTableData').DataTable({
                processing: true, // 'bProcessing' is not used in newer versions
                lengthChange: true,
                lengthMenu: [[5, 10, 25, -1], [5, 10, 25, "All"]],
                searching: true, // 'bFilter' is not used in newer versions
                ordering: true, // 'bSort' is not used in newer versions
                data: response,
                //columns: [
                //    { data: 'CategoryId' }, // Replace 'PropertyName1' with the actual property name in your response object
                //    { data: 'CategoryName' },
                //    { data: 'CategoryType' },
                //    // Add more columns as needed
                //]
            });
        }
    })
}



//$(document).ready(function () {
//    ShowCategoryData();
//});


//// Show Product List 

//function ShowCategoryData() {
//    debugger
//    $.ajax({
//        url: '/Category/CategoryList',
//        type: 'Get',
//        dataType: 'json',
//        /*contentType: 'application/x-www-form-urlencoded; charset=UTF-8',*/
//        contentType: 'application/json; charset=UTF-8',
//        success: function (data) {
//            debugger;
//            var object = '';
//            $.each(data, function (index, item) {
//                object += '<tr>';
//                object += '<td>' + item.categoryId + '</td>';
//                object += '<td>' + item.categoryName + '</td>';
//                object += '<td>' + item.categoryType + '</td>';
//                object += '<td><a herf="#" class="btn btn-primary" onclick="Edit(' + item.categoryId + ')"><i class="far fa-edit"></i></a> || <a herf="#" class="btn btn-danger" onclick="Delete(' + item.categoryId + ')"><i class="fas fa-trash-alt"></i></a> </td>';
//                object += '</tr>';
//            });
//            $('#table_data').html(object);
//        },
//        error: function () {
//            alert("Data con not get");
//        }
//    })
//}

$('#btnAddCategory').click(function () {
    $('#CategoryModel').modal('show');
});


$("#AddCategory").click(function (e) {
    debugger;
    e.preventDefault();
    var fdata = new FormData();

    //var fileInput = $('#PhotoPath')[0];
    //var file = fileInput.files[0];
    //fdata.append("PhotoPath", file);

    $("form input[type='text']").each(function (x, y) {
        fdata.append($(y).attr("name"), $(y).val());
    });

    $.ajax({
        url: '/Category/AddCategory',
        type: 'Post',
        contentType: false,
        processData: false,
        data: fdata,
        success: function () {
            swal({
                title: 'Category Added Successfuly',
                text: '',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#DD6B55',
                confirmButtonText: 'Yes!'
            })

            ClearTextBox();
            ShowCategoryData();
            HideModelPopup();
        },
        error: function () {
            alert("Record can not Added !");
        }
    });
});

// ------- Get Edit ------------

function Edit(CategoryId) {
    debugger
    $.ajax({
        url: '/Category/GetCategoryById?CategoryId=' + CategoryId,
        type: 'Get',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        success: function (response) {
            $('#CategoryModel').modal('show');
            $('#CategoryId').val(response.categoryId);
            $('#CategoryName').val(response.categoryName);
            $('#CategoryType').val(response.categoryType);
            $('#AddCategory').css('display', 'none');
            $('#UpdateCategory').css('display', 'block');
        },
        error: function () {
            alert("Record can not find");
        }

    });
}

$("#UpdateCategory").click(function (e) {
    debugger;
    e.preventDefault();
    var fdata = new FormData();

    //var fileInput = $('#PhotoPath')[0];
    //var file = fileInput.files[0];
    //fdata.append("PhotoPath", file);

    $("form input[type='text']").each(function (x, y) {
        fdata.append($(y).attr("name"), $(y).val());
    });

    $.ajax({
        url: '/Category/UpdateCategory',
        type: 'Post',
        contentType: false,
        processData: false,
        data: fdata,
        success: function () {
            swal({
                title: 'Category Updated Successfuly',
                text: '',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#DD6B55',
                confirmButtonText: 'Yes!'
            })

            ClearTextBox();
            ShowCategoryData();
            HideModelPopup();
        },
        error: function () {
            alert("Record can not Updated !");
        }
    });
});

function Delete(CategoryId) {
    debugger
    if (confirm('Are you sure, You want to delete this record ?')) {
        $.ajax({
            url: '/Category/DeleteCategory?CategoryId=' + CategoryId,
            success: function () {
                swal({
                    title: 'Data Deleted Successfuly',
                    text: '',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#DD6B55',
                    confirmButtonText: 'Yes!'
                })

                ShowCategoryData();
            },
            error: function () {
                alert("Record can not Deleted");
            }
        });
    }
}



