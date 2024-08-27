// 5 - Obtenir tous les problèmes rencontrés au cours d’une période donnée pour un produit contenant une liste de mots-clés

// Paramètres
DateOnly? startDate = DateOnly.TryParse(Util.ReadLine("Entrer la date de début (format AAAA-MM-JJ) : "), out var tempStartDate) ? tempStartDate : null; // Dates de début
DateOnly? endDate = DateOnly.TryParse(Util.ReadLine("Entrer la date de fin (format AAAA-MM-JJ) : "), out var tempEndDate) ? tempEndDate : null; // Dates de fin
var keywords = Util.ReadLine("Entrer les mots-clés"); // Mots-clés à rechercher
var productName = Util.ReadLine("Entrer le nom du produit"); // Nom du produit

// Requête
var query = 
    from t in Tickets
    where (
		t.Status == "En cours"
		&& keywords == null || t.Problem.Contains(keywords)
		&& productName == null || t.Product.Name == productName)
		&& (startDate == null || t.CreationDate >= startDate)
		&& (endDate == null || t.CreationDate <= endDate)
    select t;

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
