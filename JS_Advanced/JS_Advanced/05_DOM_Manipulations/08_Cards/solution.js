function solve() {
	const playerOneDiv = document.getElementById('player1Div');
	const playerTwoDiv = document.getElementById('player2Div');
	const resultSpans = document.getElementById('result').children;
	const historyDiv = document.getElementById('history');

	let playerOneCard = '';
   	let playerTwoCard = '';

	[playerOneDiv, playerTwoDiv].map(player => player.addEventListener('click', (event) => {
		if (event.target.name === undefined) {
			return '';
		}
		
		let selectedCard = event.target;

		player === playerOneDiv
        	? playerOneCard = showCard(resultSpans[0], selectedCard)
        	: playerTwoCard = showCard(resultSpans[2], selectedCard);

      	if (resultSpans[0].textContent !== '' && resultSpans[2].textContent !== '') {
			Number(playerOneCard.name) > Number(playerTwoCard.name)
				? createBorder(playerOneCard, playerTwoCard)
				: createBorder(playerTwoCard, playerOneCard);
			
			historyDiv.textContent += `[${playerOneCard.name} vs ${playerTwoCard.name}] `;
			restoreDefaultValues();
		}
	}));
	
	function showCard(span, card) {
		card.src = "images/whiteCard.jpg";
		span.textContent = card.name;
		
		return card;
	}

	function createBorder(winnerCard, looserCard) {
		winnerCard.style.border = '2px solid green';
		looserCard.style.border = '2px solid red';
	}

	function restoreDefaultValues() {
		resultSpans[0].textContent = '';
		resultSpans[2].textContent = '';
		playerOneCard = '';
		playerTwoCard = '';
	}
}