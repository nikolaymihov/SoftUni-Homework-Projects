function ExtractIncreasingSubsequence(inputArr){
    let currentMax = Number.MIN_SAFE_INTEGER;
    
    inputArr.forEach(number => {
        if (number >= currentMax){
            currentMax = number;
            console.log(number);
        }
    });
}

ExtractIncreasingSubsequence([1, 3, 8, 4, 10, 12, 3, 2, 24]);

ExtractIncreasingSubsequence([1, 2, 3, 4]);

ExtractIncreasingSubsequence([20, 3, 2, 15, 6, 1]);