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

// 8 - Obtenir tous les problèmes résolus contenant une liste de mots-clés

// Paramètres
var keywords = Util.ReadLine("Entrer les mots-clés"); // Mots-clés à rechercher

// Requête
var query = 
    from t in Tickets
    where t.Status == "Résolu"
		&& (keywords == null || t.Problem.Contains(keywords))
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
