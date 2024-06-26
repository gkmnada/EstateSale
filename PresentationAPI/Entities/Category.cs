﻿using System.ComponentModel.DataAnnotations;

namespace PresentationAPI.Entities
{
    public class Category
    {
        [Key]
        public int category_id { get; set; }
        public string category_name { get; set; }
        public bool status { get; set; }
    }
}
