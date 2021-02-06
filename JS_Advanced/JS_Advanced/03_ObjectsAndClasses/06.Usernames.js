function GetAndSortAllUniqueNames(inputArr){
    let uniqueNames = inputArr.filter(getUniqueValues);

    uniqueNames.sort((cur, next) => {
        return cur.length - next.length || cur.localeCompare(next);
    }).forEach(name => console.log(name));
}

function getUniqueValues(value, index, self) {
    return self.indexOf(value) === index;
}

//GetAndSortAllUniqueNames(['Ashton','Kutcher','Ariel','Lilly','Keyden','Aizen','Billy','Braston','Billy']);

GetAndSortAllUniqueNames(['Denise',
'Ignatius',
'Iris',
'Isacc',
'Indie',
'Dean',
'Donatello',
'Enfuego',
'Benjamin',
'Biser',
'Bounty',
'Renard',
'Rot']);