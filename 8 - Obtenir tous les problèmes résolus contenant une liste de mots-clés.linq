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

// 8 - Obtenir tous les problèmes résolus contenant une liste de mots-clés

// Paramètres
var keywords = Util.ReadLine("Entrer les mots-clés"); // Mots-clés à rechercher

// Requête
var query = 
    from t in Tickets
    join s in Statuses on t.StatusId equals s.Id
    join pvo in ProductVersionOS on t.ProductVersionOSId equals pvo.Id
    join p in Products on pvo.ProductId equals p.Id
    join v in Versions on pvo.VersionId equals v.Id
    join os in OperatingSystems on pvo.OperatingSystemId equals os.Id
    where
		t.StatusId == 2 &&
        (string.IsNullOrWhiteSpace(keywords) || t.Problem.Contains(keywords))
    select new
    {
        TicketId = t.Id,
        ProductName = p.Name,
        VersionNumber = v.Number,
        OperatingSystemName = os.Name,
        t.CreationDate,
        Status = s.Name,
        t.Problem,
    };

object result = query.ToList();

result.Dump();
