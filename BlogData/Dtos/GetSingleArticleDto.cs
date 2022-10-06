using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Dtos
{
    public class GetSingleArticleDto
    {

        public string Header { get; set; }

        public string Content { get; set; }

        public string? Picture { get; set; }

        public DateTime CreatedDate { get; set; }

        public int UserId { get; set; }

        public string FontSize { get; set; }
        public string FontFamily { get; set; }
        public string FontColor { get; set; }
    }
}
