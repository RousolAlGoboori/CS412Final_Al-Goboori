$(function () {
    $('.blankCustomerElement').on('click', function () {
        $('[id*="customerName"]').val($(this).text());
    });

    $('[id*="customerName"]').on('blur', function () {
        setTimeout(function () {
            EmptyAndHideCustomerList();
        }, 150);
    });

    $('[id*="customerName"]').on('input', function () {
        var userInput = $(this).val();


        if (userInput) {
            var settings = {
                "url": "https://localhost:44305/api/booking/customers/names/" + userInput,
                "method": "GET",
                "timeout": 0,
                "headers": {
                    "APIKEY": "abcd",
                    "Content-Type": "application/json"
                },
                "data": JSON.stringify({
                    "booking": {
                        "CustomerName": "Teba Ahmed",
                        "From": "Chi",
                        "To": "Tex",
                        "DepartDate": "2021-08-1",
                        "ReturnDate": "2021-11-1",
                        "UserById": "1"
                    },
                    "tripIds": [
                        1
                    ]
                }),
            };

            $.ajax(settings)
                .done(function (response) {
                    if (response.length > 0) {
                       
                        SetCustomerList(response);
                    } else {
                       
                        EmptyAndHideCustomerList()
                    }
                })
                .fail(function (response) {
                   
                    EmptyAndHideCustomerList()
                });
           
           
        } else {
            
            EmptyAndHideCustomerList()
        }
    });
    function SetCustomerList(arr) {
        var customerSearchObject = $('[id*="CustomerSearch"]');
        var customerList = customerSearchObject.find('[id*="CustomerList"]');
        var blankCustomer = customerSearchObject.find('[id*="BlankCustomer"]');

        customerList.empty();

        arr.forEach(s => {
            var theClone = blankCustomer.clone(true);

            theClone.prop('id', 'newCustomer');
            theClone.removeClass('d-none');
            theClone.text(s);
            theClone.appendTo(customerList);
        });

        if (arr.length > 0) {
            customerSearchObject.removeClass('d-none');
            blankCustomer.addClass('d-none');
        } else {
            
            EmptyAndHideCustomerList()
        }
    }

    function EmptyAndHideCustomerList() {
        var customerSearchObject = $('[id*="CustomerSearch"]');
        var customerList = customerSearchObject.find('[id*="CustomerList"]');
        customerList.empty();
        customerSearchObject.addClass('d-none');
    }
  });
