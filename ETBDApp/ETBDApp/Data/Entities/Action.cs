﻿
namespace ETBDApp.Data.Entities
{
    public class Action
    {

        public int Id { get; set; }
        
        [Required]
        public string ActionName { get; set; }


    }
}
