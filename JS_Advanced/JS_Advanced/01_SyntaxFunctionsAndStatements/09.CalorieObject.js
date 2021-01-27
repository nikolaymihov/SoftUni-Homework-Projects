function CreateCalorieObject(objectArgs){
    let caloryObj = new Object;
    
    for (let i = 0; i < objectArgs.length - 1; i++) {
        if (i % 2 == 0){
            caloryObj[objectArgs[i]] = objectArgs[i+1];
        }
    }
    return caloryObj;
}

console.log(CreateCalorieObject(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']));

console.log(CreateCalorieObject(['Potato', '93', 'Skyr', '63', 'Cucumber', '18', 'Milk', '42']));