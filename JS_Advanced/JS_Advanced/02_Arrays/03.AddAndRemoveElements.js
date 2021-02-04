function AddAndRemoveElements(inputArr){  
    let outputArr = [],
        counter = 1;
    
    inputArr.forEach((element) => {
        element === 'add' ? outputArr.push(counter) : outputArr.pop();
        counter++;
    });
    
    console.log(outputArr.length === 0 ? 'Empty' : outputArr.join('\n')); 
}

AddAndRemoveElements(['add', 'add', 'add', 'add']);

AddAndRemoveElements(['add', 'add', 'remove', 'add', 'add']);

AddAndRemoveElements(['remove', 'remove', 'remove']);