using System;
using System.Threading.Tasks;
using HReader.Base.Data;

namespace HReader.Base
{
    public interface IMetadataSource
    {
        string Name    { get; }
        string Author  { get; }
        string Version { get; }
        Uri    Website { get; }

        /// <summary>
        /// Check if this <see cref="IMetadataSource"/> is able to provide the <see cref="DefaultMetadata"/> for the given Uri. This should
        /// not attempt to resolve the metadata to check if it exists, only check if this <see cref="IMetadataSource"/>
        /// knows how to resolve the Uri to metadata.
        /// </summary>
        bool CanHandle(Uri uri);

        /// <summary>
        /// Loads the <see cref="IMetadata"/> for the given Uri. 
        /// <para>Note: will only be called if a previous called to <see cref="CanHandle"/> returned <c>true</c> for the same Uri.</para>
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        Task<IMetadata> HandleAsync(Uri uri);
    }
}