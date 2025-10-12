HexagonalOrderManagement.Core

Purpose:
This is the heart of the system — it contains both the Domain layer and Application layer (the business logic and use cases).
It defines what the system does, independent of frameworks, databases, or APIs.

-----------------------------------------------------------------------------

Responsibilities:

Defines domain entities (e.g., Order, OrderItem).

Declares domain interfaces like repositories (IOrderRepository).

Contains business rules and invariants (e.g., cannot cancel confirmed order).

Contains use cases / handlers (e.g., CreateOrderHandler).

Returns results using clean data transfer models (DTOs).

-----------------------------------------------------------------------------

Domain/
 ├── Entities/          → Core business models and behavior.
 ├── Interfaces/        → Abstractions for repositories.
 └── Exceptions/        → Domain-specific exceptions.

Application/
 ├── Commands/          → Input data for actions (CreateOrderCommand).
 ├── Handlers/          → Implements use cases (CreateOrderHandler).
 ├── DTOs/              → Data returned to other layers.
 ├── Services/          → Application-level interfaces.
 └── Common/            → Utility classes (Result, Validation, etc.)

 -----------------------------------------------------------------------------

 Dependencies:
    No external dependencies (pure C#).
    Only referenced by Infrastructure, WebApi, and Tests.