function OnBirthNumberCheckboxChange(isChecked) {
    let birthNumberInput = document.getElementById("birthNumber");
    if (isChecked == true) {
        birthNumberInput.value = "";
        birthNumberInput.disabled = true;
    }
    else {
        birthNumberInput.disabled = false;
    }
}

function ComputeBirthday(birthNumber) {
    let today = new Date();
    let pattern = /^[0-9]{6}\/[0-9]{3,4}$/;
    if (pattern.test(birthNumber)) {
        let year = birthNumber.substr(0, 2);
        if (year > today.getFullYear() - 2000)
            year = '19'+year;
        else
            year = '20'+year; 

        let month = birthNumber.substr(2, 2);
        if (month >= 50)
            month = month - 50;  

        if (month >= 20)
            month = month - 20; 

        let day = birthNumber.substr(4, 2);
        let birthday = year + "-" + month + "-" + day;
        document.getElementById("birthday").value = birthday;
        return birthday;
    }
}

