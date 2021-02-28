function getInfoForPerson(name, age, weightInKgs, heightInCms){
    let heightInMeters = heightInCms / 100;
    let bmiIndex = weightInKgs / (heightInMeters ** 2);

    let status = '';

    switch (true) {
        case bmiIndex < 18.5: status = 'underweight'; break;
        case bmiIndex < 25: status = 'normal'; break;
        case bmiIndex < 30: status = 'overweight'; break;
        default: status = 'obese';
    }

    let result = {};
    let personalInfoObj = {};

    result['name'] = name;
    personalInfoObj['age'] = age;
    personalInfoObj['weight'] = weightInKgs;
    personalInfoObj['height'] = heightInCms;
    result['personalInfo'] = personalInfoObj;
    result['BMI'] = Math.round(bmiIndex);
    result['status'] = status;

    if (status === 'obese'){
        result['recommendation'] = 'admission required';
    }

    console.log(result);
}

getInfoForPerson('Peter', 29, 75, 182);

getInfoForPerson('Honey Boo Boo', 9, 57, 137);