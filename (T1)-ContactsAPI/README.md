# Contact API — Minimal CRUD Service

What this repo is: a minimal CRUD example suitable for portfolio use, demos, or as a starting point for client projects.

A compact, professional sample Contacts API built with .NET 9. This repository demonstrates a minimal, well-structured RESTful CRUD service that is easy to run locally, inspect with Swagger/OpenAPI, and extend for production use. It is suitable to share with potential clients as a demonstration of API design and implementation.

## Highlights

- Clean, minimal architecture using ASP.NET Core and Entity Framework Core
- Interactive API documentation via Swagger / OpenAPI
- Example-ready endpoints for common CRUD operations on `Contact` resources
- In-memory database for fast local demos, with guidance to switch to a persistent provider

- Model (fields): Contact has `Id`, `FirstName`, `LastName`, `Email`, `Number`.

## Technology Stack

- .NET 9
- ASP.NET Core Web API
- Entity Framework Core (In-Memory provider by default)
- Swagger / OpenAPI

## Quick Start (Local)

Prerequisites: .NET 9 SDK

1. From the project directory run:

   `dotnet run`

Note: If your browser warns about HTTPS during local testing, trust the .NET dev certificate with:

`dotnet dev-certs https --trust`

2. Open the Swagger UI (development environment):

   `https://localhost:{port}/swagger`

3. API base path:

   `https://localhost:{port}/api/contacts`

## API Endpoints

All examples assume the API base path is `https://localhost:{port}/api/contacts`.

- GET `/api/contacts`
  - Returns list of contacts
  - Example:
    `curl -sS https://localhost:{port}/api/contacts`

Example JSON response (single item):

```json
{
  "id": 1,
  "firstName": "Jane",
  "lastName": "Doe",
  "email": "jane@example.com",
  "number": "+1-555-0100"
}
```

- GET `/api/contacts/{id}`
  - Returns a single contact or 404
  - Example:
    `curl -sS https://localhost:{port}/api/contacts/1`

- POST `/api/contacts`
  - Create a new contact. Example request body:

    ```json
    { "firstName": "Jane", "lastName": "Doe", "email": "jane@example.com", "number": "+1-555-0100" }
    ```

  - Example:
    `curl -X POST -H "Content-Type: application/json" -d '{"firstName":"Jane","lastName":"Doe","email":"jane@example.com"}' https://localhost:{port}/api/contacts`

- PUT `/api/contacts/{id}`
  - Update an existing contact. Body same shape as POST.
  - Example:
    `curl -X PUT -H "Content-Type: application/json" -d '{"firstName":"Jane Updated"}' https://localhost:{port}/api/contacts/1`

- DELETE `/api/contacts/{id}`
  - Deletes the contact with the given id
  - Example:
    `curl -X DELETE https://localhost:{port}/api/contacts/1`

## Persistence & Production Readiness

- This template uses the EF Core In-Memory provider by default. Data does NOT persist across process restarts — appropriate for demos and local development.

To enable a persistent database:

1. Replace the In-Memory registration in `Program.cs` with a relational provider (for example `UseSqlServer` or `UseNpgsql`).
2. Add the corresponding EF Core provider NuGet package, e.g. `Microsoft.EntityFrameworkCore.SqlServer`.
3. Enable and apply EF Core migrations:

   `dotnet ef migrations add InitialCreate`
   `dotnet ef database update`

## Development Notes

- Model: see `Models/Contact.cs` for the contact schema and validation defaults.
- Main entry: `Program.cs` configures services, EF Core, and Swagger.
- Controller: `Controllers/ContactController.cs` implements the CRUD endpoints.

## Customization Ideas (optional)

This template is intentionally minimal. Simple, safe enhancements you may add when appropriate:

- Switch to a persistent database and enable EF Core migrations
- Add basic request validation or small logging improvements

## Contributing

Contributions and improvements are welcome. If you change the project for your own use, consider updating the `README.md` and adding a license before publishing.

## License

Select and include a license (for example `MIT`) when you publish this repository.
