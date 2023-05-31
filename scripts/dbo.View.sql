CREATE VIEW [dbo].[CourrierDetails]
	AS 
SELECT c.*, p.Val as PrioriteVal, STRING_AGG(dept.Val, ',') as DestinatairesVal 
	FROM Courrier AS c JOIN Priorite as p 
		ON p.Id = c.PrioriteId
	LEFT JOIN Destinataire as d
		ON d.CourrierId = c.Id
	LEFT JOIN Departement dept
		ON dept.Id = d.DepDestId
	GROUP BY c.Id, c.Contenu, c.CreateurId, c.DateCreation, c.ExpediteurId, c.Objet, c.PrioriteId, p.Val
		;

	
