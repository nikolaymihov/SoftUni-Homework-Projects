function solve() {
    let actionElements = Array.from(document.querySelectorAll('.action > form > div'));
    let [lectureNameElement, dateElement, moduleElement, addButtonElement] = actionElements;
    let modulesDiv = document.getElementsByClassName('modules')[0];

    addButtonElement.addEventListener('click', function(e) {
        e.preventDefault();

        let lectureNameValue = lectureNameElement.querySelector('input').value;
        let dateValue = dateElement.querySelector('input').value;
        let moduleValue = moduleElement.querySelector('select').value;

        if (lectureNameValue && dateValue && moduleValue !== 'Select module'){
            moduleValue = moduleValue.toUpperCase();
            
            let formatedDate = formatDate(dateValue);
            let formatedHours = formatHours(dateValue);
            
            let liElement = document.createElement('li');
            liElement.className = 'flex';

            let lectureInfoElement = document.createElement('h4');
            lectureInfoElement.innerText = `${lectureNameValue} - ${formatedDate} - ${formatedHours}`;

            let delButton = document.createElement('button');
            delButton.className = 'red';
            delButton.innerText = 'Del';

            liElement.appendChild(lectureInfoElement);
            liElement.appendChild(delButton);

            if (checkIfModuleExists(modulesDiv, moduleValue)) {
                let module = getExistingModule(modulesDiv, moduleValue);
                let currentUlElement = module.querySelector('ul');

                currentUlElement.appendChild(liElement);

                let liElements = Array.from(currentUlElement.querySelectorAll("li"));
                    
                liElements.sort((li1, li2) => {
                    let li1Date = getDateFromLiElement(li1);
                    li1Date = convertDateToInitialState(li1Date);
                    li1Date = new Date(li1Date);
                    
                    let li2Date = getDateFromLiElement(li2)
                    li2Date = convertDateToInitialState(li2Date);
                    li2Date = new Date(li2Date);

                    return li1Date.getTime() - li2Date.getTime();
                })

                liElements.forEach(el => currentUlElement.appendChild(el));
            } else {
                let newModuleDivElement = document.createElement('div');
                let titleElement = document.createElement('h3');
                let ulElement = document.createElement('ul');

                titleElement.innerText = `${moduleValue}-MODULE`;
                newModuleDivElement.className = "module";
                
                ulElement.appendChild(liElement);
                newModuleDivElement.appendChild(titleElement);
                newModuleDivElement.appendChild(ulElement);
                
                modulesDiv.appendChild(newModuleDivElement);
            }
            
        } 

        lectureNameElement.querySelector('input').value = '';
        dateElement.querySelector('input').value = '';
        moduleElement.querySelector('select').value = 'Select module';

        let deleteButtons = Array.from(document.querySelectorAll('.red'));
        
        deleteButtons.forEach(deleteButton => {
            deleteButton.addEventListener('click', deleteTraining);
        });
    });

    function deleteTraining(e) {
        let liToRemove = e.target.parentElement;
        
        if (!liToRemove.nextElementSibling && !liToRemove.previousElementSibling) {
            liToRemove.parentElement.parentElement.remove();
        } else {
            liToRemove.remove();
        }
    }

    function checkIfModuleExists(modulesCollection, moduleName){
        let modulesArray = Array.from(modulesCollection.children);

        for (const module of modulesArray) {
            let currentModuleName = module.innerText.split('-')[0];
            
            if (currentModuleName === moduleName){
                return true;
            }
        }

        return false;
    }

    function getExistingModule(modulesCollection, moduleName){
        let modulesArray = Array.from(modulesCollection.children);

        for (const module of modulesArray) {
            let currentModuleName = module.innerText.split('-')[0];
            
            if (currentModuleName === moduleName){
                return module;
            }
        }
    }

    function formatDate(date) {
        let d = new Date(date),
            month = '' + (d.getMonth() + 1),
            day = '' + d.getDate(),
            year = d.getFullYear();
    
        if (month.length < 2) {
            month = '0' + month;
        }

        if (day.length < 2) { 
            day = '0' + day;
        }

        return [year, month, day].join('/');
    }
    
    function formatHours(date) {
        let d = new Date(date),
            hours = '' +d.getHours(),
            minutes = '' + d.getMinutes();
        
        if (hours.length < 2) {
            hours = '0' + hours;
        }    
        if (minutes.length < 2) {
            minutes = '0' + minutes;
        }

        return `${hours}:${minutes}`;
    }

    function convertDateToInitialState(dateValue) {
        while (dateValue.includes('/')) {
            dateValue = dateValue.replace('/', '-');
        }

        dateValue = dateValue.replace(' - ', 'T');

        return dateValue;
    }

    function getDateFromLiElement(liElement) {
        let index = liElement.querySelector('h4').textContent.indexOf('-') + 2;
        let dateAndTime = liElement.querySelector('h4').textContent.slice(index);
        
        return dateAndTime;
    }
};