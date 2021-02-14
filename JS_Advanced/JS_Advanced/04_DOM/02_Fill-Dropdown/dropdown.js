function addItem() {
    let inputTextElement = document.getElementById("newItemText");
    let inputValueElement = document.getElementById("newItemValue");

    var newOption = document.createElement('option');

    newOption.textContent = inputTextElement.value;
    newOption.value = inputValueElement.value; 

    document.getElementById("menu").appendChild(newOption);

    inputTextElement.value = '';
    inputValueElement.value = '';
}