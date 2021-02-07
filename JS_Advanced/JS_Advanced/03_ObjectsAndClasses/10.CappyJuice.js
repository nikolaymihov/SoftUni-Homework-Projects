function CalculateBottles(input){
    let juices = new Map();

    let productsToPrint = {};

    input.forEach(juiceData => {
        let [product, quantity] = juiceData.split(' => ');
        quantity = Number(quantity);

        if (!juices.has(product)){
            juices.set(product, quantity);
        } else {
            juices.set(product, juices.get(product) + quantity);
        }

        let currentProductTotalQuantity = juices.get(product);

        if (currentProductTotalQuantity > 1000){
            if (!productsToPrint.hasOwnProperty(product)){
                productsToPrint[product] = quantity;
            } else {
                productsToPrint[product] += quantity;
            } 
        }
    });

    Object.keys(productsToPrint).forEach(key => {
        let numberOfBottles = Math.floor(productsToPrint[key] / 1000);
        console.log(`${key} => ${numberOfBottles}`);
    });
}

CalculateBottles(['Orange => 2000',
                  'Peach => 1432',
                  'Banana => 450',
                  'Peach => 600',
                  'Strawberry => 549']);

CalculateBottles(['Kiwi => 234',
                  'Pear => 2345',
                  'Watermelon => 3456',
                  'Kiwi => 4567',
                  'Pear => 5678',
                  'Watermelon => 6789']);