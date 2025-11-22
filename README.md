# 📝 ToDoList – Full Stack MVC + API (.NET 9)

A simple To-Do list built with:

- **Backend:** ASP.NET Core Web API + Entity Framework Core + Azure SQL  
- **Frontend:** ASP.NET Core MVC consuming the API via HttpClient + Newtonsoft.Json  

## 📁 Solution Structure
```
ToDoList/
│
├── ToDo-Backend/        # ASP.NET Core Web API
│   ├── Models/          # ToDo_Intity entity
│   ├── Data/            # ApplicationDbcontext (EF Core)
│   ├── Controllers/     # TodosController (CRUD + Toggle)
│   └── appsettings.json # Connection string to Azure SQL
│
├── ToDo-Frontend/       # ASP.NET Core MVC app
│   ├── Models/          # TodoDto (matches backend JSON)
│   ├── Services/        # TodoApiService (calls API using HttpClient + Newtonsoft)
│   ├── Controllers/     # MVC controller calling TodoApiService
│   ├── Views/           # Razor pages for list, add, toggle, delete
│   └── appsettings.json # API BaseUrl config
│
└── README.md
```

## ⚙️ Backend Setup (ToDo-Backend)

1. **Restore packages & build**
   ```bash
   dotnet restore
   dotnet build
   ```
2. **Run EF Core migrations**
   ```powershell
   Add-Migration InitialCreate -OutputDir Data\Migrations -Context ApplicationDbcontext
   Update-Database -Context ApplicationDbcontext
   ```
3. **Run the API**
   ```bash
   dotnet run
   ```
   Backend will start at `https://localhost:5001`.

### 🔑 API Endpoints
| Method | URL | Description |
|--------|-----|--------------|
| GET | `/api/todos` | List all todos |
| GET | `/api/todos/{id}` | Get one |
| POST | `/api/todos` | Create |
| PUT | `/api/todos/{id}` | Update |
| DELETE | `/api/todos/{id}` | Delete |
| POST | `/api/todos/toggle/{id}` | Toggle completion |

## 🖥️ Frontend Setup (ToDo-Frontend)

1. **Open appsettings.json** and set your API URL:
   ```json
   "Api": {
     "BaseUrl": "https://localhost:5001"
   }
   ```
2. **Install Newtonsoft.Json**
   ```powershell
   Install-Package Newtonsoft.Json
   ```
3. **Run the MVC app**
   ```bash
   dotnet run
   ```
   Browse to `https://localhost:7069` (or the port shown in the console).

## 🧠 How It Works
- MVC frontend uses `TodoApiService` to call the backend API.
- The service sends/receives JSON using **HttpClient** and **Newtonsoft.Json**.
- Backend saves todos to **Azure SQL** via EF Core.
- `Toggle` endpoint flips `IsCompleted` with a single click.

## 🚀 Next Steps
- Add authentication or user accounts.
- Deploy both apps to **Azure App Service**.
- Switch frontend HttpClient base URL to production API.
