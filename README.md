# LocalDataService

A lightweight C# library for local data persistence using JSON files. This service provides a simple and efficient way to store and retrieve typed data locally with automatic serialization/deserialization.

## 🚀 Features

- **Type-safe data access** - Generic methods ensure compile-time type safety
- **Automatic JSON serialization** - Uses Newtonsoft.Json for reliable data persistence
- **In-memory caching** - Fast data access with automatic file synchronization
- **File-based storage** - Data stored as human-readable JSON files in `JSonData` directory


## 🛠️ Installation

1. Clone the repository:
```bash
git clone https://github.com/yourusername/local_data_service_CSharp.git
cd local_data_service_CSharp
```

2. Build the project:
```bash
dotnet build
```

3. Run the project:
```bash
dotnet run --project LocalDataService
```

## 📖 Usage

### Basic Usage

```csharp
using LocalDataService;

// Create an instance of the service
var localDataService = new LocalDatasService();

// Get data of a specific type
var dataList = localDataService.Get<List<DataB>>();

// Modify the data
dataList.Add(new DataB());

// Dispose to save changes automatically
localDataService.Dispose();
```

### Using Statement (Recommended)

```csharp
using (var localDataService = new LocalDatasService())
{
    var dataList = localDataService.Get<List<DataB>>();
    dataList.Add(new DataB());
    
    // Data is automatically saved when disposed
}
```

## 🏗️ Architecture

### Core Components

1. **LocalDatasService** - Main service class that manages data access and persistence
2. **DataRepository** - Registers and configures available data types
3. **DataModel<T>** - Generic wrapper for typed data with persistence capabilities
4. **JsonManager<T>** - Handles JSON serialization/deserialization
5. **IDataModel** - Interface defining the contract for data models



## 🔧 Configuration

### Adding New Data Types

1. Define your data class in `DatasRepository.cs`:
```csharp
public class MyNewData
{
    public string Name { get; set; }
    public int Value { get; set; }
}
```

2. Register it in `DataRepasitory.cs`:
```csharp
private void RegisterRepasitory()
{
    // Existing registrations...
    AddData<MyNewData>("MyDataFile");
}
```

3. Use it in your application:
```csharp
var myData = localDataService.Get<MyNewData>();
```

## 💾 Data Storage

- All data is stored in the `JSonData` directory
- Files are created automatically if they don't exist
- Data is saved as `.txt` files containing JSON
- Files are human-readable and can be manually edited if needed

## 🔒 Error Handling

The service throws an exception if you try to access a data type that hasn't been registered:

```csharp
// This will throw an exception if UnregisteredType is not in the repository
var data = localDataService.Get<UnregisteredType>();
// Exception: "There is no such data in the local storage"
```