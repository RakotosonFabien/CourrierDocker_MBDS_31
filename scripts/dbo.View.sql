CREATE VIEW [dbo].[CourrierDetails]
	AS 
SELECT c.*, p.Val as PrioriteVal, STRING_AGG(dept.Val, ',') as DestinatairesVal, CONCAT(u.Nom, ' ', u.Prenom) as ExpediteurVal
	FROM Courrier AS c JOIN Priorite as p 
		ON p.Id = c.PrioriteId
	JOIN MyUser AS u
		ON u.Id = c.ExpediteurId 
	LEFT JOIN Destinataire as d
		ON d.CourrierId = c.Id
	LEFT JOIN Departement dept
		ON dept.Id = d.DepDestId
	GROUP BY c.Id, c.Contenu, c.CreateurId, c.DateCreation, c.ExpediteurId, c.Objet, c.PrioriteId, p.Val, u.Nom, u.Prenom
		;
