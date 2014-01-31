using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HauntedHouseSoftware.SecureNotePad.DomainObjects
{
    public sealed class ApplicationSettings
    {
        public int WindowPositionX { get; set; }
        public int WindowPositionY { get; set; }
        public int WindowWidth { get; set; }
        public int WindowHeight { get; set; }
        public FormWindowState FormWindowState { get; set; }
        public byte BackgroundColorRed { get; set; }
        public byte BackgroundColorGreen { get; set; }
        public byte BackgroundColorBlue { get; set; }
        public byte ForegroundColorRed { get; set; }
        public byte ForegroundColorGreen { get; set; }
        public byte ForegroundColorBlue { get; set; }
    }
}
