# Enterprise Info Manager

Enterprise Info Manager is an ASP.NET Core MVC application that manages employees and departments. The application uses MongoDB for data storage.

## Features

- Create, read, update, and delete (CRUD) operations for employees and departments.
- Validation for input fields.
- Error handling and logging.
- Seed database with initial data.

## Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MongoDB](https://www.mongodb.com/try/download/community)

## Setup

1. **Clone the repository:**

    ```bash
    git clone https://github.com/yourusername/EnterpriseInfoManager.git
    cd EnterpriseInfoManager
    ```

2. **Install dependencies:**

    ```bash
    dotnet restore
    ```

3. **Configure MongoDB:**

    Ensure MongoDB is running on your machine. Update the `appsettings.json` file with your MongoDB connection string and database name.

    **appsettings.json**
    ```json
    {
      "MongoDBSettings": {
        "ConnectionString": "mongodb://localhost:27017",
        "DatabaseName": "EnterpriseInfoManager"
      },
      "Logging": {
        "LogLevel": {
          "Default": "Information",
          "Microsoft": "Warning",
          "Microsoft.Hosting.Lifetime": "Information"
        }
      },
      "AllowedHosts": "*"
    }
    ```

4. **Run the application:**

    ```bash
    dotnet run
    ```

5. **Open the application:**

    Open your web browser and navigate to `http://localhost:5000`.

## Project Structure

- **Controllers:** Contains the MVC controllers for handling HTTP requests.
- **Models:** Contains the data models for employees and departments.
- **Repositories:** Contains the repository classes for data access.
- **Views:** Contains the Razor views for rendering HTML pages.
- **Data:** Contains the database seeder for seeding initial data.

## Usage

### Employees

- **List Employees:** Navigate to `http://localhost:5000/Employees`
- **Create Employee:** Navigate to `http://localhost:5000/Employees/Create`
- **Edit Employee:** Navigate to `http://localhost:5000/Employees/Edit/{id}`
- **Delete Employee:** Navigate to `http://localhost:5000/Employees/Delete/{id}`

### Departments

- **List Departments:** Navigate to `http://localhost:5000/Departments`
- **Create Department:** Navigate to `http://localhost:5000/Departments/Create`
- **Edit Department:** Navigate to `http://localhost:5000/Departments/Edit/{id}`
- **Delete Department:** Navigate to `http://localhost:5000/Departments/Delete/{id}`

## Error Handling

The application uses middleware to catch and log errors. If an error occurs, a user-friendly error page is displayed.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.