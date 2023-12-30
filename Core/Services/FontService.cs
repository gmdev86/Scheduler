using System.Drawing.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Scheduler.Core.Services
{
    public class FontService
    {
        public static Font LoadFontAwesome()
        {
            string fontFilePath = Path.Combine(Application.StartupPath, "Core\\Font\\fontawesome-webfont.ttf");
            PrivateFontCollection privateFonts = new PrivateFontCollection();
            privateFonts.AddFontFile(fontFilePath);
            return new Font(privateFonts.Families[0], 12f);
        }
    }
}
