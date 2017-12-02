using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace HReader.Base.Data
{
    public class DefaultMetadata : IMetadata
    {
        public DefaultMetadata(
            Kind                     kind,
            Language                 language,
            IReadOnlyList<Series>    series,
            IReadOnlyList<Character> characters,
            string                   title,
            IReadOnlyList<Artist>    artists,
            IReadOnlyList<Tag>       tags,
            IReadOnlyList<Uri>       pages,
            Uri                      cover)
        {
            Pages      = pages;
            Cover      = cover;
            Kind       = kind       ?? Kind.Unknown;
            Language   = language   ?? Language.Unknown;
            Series     = series     ?? ImmutableList<Series>.Empty;
            Characters = characters ?? ImmutableList<Character>.Empty;
            Title      = title      ?? string.Empty;
            Artists    = artists    ?? ImmutableList<Artist>.Empty;
            Tags       = tags       ?? ImmutableList<Tag>.Empty;
        }

        public string                   Title      { get; }
        public IReadOnlyList<Artist>    Artists    { get; }
        public Language                 Language   { get; }
        public Kind                     Kind       { get; }
        public Uri                      Cover      { get; }
        public IReadOnlyList<Uri>       Pages      { get; }
        public IReadOnlyList<Series>    Series     { get; }
        public IReadOnlyList<Character> Characters { get; }
        public IReadOnlyList<Tag>       Tags       { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"[{Kind}] {Title} in {Language} ({Pages.Count} Pages)";
        }
    }
}