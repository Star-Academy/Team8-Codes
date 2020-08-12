using System.Collections.Generic;
using GoogleSharp.Src.Core.Structures;

namespace GoogleSharp.Src.Core.Engine
{
    public interface IInvertedIndex
    {
        HashSet<Document> GetDocumentsOfToken(Token token);
    }
}