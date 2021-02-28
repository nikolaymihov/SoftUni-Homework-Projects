function sortArray(numsArray, typeOfSorting){
    if (typeOfSorting.toLowerCase() === 'asc'){
        numsArray.sort((a, b) => a - b);
    } else {
        numsArray.sort((a, b) => b - a);
    }

    return numsArray;
}

console.log(sortArray([14, 7, 17, 6, 8], 'asc'));

console.log(sortArray([14, 7, 17, 6, 8], 'desc'));