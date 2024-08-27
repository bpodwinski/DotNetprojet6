// 1 - Obtenir tous les problèmes en cours

// Requête
var query = 
    from t in Tickets
    where (t.Status == "En cours")
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
