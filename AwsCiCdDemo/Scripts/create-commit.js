const textarea = document.getElementById('commit-msg-txt');

document.getElementById('commit-btn').addEventListener('click', () => {
    $.ajax({
        url: '/api/commits',
        contentType: 'application/json',
        data: JSON.stringify({ commitMsg: textarea.value }),
        method: 'POST',
    })
        .done(() => console.log("success!"))
        .fail(() => console.error("Failed to start build"));
});