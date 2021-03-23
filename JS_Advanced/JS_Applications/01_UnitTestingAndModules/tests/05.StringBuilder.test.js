const expect = require('chai').expect;
const assert = require('chai').assert;
const StringBuilder = require('../02.FunctionalitiesToTest').StringBuilder;
const ERROR_MESSAGE = 'Function did not return the correct result!';

describe('StringBuilder class tests', () => {
    describe('structure tests', () => {
        it('should exists when requiring the correct javascript file', () => {
            expect(StringBuilder).to.exist
        });

        //because in JS there aren't classes and the functions can be used to somewhat simulate classes
        it('should be with type equal to function', () => {
            expect(typeof StringBuilder).to.equal('function');
        });

        it('should have the correct function properties', () => {
            assert.isFunction(StringBuilder.prototype.append);
            assert.isFunction(StringBuilder.prototype.prepend);
            assert.isFunction(StringBuilder.prototype.insertAt);
            assert.isFunction(StringBuilder.prototype.remove);
            assert.isFunction(StringBuilder.prototype.toString);
        });
    });

    describe('constructor tests', () => {
        it('should works correctly with a string value', () => {
            let myBuilder = new StringBuilder('Str');
            expect(myBuilder).to.have.property('_stringArray').with.lengthOf(3, ERROR_MESSAGE);
        });
        
        it('should works correctly with an empty value', () => {
            let myBuilder = new StringBuilder();
            expect(myBuilder).to.have.property('_stringArray').with.lengthOf(0, ERROR_MESSAGE);
        });
        
        it('should throws an error message with a non-string parameter', () => {
            expect(() => new StringBuilder(1)).to.Throw('Argument must be а string');
        });
    });

    describe('append tests', () => {
        it('should throws an error message with a non-string parameter', () => {
            let myBuilder = new StringBuilder('Str');
            expect(() => myBuilder.append(1)).to.Throw('Argument must be а string');
        });

        it('should enlarge the current string length with the length of the appended text', () => {
            let myBuilder = new StringBuilder('Str');
            myBuilder.append('ing');
            expect(myBuilder).to.have.property('_stringArray').with.lengthOf(6);
        });

        it('should append the text at the end of the current string', () => {
            let myBuilder = new StringBuilder('Str');
            myBuilder.append('A');
            expect(myBuilder._stringArray[3]).to.equal('A');
        });
    });

    describe('prepend tests', () => {
        it('should throws an error message with a non-string parameter', () => {
            let myBuilder = new StringBuilder('Str');
            expect(() => myBuilder.prepend(1)).to.Throw('Argument must be а string');
        });

        it('should enlarge the current string length with the length of the prepended text', () => {
            let myBuilder = new StringBuilder('Str');
            myBuilder.prepend('a');
            expect(myBuilder).to.have.property('_stringArray').with.lengthOf(4);
        });

        it('should prepend the text at the start of the current string', () => {
            let myBuilder = new StringBuilder('Str');
            myBuilder.prepend('a');
            expect(myBuilder._stringArray[0]).to.equal('a');
        });
    });

    describe('insertAt tests', () => {
        it('should throws an error message with a non-string parameter', () => {
            let myBuilder = new StringBuilder('Str');
            expect(() => myBuilder.insertAt(1, 1)).to.Throw('Argument must be а string');
        });

        it('should enlarge the current string length with the length of the inserted text', () => {
            let myBuilder = new StringBuilder('Str');
            myBuilder.insertAt('ing', 3);
            expect(myBuilder).to.have.property('_stringArray').with.lengthOf(6);
        });

        it('should insert the text at the correct index of the current string', () => {
            let myBuilder = new StringBuilder('Str');
            myBuilder.insertAt('ing', 3);
            expect(myBuilder._stringArray[3]).to.equal('i');
        });
    });

    describe('remove', () => {
        it('should reduce the current string length with the length of the removed text', () => {
            let myBuilder = new StringBuilder('abc');
            myBuilder.remove(1, 1);
            expect(myBuilder).to.have.property('_stringArray').with.lengthOf(2);
        });

        it('should works correctly when removing one character at a given index', () => {
            let myBuilder = new StringBuilder('abc');
            myBuilder.remove(1, 1);
            expect(myBuilder._stringArray.join('')).to.equal('ac');
        });

        it('should works correctly when removing more than one characters at a given index', () => {
            let myBuilder = new StringBuilder('abcdef');
            myBuilder.remove(1, 3);
            expect(myBuilder._stringArray.join('')).to.equal('aef');
        });

        it('should works correctly when removing with length equal to the current string length', () => {
            let myBuilder = new StringBuilder('abc');
            myBuilder.remove(0, 3);
            expect(myBuilder._stringArray.join('')).to.equal('');
        });
    });

    describe('toString', () => {
        it('should works correctly', () => {
            let result = new StringBuilder('test');
            expect(result.toString()).to.equal('test');
        });
    });

    describe('full test of the StringBuilder class', function(){
        it('should works correctly with the given example logic test', () => {
            let str = new StringBuilder('hello');
            str.append(', there');
            str.prepend('User, ');
            str.insertAt('woop', 5);
            str.remove(6, 3);
            expect(str.toString()).to.equal('User,w hello, there');
        });
    });
});