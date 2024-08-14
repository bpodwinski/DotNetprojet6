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
string? productName = null; // Nom du produit, ou null pour tous les produits
string? versionNumber = null; // Numéro de version, ou null pour toutes les versions

var query = 
    from t in Tickets
    where t.Status == "En cours"
          && (productName == null || t.Product.Name == productName)
          && (versionNumber == null || t.Version.Number == versionNumber)
    select t;

// Filtrage par mots-clés en utilisant une logique compatible avec LINQ to SQL
if (keywords.Length > 0)
{
    // Utiliser une expression OR pour chaque mot-clé
    var keywordFilter = keywords[0];
    query = query.Where(t => t.Problem.Contains(keywordFilter));

    for (int i = 1; i < keywords.Length; i++)
    {
        var keyword = keywords[i];
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
