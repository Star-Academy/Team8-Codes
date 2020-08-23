using System.Collections.Generic;
using System.Linq;

using BagherEngine.Elastic;
using BagherEngine.Models;
using BagherEngine.Utils;

public class Program
{
    // public static void Main(string[] args)
    // {
    //     return;
    // }

    public static void CreateIndex()
    {
        var indexDefiner = new IndexDefiner();
        indexDefiner.CreateIndex("bagher-documents");
    }

    public static void ImportDocuments()
    {
        var documents = FileHandler.GetDocumentsFromFolder("Resources/Documents");
        var ids = documents.Select(doc => doc.Id).ToList();
        var importer = new Importer<Document>();
        importer.Import(documents, "bagher-documents", ids);
    }
}
