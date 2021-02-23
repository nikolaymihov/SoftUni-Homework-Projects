function solve() {
   const searchButton = document.getElementById('searchBtn');
   const searchField = document.getElementById('searchField');
   const allTableData = document.querySelectorAll('tbody > tr');

   searchButton.addEventListener('click', () => {
      clearSelectClasses(allTableData);
      
      let searchFieldValue = searchField.value.toLowerCase();

      if (searchFieldValue.length > 0){
         
         for (let i = 0; i < allTableData.length; i++) {
            let currentRowData = allTableData[i].innerText.toLowerCase();
            
            if (currentRowData.includes(searchFieldValue)){
               allTableData[i].classList.add('select');
            }
         }
      }

      searchField.value = '';
   });

   function clearSelectClasses(data){
      for (let i = 0; i < data.length; i++) {
         data[i].classList.remove('select');
      }
   }
}