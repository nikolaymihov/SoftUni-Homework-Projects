function attachEvents() {
    const httpRequest = new XMLHttpRequest();
    const phonebookUlElement = document.getElementById('phonebook');
    const loadButton = document.getElementById('btnLoad');
    const createButton = document.getElementById('btnCreate');
    const personInputElement = document.getElementById('person');
    const phoneInputElement = document.getElementById('phone');

    const getAndPostURL = 'https://phonebook-nakov.firebaseio.com/phonebook.json';

    createButton.addEventListener('click', function() {
        let person = personInputElement.value;
        let phone = phoneInputElement.value;
        
        httpRequest.open('POST', getAndPostURL);
        httpRequest.send(JSON.stringify({ person, phone }));
        
        personInputElement.value = '';
        phoneInputElement.value = '';   

        getContacts();
    });

    loadButton.addEventListener('click', getContacts);

    function getContacts() {
        httpRequest.addEventListener('loadend', function() {
            phonebookUlElement.innerHTML = ''; 
            
            if (this.status === 200) {

                let phonebookData = JSON.parse(this.responseText);
            
                Object.keys(phonebookData).forEach((key) => {
                    let currentObject = phonebookData[key];
                    
                    let listItem = document.createElement('li');
                    listItem.textContent = `${currentObject.person}: ${currentObject.phone}`;
                    
                    let deleteButton = document.createElement('button'); 
                    deleteButton.textContent = 'Delete';

                    listItem.appendChild(deleteButton);
                    phonebookUlElement.appendChild(listItem);

                    deleteButton.addEventListener('click', function() {
                        let deleteURL = `https://phonebook-nakov.firebaseio.com/phonebook/${key}.json`;
                        
                        httpRequest.open('DELETE', deleteURL);
                        httpRequest.send();
                    });
                });
            }
        });

        httpRequest.open('GET', getAndPostURL);
        httpRequest.send();
    }
}

attachEvents();