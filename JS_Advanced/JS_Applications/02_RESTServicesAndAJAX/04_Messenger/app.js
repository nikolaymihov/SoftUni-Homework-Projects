function attachEvents() {
    const httpRequest = new XMLHttpRequest();
    const textAreaElement = document.getElementById('messages');
    const authorInputElement = document.getElementById('author');
    const messageInputElement = document.getElementById('content');
    const sendButton = document.getElementById('submit');
    const refreshButton = document.getElementById('refresh');

    const url = 'https://rest-messanger.firebaseio.com/messanger.json';

    sendButton.addEventListener('click', function() {
        let author = authorInputElement.value;
        let content = messageInputElement.value;
        
        httpRequest.open('POST', url);
        httpRequest.send(JSON.stringify({ author, content }));
        
        authorInputElement.value = '';
        messageInputElement.value = '';
    });

    refreshButton.addEventListener('click', function() {
        httpRequest.addEventListener('loadend', function() {
            textAreaElement.innerText = '';
            
            if (this.status === 200){
                let messages = JSON.parse(this.responseText);

                let counter = 0;

                Object.keys(messages).forEach((key) => {
                    let currentObject = messages[key];

                    if (counter > 0){
                        textAreaElement.textContent += '\n';
                    }

                    textAreaElement.textContent += `${currentObject.author}: ${currentObject.content}`
                    counter++;
                });
            }
        });
        
        httpRequest.open('GET', url);
        httpRequest.send();
    });
}

attachEvents();