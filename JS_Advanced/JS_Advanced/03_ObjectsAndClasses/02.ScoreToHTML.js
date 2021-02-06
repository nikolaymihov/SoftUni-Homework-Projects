function ScoreToHTML(inputJSON){
    let inputAsArrayOfObjects = JSON.parse(inputJSON);
    
    let html = '<table>\n\t<tr>';


    Object.keys(inputAsArrayOfObjects[0]).forEach(key => {
        html+= `<th>${key}</th>`;
    });

    html += '</tr>\n';

    inputAsArrayOfObjects.forEach(obj => {
        html+= `\t<tr><td>${Object.values(obj)[0]}</td><td>${Object.values(obj)[1]}</td></tr>\n`;
    });

    html += '</table>';

    return html;
}

console.log(ScoreToHTML(['[{"name":"Pesho","score":479},{"name":"Gosho","score":205}]']));