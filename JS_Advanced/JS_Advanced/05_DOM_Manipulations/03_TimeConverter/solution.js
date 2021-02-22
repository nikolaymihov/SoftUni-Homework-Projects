function attachEventsListeners() {
    const daysInput = document.getElementById('days');
    const hoursInput = document.getElementById('hours');
    const minutesInput = document.getElementById('minutes');
    const secondsInput = document.getElementById('seconds');

    let convertButtons = Array.from(document.querySelectorAll('input[type="button"]'));

    convertButtons.forEach(button => {
        button.addEventListener('click', (event) => {
            let clickedButtonId = event.target.id;
            let days = 0;

            switch (clickedButtonId) {
                case 'daysBtn':
                    days = Number(daysInput.value);
                    ConvertTime(days);
                    break;
                case 'hoursBtn':
                    days = Number(hoursInput.value) / 24;
                    ConvertTime(days);
                    break;
                case 'minutesBtn':
                    days = Number(minutesInput.value) / 1440;
                    ConvertTime(days);
                    break;
                case 'secondsBtn':
                    days = Number(secondsInput.value) / 86400;
                    ConvertTime(days);
                    break;
            }
        });
    });

    function ConvertTime(days) {
        daysInput.value = days;
        hoursInput.value = days * 24;
        minutesInput.value = days * 1440;
        secondsInput.value = days * 86400;
    }
}