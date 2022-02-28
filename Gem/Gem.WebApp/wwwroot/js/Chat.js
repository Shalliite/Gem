"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;
let temp = 0;
connection.on("ReceiveMessage", function (user, message) {
    var li = document.createElement("li");
    
    document.getElementById("messagesList").appendChild(li);
    
    temp++;
    if (temp > 3) {
        document.getElementById('messagesList').removeChild(document.getElementById('messagesList').getElementsByTagName('li')[0]);
    }

    //document.getElementById("messagesList").insertBefore(li);
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you 
    // should be aware of possible script injection concerns.
    li.textContent = `${user}: ${message}`;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});