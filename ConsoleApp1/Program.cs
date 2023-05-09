using Microsoft.Office.Interop.PowerPoint;
using static System.Net.Mime.MediaTypeNames;

class Program
{
    static void Main(string[] args)
    {
        Application pptApp = new Application();
        Presentation pptPresentation = pptApp.Presentations.Add();

        // Agregar una diapositiva
        pptPresentation.Slides.Add(1, PpSlideLayout.ppLayoutTitleOnly);

        // Agregar texto a la diapositiva
        pptPresentation.Slides[1].Shapes[1].TextFrame.TextRange.Text = "Título de la diapositiva";
        pptPresentation.Slides[1].Shapes[2].TextFrame.TextRange.Text = "Texto de la diapositiva";

        pptPresentation.SaveAs(@"C:\ruta\de\archivo.pptx");
        pptPresentation.Close();
        pptApp.Quit();
    }
}
