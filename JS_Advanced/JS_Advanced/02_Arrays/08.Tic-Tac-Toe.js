function CheckResultOfTicTacToeGame(playersMoves){
    let dashboard = [[false, false, false],
                     [false, false, false],
                     [false, false, false]];
    
    let currentPlayerSign = 'X',
        hasAWinner = false;

    playersMoves.forEach(playerMove => {
        if (!hasAWinner){

            let [row, col] = playerMove.split(' ').map(num => Number(num));

            if (dashboard[row][col] === false){ //the place is not taken
                dashboard[row][col] = currentPlayerSign;

                if (CheckIfPlayerWins(dashboard, currentPlayerSign)){
                    hasAWinner = true;
                }

                if (!hasAWinner){
                    currentPlayerSign = currentPlayerSign === 'X' ? 'O' : 'X';
                }

            } else {
                console.log('This place is already taken. Please choose another!');
            }
        }    
    });

    if (hasAWinner){
        console.log(`Player ${currentPlayerSign} wins!`);
    } else {
        console.log('The game ended! Nobody wins :(');
    }

    PrintMatrix(dashboard);
}

function CheckIfPlayerWins(board, sign){
    let isWinner = false;

    for (let i = 0; i < 3; i++) {

        //check rows
        if (board[i][0] === sign && board[i][1] === sign && board[i][2] === sign){
            isWinner = true;
            break;
        }
        
        //check cols
        if (board[0][i] === sign && board[1][i] === sign && board[2][i] === sign){
            isWinner = true;
            break;
        }
    }

    if (!isWinner){

        //check the two diagonals
        if ((board[0][0] === sign && board[1][1] === sign && board[2][2] === sign) ||
            (board[2][0] === sign && board[1][1] === sign && board[0][2] === sign)) {
            isWinner = true;
        }
    }

    return isWinner;
}

function PrintMatrix(dashboard){
    dashboard.forEach(row => {
        console.log(row.join('\t'));
    });
}

CheckResultOfTicTacToeGame(["0 1", "0 0", "0 2", "2 0", "1 0", "1 1", "1 2", "2 2", "2 1", "0 0"]);

CheckResultOfTicTacToeGame(["0 0", "0 0", "1 1", "0 1", "1 2", "0 2", "2 2", "1 2", "2 2", "2 1"]);

CheckResultOfTicTacToeGame(["0 1", "0 0", "0 2", "2 0", "1 0", "1 2", "1 1", "2 1", "2 2", "0 0"]);