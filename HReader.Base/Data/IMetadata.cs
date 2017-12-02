using System;
using System.Collections.Generic;

namespace HReader.Base.Data
{
    public interface IMetadata
    {
        IReadOnlyList<Artist> Artists { get; }
        IReadOnlyList<Character> Characters { get; }
        Uri Cover { get; }
        Kind Kind { get; }
        Language Language { get; }
        IReadOnlyList<Uri> Pages { get; }
        IReadOnlyList<Series> Series { get; }
        IReadOnlyList<Tag> Tags { get; }
        string Title { get; }
    }
}