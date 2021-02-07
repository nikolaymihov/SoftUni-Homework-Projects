function HeroicInventory(input){
    let result = [];

    for (const heroArgs of input) {
        let [name, level, items] = heroArgs.split(' / ');
        level = Number(level);
        items = items ? items.split(', ') : [];

        result.push({name, level, items});
    }

    console.log(JSON.stringify(result));
}

HeroicInventory(['Isacc / 25 / Apple, GravityGun',
                 'Derek / 12 / BarrelVest, DestructionSword',
                 'Hes / 1 / Desolator, Sentinel, Antara']);

HeroicInventory(['Jake / 1000 / Gauss, HolidayGrenade']);

HeroicInventory(['Stamat / 34']);