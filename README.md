## Calculator API
A small .NET 8 Web API that performs basic arithmetic operations (add, subtract, multiply, divide). The project includes request logging, API‑key authentication, and unit tests.
### Running the API
- Requires .NET 8 SDK
- Clone the repository and run:
```
dotnet run --project Calculator.Api
```

The API will start on `https://localhost:<port>` and expose Swagger at:
```
/swagger
```

### Authentication
All endpoints require an API key sent via header:
```
X-Api-Key: <your-key>
```

The key is configured in `appsettings.json`.
### Endpoints
All endpoints are under the `Calculation` controller:
- POST /calculation/add
- POST /calculation/subtract
- POST /calculation/multiply
- POST /calculation/divide
Each accepts a JSON body:
```json
{
  "x": 10,
  "y": 5
}
```

### Postman Collection
A Postman collection is included in the repository:
```
/postman/Calculator.postman_collection.json
```

It contains all endpoints and the required API‑key header.
### Tests
Unit tests are located in:
`Calculator.Tests`


They cover the calculator service logic.
