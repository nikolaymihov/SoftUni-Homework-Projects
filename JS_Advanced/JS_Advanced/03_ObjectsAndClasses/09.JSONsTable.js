function ConvertJSONToHTMLTable(input){
    let allCreatedObjects = [];

    for (const jsonRow of input) {
        let newObj = JSON.parse(jsonRow);

        allCreatedObjects.push(newObj);
    }

    let html = "<table>\n\t<tr>\n";

    Object.keys(allCreatedObjects[0]).forEach(key => {
        html += `\t\t<th>${key.toUpperCase()}</th>\n`;
    });

    html += "\t</tr>\n";

    allCreatedObjects.forEach(obj => {
        html += "\t<tr>\n";
        
        Object.values(obj).forEach(value => {
            html += `\t\t<td>${value}</td>\n`;
        });
        
        html += "\t</tr>\n";
    });

    html += "</table>"

    console.log(html);
}

ConvertJSONToHTMLTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
                        '{"name":"Teo","position":"Lecturer","salary":1000}',
                        '{"name":"Georgi","position":"Lecturer","salary":1000}']);