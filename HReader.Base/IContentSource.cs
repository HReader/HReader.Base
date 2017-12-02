using System;
using System.IO;
using System.Threading.Tasks;

namespace HReader.Base
{
    /// <summary>
    /// The interface external plugins must implement to make a content source
    /// available to HReader.
    /// </summary>
    public interface IContentSource
    {
        string Name { get; }
        string Author { get; }
        string Version { get; }
        Uri Website { get; }

        /// <summary>
        /// Check if this <see cref="IContentSource"/> is able to provide the content for the given Uri. This should
        /// not attempt to resolve the resource to check if it exists, only check if this <see cref="IContentSource"/>
        /// knows how to resolve the Uri to content.
        /// </summary>
        bool CanHandle(Uri uri);

        /// <summary>
        /// Loads the content for given Uri by calling <paramref name="consumer"/> with the content stream.
        /// The stream should be disposed of after waiting for <paramref name="consumer"/> finish.
        /// <para>Note: will only be called if a previous called to <see cref="CanHandle"/> returned <code>true</code> for the same Uri.</para>
        /// </summary>
        Task HandleAsync(Uri uri, Func<Stream, Task> consumer);
    }
}