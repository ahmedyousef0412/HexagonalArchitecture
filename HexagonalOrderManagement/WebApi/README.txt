

Purpose:
This project is the entry point — the driving adapter in Hexagonal Architecture.
It exposes the API endpoints and translates HTTP requests into application commands.


-----------------------------------------------------------------------------

Responsibilities:

Provides RESTful endpoints (Controllers).

Maps DTOs between HTTP and application layer.

Configures the application startup (DI, Swagger, EF Core, etc.).

Acts as the bridge between clients and business logic.


-----------------------------------------------------------------------------

Controllers/
 └── OrdersController.cs      → Exposes endpoints for order operations.

DependencyInjection/
 └── ApplicationRegistration.cs  → Registers Core services and handlers.

Program.cs                    → Main entry point, configures the app.
appsettings.json              → Database connection and environment settings.


-----------------------------------------------------------------------------

Dependencies:

Depends on Core and Infrastructure

Uses ASP.NET Core, Swagger, and EF Core