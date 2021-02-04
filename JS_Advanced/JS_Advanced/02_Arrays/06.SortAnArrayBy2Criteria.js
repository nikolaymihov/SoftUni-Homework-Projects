function SortArray(input) {
    input.sort((cur, next) => {
        return cur.length - next.length || cur.localeCompare(next);
    }).forEach(el => console.log(el)); 
}

SortArray(['alpha', 'beta', 'gamma']);

SortArray(['Isacc', 'Theodor', 'Jack', 'Harrison', 'George']);

SortArray(['test', 'Deny', 'omen', 'Default']);