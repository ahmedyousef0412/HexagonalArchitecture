Purpose:
This project contains the technical implementations of the abstractions defined in the [ Core ].
It acts as the [outbound adapter] in Hexagonal Architecture — handling database access, file storage, or external API calls.







-----------------------------------------------------------------------------

Responsibilities:

Implements repositories (e.g., OrderRepository).

Provides EF Core DbContext and entity configurations.

Handles migrations and database connection.

Registers dependencies for dependency injection.


-----------------------------------------------------------------------------


Persistence/
 ├── AppDbContext.cs          → EF Core context class.
 ├── Repositories/            → Concrete implementations of IOrderRepository.
 └── Configurations/          → Fluent API configurations for entities.

DependencyInjection/
 └── ServiceRegistration.cs   → Registers Infrastructure services in DI container.

------------------------------------------------------------------------------

Dependencies:

Depends on Core

Uses Microsoft.EntityFrameworkCore, SQL Server, and Microsoft.Extensions.DependencyInjection