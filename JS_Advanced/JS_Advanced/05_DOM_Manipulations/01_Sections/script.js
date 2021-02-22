function create(words) {
   let mainDiv = document.getElementById('content');
   
   words.forEach(element => {
      let newDivElement = document.createElement('div');
      let newParagraph = document.createElement('p');
      
      let textNode = document.createTextNode(element);
      newParagraph.style.display = 'none';

      newParagraph.appendChild(textNode);
      newDivElement.appendChild(newParagraph);

      mainDiv.appendChild(newDivElement);
   });

   mainDiv.addEventListener('click', (event) => {
      event.target.firstChild.style.display = 'block';
   }); 
}