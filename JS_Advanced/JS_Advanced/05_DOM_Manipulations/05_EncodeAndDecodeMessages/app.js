function encodeAndDecodeMessages() {
    const textAreas = document.getElementsByTagName('textArea');
    const buttons = Array.from(document.getElementsByTagName('button'));

    buttons.forEach(button => {
        button.addEventListener('click', (event) => {
            if (event.target === buttons[0]){
                textAreas[1].value = generateMessage(textAreas[0].value, 1);
                textAreas[0].value = '';
            } else {
                textAreas[0].value = generateMessage(textAreas[1].value, -1);
                textAreas[1].value = '';
            }
        });
    });

    function generateMessage(message, increment) {
        let newMessage = '';
        
        for (let i = 0; i < message.length; i++) {
            let char = message.charCodeAt(i);
            newMessage += String.fromCharCode(char += increment);
        }
        
        return newMessage;
    }
}