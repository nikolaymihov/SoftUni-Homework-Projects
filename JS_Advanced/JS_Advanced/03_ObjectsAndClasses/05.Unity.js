class Rat{
    constructor(name){
        this.name = name;
        this.unitedRats = [];
    }

    unite(ratObj){
        if (ratObj instanceof Rat) {
            this.unitedRats.push(ratObj);
        }
    }

    getRats() {
        return this.unitedRats;
    }

    toString() {
        let output = [];
        
        output.push(`${this.name}`);
        
        this.unitedRats.forEach(rat => {
            output.push(`##${rat.name}`);
        });

        return output.join('\n');
    }

}

let firstRat = new Rat("Peter");
console.log(firstRat.toString()); // Peter
 
console.log(firstRat.getRats()); // []

firstRat.unite(new Rat("George"));
firstRat.unite(new Rat("Alex"));
console.log(firstRat.getRats());
// [ Rat { name: 'George', unitedRats: [] },
//  Rat { name: 'Alex', unitedRats: [] } ]

console.log(firstRat.toString());
// Peter
// ##George
// ##Alex