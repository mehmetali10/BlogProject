﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Entity
{
    public class Article
    {
        public int Id { get; set; }

        [Required()]
        public string Header { get; set; }

        [Required()]
        public string Content { get; set; }

        public string? Picture { get; set; }

        [Required()]
        public DateTime CreatedDate { get; set; }

        [Required()]
        public int UserId { get; set; }

        public string FontSize { get; set; }
        public string FontFamily { get; set; }
        public string FontColor { get; set; }

    }
}
