function SortAndPrintProducts(input){
    let result = {};

    input.forEach(productData => {
        let [product, price] = productData.split(' : ');
        price = Number(price);

        let firstLetter = product.charAt(0);

        if (!result.hasOwnProperty(firstLetter)){
            result[firstLetter] = [];
        } 

        result[firstLetter].push({product, price});
    });

    Object.values(result).forEach(innerArr => {
        innerArr.sort(compare);
    });

    Object.keys(result).sort().forEach(key => {
        console.log(`${key}`);

        Object.keys(result[key]).forEach(productObj => {
            let currentProduct = Object.values(result[key][productObj])[0];
            let currentProdPrice = Object.values(result[key][productObj])[1];

           console.log(`  ${currentProduct}: ${currentProdPrice}`);
        });
    });
}

function compare(a, b) {
    // Use toUpperCase() to ignore character casing
    const productA = a.product.toUpperCase();
    const productB = b.product.toUpperCase();
  
    let comparison = 0;

    if (productA > productB) {
        comparison = 1;
    } else if (productA < productB) {
        comparison = -1;
    }

    return comparison;
}

SortAndPrintProducts(['Appricot : 20.4',
                      'Fridge : 1500',
                      'TV : 1499',
                      'Deodorant : 10',
                      'Boiler : 300',
                      'Apple : 1.25',
                      'Anti-Bug Spray : 15',
                      'T-Shirt : 10']);

SortAndPrintProducts(['Banana : 2',
                      'Rubic\'s Cube : 5',
                      'Raspberry P : 4999',
                      'Rolex : 100000',
                      'Rollon : 10',
                      'Rali Car : 2000000',
                      'Pesho : 0.000001',
                      'Barrel : 10']);