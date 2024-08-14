<Query Kind="Statements">
  <Connection>
    <ID>8c7b4d93-c7a8-473a-b440-f15355aa5135</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>ENKI</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>NexaWorksProd</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

string[] keywords = { "utilisateur" }; // Liste de mots-clés à rechercher
string? productName = "Maître des Investissements"; // Nom du produit, obligatoire pour cibler un produit spécifique
string? versionNumber = null; // Numéro de version, ou null pour toutes les versions
DateOnly? startDate = DateOnly.Parse("2024-01-01"); // Date de début de la période
DateOnly? endDate = DateOnly.Parse("2024-12-31"); // Date de fin de la période

var query = 
    from t in Tickets
    where t.Status == "Résolu"
          && t.Product.Name == productName
          && (versionNumber == null || t.Version.Number == versionNumber)
          && (startDate == null || t.ResolutionDate >= startDate)
          && (endDate == null || t.ResolutionDate <= endDate)
    select t;

// Filtrage par mots-clés en utilisant Contains
if (keywords.Length > 0)
{
    foreach (var keyword in keywords)
    {
        query = query.Where(t => t.Problem.Contains(keyword));
    }
}

var result = query.Select(t => new
{
    TicketId = t.Id,
    ProductName = t.Product.Name,
    VersionNumber = t.Version.Number,
    OperatingSystemName = t.OperatingSystem.Name,
    t.CreationDate,
    t.ResolutionDate,
    t.Status,
    t.Problem,
    t.Resolution
}).ToList();

result.Dump();
