function solve() {
	const textAreas = document.getElementsByTagName('textarea');
	const inputArea = textAreas[0];
	const outputArea = textAreas[1];
	const tBody = document.querySelector('tBody');
	
	//enable the initial checkbox
	const initialCheckbox = document.querySelectorAll('input[type="checkbox"]')[0];
	initialCheckbox.disabled = false;

	Object.values(document.getElementsByTagName('button')).map(btn => btn.addEventListener('click', () => {
		if (btn.textContent === 'Generate') {
			createElements();
		} else if (btn.textContent === 'Buy') {
			findCheckedRows();
		}
	}))

	function createElements() {
		let furnitureObjects = JSON.parse(inputArea.value);
		
		for (let obj of furnitureObjects) {
			let tr = document.createElement('tr');
			let td = document.createElement('td');
			
			for (let i = 0; i < 5; i++) {
				tr.appendChild(td.cloneNode(true));
		  	}
		  
			fillRowData(tr, obj);
			tBody.appendChild(tr);
		}
	}

	function fillRowData(tr, obj) {
		tr.children[0].innerHTML = `<img src=${obj['img']}>`;
		tr.children[1].innerHTML = `<p>${obj['name']}</p>`;
		tr.children[2].innerHTML = `<p>${obj['price']}</p>`;
		tr.children[3].innerHTML = `<p>${obj['decFactor']}</p>`;
	    tr.children[4].innerHTML = `<input type="checkbox"/>`;
	}

	function findCheckedRows() {
		outputArea.value = '';

		let checkboxes = document.querySelectorAll('input[type="checkbox"]');
		let orderedFurnitures = [];
		let totalPrice = 0;
		let decFactor = 0;
		let rows = tBody.children;
		
		for (let i = 0; i < rows.length; i++) {
			if (checkboxes[i].checked === true) {
				let currentRowData = rows[i].children;
				addFurniture(currentRowData);
			}
		}
		
		printResult(orderedFurnitures, totalPrice, decFactor);

		function addFurniture(rowData) {
			orderedFurnitures.push(rowData[1].textContent.trim());
		  	totalPrice += Number(rowData[2].textContent);
		  	decFactor += Number(rowData[3].textContent);
		}

		function printResult(orderedFurnitures, totalPrice, decFactor) {
			outputArea.value +=
			  `Bought furniture: ${orderedFurnitures.join(', ')} \n` +
			  `Total price: ${totalPrice.toFixed(2)} \n` +
			  `Average decoration factor: ${(decFactor / orderedFurnitures.length)}\n`;
		}
	}
}