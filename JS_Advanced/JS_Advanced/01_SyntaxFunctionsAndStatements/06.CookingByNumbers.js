function DoTheCooking(numberAsStr, ...operations){
    let number = Number(numberAsStr),
        result = [];

    operations.forEach(element => {
        switch (element.toLowerCase()){
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number += 1;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number -= number * 0.2;
                break;
        };

        result.push(number);
    });

    return result.join('\n');
}

console.log(DoTheCooking('32', 'chop', 'chop', 'chop', 'chop', 'chop'));

console.log(DoTheCooking('9', 'dice', 'spice', 'chop', 'bake', 'fillet'));