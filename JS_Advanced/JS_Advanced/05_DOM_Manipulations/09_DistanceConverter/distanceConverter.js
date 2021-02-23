function attachEventsListeners() {
    const inputUnits = document.getElementById('inputUnits');
    const outputUnits = document.getElementById('outputUnits');
    const convertButton = document.getElementById('convert');
    const inputDistance = document.getElementById('inputDistance');
    const outputDistance = document.getElementById('outputDistance');

    convertButton.addEventListener('click', () => {
        let inputValue = inputUnits.value;
        let outputValue = outputUnits.value;
        let inputDistanceValue = Number(inputDistance.value);

        let inputDistanceInMeters = convertToMeters(inputValue, inputDistanceValue);
        let resultDistance = convertMetersToOutputValue(outputValue, inputDistanceInMeters);

        outputDistance.value = resultDistance;
    })

    function convertToMeters(convertFrom, distance){
        switch (convertFrom) {
            case 'km': //kilometers
                return distance * 1000;
            case 'm': //meters
                return distance;
            case 'cm': //centimeters
                return distance * 0.01;
            case 'mm': //millimeters
                return distance * 0.001;
            case 'mi': //miles
                return distance * 1609.34;
            case 'yrd': //yards
                return distance * 0.9144;
            case 'ft': //feet
                return distance * 0.3048;
            case 'in': //inches
                return distance * 0.0254;
        }
    }

    function convertMetersToOutputValue(convertTo, distanceInMeters){
        switch (convertTo) {
            case 'km': //kilometers
                return distanceInMeters / 1000;
            case 'm': //meters
                return distanceInMeters;
            case 'cm': //centimeters
                return distanceInMeters / 0.01;
            case 'mm': //millimeters
                return distanceInMeters / 0.001;
            case 'mi': //miles
                return distanceInMeters / 1609.34;
            case 'yrd': //yards
                return distanceInMeters / 0.9144;
            case 'ft': //feet
                return distanceInMeters / 0.3048;
            case 'in': //inches
                return distanceInMeters / 0.0254;
        }
    }
}