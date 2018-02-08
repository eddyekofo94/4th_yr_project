@*@functions {*@
@*    public object ViewData { get; set; }*@
@*}*@
@{
    ViewData[$"" + $"Title"] = "Message";
}

<h2>Messages</h2>
<div class="container">
    <input type="button" id="getValues" value="Send" />
    <ul id="discussion"></ul>
    </div>
@*<div id="chat">*@
@*    <form id="frm-send-message" action="#">*@
@*        <label for="message">Message:</label>*@
@*        <input type="text" id="message" />*@
@*        <input type="submit" id="send" value="Send" />*@
@*    </form>*@
@*    <div class="clear">*@
@*    </div>*@
@*    <ul id="messages"></ul>*@
@*</div>*@
<script src="~/js/signalr-client-1.0.0-alpha2-final.min.js"></script>

    <script type="text/javascript">
var transport = signalR.TransportType.WebSockets;
var connection = new signalR.HubConnection('http://${document.location.host}/notifications', { transport: transport });
var button = document.getElementById("getValues");
connection.on('updateStuff', (value) => {
    var liElement = document.createElement('li');
liElement.innerHTML = 'Someone caled a controller method with value: ' + value;
document.getElementById('discussion').appendChild(liElement);
});
button.addEventListener("click", event => {
    fetch("http://localhost:5000//api/Chat/")
.then(function (data) {
    console.log(data);
})
    .catch(function (error) {
        console.log(err);
    });
});
connection.start();
</script>