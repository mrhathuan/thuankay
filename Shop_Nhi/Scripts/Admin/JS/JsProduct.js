

//Change status
$(document).ready(function () {
    $('.trangthai').off('click').on('click', function (e) {
        e.preventDefault();
        var status = $(this);
        var id = status.data('id');
        $.ajax({
            url: '/Pn/Product/ChangeStatus',
            type: 'POST',
            data: { id: id },
            dataType: 'JSON',
            success: function (res) {
                if (res.status == true) {
                    status.empty().append('<span class="btn btn-success btn-xs">Đã về</span>')
                } else {
                    status.empty().append('<span class=""btn btn-warning btn-xs">Sắp về</span>');
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    });
});


//Xóa
$(document).ready(function () {
    $('.del-pro').off('click').on('click', function (e) {
        e.preventDefault();
        var cf = confirm("Bạn chắc chắn muốn xóa sản phẩm này?");
        var id = $(this).data('id');
        var remove_row = '#row_' + id;
        if (cf) {
            $.ajax({
                url: "/Pn/Product/Delete",
                data: { id: id },
                dataType: "JSON",
                type: "POST",
                success: function (res) {
                    if (res.status == true) {
                        alert("Xóa sản phẩm thành công");
                        $(remove_row).remove();
                    } else {
                        alert("Xóa sản phẩm thất bại");
                    }
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            })
        }
    });
});


//Quản lý ảnh
$(document).ready(function () {
    //
    $('.btn-image').off('click').on('click', function (e) {
        e.preventDefault();                
        $('#hidProductId').val($(this).data('id'));
        var id = $(this).data('id');
        $.ajax({
            url:"/Pn/Product/LoadImages",
            type: "GET",
            data: {id: id},
            dataType:"JSON",
            success: function (res) {
                var data = res.data;
                var html = '';
                if (res.status == true) {
                    $('#imagesManage').modal('show');
                    $.each(data, function (i, item) {
                        html += '<div style="float:left"><img src="' + item + '" width="100" /><a class="btn-delImage" href="#"><i class="glyphicon glyphicon-remove"></i></a></div>';
                    });
                    $('#imageList').html(html);

                    $('.btn-delImage').off('click').on('click', function (e) {
                        e.preventDefault();
                        $(this).parent().remove();
                    });
                } else {
                    $('#imagesManage').modal('show');
                    $('#imageList').empty();
                }
            }
        });
    //
});
//
$('#btnChooImage').off('click').on('click', function () {
    var finder = new CKFinder();
    finder.selectActionFunction = function (url) {
        $('#imageList').append('<div style="float:left"><img src="' + url + '" width="100" /><a class="btn-delImage" href="#"><i class="glyphicon glyphicon-remove"></i></a></div>');

        $('.btn-delImage').off('click').on('click', function (e) {
            e.preventDefault();
            $(this).parent().remove();
        });
    };
    finder.popup();
});
//
$('#btnSaveImage').off('click').on('click', function () {
    var images = [];
    var id = $('#hidProductId').val();
    $.each($('#imageList img'), function (i, item) {
        images.push($(item).prop('src'));
    })

    $.ajax({
        url: "/Pn/Product/SaveImages",
        type: "POST",
    data: {
        id:id,
        images:JSON.stringify(images)
    },
    dataType:"JSON",
    success: function (res) {
        $('#imagesManage').modal('hide');
        $('#imageList').empty();
        alert("Cập nhật ảnh thành công");
    }
})
});
//
});