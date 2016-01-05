using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarisMissionChoir.Models
{
    public class MediaImage
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
    }
}
