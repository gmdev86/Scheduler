using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Scheduler.Core.Services
{
    public class ReportPrinter
    {
        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
        private DataGridView dataGridView;

        public ReportPrinter(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDocument.DefaultPageSettings.Landscape = true;
            printPreviewDialog.Document = printDocument;
        }

        public void Print()
        {
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bitmap = new Bitmap(dataGridView.Width, dataGridView.Height);
            dataGridView.DrawToBitmap(bitmap, new Rectangle(0, 0, dataGridView.Width, dataGridView.Height));
            e.Graphics.DrawImage(bitmap, new Point(10, 10));
        }
    }
}
