using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Aliens
    {
        public Bitmap AlienTexture = Resource1.Alien;
        public int alienX { get; set; }
        public int alienY { get; set; }
        public bool deleted { get; set; } = false;
        public bool active { get; set; } = false;
        public bool armored { get; set; } = false;
    }
}
