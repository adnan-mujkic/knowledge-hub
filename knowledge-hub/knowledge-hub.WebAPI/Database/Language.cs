﻿using System.ComponentModel.DataAnnotations;

namespace knowledge_hub.WebAPI.Database
{
   public class Language
   {
      [Key]
      public int LanguageId { get; set; }

      [Required]
      public string Name { get; set; }
   }
}
