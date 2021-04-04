# .NET REST API

## Technologies 
- .net core 3.1
- CQRS
- Entity Framework
- Onion Architecture

Contains 17 Unit tests (I am not covering all the code, but I did all the different scenarios)

Post 
link: https://localhost:5001/orders

payload:
```json
{
    "OrderNumber": "1",
    "Items":[
    {
        "ItemNumber": "123",
        "Quantity": "2"
    },{
        "ItemNumber": "127",
        "Quantity": "1"
    }]
}
```

Get
link: https://localhost:5001/orders/1