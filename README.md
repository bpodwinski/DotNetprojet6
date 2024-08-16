# NexaWorks
OpenClassrooms Projet 6 : Modélisez et créez une base de données pour une application .NET

## Entity-Relationship Diagram (ERD)

Le diagramme suivant représente le modèle entité-association du système de gestion des tickets de NexaWorks :

## Entités

- **Produit (Product)**
  - **Id** : Clé primaire, identifiant unique pour chaque produit.
  - **Nom (Name)** : Le nom du produit.

- **Version**
  - **Id** : Clé primaire, identifiant unique pour chaque version.
  - **Numéro (Number)** : Le numéro de version (par exemple, 1.0, 2.0).
  - **ProductId** : Clé étrangère reliant à l'entité Produit.

- **Système d'Exploitation (OperatingSystem)**
  - **Id** : Clé primaire, identifiant unique pour chaque système d'exploitation.
  - **Nom (Name)** : Le nom du système d'exploitation (par exemple, Windows, macOS, Linux).

- **Ticket**
  - **Id** : Clé primaire, identifiant unique pour chaque ticket.
  - **Problème (Problem)** : Description du problème signalé.
  - **Résolution (Resolution)** : Description de la manière dont le problème a été résolu.
  - **Date de Création (CreationDate)** : La date à laquelle le ticket a été créé.
  - **Date de Résolution (ResolutionDate)** : La date à laquelle le ticket a été résolu (si résolu).
  - **Statut (Status)** : Le statut actuel du ticket (par exemple, "En cours", "Résolu").
  - **ProductId** : Clé étrangère reliant à l'entité Produit.
  - **VersionId** : Clé étrangère reliant à l'entité Version.
  - **OperatingSystemId** : Clé étrangère reliant à l'entité Système d'Exploitation.

## Relations

- **Produit** a une relation **un-à-plusieurs** avec **Version**.
- **Ticket** a une relation **plusieurs-à-un** avec **Produit**.
- **Ticket** a une relation **plusieurs-à-un** avec **Version**.
- **Ticket** a une relation **plusieurs-à-un** avec **Système d'Exploitation**.

### UML Diagramme

![UML Diagram](https://uml.benoitpodwinski.com/png/bL0n3i8m3Dpx2giZKZ_02WiBHO3OqzQ2Y2P1YJD4BNydWHIQggh4PFbyvpiR9N5oa1-qQcnDENGPm0fs3Qo1ItetUoRGjuOqbzVicMKOHHVKXYivBxAYGlsJ1IoQV7cZLUK3DIDFF3b3AFxBSURr7UUpUykgHP7cEA9HhIKVFSKt6bb0juo2KIYbRDr4CpSz4IDhbgyDMFnOWarE7tydhe2-BmhL3Me_ps_CW63IvLFEvnSfPT0jK2OX5gWl)
