"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/RoomHub").build();

connection.start().then(function () {
    alert('連線成功');
}).catch(function (err) {
    return console.error(err.toString());
});

//

