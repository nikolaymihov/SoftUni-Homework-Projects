function getArgumentsInfo(...args){
    let types = {};

    args.forEach(argument => {
        let currentArgType = typeof argument;

        if (!types.hasOwnProperty(currentArgType)){
            types[currentArgType] = 1;
        } else {
            types[currentArgType] += 1;
        }

        console.log(`${(currentArgType)}: ${argument}`);
    });

    Object.keys(types).sort((a, b) => types[b] - types[a]).forEach(type => {
        console.log(`${type} = ${types[type]}`);
    });
};

getArgumentsInfo('cat', 42, function () { console.log('Hello world!'); });
