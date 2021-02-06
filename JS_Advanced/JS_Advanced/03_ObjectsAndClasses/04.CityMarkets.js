function GetTownDetails(input){
    let towns = {};

    for (let i = 0; i < input.length; i++) {
        let townArgs = input[i].split('->').map(t => t.trim());
        let townName = townArgs[0];
        let productName = townArgs[1];
        let [productSales, productPrice] = townArgs[2].split(':').map(p => p.trim());
        
        if (!towns.hasOwnProperty(townName)){
            towns[townName] = {};
        }

        if(!towns[townName].hasOwnProperty(productName)){
            towns[townName][productName] = 0;
        }

        towns[townName][productName] += productSales * productPrice;
    }

    Object.keys(towns).forEach(town => {
        console.log(`Town - ${town}`);
        
        Object.keys(towns[town]).forEach(product => {
            console.log(`$$$${product} : ${towns[town][product]}`);
        })
    });
}

GetTownDetails(['Sofia -> Laptops HP -> 200 : 2000',
                'Sofia -> Raspberry -> 200000 : 1500',
                'Sofia -> Audi Q7 -> 200 : 100000',
                'Montana -> Portokals -> 200000 : 1',
                'Montana -> Qgodas -> 20000 : 0.2',
                'Montana -> Chereshas -> 1000 : 0.3']);