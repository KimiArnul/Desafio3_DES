   SELECT u.Email, r.Name AS Rol
   FROM AspNetUsers u
   JOIN AspNetUserRoles ur ON ur.UserId = u.Id
   JOIN AspNetRoles r ON r.Id = ur.RoleId;