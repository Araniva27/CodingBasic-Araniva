const getAllSales = () => {
    
    var pageNumber = $('#pageNumber').val();    
    var pageSize = $('#pageSize').val();    

    if(pageNumber >= 1 && pageSize >= 1)
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Sale?pageNumber=${pageNumber}&pageSize=${pageSize}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 

                $('#allSales-table tbody').empty();
                $.each(data, function (index, sale) {
                    $('#allSales-table tbody').append(`
                        <tr>
                            <th scope="row">${sale.businessEntityId}</th>
                            <td>${sale.firstName}</td>
                            <td>${sale.middleName}</td>
                            <td>${sale.jobTitle}</td>
                            <td>${sale.phoneNumber}</td>
                            <td>${sale.city}</td>
                            <td>${sale.stateProvinceName}</td>
                            <td>${sale.emailAddress}</td>
                            <td>${sale.salesYtd.toFixed(2)}</td>
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

const getSalesByPerson = () => {
    
    var pageNumber = $('#pageNumber').val();    
    var pageSize = $('#pageSize').val();  
    var personName = $('#PersonName').val();
    var year = $('#txtYear').val();  

    if(pageNumber >= 1 && pageSize >= 1)
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Sale/getSalesByPerson?personName=${personName}&year=${year}&pageNumber=${pageNumber}&pageSize=${pageSize}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 

                $('#salesByPerson-table tbody').empty();
                $.each(data, function (index, sale) {
                    $('#salesByPerson-table tbody').append(`
                        <tr>
                            <th scope="row">${sale.businessEntityID}</th>
                            <td>${sale.salesOrderNumber}</td>
                            <td>${sale.salesPersonName}</td>
                            <td>${sale.territoryName}</td>
                            <td>${sale.dueDate}</td>
                            <td>${sale.subTotal.toFixed(2)}</td>
                            <td>${sale.totalDue.toFixed(2)}</td>
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
