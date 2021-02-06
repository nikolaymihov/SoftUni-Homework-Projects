function CountWords(input){
    let inputAsStr = input.shift();
    let inputArgs = inputAsStr.match(/\b(\w+)\b/g);

    resultObj = {};
    
    for (var i = 0; i < inputArgs.length; i++) {
        var word = inputArgs[i];
        resultObj[word] = resultObj[word] ? resultObj[word] + 1 : 1;
    }

    console.log(resultObj);
}

CountWords(["Far too slow, you're far too slow."]);
CountWords(['JS devs use Node.js for server-side JS.-- JS for devs']);