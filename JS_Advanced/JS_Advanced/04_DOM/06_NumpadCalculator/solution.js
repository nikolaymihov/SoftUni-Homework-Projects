function solve() {
    let expression = document.getElementById('expressionOutput');
    let result = document.getElementById('resultOutput');

    document.querySelector('.clear').addEventListener('click', Clear);
    document.querySelector('.keys').addEventListener('click', ExecuteClickedButton);

    function Clear(){
        expression.textContent = '';
        result.textContent = '';
    }

    function ExecuteClickedButton(event){
        let pressedButton = event.target.value;

        switch (pressedButton) {
            case '/':
            case '*':
            case '-':
            case '+':
                expression.textContent += ` ${pressedButton} `; 
                break;
            case '=':
                let currentExpressionElements = expression.textContent.trim().split(' ');

                if (currentExpressionElements.length != 3){
                    result.textContent = 'NaN';
                    return;
                }

                let leftOperand = Number(currentExpressionElements[0]);
                let operator = currentExpressionElements[1];
                let rightOperand = Number(currentExpressionElements[2]);

                result.textContent = CalculateResult(leftOperand, operator, rightOperand);
                break;
            default:
                expression.textContent += pressedButton;
                break;
        }
    }

    function CalculateResult(leftOperand, operator, rightOperand){
        switch (operator) {
            case '/':
                return leftOperand / rightOperand;
            case '*':
                return leftOperand * rightOperand;
            case '-':
                return leftOperand - rightOperand;
            case '+':
                return leftOperand + rightOperand;
        }
    }
}