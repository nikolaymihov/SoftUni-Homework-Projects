function solve() {
   const messagesDiv = document.getElementById("chat_messages");

   document
      .getElementById("send")
      .addEventListener('click', () => {
         let inputForm = document.getElementById("chat_input");
         let inputText = inputForm.value;
         let newMessageDiv = document.createElement("div");
         
         newMessageDiv.className = "message my-message";  
         newMessageDiv.innerHTML = inputText;
         
         messagesDiv.appendChild(newMessageDiv);

         inputForm.value = '';
      });
}