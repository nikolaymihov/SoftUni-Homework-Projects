function solve() {
    let selectMenuTo = document.getElementById('selectMenuTo');

    let valuesToAppend = ['binary', 'hexadecimal'];
    let labelsToAppend = ['Binary', 'Hexadecimal'];

    for (let i = 0; i < valuesToAppend.length; i++) {
        selectMenuTo.insertAdjacentHTML('beforeend', 
            `<option value="${valuesToAppend[i]}">${labelsToAppend[i]}</option>`
        );
    }

    document.getElementsByTagName('button')[0].addEventListener('click', () => {
        let result = document.getElementById('result');
        let inputElement = document.getElementById('input');
        let inputNumber = Number(inputElement.value);

        if (selectMenuTo.value === 'binary'){
            result.value = (inputNumber >>> 0).toString(2);;
        } else if (selectMenuTo.value === 'hexadecimal'){
            result.value = inputNumber.toString(16).toUpperCase();
        } else {
            result.value = 'NaN';
        }

        inputElement.value = '';
    });
}