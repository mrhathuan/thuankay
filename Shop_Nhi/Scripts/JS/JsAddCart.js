﻿//Set like

toastr.options = {
    "closeButton": true
};

$(document).ready(function () {
    $('.like').off('click').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var aapro = '#aa-product-hvr-content_' + id;
        var like = '#like_' + id;
        $.ajax({
            url: "/Home/SetLike",
            data: { id: id },
            type: "POST",
            dataType: "JSON",
            success: function (res) {
                if (res.status == true) {
                    //$(aapro).removeClass('like').append('<a data-toggle="tooltip" data-placement="top" title="Đã thích"><span class="fa fa-heart"></span></a>')
                    $(like).removeAttr("href");
                    $(like).empty().append('<i class="fa fa-heart"></i>');
                }
            }
        })
    })
});
//get produc
$(document).ready(function () {
    $('.quick-view').off('click').on('click', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        $('#hidProductId').val($(this).data('id'));
        $.ajax({
            url: '/Home/GetProduct',
            data: { id: id },
            type: 'POST',
            dataType: 'JSON',
            success: function (res) {
                var data = res.product;
                var cate = res.category;
                $('#quick-view-modal').modal('show');
                $('.aa-product-view-slider').html('<img class="img-responsive" src="'+data.image+'" />');                
                $('.aa-product-view-content h3').html('' + data.productName);
                $('.aa-product-view-content p').html('' + data.description);
                $('.aa-product-view-price').html('' + addPeriod(data.price) + '<sup><u>đ</u></sup>');
                $('.aa-prod-category').html('Danh mục:' + ' ' + '<a href="/san-pham/' + cate.metatTitle + '-' + cate.ID + '">' + cate.name + '</a>');
                if (data.quantity == null) {                    
                    $('#add-cart-modal').remove();
                }
                
                $('#aa-cart-modal-detail').attr("href", "/chi-tiet/" + data.metatTitle + "-" + data.ID + "");
                
            }
        })
    })
});
//Add cart
$(document).ready(function () {
    toastr.options = {
        "closeButton": true
    };
    $('.aa-add-card-btn').off('click').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);     
        var id = $(this).data('id');
        var btn_id = '.btn-product_' + id;
        $.ajax({
            url: '/Cart/AddCartItem',
            type: 'GET',
            dataType: 'JSON',
            data: { id: id, qty: 1 },
            success: function (res) {
                var html = '';
                var productItem = res.productItem;
                $.each(productItem, function (key, item) {
                    html += '<li id="aa-cartbox-item_' + item.ID + '">';
                    html += '<a class="aa-cartbox-img"><img alt="' + item.productName + '" src="' + item.image + '"/></a>';
                    html += '<div class="aa-cartbox-info">' +
                                        '<h4><a>' + item.productName + '</a></h4>' +
                                        '<p>' + item.quantity + ' x ' + addPeriod(item.price) + ' <sup><u>đ</u></sup></span>' + '</p>' +
                                   '</div>'
                    html += '<a class="aa-remove-product" data-id="' + item.ID + '" href="#"><span class="fa fa-times"></span></a>';
                    html += '</li>'
                });
                $('.aa-cartbox-summary ul').empty().append(html+'<li>'+
                                   ' <span class="aa-cartbox-total-title">'+
                                       ' Tổng tiền  </span>'+                        
                                   ' <span class="aa-cartbox-total-price">'+
                                       addPeriod(res.tongtien)+'<sup><u>đ</u></sup>'+
                                    '</span>'+
                               ' </li>');
                $('.aa-cart-notify').html(res.soluong);                
                $('.aa-cartbox-total-price').empty().append(addPeriod(res.tongtien+'<sup><u>đ</u></sup>'));
                $(btn).empty().append('<i class="fa fa-refresh fa-spin fa-3x fa-fw"></i>');
                $(btn_id).empty().append('<a class="aa-add-card-btn-ok"><span class="fa fa-refresh fa-pulse fa-1x fa-fw"></span> Thêm vào giỏ</a>');
                setTimeout(function () {
                    $(btn_id).empty().append('<a class="aa-add-card-btn-ok" href="/gio-hang"><span class="fa fa-check"></span> Xem giỏ hàng</a>');
                    toastr.success('Thêm sản phẩm vào giỏ thành công', '');
                }, 1300);
               
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    });
});

//Định dạng tiền
function addPeriod(nStr) {
    nStr += '';
    var x = nStr.split(',');
    var x1 = x[0];
    var x2 = x.length > 1 ? ',' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}

//Add detail
$(document).ready(function () {
    $('#AddCartDetail').click(function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var qty = $('#quantity').val();
        if (qty > 0) {
            $.ajax({
                url: '/Cart/AddCartItem',
                data: { id: id, qty: qty },
                type: 'POST',
                dataType: 'JSON',
                success: function (res) {
                    var html = '';
                    var productItem = res.productItem;
                    $.each(productItem, function (key, item) {
                        html += '<li id="aa-cartbox-item_' + item.ID + '">';
                        html += '<a class="aa-cartbox-img"><img alt="' + item.productName + '" src="' + item.image + '"/></a>';
                        html += '<div class="aa-cartbox-info">' +
                                            '<h4><a>' + item.productName + '</a></h4>' +
                                            '<p>' + item.quantity + ' x ' + addPeriod(item.price) + ' <sup><u>đ</u></sup></span>' + '</p>' +
                                       '</div>'
                        html += '<a class="aa-remove-product" data-id="' + item.ID + '" href="#"><span class="fa fa-times"></span></a>';
                        html += '</li>'
                    });
                    $('.aa-cartbox-summary ul').empty().append(html + '<li>' +
                                       ' <span class="aa-cartbox-total-title">' +
                                           ' Tổng tiền  </span>' +
                                       ' <span class="aa-cartbox-total-price">' +
                                           addPeriod(res.tongtien) + '<sup><u>đ</u></sup>' +
                                        '</span>' +
                                   ' </li>');
                    $('.aa-cart-notify').html(res.soluong);
                    $('.aa-cartbox-total-price').empty().append(addPeriod(res.tongtien));
                    $('#btn-detail').empty().append('<a class="btn btn-warning"><span class="fa fa-refresh fa-pulse fa-1x fa-fw"></span> Thêm vào giỏ</a>')
                    setTimeout(function () {
                        $('#btn-detail').empty().append('<a class="btn btn-warning" href="/gio-hang"><span class="fa fa-check"></span> Xem giỏ hàng</a>');
                        toastr.success('Thêm sản phẩm vào giỏ thành công', '');
                    }, 1300);
                   
                },
                error: function () {
                    alert(errormessage.responseText);
                }
            });//End:ajax
        } else {
            toastr.error('Số lượng không đúng', '');           
        }
        
    });
    return false;
});

//Addcart popup
$(document).ready(function () {
    $('#add-cart-modal').off('click').on('click', function (e) {
        e.preventDefault();
        var id = $('#hidProductId').val();
        var qty = $('#quantity').val();
        if (qty > 0) {
            $.ajax({
                url: '/Cart/AddCartItem',
                data: { id: id, qty: qty },
                type: 'POST',
                dataType: 'JSON',
                success: function (res) {
                    if (res.productItem != null) {
                        toastr.success('Thêm sản phẩm vào giỏ thành công', '');
                        setTimeout(function () {
                            location.href = '/';
                        }, 2300);
                    }
                },
                error: function () {
                    alert(errormessage.responseText);
                }
            })
        } else {
            toastr.error('Số lượng không đúng', '');
        }
    });   
});

