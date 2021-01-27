function CheckIfAllNumsAreEqual(number){
    let areEqualFlag = true,
        sum = 0,
        numbers = Array.from(String(number), Number);
        lastCheckedNum = numbers[0];

    numbers.forEach(element => {
        if (element !== lastCheckedNum && areEqualFlag){
            areEqualFlag = false;
        }

        sum += element;

        lastCheckedNum = element;
    });

    return `${areEqualFlag}\n${sum}`;
}

console.log(CheckIfAllNumsAreEqual(2222222));

console.log(CheckIfAllNumsAreEqual(1234));