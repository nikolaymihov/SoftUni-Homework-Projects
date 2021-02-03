function PrintArrayWithDelimeter(inputArr){
    let delimiter = inputArr.pop();

    console.log(inputArr.join(delimiter));
}

PrintArrayWithDelimeter(['One', 'Two', 'Three', 'Four', 'Five', '-']);

PrintArrayWithDelimeter(['How about no?', 'I','will', 'not', 'do', 'it!', '_']);