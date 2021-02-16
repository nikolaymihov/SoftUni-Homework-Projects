function solve() {
    let correctAnswersCount = 0,
        currentQuestionIndex = 0,
        questionsInfo = { 0: 'onclick', 1: 'JSON.stringify()', 2: 'A programming API for HTML and XML documents' };

    let hiddenSections = document.getElementsByTagName('section');

    document.querySelectorAll('.answer-text').forEach(answer => {
        answer.addEventListener('click', (event) => {
            let selectedAnswer = event.target.innerText;

            if (questionsInfo[currentQuestionIndex] === selectedAnswer) {
                correctAnswersCount++;
            }

            hiddenSections[currentQuestionIndex].style.display = 'none';

            if (currentQuestionIndex < 2) {
                hiddenSections[currentQuestionIndex + 1].style.display = 'block';
                currentQuestionIndex++;
            } else {
                let result = document.querySelector('li.results-inner h1');

                if (correctAnswersCount === 3){
                    result.innerText = 'You are recognized as top JavaScript fan!';
                } else {
                    result.innerText = `You have ${correctAnswersCount} right answers`;
                }

                document.getElementById('results').style.display = 'block';
            }
        })
    })
}
