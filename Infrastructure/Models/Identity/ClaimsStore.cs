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

            new Claim("Create ListItem", "Create ListItem"),
            new Claim("Edit ListItem","Edit ListItem"),
            new Claim("View ListItem", "View ListItem"),
            new Claim("Delete ListItem", "Delete ListItem"),

            new Claim("Create Role", "Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("View Role", "View Role"),
            new Claim("Delete Role", "Delete Role"),

            new Claim("Create User", "Create User"),
            new Claim("Edit User","Edit User"),
            new Claim("View User", "View User"),
            new Claim("Delete User", "Delete User"),
           
            new Claim("Create Role", "Create Role"),
            new Claim("Edit Role","Edit Role"),
            new Claim("View Role", "View Role"),
            new Claim("Delete Role", "Delete Role"),
        };

    }
}
