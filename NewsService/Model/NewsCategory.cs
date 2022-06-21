﻿using System.ComponentModel.DataAnnotations;

namespace NewsService.Model
{
    public class NewsCategory
    {
       public int Id { get; set; }

       [Required]
       [MaxLength(100)]
       public string Name { get; set; }

       [Required]
       [MaxLength(300)]
       public string Description { get; set; }
       public ICollection<News> News { get; set; }
    }
}
