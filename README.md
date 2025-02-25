# 🎵 Melody Record Shop 🎶

This is a backend API built using ASP.NET Core, designed to manage inventory for an e-commerce platform **Melody Record Shop**, a music album superstore. 
It provides endpoints for CRUD operations and integrates with a secure database and authentication system.



## 💡 Features

- **List all albums in stock**  
  Easily see every album we currently have available.

- **Get album by ID**  
  Retrieve detailed information about a specific album using its unique ID.

- **Add new albums to the database**  
  Update the inventory with new stock as it arrives.

- **Update album details**  
  Modify the details of an album, like stock quantity, title, or genre.

- **Delete albums from the database**  
  Remove albums that are no longer part of our catalog.

---

## 🚀 Getting Started

### Prerequisites

Before running the project, ensure the following are installed:
- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher)
- [SQL Server](https://www.microsoft.com/en-us/sql-server) or any other supported database


## API Documentation

### Example Endpoints
- **GET /api/albums**: Retrieve all albums.
- **GET /api/albums/id**: Retrieve an albums by it's id.
- **GET /api/albums/filter?artist=The%20Beatles&genre=0**: Filter albums by it's Title/Artist/Genre/ReleaseYear.
- **POST /api/albums**: Add a new albums.
- **PATCH /api/albums/id**: Update album details.
- **DELETE /api/albums/id**: Delete an album.



## Technologies Used
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Swagger/OpenAPI
