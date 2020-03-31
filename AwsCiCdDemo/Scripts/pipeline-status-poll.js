const pipelineInfoContainer = $('#pipeline-info-container');

function getPipelineInfo() {
    $.getJSON('/api/pipeline')
        .done(data => {
            if (!data) {
                return;
            }
            const json = JSON.stringify(data, null, 3)
                .replace(/ /g, '&nbsp;')
                .replace(/\n/g, '<br/>');
            console.log(json);
            pipelineInfoContainer.html(json);
        })
        .fail((xhr, err) => console.error('failed to get pipeline status', err));
}

getPipelineInfo();

setInterval(getPipelineInfo, 5000);
