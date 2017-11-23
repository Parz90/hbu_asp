
/// <reference path="jquery.validate.js" />  
/// <reference path="jquery.validate.unobtrusive.js" />  



$.validator.unobtrusive.adapters.add(
    'containsxor',
    ['value1', 'value2'],
    function (options) {
        options.rules['containsxor2'] = options.params;
        options.messages['containsxor2'] = options.message;
    }
);

jQuery.validator.addMethod('containsxor2', function (value, element, params) {

    var v1 = params['value1'];
    var v2 = params['value2'];

    var v1value = $("body").find('#' + v1).val();
    var v2value = $("body").find('#' + v2).val();


    var i1 = value.indexOf(v1value);
    var i2 = value.indexOf(v2value);

    var retValue = (i1 >= 0 | i2 >=0); 

    return (i1 >= 0 | i2 >= 0); 

}, '');

