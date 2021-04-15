const baseUrl = 'https://furniture-store-b05e3-default-rtdb.firebaseio.com';

const createForm = document.getElementById('create-form');
const makeInput = createForm.querySelector('#new-make');
const modelInput = createForm.querySelector('#new-model');
const yearInput = createForm.querySelector('#new-year');
const descriptionInput = createForm.querySelector('#new-description');
const priceInput = createForm.querySelector('#new-price');
const imageInput = createForm.querySelector('#new-image');
const materialInput = createForm.querySelector('#new-material');

const routes = {
    'home' : document.getElementById('home-section'),
    'create' : document.getElementById('create-section'),
    'details' : document.getElementById('details-section'),
    'profile' : document.getElementById('profile-section')
}

const router = (pathname) => {
    let [path, id] = pathname.split('/').filter(x => x);

    //Hide all sections
    Object.values(routes).forEach(section => section.style.display = 'none');

    //Show only the desired specific section
    routes[path].style.display = 'block';

    switch (path) {
        case 'home':
            renderHomePage();
            break;
        case 'details':
            renderDetailsPage(id);
            break;
    }
};

document.querySelector('nav').addEventListener('click', onRouteChange);

createForm.addEventListener('submit', onCreateSubmit);

function onRouteChange(e) {
    if (e.target.tagName != 'A') {
        return;
    }
    
    e.preventDefault();

    let url = new URL(e.target.href);

    redirect(url.pathname);
}

function onCreateSubmit(e) {
    e.preventDefault();

    let make = makeInput.value;
    let model = modelInput.value;
    let year = yearInput.value;
    let description = descriptionInput.value;
    let price = priceInput.value;
    let image = imageInput.value;
    let material = materialInput.value;

    let newFurniture = {
        make,
        model,
        year,
        description,
        price,
        image,
        material
    }

    fetch(`${baseUrl}/furnitures.json`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(newFurniture)
    })
        .then(res => res.json())
        .then(data => {
            makeInput.value = '';
            modelInput.value = '';
            yearInput.value = '';
            descriptionInput.value = '';
            priceInput.value = '';
            imageInput.value = '';
            materialInput.value = '';   
            
            redirect('home');
        });
}

function redirect(path) {
    history.pushState({}, '', path);

    router(path);
}

function renderHomePage() {
   let furnituresListElement = document.getElementById('furniture-list');
   
    //Get all furnitures
    fetch(`${baseUrl}/furnitures.json`)
        .then(res => res.json())
        .then(data => {
            //Use template to render
            let furnituresHtml = Object.keys(data).map(key => furnitureItemTemplate(key, data[key])).join('');

            //Append to DOM
            furnituresListElement.innerHTML = furnituresHtml;
        });
}

function renderDetailsPage(id) {
    fetch(`${baseUrl}/furnitures/${id}.json`)
        .then(res => res.json())
        .then(furnitureObj => {
            let detailsView = document.getElementById('details-view');
            let detailsImageDiv = document.querySelector('div#details-section div.image-container');

            detailsImageDiv.innerHTML = `<img src="${furnitureObj.image}" />`;

            detailsView.innerHTML = `
                <p>Make: ${furnitureObj.make}</p>
                <p>Model: ${furnitureObj.model}</p>
                <p>Year: ${furnitureObj.year}</p>
                <p>Description: ${furnitureObj.description}</p>
                <p>Price: ${furnitureObj.price}</p>
                <p>Material: ${furnitureObj.material}</p>
            `;
        })
}

//Adding it here as well in order to work after reload, 
//because on reload the nav section click event listener is not triggered
router(location.pathname);