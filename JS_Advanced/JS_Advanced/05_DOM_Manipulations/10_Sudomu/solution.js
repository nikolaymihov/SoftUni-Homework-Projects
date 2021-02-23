function solve() {
    const table = document.getElementsByTagName('table')[0];
    const resultParagraph = document.querySelector('#check > p')
    const buttons = document.querySelectorAll('tfoot button');

    Object.values(buttons).map(button => button.addEventListener('click', (event) => {
        const tableData = document.querySelectorAll('tbody > tr > td > input');
        
        if (event.target.innerText === 'Quick Check'){
            let tableDataAsMatrix = convertTableDataToMatrix(tableData);

            checkSudomu(tableDataAsMatrix);
        } else {
            Array.from(tableData).forEach(input => (input.value = ''));
            table.style.border = 'none';
            resultParagraph.textContent = '';
        }
    }));

    function convertTableDataToMatrix(tableData){
        let matrix = [];
        let firstRowData = [];
        let secondRowData = [];
        let thirdRowData = [];

        for (let counter = 0; counter < 9; counter++) {
            currentCellValue = Number(tableData[counter].value);
            
            if (counter < 3){
                firstRowData.push(currentCellValue);
            } else if (counter < 6){
                secondRowData.push(currentCellValue);
            } else if (counter < 9){
                thirdRowData.push(currentCellValue);
            }
        }

        matrix.push(firstRowData);
        matrix.push(secondRowData);
        matrix.push(thirdRowData);

        return matrix;
    }

    function checkSudomu(dataAsMatrix){
        let isValid = true;
    
        for (let row = 0; row < dataAsMatrix.length; row++) {
            let sumOfRow = 0,
                sumOfCol = 0;
    
            for (let col = 0; col < dataAsMatrix[row].length; col++){
                if (dataAsMatrix[row][col] > 3 
                    || dataAsMatrix[row][col] < 1
                    || dataAsMatrix[col][row] > 3
                    || dataAsMatrix[col][row] < 1){
                    
                    isValid = false;
                    break;
                } else {
                    sumOfRow += dataAsMatrix[row][col];
                    sumOfCol += dataAsMatrix[col][row];
                }
            }
    
            if (sumOfRow !== 6 || sumOfCol !== 6 || hasDuplicates(dataAsMatrix[row])) {
                isValid = false;
                break;
            }
        }
        
        if (isValid) {
            table.style.border = '2px solid green';
            resultParagraph.textContent = 'You solve it! Congratulations!';
            resultParagraph.style.color = 'green';
        } else {
            table.style.border = '2px solid red';
            resultParagraph.textContent = 'NOP! You are not done yet…';
            resultParagraph.style.color = 'red';
        }
    }

    function hasDuplicates(array) {
        return (new Set(array)).size !== array.length;
    }
}