using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTask.Model;
using Microsoft.AspNetCore.Identity;

namespace FinalTask.Areas.Identity.Data;

// Add profile data for application users by adding properties to the FinalTaskUser class
public class FinalTaskUser : IdentityUser
{
    public List<Category> Categories { get; set; }
}

