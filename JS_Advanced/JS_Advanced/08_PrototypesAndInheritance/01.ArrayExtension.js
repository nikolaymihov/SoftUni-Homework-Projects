(function solve() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        if (n < 0 || n > this.length){
            throw new Error ('The number cannot be negative or higher than the length of the array!');
        }

        let result = [];

        for (let i = n; i < this.length; i++) {
            result.push(this[i]);
        }

        return result;
    }

    Array.prototype.take = function (n) {
        if (n < 0 || n > this.length){
            throw new Error ('The number cannot be negative or higher than the length of the array!');
        }

        let result = [];

        for (let i = 0; i < n; i++) {
            result.push(this[i]);
        }

        return result;
    }

    Array.prototype.sum = function () {
        return this.reduce((a, b) => a + b, 0);
    }

    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
}());

let numbers = [1,2,3,4,5,9];

console.log(numbers.average());