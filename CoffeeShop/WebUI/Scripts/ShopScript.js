function CalculateQuantity() {
    $.ajax({
        //url: '@Url.Action("CalculateQuantity", "OrderFlavor")',
        url: '/OrderFlavor/CalculateQuantity',        
        cache: false
    }).done(function (data) {
        $('#order-flavor-quantity').text(data);
    }).fail(function () {
        alert('При выполенении запроса (количество материалов) произошла ошибка!');
    });
};