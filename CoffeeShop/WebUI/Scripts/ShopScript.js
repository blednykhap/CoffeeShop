function CalculateQuantity() {
    $.ajax({
        //url: '@Url.Action("CalculateQuantity", "OrderFlavor")',
        url: '/CurrentOrder/CalculateQuantity',        
        cache: false
    }).done(function (data) {
        $('#order-flavor-quantity').text(data);
    }).fail(function () {
        alert('При выполенении запроса (количество материалов) произошла ошибка!');
    });
    //$.validator.unobtrusive.parse();
    $("form").removeData("validator");
    $("form").removeData("unobtrusiveValidation");
    $.validator.unobtrusive.parse("form");
};

$(document).ajaxStart(function () {
    
    $("body").append("<div id='loading' style='position:absolute;top:50%;left:50%;width:100px;text-align:center;'> <img src='/Images/Loades/RoundLoader.gif'/></div>");
    
});

$(document).ajaxStop(function () {
    $("body").children("#loading").remove();
});