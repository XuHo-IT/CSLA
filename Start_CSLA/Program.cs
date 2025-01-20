using System;
using System.Text;
using Csla;
using Csla.Configuration;
using IronPdf;
using Microsoft.Extensions.DependencyInjection;
using Start_CSLA;
namespace csla_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddCsla();
            var provider = services.BuildServiceProvider();
           var  applicationContext = provider.GetService<ApplicationContext>();
            var db = provider.GetRequiredService<IDataPortal<BO>>();
            var newPerson = db.Create();
            Console.WriteLine($"New person: {newPerson.Name}");
            var exsitingPerson = db.Fetch(1);
            Console.WriteLine($"Fetched person: {exsitingPerson.Name}");
            //Generate PDF
            var htmlContent = new StringBuilder();
            htmlContent.Append("<h1>Person Details</h1>");
            htmlContent.Append($"<p><strong>New Person:</strong>{newPerson.Name}</p>");
            htmlContent.Append($"<p><strong>Fetched Person:</strong>{exsitingPerson.Name}</p>");
            //Create PDF
            var renderer = new ChromePdfRenderer();
            var pdfDocument = renderer.RenderHtmlAsPdf(htmlContent.ToString());
            //Save PDF
            var outputPath = "PersonDetails.pdf";
            pdfDocument.SaveAs(outputPath);
            Console.WriteLine($"PDF generated and saved to {outputPath}");
        }
    }
}