// 6 - Obtenir tous les problèmes résolus

// Requête
var query = 
    from t in Tickets
    where (t.Status == "Résolu")
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
