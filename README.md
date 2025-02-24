# Pizza Palace API

Welcome to the Pizza Palace API project! This API is designed to manage pizza ordering and delivery tracking. Below you will find information on how to set up and use the API.

## Features

- **Pizza Ordering Management**: Create, retrieve, and manage pizza orders.
- **Delivery Tracking**: Schedule and track deliveries for pizza orders.
- **Health Checks**: Monitor the health of the application to ensure it is running smoothly.

## Project Structure

The project is organized into several folders:

- **Controllers**: Contains the API controllers for handling HTTP requests.
  - `OrdersController.cs`: Manages pizza order requests.
  - `DeliveriesController.cs`: Manages delivery requests.

- **Models**: Contains the data models used in the application.
  - `Order.cs`: Represents a pizza order.
  - `Delivery.cs`: Represents a delivery.

- **Repositories**: Contains the data access layer for managing orders and deliveries.
  - `IOrderRepository.cs` / `OrderRepository.cs`: Interfaces and implementations for order management.
  - `IDeliveryRepository.cs` / `DeliveryRepository.cs`: Interfaces and implementations for delivery management.

- **Services**: Contains business logic related to orders and deliveries.
  - `OrderService.cs`: Contains methods for placing and retrieving orders.
  - `DeliveryService.cs`: Contains methods for scheduling and tracking deliveries.

- **Tests**: Contains unit tests for controllers, repositories, and services to ensure the application behaves as expected.

## Setup Instructions

1. Clone the repository:
   ```
   git clone <repository-url>
   ```

2. Navigate to the project directory:
   ```
   cd PizzaPalaceApi
   ```

3. Restore the dependencies:
   ```
   dotnet restore
   ```

4. Run the application:
   ```
   dotnet run
   ```

5. Access the API documentation at `/swagger` after the application starts.

## Usage

- **Create an Order**: Send a POST request to `/api/orders` with the order details.
- **Get an Order**: Send a GET request to `/api/orders/{id}` to retrieve a specific order.
- **Create a Delivery**: Send a POST request to `/api/deliveries` with the delivery details.
- **Get Delivery Status**: Send a GET request to `/api/deliveries/{id}` to retrieve the status of a specific delivery.

## Health Checks

The API includes health checks that can be accessed at `/health` to monitor the application's status.

## Contributing

Contributions are welcome! Please submit a pull request or open an issue for any enhancements or bug fixes.

## License

This project is licensed under the MIT License. See the LICENSE file for details.