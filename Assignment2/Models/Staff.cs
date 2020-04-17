using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Identity;

namespace Assignment2.Models
{
    public class Staff : IdentityUser
    {
        public string Name { get; set; }
    }




}