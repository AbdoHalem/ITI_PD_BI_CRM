// 1. Import the generated message classes and the service client
const { OrderRequest, OrderItem } = require('./order_pb.js');
const { OrderServiceClient } = require('./order_grpc_web_pb.js');

// 2. Create an instance of the client
// IMPORTANT: Make sure this URL matches the OrderService port in Visual Studio!
const client = new OrderServiceClient('https://localhost:7282', null, null);

// 3. Create the order request object
const request = new OrderRequest();
request.setOrderid(1050); // Random Order ID
request.setUserid(1);     // User 1 exists in the Payment service
request.setPrice(0);      // Price will be calculated by the backend

// 4. Create an item and add it to the order
const item1 = new OrderItem();
item1.setItemid(1);       // Item 1 exists in the Inventory service
item1.setQuantity(2);     // Asking for 2 items
item1.setPrice(50);       // Price per item is 50

// Add the item to the request
request.addItems(item1);

console.log('Sending CreateOrder request to the gRPC backend...');

// 5. Call the gRPC method on the server
client.createOrder(request, {}, (err, response) => {
    const resultDiv = document.getElementById('result');
    
    if (err) {
        console.error('Error occurred:', err.message);
        resultDiv.innerText = 'Error: ' + err.message;
        resultDiv.style.color = 'red';
        return;
    }

    // 6. Read the properties from the response
    const isSuccess = response.getIssuccess();
    const message = response.getMessage();

    console.log('Is Success:', isSuccess);
    console.log('Message:', message);

    // Display the result on the screen
    resultDiv.innerText = `Status: ${isSuccess ? 'Success' : 'Failed'} \nMessage: ${message}`;
    resultDiv.style.color = isSuccess ? 'green' : 'orange';
});