const textarea = $('#commit-msg-txt');

$('#commit-btn').click(() => {
    $.ajax({
        url: '/api/commits',
        contentType: 'application/json',
        data: JSON.stringify({ commitMsg: textarea.value }),
        method: 'POST',
    })
        .done(() => console.log("success!"))
        .fail(() => console.error("Failed to start build"));
});