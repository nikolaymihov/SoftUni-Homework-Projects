function solve() {
    const inputField = document.getElementsByTagName('input')[0];
    
    let listElements = document.getElementsByTagName('li');
 
    document
        .getElementsByTagName('button')[0]
        .addEventListener('click', () => {
            let name = inputField.value;
 
            if (name) {
                let firstLetter = name[0].toLocaleUpperCase();
                let index = firstLetter.charCodeAt(0) - 65; //char A is the 65th character in the ASCII table
                name = firstLetter + name.slice(1).toLocaleLowerCase();
 
                if (listElements[index].innerHTML.length <= 0) {
                    listElements[index].innerHTML += name;
                } else {
                    listElements[index].innerHTML += ', ' + name;
                }
 
                inputField.value = '';
            }
        });
}