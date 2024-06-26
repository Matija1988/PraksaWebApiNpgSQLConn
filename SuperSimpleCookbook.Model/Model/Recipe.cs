﻿using System.ComponentModel.DataAnnotations;

namespace SuperSimpleCookbook.Model
{
    public class Recipe : IEntity
    {
        public int Id { get; set; }


        [Required, StringLength(200, ErrorMessage = "Maximum allowed number of characters = 200")]
        public string Title { get; set; }


        [Required, StringLength(200, ErrorMessage = "Maximum allowed number of characters = 200")]
        public string Subtitle { get; set; }


        [Required, StringLength(4000, ErrorMessage = "Maximum allowed number of characters = 4000")]
        public string Text { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
