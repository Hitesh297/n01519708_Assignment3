function UpdateTeacher() {

	var URL = "http://localhost:61525/api/TeacherData/UpdateTeacher";

	var rq = new XMLHttpRequest();

	var TeacherFname = document.getElementById('FirstName').value;
	var TeacherLname = document.getElementById('LastName').value;
	var TeacherEmployeeNumber = document.getElementById('EmployeeNumber').value;
	var TeacherSalary = document.getElementById('Salary').value;
	var TeacherId = document.getElementById('TeacherId').value;

	//validate if first name is empty
	var fnameError = document.getElementById('fnameError');
	if (TeacherFname === null || TeacherFname === "") {
		fnameError.style.display = 'block';
		return;
	} else {
		fnameError.style.display = 'none';
    }

	//validate is last name is empty
	var lnameError = document.getElementById('lnameError');
	if (TeacherLname === null || TeacherLname === "") {
		lnameError.style.display = 'block';
		return;
	} else {
		lnameError.style.display = 'none';
    }

	//validate if salary is empty
	var salaryError = document.getElementById('salaryError');
	if (TeacherSalary === null || TeacherSalary === "") {
		salaryError.style.display = 'block';
		return;
	} else {
		salaryError.style.display = 'none';
    }


	var TeacherData = {
		"teacherId": TeacherId,
		"firstName": TeacherFname,
		"lastName": TeacherLname,
		"employeeNumber": TeacherEmployeeNumber,
		"salary": TeacherSalary
	};


	rq.open("POST", URL, true);
	rq.setRequestHeader("Content-Type", "application/json");
	rq.onreadystatechange = function () {
		//we return void so we check for 204
		if (rq.readyState == 4 && rq.status == 204) {
			//request is successful and the request is finished
			var successmsg = document.getElementById('successmsg');
			console.log(successmsg);
			successmsg.style.display = 'block';
			window.location.href = "http://localhost:61525/Teacher/show/"+ TeacherId;

		}

	}
	//POST information sent through the .send() method
	rq.send(JSON.stringify(TeacherData));

}