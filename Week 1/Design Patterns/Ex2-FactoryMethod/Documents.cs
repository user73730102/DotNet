using System;

namespace Ex2_FactoryMethod
{
    public interface IDocument
    {
        void Open();
        void Save();
    }

    public class WordDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Word Document...");
        public void Save() => Console.WriteLine("Saving Word Document...");
    }

    public class PdfDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening PDF Document...");
        public void Save() => Console.WriteLine("Saving PDF Document...");
    }

    public class ExcelDocument : IDocument
    {
        public void Open() => Console.WriteLine("Opening Excel Document...");
        public void Save() => Console.WriteLine("Saving Excel Document...");
    }
}
