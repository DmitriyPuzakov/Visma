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
                console.log(resp);
            }
        });
    })
});