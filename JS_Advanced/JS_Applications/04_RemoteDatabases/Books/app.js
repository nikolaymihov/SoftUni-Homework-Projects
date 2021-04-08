window.addEventListener('load', () => { 
    const baseUrl = 'https://books-f6ec9-default-rtdb.firebaseio.com';
    const tableElement = document.querySelector('table');
    const loadBooksButton = document.getElementById('loadBooks');
    const formElement = document.querySelector('form');
    const submitButton = document.querySelector('form > button');
    const titleInputElement = document.getElementById('title');
    const authorInputElement = document.getElementById('author');
    const isbnInputElement = document.getElementById('isbn');

    loadBooks(baseUrl);

    loadBooksButton.addEventListener('click', () => {
        loadBooks(baseUrl);
    });

    submitButton.addEventListener('click', function(e) {
        e.preventDefault();

        if (!titleInputElement.value || !authorInputElement.value || !isbnInputElement.value) {
            alert('Please fill all fields!');
            return;
        } 

        let newBook = {
            title : titleInputElement.value,
            author : authorInputElement.value,
            isbn : isbnInputElement.value
        }
        
        addBook(baseUrl, newBook);

        titleInputElement.value = '';
        authorInputElement.value = '';
        isbnInputElement.value = '';
    });

    tableElement.addEventListener('click', function(e) {        
        if (e.target.textContent === 'Edit') {
            const clickedBookId = e.target.parentNode.parentNode.getAttribute('id');
            let clickedBookArgs = Array.from(e.target.parentNode.parentNode.children);

            editBook(clickedBookId, clickedBookArgs, formElement, baseUrl);
        }
        
        if (e.target.textContent === 'Delete') {
            const clickedBookId = e.target.parentNode.parentNode.getAttribute('id');
            
            deleteBook(clickedBookId, baseUrl);
        }
    });
});

function loadBooks(url) {
    const tableBody = document.querySelector('table > tbody');
    tableBody.innerHTML = '';

    fetch(`${url}/books.json`)
        .then(res => res.json())
        .then(data => {
            Object.keys(data).forEach((key) => {
                const newBookRow = createBookRow(key, data[key]);
                tableBody.appendChild(newBookRow);
            }); 
        });
}

function addBook(url, bookObj) {
    fetch(`${url}/books.json`, { 
        method: 'POST', 
        body: JSON.stringify(bookObj) 
    })
      .then(alert('The newly created book was added successfully!'))
      .catch(err => {
          alert(err);
      });
}

function editBook(bookId, bookArgs, form, url) {
    const submitButton = form.querySelector('button');
    submitButton.style.display = 'none';

    const inputFields = Array.from(form.getElementsByTagName('input'));
    const titleInput = inputFields[0]; 
    const authorInput = inputFields[1];
    const isbnInput = inputFields[2];

    titleInput.value = bookArgs[0].innerText;
    authorInput.value = bookArgs[1].innerText;
    isbnInput.value = bookArgs[2].innerText;

    const saveButton = createElement('button', 'Save');
    saveButton.style.display = 'inline-block';
    const cancelButton = createElement('button', 'Cancel');
    cancelButton.style.display = 'inline-block';
    form.append(saveButton,cancelButton);

    saveButton.addEventListener('click', function(e) {
        e.preventDefault();
        
        if (!titleInput.value || !authorInput.value || !isbnInput.value) {
            alert('Please fill all fields!');
        } else {
            let editedBook = {
                title: titleInput.value,
                author: authorInput.value, 
                isbn: isbnInput.value
            }

            fetch(`${url}/books/${bookId}.json`, { 
                method: 'PUT', 
                body: JSON.stringify(editedBook) 
            }).then(() => {
                titleInput.value = '';
                authorInput.value = '';
                isbnInput.value = '';
                
                saveButton.style.display = 'none';
                cancelButton.style.display = 'none';
                submitButton.style.display = 'block';
                
                alert('The book was edited successfully!');
            })
              .catch(err => {
                  alert(err);
              });
            
        }
    });
}

function deleteBook(bookId, url) {
    fetch(`${url}/books/${bookId}.json`, { 
        method: 'DELETE'
    }).then(alert('The book was deleted successfully!'))
      .catch(err => {
        alert(err);
    });
}

function createBookRow(id,bookObj) {
    const bookRowElement = createElement('tr');
    bookRowElement.setAttribute('id', id);
    const titleDataElement = createElement('td', bookObj.title);
    const authorDataElement = createElement('td', bookObj.author);
    const isbnDataElement = createElement('td', bookObj.isbn);
    const buttonsDataElement = createElement('td');
    const editButtonElement = createElement('button', 'Edit');
    const deleteButtonElement = createElement('button', 'Delete');

    buttonsDataElement.append(editButtonElement, deleteButtonElement);
    bookRowElement.append(titleDataElement, authorDataElement, isbnDataElement, buttonsDataElement);

    return bookRowElement;
}

function createElement(type, text, classNames) {
    const element = document.createElement(type);
    
    if (text) {
        element.innerText = text;
    }
    
    if (classNames) {
        element.classList.add(...classNames);
    }

    return element;
}