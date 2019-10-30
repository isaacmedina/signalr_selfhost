$(function () {
    //Set the hubs URL for the connection
    $.connection.hub.url = "http://localhost:8020/signalr";

    // Declare a proxy to reference the hub.
    var cnnVessel = $.connection.vesselHub;

    $.connection.hub.start(function () {
        var group = $('#groupList').val();
        cnnVessel.server.join(group);
        cnnVessel.lastGroup = group;
    });

    $('#btnConenct').click(function () {
        $('#message').text('Connecting to ' + $('#groupList').val() + ' ...');
        setTimeout(function () {
            if ($.connection.hub.state === 1) {
                var group = $('#groupList').val();
                cnnVessel.server.removeGroup(cnnVessel.lastGroup);
                cnnVessel.server.join(group);
                cnnVessel.lastGroup = group;
            } else {
                connect()
            }
        }, 1000)

    });

    function connect() {
        $.connection.hub.start().done(function () {
            $('#message').text('Done!');
        });
    }

    // Create a function that the hub can call to broadcast messages.
    cnnVessel.client.addMessage = function (message) {
        console.log('Notification received for group ' + $('#groupList').val() + ' at time ' + new Date().toJSON());
        var data = JSON.parse(message);
        grid.store.objectStore.data = JSON.parse(data).Data;
        //grid.store.query({ id: '*' }).forEach(function (item) {
        //    debugger;
        //    grid.store.remove(item.Seq);
        //});

        //data.Data.foEach(item => {
        //    debugger;
        //    grid.store.put(item);
        //});

    }
});