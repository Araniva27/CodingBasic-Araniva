const getAllProducts = () => {
    
    var pageNumber = $('#pageNumber').val();
    var pageSize = $('#pageSize').val();

    if(pageNumber >= 1 && pageSize >= 1)
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Product?pageNumber=${pageNumber}&pageSize=${pageSize}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 
                $('#products-table tbody').empty();

                // 
                $.each(data, function (index, product) {
                    $('#products-table tbody').append(`
                        <tr>
                            <th scope="row">${product.productId}</th>
                            <td>${product.name}</td>
                            <td>${product.productNumber}</td>
                            <td>${product.sellStartDate}</td>
                            <td>${product.safetyStockLevel}</td>
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

const getProductsByName = () => {
    
    var productName = $('#productName').val();    

    if(productName != '')
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Product/${productName}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 
                $('#productsByName-table tbody').empty();

                // 
                $.each(data, function (index, product) {
                    $('#productsByName-table tbody').append(`
                        <tr>
                            <th scope="row">${product.productId}</th>
                            <td>${product.name}</td>
                            <td>${product.productNumber}</td>
                            <td>${product.sellStartDate}</td>
                            <td>${product.safetyStockLevel}</td>
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

const getProductsByCategoryType = () => {
    
    var categoryType = $('#categoryType').val();    

    if(categoryType != '')
    {
        $.ajax({
            // 
            url : `http://localhost:5168/Product/ProductByCategoryType/${categoryType}`,            
            type : 'GET',        
            dataType : 'json',
                
            success : function(data) {
            // 
                $('#productsByCategory-table tbody').empty();

                // 
                $.each(data, function (index, product) {
                    $('#productsByCategory-table tbody').append(`
                        <tr>
                            <th scope="row">${product.productId}</th>
                            <td>${product.name}</td>
                            <td>${product.productNumber}</td>
                            <td>${product.sellStartDate}</td>
                            <td>${product.safetyStockLevel}</td>
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