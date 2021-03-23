const assert = require('chai').assert;
const mathEnforcer = require('../02.FunctionalitiesToTest').mathEnforcer;
const ERROR_MESSAGE = 'Function did not return the correct result!';

describe('mathEnforcer tests', () => {
    describe('structure tests', () => {    
        it('should be of type object', () => {
            assert.equal((typeof mathEnforcer), 'object', ERROR_MESSAGE);
        });

        it('object properties should be of type function', function () {
            assert.equal((typeof mathEnforcer.addFive), 'function', ERROR_MESSAGE);
            assert.equal((typeof mathEnforcer.subtractTen), 'function', ERROR_MESSAGE);
            assert.equal((typeof mathEnforcer.sum), 'function', ERROR_MESSAGE);
        });
    });    
    
    describe('addFive tests', () => {
        it('should return undefined with a non-number parameter', () => {
            //Act
            let result = mathEnforcer.addFive('George');
    
            //Assert
            assert.equal(result, undefined, ERROR_MESSAGE);
        });

        it('should return correct result with a floating-point number parameter', () => {
            //Act
            let result = mathEnforcer.addFive(3.14159);

            //Assert
            assert.closeTo(result, 8.14, 0.01, ERROR_MESSAGE);
        });

        it('should return correct result with a negative number parameter', () => {
            //Act
            let result = mathEnforcer.addFive(-10);

            //Assert
            assert.equal(result, -5, ERROR_MESSAGE);
        });

        it('should return correct result with an integer number parameter', () => {
            //Act
            let result = mathEnforcer.addFive(15);

            //Assert
            assert.equal(result, 20, ERROR_MESSAGE);
        });
    });

    describe('subtractTen tests', () => {
        it('should return undefined with a non-number parameter', () => {
            //Act
            let result = mathEnforcer.subtractTen({name: 'Pesho', age: 25});
    
            //Assert
            assert.equal(result, undefined, ERROR_MESSAGE);
        });

        it('should return correct result with a floating-point number parameter', () => {
            //Act
            let result = mathEnforcer.subtractTen(13.14159);

            //Assert
            assert.closeTo(result, 3.14, 0.01, ERROR_MESSAGE);
        });

        it('should return correct result with a negative number parameter', () => {
            //Act
            let result = mathEnforcer.subtractTen(10);

            //Assert
            assert.equal(result, 0, ERROR_MESSAGE);
        });

        it('should return correct result with an integer number parameter', () => {
            //Act
            let result = mathEnforcer.subtractTen(40);

            //Assert
            assert.equal(result, 30, ERROR_MESSAGE);
        });
    });

    describe('sum tests', () => {
        it('should return undefined with a non-number first parameter', () => {
            //Act
            let result = mathEnforcer.sum({name: 'Pesho', age: 25}, 10);
    
            //Assert
            assert.equal(result, undefined, ERROR_MESSAGE);
        });

        it('should return undefined with a non-number second parameter', () => {
            //Act
            let result = mathEnforcer.sum(20, 'Peter');
    
            //Assert
            assert.equal(result, undefined, ERROR_MESSAGE);
        });

        it('should return correct result with a floating-point number parameter', () => {
            //Act
            let result = mathEnforcer.sum(13.14159, 10);

            //Assert
            assert.closeTo(result, 23.14, 0.01, ERROR_MESSAGE);
        });

        it('should return correct result with a two floating-point number parameters', () => {
            //Act
            let result = mathEnforcer.sum(5.151, 10.055);

            //Assert
            assert.closeTo(result, 15.21, 0.01, ERROR_MESSAGE);
        });

        it('should return correct result with a negative number parameter', () => {
            //Act
            let result = mathEnforcer.sum(10, -10);

            //Assert
            assert.equal(result, 0, ERROR_MESSAGE);
        });

        it('should return correct result with a two negative number parameters', () => {
            //Act
            let result = mathEnforcer.sum(-40, -10);

            //Assert
            assert.equal(result, -50, ERROR_MESSAGE);
        });

        it('should return correct result with a two integer number parameters', () => {
            //Act
            let result = mathEnforcer.sum(1000, 24);

            //Assert
            assert.equal(result, 1024, ERROR_MESSAGE);
        });
    });
});