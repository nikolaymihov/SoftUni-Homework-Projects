const assert = require('chai').assert;
const isOddOrEven = require('../02.FunctionsToTest').isOddOrEven;
const ERROR_MESSAGE = 'Function did not return the correct result!';

describe('isOddOrEven negative tests', () => {
    it('should return undefined with a number parameter', () => {
        //Arrange
        let parameter = 10;

        //Act
        let result = isOddOrEven(parameter);

        //Assert
        assert.equal(result, undefined, ERROR_MESSAGE);
    });

    it('should return undefined with an object parameter', () => {
        //Arrange
        let obj = {name: 'Gosho'};

        //Act
        let result = isOddOrEven(obj);

        //Assert
        assert.equal(result, undefined, ERROR_MESSAGE);
    });
});

describe('isOddOrEven positive tests', () => {
    it('should return correct result whith an even length', () => {
        let result = isOddOrEven('roar');

        assert.equal(result, 'even', ERROR_MESSAGE);
    });

    it('should return correct result whith an odd length', () => {
        let result = isOddOrEven('Peter');

        assert.equal(result, 'odd', ERROR_MESSAGE);
    });

    it('should return correct values with multiple consecutive checks', () => {
        let result1 = isOddOrEven('cat');
        assert.equal(result1, 'odd', ERROR_MESSAGE);

        let result2 = isOddOrEven('tuPac');
        assert.equal(result2, 'odd', ERROR_MESSAGE);

        let result3 = isOddOrEven('');
        assert.equal(result3, 'even', ERROR_MESSAGE);

        let result4 = isOddOrEven('az sum pich!');
        assert.equal(result4, 'even', ERROR_MESSAGE);
    });
});