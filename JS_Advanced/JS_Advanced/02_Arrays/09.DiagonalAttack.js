function CheckTheSumOfTheDiagonals(inputArr){
    let inputAsMatrix = [];
    
    inputArr.forEach((stringRow, index) => {
        inputAsMatrix[index] = stringRow.split(' ').map(num => Number(num));
    });
    
    let firstDiagonalSum = CalculateSumOfTheFirstDiagonal(inputAsMatrix),
        secondDiagonalSum = CalculateSumOfTheSecondDiagonal(inputAsMatrix);

    if (firstDiagonalSum === secondDiagonalSum){
        for (let row = 0; row < inputAsMatrix.length; row++) {
           for (let col = 0; col < inputAsMatrix.length; col++) {
               if ((row != col) && (row != inputAsMatrix.length-1-col)){
                   inputAsMatrix[row][col] = firstDiagonalSum;
               }
           } 
        }
    }

    PrintMatrix(inputAsMatrix);
}

function CalculateSumOfTheFirstDiagonal(matrix){
    let sum = 0;
    
    for (let i = 0; i < matrix.length; i++) {
        sum += matrix[i][i];
    }

    return sum;
}

function CalculateSumOfTheSecondDiagonal(matrix){
    let sum = 0;
    
    for (let i = 0; i < matrix.length; i++) {
        sum += matrix[i][matrix.length-1-i];
    }

    return sum;
}

function PrintMatrix(matrix){
    matrix.forEach(row => {
        console.log(row.join(' '));
    });
}


CheckTheSumOfTheDiagonals(['5 3 12 3 1',
                           '11 4 23 2 5',
                           '101 12 3 21 10',
                           '1 4 5 2 2',
                           '5 22 33 11 1']);

                           
CheckTheSumOfTheDiagonals(['1 1 1',
                           '1 1 1',
                           '1 1 0']);