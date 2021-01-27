function GetInfoAboutFruitPurchase(fruitName, quiantityInGrams, pricePerKg){
    let quantityInKgs = quiantityInGrams / 1000;
    let neededMoney = quantityInKgs * pricePerKg;

    return `I need $${neededMoney.toFixed(2)} to buy ${quantityInKgs.toFixed(2)} kilograms ${fruitName}.`;
}

console.log(GetInfoAboutFruitPurchase('orange', 2500, 1.80));

console.log(GetInfoAboutFruitPurchase('apple', 1563, 2.35));
