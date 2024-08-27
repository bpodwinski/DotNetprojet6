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

// 7 - Obtenir tous les problèmes résolus au cours d’une période donnée pour un produit

// Paramètres
DateOnly? startDate = DateOnly.TryParse(Util.ReadLine("Entrer la date de début (format AAAA-MM-JJ) : "), out var tempStartDate) ? tempStartDate : null; // Dates de début
DateOnly? endDate = DateOnly.TryParse(Util.ReadLine("Entrer la date de fin (format AAAA-MM-JJ) : "), out var tempEndDate) ? tempEndDate : null; // Dates de fin
var productName = Util.ReadLine("Entrer le nom du produit"); // Nom du produit

// Requête
var query = 
    from t in Tickets
    where (
		t.Status == "Résolu"
		&& productName == null || t.Product.Name == productName)
		&& (startDate == null || t.CreationDate >= startDate)
		&& (endDate == null || t.CreationDate <= endDate)
    select new
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
    };

query.Dump();
