function IsMagic(inputMatrix){
    let isMagicFlag = true;

    for (let row = 0; row < inputMatrix.length; row++) {
        let sumOfRow = 0,
            sumOfCol = 0;

        for (let col = 0; col < inputMatrix[row].length; col++){
            sumOfRow += inputMatrix[row][col];
            sumOfCol += inputMatrix[col][row];
        }

        if (sumOfRow !== sumOfCol) {
            isMagicFlag = false;
            break;
        }
    }

    console.log(isMagicFlag);
}

IsMagic([[4, 5, 6], [6, 5, 4], [5, 5, 5]]);

IsMagic([[11, 32, 45], [21, 0, 1], [21, 1, 1]]);

IsMagic([[1, 0, 0], [0, 0, 1], [0, 1, 0]]);