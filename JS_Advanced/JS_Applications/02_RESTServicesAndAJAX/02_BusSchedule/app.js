function solve() {
    const httpRequest = new XMLHttpRequest();
    const departButtonElement = document.getElementById('depart');
    const arriveButtonElement = document.getElementById('arrive');
    const infoSpanElement = document.querySelector('.info');
    
    let scheduleData = { next: 'depot'};
    
    function depart() {
        httpRequest.addEventListener('loadend', function() {
            if (httpRequest.status < 300) {
                scheduleData = JSON.parse(this.responseText);
                
                infoSpanElement.innerText = `Next stop ${scheduleData.name}`;
                departButtonElement.disabled = true;
                arriveButtonElement.disabled = false;
    
            } else {
                infoSpanElement.innerText = 'Error';
                departButtonElement.disabled = true;
                arriveButtonElement.disabled = true;
            }
        });

        const url = `https://judgetests.firebaseio.com/schedule/${scheduleData.next}.json`;

        httpRequest.open('GET', url);
        httpRequest.send();
    }

    function arrive() {
        infoSpanElement.innerText = `Arriving at ${scheduleData.name}`;
        departButtonElement.disabled = false;
        arriveButtonElement.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();