using System.Collections.Generic;
using System.Security.Claims;

namespace Infrastructure.Models
{
    public class ClaimsStore
    {
        public static List<Claim> AllClaims = new List<Claim>()
        {
            new Claim("Create Product", "Create Product"),
            new Claim("Edit Product","Edit Product"),
            new Claim("View Product", "View Product"),
            new Claim("Delete Product", "Delete Product"),

            new Claim("Create Category", "Create Category"),
            new Claim("Edit Category","Edit Category"),
            new Claim("View Category", "View Category"),
            new Claim("Delete Category", "Delete Category"),

            new Claim("Create Supplier", "Create Supplier"),
            new Claim("Edit Supplier","Edit Supplier"),
            new Claim("View Supplier", "View Supplier"),
            new Claim("Delete Supplier", "Delete Supplier"),

            new Claim("Create Shipper", "Create Shipper"),
            new Claim("Edit Shipper","Edit Shipper"),
            new Claim("View Shipper", "View Shipper"),
            new Claim("Delete Shipper", "Delete Shipper"),

            new Claim("Create Role", "Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("View Role", "View Role"),
            new Claim("Delete Role", "Delete Role"),

            new Claim("Create User", "Create User"),
            new Claim("Edit User","Edit User"),
            new Claim("View User", "View User"),
            new Claim("Delete User", "Delete User"),

            new Claim("Create Customer", "Create Customer"),
            new Claim("Edit Customer","Edit Customer"),
            new Claim("View Customer", "View Customer"),
            new Claim("Delete Customer", "Delete Customer"),

            new Claim("Create Employee", "Create Employee"),
            new Claim("Edit Employee","Edit Employee"),
            new Claim("View Employee", "View Employee"),
            new Claim("Delete Employee", "Delete Employee"),

            new Claim("Create Role", "Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("View Role", "View Role"),
            new Claim("Delete Role", "Delete Role"),
        };

    }
}
