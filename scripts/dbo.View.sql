CREATE VIEW [dbo].[CourrierDetails]
	AS SELECT c.*, CONCAT(coursier.Nom, ' ', coursier.Prenom) as CoursierVal, p.Val as PrioriteVal, STRING_AGG(dept.Val, ',') as DestinatairesVal, CONCAT(u.Nom, ' ', u.Prenom) as ExpediteurVal, 
STRING_AGG(COALESCE(CONVERT(VARCHAR(19), d.DateRecepSec, 121), 'NULL'), ',') as DateRecepSec, STRING_AGG(COALESCE(CONVERT(VARCHAR(19), d.DateRecepDr, 121), 'NULL'), ',') as DateRecepDr, STRING_AGG(COALESCE(CONVERT(VARCHAR(19), d.DateRecepLiv, 121), 'NULL'), ',') as DateRecepLiv 
	FROM Courrier AS c JOIN Priorite as p 
		ON p.Id = c.PrioriteId
	JOIN MyUser AS u
		ON u.Id = c.ExpediteurId 
	JOIN MyUser AS coursier
		ON coursier.Id = c.CoursierID
	LEFT JOIN Destinataire as d
		ON d.CourrierId = c.Id
	LEFT JOIN Departement dept
		ON dept.Id = d.DepDestId
	GROUP BY c.Id, c.Contenu, c.CreateurId, c.DateCreation, c.ExpediteurId, c.Objet, c.PrioriteId, c.CourrierRef, p.Val, u.Nom, u.Prenom, c.CoursierID, coursier.Nom, coursier.Prenom
		;