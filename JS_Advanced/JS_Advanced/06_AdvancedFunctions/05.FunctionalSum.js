function add(a) {
    var total = a;
  
    function innerFunc(b) {
        total += b;
        return innerFunc;
    }
  
    innerFunc.toString = function() { return total; }
  
    return innerFunc;
}

console.log(add(1)(6)(-3));