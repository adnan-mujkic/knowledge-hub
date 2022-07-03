using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace knowledge_hub.WebAPI.Database
{
   public class User
   {
      [Key]
      public int UserId { get; set; }
      public string? Username { get; set; }
      public string? ImagePath { get; set; }
      public string? Biography { get; set; }
      public int LoginId { get; set; }
      public Login Login { get; set; }
      public virtual UserRoles UserRole { get; set; }
   }
}
