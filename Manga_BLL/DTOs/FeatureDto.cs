using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manga_BLL.DTOs
{
    public class FeatureDto
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime DateAppear { get; set; }

        public DateTime? DateDisappear { get; set; }
    }
}
