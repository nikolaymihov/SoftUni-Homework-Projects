function getInfo() {
    const httpRequest = new XMLHttpRequest();
    const stopIdInput = document.getElementById('stopId');
    const stopNameDiv = document.getElementById('stopName');
    const busesUl = document.getElementById('buses');

    httpRequest.addEventListener('loadend', function() {
        if (httpRequest.status == 200) {
            let busObject = JSON.parse(this.responseText);
            
            stopNameDiv.innerText = busObject.name;

            Object.keys(busObject.buses).forEach(key => { 
                let newLiElement = document.createElement('li');
                newLiElement.innerText = `Bus ${key} arrives in ${busObject.buses[key]} minutes`;

                busesUl.appendChild(newLiElement);
            })

        } else {
            stopNameDiv.innerText = 'Error';
        }

        stopIdInput.value = '';
    });

    const url = `https://judgetests.firebaseio.com/businfo/${stopIdInput.value}.json` ;

    httpRequest.open('GET', url);
    httpRequest.send();
}