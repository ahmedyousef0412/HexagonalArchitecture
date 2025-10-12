

Purpose:
This project contains unit tests for the Core layer — ensuring the domain logic and use cases behave correctly.


-----------------------------------------------------------------------------

Responsibilities:

Test domain behavior (entities and value objects).

Test use case handlers and business rules.

Use mocking to isolate dependencies.


-----------------------------------------------------------------------------

DomainTests/
 └── OrderTests.cs             → Tests for domain entity logic.

ApplicationTests/
 └── CreateOrderHandlerTests.cs → Tests for use case behavior.

TestUtilities/
 └── FakeRepositories.cs       → Fake or in-memory repositories for testing.


 -----------------------------------------------------------------------------

 Dependencies:

Depends on HexagonalOrderManagement.Core

Uses xUnit and FluentAssertions 