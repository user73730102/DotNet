using System;

namespace Ex2_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Factory Method Pattern...");

            // Use the factories to create different documents
            DocumentFactory wordFactory = new WordDocumentFactory();
            IDocument doc1 = wordFactory.CreateDocument();
            doc1.Open();
            doc1.Save();

            Console.WriteLine();

            DocumentFactory pdfFactory = new PdfDocumentFactory();
            IDocument doc2 = pdfFactory.CreateDocument();
            doc2.Open();
            doc2.Save();

            Console.WriteLine();

            DocumentFactory excelFactory = new ExcelDocumentFactory();
            IDocument doc3 = excelFactory.CreateDocument();
            doc3.Open();
            doc3.Save();
            
            Console.WriteLine("\nFactory method pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
