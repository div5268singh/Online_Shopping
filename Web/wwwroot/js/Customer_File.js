$(document).ready(function () {
    ShowCustomerData();
    RoleDropDown()
});

function RoleDropDown() {
    debugger
    $.ajax({
        type: "Get",
        url: "/Login/GetRoleList",
        contentType: "application/json",
        success: function (data) {
            $("#RoleId").html("");
            $("#RoleId").append("<option value=''>" + "Select Role Name" + "</option > ")
            for (var i = 0; i < data.legth; i++) {
                $("#RoleId").append("<option value=" + data[i].roleId + ">" + data[i].roleName + "</option")
            }
        }
    });
}

// Show Product List 

function ShowCustomerData() {
    debugger
    $.ajax({
        url: '/Customer/CustomerList',
        type: 'Get',
        dataType: 'json',
        /*contentType: 'application/x-www-form-urlencoded; charset=UTF-8',*/
        contentType: 'application/json; charset=UTF-8',
        success: function (data) {
            debugger;
            var object = '';
            $.each(data, function (index, item) {
                object += '<tr>';
                object += '<td>' + item.customerId + '</td>';
                object += '<td>' + item.roleId + '</td>';
                object += '<td>' + item.customerName + '</td>';
                object += '<td>' + item.phone + '</td>';
                object += '<td>' + item.address + '</td>';
                object += '<td>' + item.city + '</td>';
                object += '<td>' + item.postalCode + '</td>';
                object += '<td>' + item.country + '</td>';
                object += '<td><img src="/Images/Customers/' + item.photo + '"height="40" width="50"></td>';
                object += '<td>' + item.email + '</td>';
                object += '<td>' + item.password + '</td>';
                object += '<td><a herf="#" class="btn btn-primary" onclick="Edit(' + item.customerId + ')"><i class="far fa-edit"></i></a> || <a herf="#" class="btn btn-danger" onclick="Delete(' + item.customerId + ')"><i class="fas fa-trash-alt"></i></a> </td>';
                object += '</tr>';
            });
            $('#table_data').html(object);
        },
        error: function () {
            alert("Data con not get");
        }
    })
}

$('#btnAddCustomer').click(function () {
    $('#CustomerModel').modal('show');
});


$("#AddCustomer").click(function (e) {
    debugger;
    e.preventDefault();
    var fdata = new FormData();

    var fileInput = $('#PhotoPath')[0];
    var file = fileInput.files[0];
    fdata.append("PhotoPath", file);

    $("form input[type='text']").each(function (x, y) {
        fdata.append($(y).attr("name"), $(y).val());
    });

    var value = $('select#RoleId option:selected').val();
    fdata.append("RoleId",value)

    $.ajax({
        url: '/Customer/AddCustomer',
        type: 'Post',
        contentType: false,
        processData: false,
        data: fdata,
        success: function () {
            swal({
                title: 'Customer Added Successfuly',
                text: '',
                type: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#DD6B55',
                confirmButtonText: 'Yes!'
            })

            ClearTextBox();
            ShowCustomerData();
            HideModelPopup();
        },
        error: function () {
            alert("Record can not Added !");
        }
    });
});

// ------- Get Edit ------------

function Edit(CustomerId) {
    debugger
    $.ajax({
        url: '/Customer/GetCustomerById?CustomerId=' + CustomerId,
        type: 'Get',
        contentType: 'application/x-www-form-urlencoded',
        dataType: 'json',
        success: function (response) {
            $('#CustomerModel').modal('show');
            $('#CustomerId').val(response.customerId);
            $('#RoleId').val(response.roleId);
            $('#CustomerName').val(response.customerName);
            $('#Phone').val(response.phone);
            $('#Address').val(response.address);
            $('#City').val(response.city);
            $('#PostalCode').val(response.postalCode);
            $('#Country').val(response.country);
            $('#PhotoPath').val(response.photoPath);
            $('#Email').val(response.email);
            $('#Password').val(response.password);
            $('#AddCustomer').css('display', 'none');
            $('#UpdateCustomer').css('display', 'block');
        },
        error: function () {
            alert("Record can not find");
        }

    });
}

$("#UpdateCustomer").click(function (e) {
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
        url: '/Customer/UpdateCustomer',
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
            ShowCustomerData();
            HideModelPopup();
        },
        error: function () {
            alert("Record can not Updated !");
        }
    });
});

function Delete(CustomerId) {
    debugger
    if (confirm('Are you sure, You want to delete this record ?')) {
        $.ajax({
            url: '/Customer/DeleteCustomer?CustomerId=' + CustomerId,
            success: function () {
                swal({
                    title: 'Data Deleted Successfuly',
                    text: '',
                    type: 'warning',
                    showCancelButton: true,
                    confirmButtonColor: '#DD6B55',
                    confirmButtonText: 'Yes!'
                })

                ShowCustomerData();
            },
            error: function () {
                alert("Record can not Deleted");
            }
        });
    }
}

// ---------


