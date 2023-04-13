$(document).ready(function () {
    ShowCount();
    $('body').on('click', '.btnAddToCart', function (e) {
        e.preventDefault();
        var id = $(this).data('id');
        var quatity = 1;
        var tQuantity = $('#quantity_value').text();
        if (tQuantity != '') {
            quatity = parentInt(tQuantity);
        }
        $.ajax({
            url: '/shoppingcart/addtocart',
            type: 'POST',
            data: { id: id, quantity: quatity },
            success: function (rs) {
                if (rs.Success) {
                    $('#checkout_items').html(rs.Count);
                    alert(rs.msg);
                }
            }
        });
    }); 
    //$('body').on('click', '.btnUpdate', function (e) {
    //    e.preventDefault();
    //    var id = $(this).data("id");
       
    //    var quantity = $('#Quantity_' + id).val();
    //    Update(id, quantity);


       
    //});
});

function ShowCount() {
    $.ajax({
        url: '/shoppingcart/ShowCount',
        type: 'GET',
        
        success: function (rs) {
            $('#checkout_items').html(rs.Count);
 
        }
    });
}
function LoadCard (){
    $.ajax({
        url: '/shoppingcart/Partial_Item_Cart',
        type: 'GET',
        success: function (rs) {
            $('#load_data').html(rs);

        }
    });
}
function Update(id,quantity) {
    $.ajax({
        url: '/shoppingcart/Update',
        type: 'POST',
        data: {id:id ,quantity:quantity},
        success: function (rs) {
            if (rs.Success) { LoadCard(); }
           
        }
    });
}

