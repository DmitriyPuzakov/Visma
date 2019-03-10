$(document).ready(() => {
    $("#process").click(() => {
        var shortNumber = $("#shortNumber").val();
        
        $.ajax({
            url:"/App/Process",
            type:"POST",
            data: {
                shortNumber: shortNumber
            },
            dataType:"json",
            success:(resp) => {
                $("#longAccountNumber").val(resp.LongNumber);
                $("#checkDigitValid").val(resp.CheckDigitValid);
                $("#status").val(resp.Status);
            }
        });
    })
});