# NexaWorks
OpenClassrooms Projet 6 : Modélisez et créez une base de données pour une application .NET

## Entity-Relationship Diagram (ERD)

The following diagram represents the entity-relationship model of the NexaWorks ticketing system:

### Entities

- **Product**
  - **Id**: Primary key, unique identifier for each product.
  - **Name**: The name of the product.
  
- **Version**
  - **Id**: Primary key, unique identifier for each version.
  - **Number**: The version number (e.g., 1.0, 2.0).
  - **ProductId**: Foreign key linking to the `Product` entity.

- **OperatingSystem**
  - **Id**: Primary key, unique identifier for each operating system.
  - **Name**: The name of the operating system (e.g., Windows, macOS, Linux).

- **Ticket**
  - **Id**: Primary key, unique identifier for each ticket.
  - **Problem**: Description of the problem reported.
  - **Resolution**: Description of how the problem was resolved.
  - **CreationDate**: The date when the ticket was created.
  - **ResolutionDate**: The date when the ticket was resolved (if resolved).
  - **Status**: The current status of the ticket (e.g., "En cours", "Résolu").
  - **ProductId**: Foreign key linking to the `Product` entity.
  - **VersionId**: Foreign key linking to the `Version` entity.
  - **OperatingSystemId**: Foreign key linking to the `OperatingSystem` entity.

### Relationships

- **Product** has a **one-to-many** relationship with **Version**.
- **Ticket** has a **many-to-one** relationship with **Product**.
- **Ticket** has a **many-to-one** relationship with **Version**.
- **Ticket** has a **many-to-one** relationship with **OperatingSystem**.

### UML Diagram

To visualize the UML diagram, use the following diagram:

![UML Diagram](https://uml.benoitpodwinski.com/uml/bL0n3i8m3Dpx2giZKZ_02WiBHO3OqzQ2Y2P1YJD4BNydWHIQggh4PFbyvpiR9N5oa1-qQcnDENGPm0fs3Qo1ItetUoRGjuOqbzVicMKOHHVKXYivBxAYGlsJ1IoQV7cZLUK3DIDFF3b3AFxBSURr7UUpUykgHP7cEA9HhIKVFSKt6bb0juo2KIYbRDr4CpSz4IDhbgyDMFnOWarE7tydhe2-BmhL3Me_ps_CW63IvLFEvnSfPT0jK2OX5gWl)