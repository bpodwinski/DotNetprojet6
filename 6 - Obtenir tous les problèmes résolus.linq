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

// 6 - Obtenir tous les problèmes résolus

// Requête
var query = 
    from t in Tickets
	join s in Statuses on t.StatusId equals s.Id
    join p in Products on t.ProductId equals p.Id
	join v in Versions on t.VersionId equals v.Id
	join os in OperatingSystems on t.OperatingSystemId equals os.Id
    where t.StatusId == 2
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

query.Dump();