function attachEvents() {
    const locationInputElement = document.getElementById('location');
    const submitButtonElement = document.getElementById('submit');
    const forecastDivElement = document.getElementById('forecast');
    const currentWeatherDivElement = document.getElementById('current');
    const upcomingForecastDivElement = document.getElementById('upcoming');

    const htmlSymbols = {
        Sunny: '&#x2600;',
        'Partly sunny': '&#x26C5;',
        Overcast: '&#x2601;',
        Rain: '&#x2614;',
        Degrees: '&#176;'
    };

    let errorShown = false;

    submitButtonElement.addEventListener('click', main);
    
    function main() {
        let cityInput = locationInputElement.value.toLocaleLowerCase();

        currentWeatherDivElement.innerHTML = '<div class="label">Current conditions</div>';
        upcomingForecastDivElement.innerHTML = '<div class="label">Three-day forecast</div>';

        if (errorShown) {
            forecastDivElement.removeChild(forecastDivElement.lastElementChild);
        }

        fetch('https://judgetests.firebaseio.com/locations.json')
            .then(res => res.json())
            .then(citiesData => findCity(citiesData, cityInput))
            .then(({code}) => requestWeatherInfoForCity(code))
            .catch(err => handleErrors());
        
        locationInputElement.value = '';
    }

    function findCity(data, city) {
        return data.find((obj) => obj.name.toLocaleLowerCase() === city);
    }

    function requestWeatherInfoForCity(cityCode) {
        return Promise.all([
            displayCurrentDayInfo(cityCode),
            displayNextDaysInfo(cityCode)
        ]);
    }

    function displayCurrentDayInfo(cityCode) {
        fetch(`https://judgetests.firebaseio.com/forecast/today/${cityCode}.json`)
            .then(res => res.json())
            .then(data => {
                let forecastsObj = data.forecast;
                
                const foreCastsDiv = createElement('div', ['forecasts']);
                const conditionSymbolSpan = createElement('span', ['condition', 'symbol'], htmlSymbols[forecastsObj.condition]);
                const conditionSpan = createElement('span', ['condition']);
                const nameSpan = createElement('span', ['forecast-data'], data.name);
                const temperatureSpan = createElement('span', ['forecast-data'], `${forecastsObj.low}${htmlSymbols.Degrees}/${forecastsObj.high}${htmlSymbols.Degrees}`);
                const weatherSpan = createElement('span',['forecast-data'], forecastsObj.condition);

                conditionSpan.append(nameSpan, temperatureSpan, weatherSpan);
                foreCastsDiv.append(conditionSymbolSpan, conditionSpan);

                forecastDivElement.style.display = 'block';
                currentWeatherDivElement.style.display = 'block'
                currentWeatherDivElement.appendChild(foreCastsDiv);
            })
    }

    function displayNextDaysInfo(cityCode) {
        fetch(`https://judgetests.firebaseio.com/forecast/upcoming/${cityCode}.json`)
            .then(res => res.json())
            .then(data => {
                const foreCastInfoDiv = createElement('div', ['forecast-info']);

                for (let i = 0; i < data.forecast.length; i++) {
                    let forecastsObj = data.forecast[i];
    
                    const upcomingSpan = createElement('span', ['upcoming']);
                    const symbolSpan = createElement('span', ['symbol'], htmlSymbols[forecastsObj.condition]);
                    const temperatureSpan = createElement('span', ['forecast-data'], `${forecastsObj.low}${htmlSymbols.Degrees}/${forecastsObj.high}${htmlSymbols.Degrees}`);
                    const weatherSpan = createElement('span', ['forecast-data'], forecastsObj.condition);

                    upcomingSpan.append(symbolSpan, temperatureSpan, weatherSpan);
                    foreCastInfoDiv.appendChild(upcomingSpan);
                }
                
                forecastDivElement.style.display = 'block';
                upcomingForecastDivElement.style.display = 'block'
                upcomingForecastDivElement.appendChild(foreCastInfoDiv);
            })
    }

    function handleErrors() {
        errorShown = true;

        currentWeatherDivElement.style.display = 'none';
        upcomingForecastDivElement.style.display = 'none';
        
        const errorDiv = createElement('div', ['label'], 'Error');
        forecastDivElement.style.display = 'block';
        forecastDivElement.appendChild(errorDiv);
    }

    function createElement(type, classNames, text) {
        const element = document.createElement(type);
        
        if (classNames) {
            element.classList.add(...classNames);
        }

        if (text) {
            element.innerHTML = text;
        }

        return element;
    }
}

attachEvents();