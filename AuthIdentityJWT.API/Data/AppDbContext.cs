using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthIdentityJWT.API.Data;

public class AppDbContext(DbContextOptions options) : IdentityDbContext<IdentityUser>(options);