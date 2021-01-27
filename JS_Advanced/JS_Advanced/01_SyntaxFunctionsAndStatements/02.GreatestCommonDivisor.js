function CalculateGCD(x, y) {
    if ((typeof x !== 'number') || (typeof y !== 'number')) 
      return false;

    x = Math.abs(x);
    y = Math.abs(y);

    while(y) {
      let t = y;
      y = x % y;
      x = t;
    }

    return x;
}
  
console.log(CalculateGCD(15, 5));

console.log(CalculateGCD(2154, 458));