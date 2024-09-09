<Query Kind="Statements">
  <Connection>
    <ID>8c7b4d93-c7a8-473a-b440-f15355aa5135</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <Database>NexaWorksProd</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
  <IncludeUncapsulator>false</IncludeUncapsulator>
</Query>

// 9 - Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés

// Paramètres
var keywords = Util.ReadLine("Entrer les mots-clés"); // Mots-clés à rechercher
var productName = Util.ReadLine("Entrer le nom du produit"); // Nom du produit

// Requête
var query = 
    from t in Tickets
    join s in Statuses on t.StatusId equals s.Id
    join p in Products on t.ProductId equals p.Id
	join v in Versions on t.VersionId equals v.Id
	join os in OperatingSystems on t.OperatingSystemId equals os.Id
    where
		t.StatusId == 2 &&
		(string.IsNullOrWhiteSpace(productName) || p.Name == productName) &&
        (string.IsNullOrWhiteSpace(keywords) || t.Problem.Contains(keywords))
    select new
    {
        TicketId = t.Id,
        Product = p.Name,
		Version = v.Number,
		OperatingSystem = os.Name,
        t.CreationDate,
		t.ResolutionDate,
        Status = s.Name,
        t.Problem,
		t.Resolution
    };

object result = query.ToList();

result.Dump();
