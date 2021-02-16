function solve() {
   let textArea = document.querySelector('body > div > textarea');
   let totalPrice = 0;
   let listOfUniqueProducts = [];
   let addButtons = document.getElementsByClassName('add-product');
   let buttonsArray = Array.from(addButtons);

   for (let i = 0; i < buttonsArray.length; i++) {
       
      buttonsArray[i].addEventListener('click', function one() {
           let name = document.querySelector(`body > div > div:nth-child(${i + 2}) > div.product-details > div`).textContent;
           let price = document.querySelector(`body > div > div:nth-child(${i + 2}) > div.product-line-price`).textContent;

           if (!listOfUniqueProducts.includes(name)) {
               listOfUniqueProducts.push(name);
           }
           
           let result = `Added ${name} for ${price} to the cart.\n`;
           totalPrice += Number(price);
           textArea.value += result;
       });
   }

   let checkoutButton = document.querySelector('body > div > button');

   checkoutButton.addEventListener('click', function final() {
       let finalMsg = `You bought ${listOfUniqueProducts.join(', ')} for ${totalPrice.toFixed(2)}.`;
       textArea.value += finalMsg;
       disableButtons();
   });

   function disableButtons() {
      let buttons = Array.from(document.querySelectorAll('button'));
      buttons.forEach(button => button.disabled = true);
   }
}