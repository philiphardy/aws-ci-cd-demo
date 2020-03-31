const pipelineInfoContainer = $('#pipeline-info-container');
const pipelineStatus = $('#pipeline-status');

function isPipelineRunning(data) {
    return !!data.StageStates.find(stageState => stageState.LatestExecution.Status.Value === 'InProgress');
}

function getPipelineInfo() {
    $.getJSON('/api/pipeline')
        .done(data => {
            if (!data) {
                return;
            }

            if (isPipelineRunning(data)) {
                pipelineStatus.text("Running");
                pipelineStatus.addClass("label-success");
                pipelineStatus.removeClass("label-default");
            } else {
                pipelineStatus.text("Idle");
                pipelineStatus.addClass("label-default");
                pipelineStatus.removeClass("label-success");
            }

            const json = JSON.stringify(data, null, 3)
                .replace(/ /g, '&nbsp;')
                .replace(/\n/g, '<br/>');
            pipelineInfoContainer.html(json);
        })
        .fail((xhr, err) => console.error('failed to get pipeline status', err));
}

getPipelineInfo();

setInterval(getPipelineInfo, 5000);
