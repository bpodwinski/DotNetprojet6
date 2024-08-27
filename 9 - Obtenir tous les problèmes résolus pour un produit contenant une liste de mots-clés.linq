// 9 - Obtenir tous les problèmes résolus pour un produit contenant une liste de mots-clés

// Paramètres
var keywords = Util.ReadLine("Entrer les mots-clés"); // Mots-clés à rechercher
var productName = Util.ReadLine("Entrer le nom du produit"); // Nom du produit

// Requête
var query = 
    from t in Tickets
    where t.Status == "Résolu"
		&& (keywords == null || t.Problem.Contains(keywords))
		&& (productName == null || t.Product.Name == productName)
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
