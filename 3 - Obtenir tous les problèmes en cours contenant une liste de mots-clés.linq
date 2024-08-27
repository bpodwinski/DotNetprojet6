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

var keywords = Util.ReadLine("Entrer les mots-clés"); // Liste de mots-clés à rechercher
var productName = Util.ReadLine("Entrer le nom du produit"); // Nom du produit, ou null pour tous les produits
var versionNumber = Util.ReadLine("Entrer les numéros de version"); // Numéro de version, ou null pour toutes les versions

var query = 
    from t in Tickets
    where t.Status == "En cours"
		&& (keywords == null || t.Problem.Contains(keywords))
		&& (productName == null || t.Product.Name == productName)
		&& (versionNumber == null || t.Version.Number == versionNumber)
    select t;

object result = query.Select(t => new
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
