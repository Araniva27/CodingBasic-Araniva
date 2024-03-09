const getAllPeople = () => {
    
    var pageNumber = $('#pageNumber').val();
    var pageSize = $('#pageSize').val();

    if(pageNumber >= 1 && pageSize >= 1)
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Person?pageNumber=${pageNumber}&pageSize=${pageSize}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 
                $('#people-table tbody').empty();

                // 
                $.each(data, function (index, person) {
                    $('#people-table tbody').append(`
                        <tr>
                            <th scope="row">${person.businessEntityId}</th>
                            <td>${person.firstName}</td>
                            <td>${person.middleName}</td>
                            <td>${person.lastName}</td>
                            <td>${person.jobTitle}</td>
                            <td>${person.phoneNumber}</td>
                            <td>${person.city}</td>
                            <td>${person.stateProvinceName}</td>
                            <td>${person.countryRegionName}</td>
                        </tr>
                    `);
                });     
            },

            error : function(xhr, status) {
                alert('Ha ocurrido un error al obtener la información');       
            },       
        });

    }else{
        Swal.fire({
            title: "Warning",
            text: "You must enter valid values",
            icon: "warning"
        });
    }        
}


const getPeopleByName = () => {
        
    var employeeName = $('#employeeName').val();

    if(employeeName != '')
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Person/${employeeName}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 
                $('#peopleByName-table tbody').empty();

                // 
                $.each(data, function (index, person) {
                    $('#peopleByName-table tbody').append(`
                        <tr>
                            <th scope="row">${person.businessEntityID}</th>
                            <td>${person.employeeName}</td>
                            <td>${person.gender}</td>
                            <td>${person.jobTitle}</td>                            
                            <td>${person.dateOfBirth}</td>
                            <td>${person.hireDate}</td>
                            <td>${person.vacationHours}</td>
                        </tr>
                    `);
                });                     
            },

            error : function(xhr, status) {
                alert('Ha ocurrido un error al obtener la información');       
            },       
        });

    }else{
        Swal.fire({
            title: "Warning",
            text: "You must enter valid values",
            icon: "warning"
        });
    }        
}

const getPeopleByType = () => {
        
    var employeeType = $('#employeeType').val();

    if(employeeType != '')
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Person/personType/${employeeType}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 
                $('#peopleByType-table tbody').empty();

                // 
                $.each(data, function (index, person) {
                    $('#peopleByType-table tbody').append(`
                        <tr>
                            <th scope="row">${person.businessEntityID}</th>
                            <td>${person.employeeName}</td>
                            <td>${person.gender}</td>
                            <td>${person.jobTitle}</td>                            
                            <td>${person.dateOfBirth}</td>
                            <td>${person.hireDate}</td>
                            <td>${person.vacationHours}</td>
                        </tr>
                    `);
                });                     
            },

            error : function(xhr, status) {
                alert('Ha ocurrido un error al obtener la información');       
            },       
        });

    }else{
        Swal.fire({
            title: "Warning",
            text: "You must enter valid values",
            icon: "warning"
        });
    }        
}

const getPeopleByNameAndType = () => {
        
    var employeeType = $('#employeeType').val();
    var employeeName = $('#employeeName').val();

    if(employeeType != '' && employeeName != '')
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Person/personByNameAndPersonType?name=${employeeName}&personType=${employeeType}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 
                $('#peopleByTypeAndName-table tbody').empty();

                // 
                $.each(data, function (index, person) {
                    $('#peopleByTypeAndName-table tbody').append(`
                        <tr>
                            <th scope="row">${person.businessEntityID}</th>
                            <td>${person.employeeName}</td>
                            <td>${person.gender}</td>
                            <td>${person.jobTitle}</td>                            
                            <td>${person.dateOfBirth}</td>
                            <td>${person.hireDate}</td>
                            <td>${person.vacationHours}</td>
                        </tr>
                    `);
                });                                     
            },

            error : function(xhr, status) {
                alert('Ha ocurrido un error al obtener la información');       
            },       
        });

    }else{
        Swal.fire({
            title: "Warning",
            text: "You must enter valid values",
            icon: "warning"
        });
    }        
}