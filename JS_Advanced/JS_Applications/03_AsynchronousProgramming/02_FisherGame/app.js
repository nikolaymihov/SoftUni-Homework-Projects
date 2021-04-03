function attachEvents() {
    const baseURL = 'https://fisher-game.firebaseio.com/catches';
    const addForm = document.getElementById('addForm');
    const catchesDiv = document.getElementById('catches');
    const template = catchesDiv.children[0];

    class Catch {
        constructor(angler, weight, species, location, bait, captureTime) {
            this.angler = angler;
            this.weight = weight;
            this.species = species;
            this.location = location;
            this.bait = bait;
            this.captureTime = captureTime;
        }
    }

    const buttonsFunctionality = {
        Add: () => addCatch(),
        Load: () => loadCatch(),
        Update: (btn) => updateCatch(btn),
        Delete: (btn) => deleteCatch(btn)
    }

    document.getElementsByTagName('body')[0].addEventListener('click', function (e) {
        if (typeof buttonsFunctionality[e.target.textContent] === 'function') {
            buttonsFunctionality[e.target.textContent](e.target);
        }
    });

    function addCatch() {
        const values = getValuesFromInputForm(addForm);
        const catchToAdd = new Catch(...values);

        const url = `${baseURL}.json`;

        fetch(url, { 
                method: 'POST', 
                body: JSON.stringify(catchToAdd) 
        }).then(handleErrors)
          .then(res => res.json())
          .catch(console.error);

        loadCatch();
    }

    async function updateCatch(btn) {
        const idToUpdate = btn.parentNode.getAttribute('data-id');
        const values = getValuesFromInputForm(btn.parentNode);
        const catchToUpdate = new Catch(...values);

        const url = `${baseURL}/${idToUpdate}.json`;

        await fetch(url, { 
                method: 'PUT', 
                body: JSON.stringify(catchToUpdate) 
        }).then(handleErrors)
          .then(res => res.json())
          .catch(console.error);

        loadCatch();
    }

    async function deleteCatch(btn) {
        const idToDelete = btn.parentNode.getAttribute('data-id');
        
        const url = `${baseURL}/${idToDelete}.json`;

        await fetch(url, { method: 'DELETE' })
            .then(handleErrors)
            .then(res => res.json())
            .catch(console.error);
        
        loadCatch();
    }

    function loadCatch() {
        const url = `${baseURL}.json`;
        
        fetch(url, { method: 'GET' })
            .then(handleErrors)
            .then(res => res.json())
            .then(extractData)
            .catch(console.error);
    }

    function getValuesFromInputForm(element) {
        return Array
            .from(element.getElementsByTagName('input'))
            .reduce((arr, input) => {
                arr.push(input.value);
                return arr;
            }, []);
    }

    function extractData(data) {
        catchesDiv.innerHTML = '';

        Object.keys(data).forEach(code => {
            fillInfo(code, data[code]);
        });
    }

    function fillInfo(code, obj) {
        let domElement = template.cloneNode(true);

        domElement.setAttribute('data-id', code);

        Array.from(domElement.children).map(el => {
            if (el.tagName === 'INPUT') {
                el.value = obj[el.className];
            }
        })

        catchesDiv.appendChild(domElement);
    }

    function handleErrors(res){
        if(!res.ok){
            throw new Error(`${res.status} - ${res.statusText}`);
        }

        return res;
    }
}

attachEvents();