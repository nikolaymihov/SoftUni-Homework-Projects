function ExtractWordsToUpper(inputText) {
    let result = inputText.toUpperCase()
                     .match(/\w+/g)
                     .join(', ');

    return result;
}

console.log(ExtractWordsToUpper('Hi, how are you?'));

console.log(ExtractWordsToUpper('hello'));