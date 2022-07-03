﻿namespace knowledge_hub.Models.Model.Responses
{
   public class UserResponse : BaseResponse
   {
      public int UserId { get; set; }
      public string  Email { get; set; }
      public string  Username { get; set; }
      public string  ImagePath { get; set; }
      public string  Biography { get; set; }
      public string  UserRole { get; set; }
   }
}
