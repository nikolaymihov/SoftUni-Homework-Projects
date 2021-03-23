const expect = require('chai').expect;
const lookupChar = require('../02.FunctionalitiesToTest').lookupChar;
const ERROR_MESSAGE = 'Function did not return the correct result!';

describe('lookupChar negative tests', () => {
    it('should return undefined with a non-string first parameter', () => {
        expect(lookupChar(13, 0)).to.equal(undefined, ERROR_MESSAGE);
    });

    it('should return undefined with a non-integer second parameter', () => {
        expect(lookupChar('Peter', 'George')).to.equal(undefined, ERROR_MESSAGE);
    });

    it('should return undefined with a floating-point number as a second parameter', () => {
        expect(lookupChar('Peter', 5.5)).to.equal(undefined, ERROR_MESSAGE);
    });

    it('should return "Incorrect index" with an incorrect index value', () => {
        expect(lookupChar('George', 13)).to.equal('Incorrect index', ERROR_MESSAGE);
    });

    it('should return "Incorrect index" with a negative index value', () => {
        expect(lookupChar('Peter', -1)).to.equal('Incorrect index', ERROR_MESSAGE);
    });

    it('should return "Incorrect index" with an index value equal to string length', () => {
        expect(lookupChar('Steven', 6)).to.equal('Incorrect index', ERROR_MESSAGE);
    });
});

describe('lookupChar positive tests', () => {
    it('should return correct value with correct parameters', () => {
        expect(lookupChar('Peter', 3)).to.equal('e', ERROR_MESSAGE);
    });

    it('should return correct value with correct parameters', () => {
        expect(lookupChar('George', 0)).to.equal('G', ERROR_MESSAGE);
    });
});