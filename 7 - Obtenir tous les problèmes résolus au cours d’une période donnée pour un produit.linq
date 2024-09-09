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

// 7 - Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit

// Paramètres
DateOnly? startDate = DateOnly.TryParse(Util.ReadLine("Entrer la date de début (format AAAA-MM-JJ) : "), out var tempStartDate) ? tempStartDate : null; // Dates de début
DateOnly? endDate = DateOnly.TryParse(Util.ReadLine("Entrer la date de fin (format AAAA-MM-JJ) : "), out var tempEndDate) ? tempEndDate : null; // Dates de fin
var productName = Util.ReadLine("Entrer le nom du produit"); // Nom du produit

// Requête
var query = 
    from t in Tickets
    join s in Statuses on t.StatusId equals s.Id
    join pvo in ProductVersionOS on t.ProductVersionOSId equals pvo.Id
    join p in Products on pvo.ProductId equals p.Id
    join v in Versions on pvo.VersionId equals v.Id
    join os in OperatingSystems on pvo.OperatingSystemId equals os.Id
    where (
		t.StatusId == 2 &&
        (string.IsNullOrWhiteSpace(productName) || p.Name == productName) &&
		(startDate == null || t.CreationDate >= startDate) &&
		(endDate == null || t.CreationDate <= endDate)
    )
    select new
    {
        TicketId = t.Id,
        ProductName = p.Name,
        VersionNumber = v.Number,
        OperatingSystemName = os.Name,
        Status = s.Name,
        t.CreationDate,
        t.Problem,
    };

query.Dump();