function PrintEveryNthElement(inputArr){
    let step = Number(inputArr.pop());

    for (let i = 0; i < inputArr.length; i+=step) {
        console.log(inputArr[i]);
    }
}

PrintEveryNthElement(['5', '20', '31', '4', '20', '2']);

PrintEveryNthElement(['dsa','asd', 'test', 'tset', '2']);

PrintEveryNthElement(['1', '2','3', '4', '5', '6']);