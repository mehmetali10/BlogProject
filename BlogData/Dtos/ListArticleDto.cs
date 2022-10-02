using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogData.Dtos
{
    public class ListArticleDto
    {
        public string Header { get; set; }
        public string Content { get; set; }
        public string Picture { get; set; }
        public string FontSize { get; set; }
        public string FontFamily { get; set; }
        public string FontColor { get; set; }
        public string UserName { get; set; }
    }
}
