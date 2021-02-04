function RotateArray(inputArr){  
    let numberOfRotations = Number(inputArr.pop()),
        numberOfRealRotations = numberOfRotations % inputArr.length;

    for (let index = 1; index <= numberOfRealRotations; index++){
        inputArr.unshift(inputArr.pop());
    }

    console.log(inputArr.join());
}

RotateArray(['1', '2', '3', '4', '2']);

RotateArray(['Banana', 'Orange', 'Coconut', 'Apple', '15']);