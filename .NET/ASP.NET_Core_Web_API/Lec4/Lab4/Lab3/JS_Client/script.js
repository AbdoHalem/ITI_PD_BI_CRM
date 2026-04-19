async function getStudents(){
    // URL of the students API (ASP.NET Web API)
    const API_URL = 'https://localhost:7259/api/Students';

    // Clear the table
    document.getElementById('students-body').innerHTML = '';

    // Fetch students from the API
    try{
        const response = await fetch(API_URL);
        if(response.ok){
            const students = await response.json();
            // TODO: Display students in the UI
            document.getElementById('students-body').innerHTML = students.map(student => `
                <tr>
                    <td>${student.st_Id}</td>
                    <td>${student.st_Fname}</td>
                    <td>${student.st_Lname}</td>
                    <td>${student.st_Address}</td>
                    <td>${student.st_Age}</td>
                    <td>${student.dept_Name}</td>
                    <td>${student.supervisor_Name}</td>
                </tr>
            `).join('');
        }
    }
    catch(error){
        console.error("Error fetching students");
    }
}