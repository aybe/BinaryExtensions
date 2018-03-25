using System.Linq;
using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    /// <summary>
    ///     Locates a directory from current directory, upwards.
    /// </summary>
    [PublicAPI]
    public sealed class DirectoryLocator
    {
        /// <summary>
        ///     Initializes a new instance of <see cref="DirectoryLocator" />.
        /// </summary>
        /// <param name="directory">
        ///     Directory name to search.
        /// </param>
        /// <exception cref="ArgumentException">
        ///     <paramref name="directory" /> is <c>null</c> or white-space.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        ///     Directory could not be found.
        /// </exception>
        public DirectoryLocator([NotNull] string directory)
        {
            if (string.IsNullOrWhiteSpace(directory))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(directory));

            var info = new DirectoryInfo(Environment.CurrentDirectory);

            while (info != null)
            {
                var directories = info.GetDirectories(directory);
                if (directories.Any())
                    break;

                info = info.Parent;
            }

            if (info == null)
                throw new DirectoryNotFoundException("Directory could not be found.");

            Directory = Path.Combine(info.FullName, directory);
        }

        /// <summary>
        ///     Gets the full path to the found directory.
        /// </summary>
        public string Directory { get; }

        /// <summary>
        ///     Opens a stream to a file path relative to <see cref="Directory" />
        /// </summary>
        /// <param name="relativePath">
        ///     Relative file path.
        /// </param>
        /// <returns>
        ///     The opened stream.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="relativePath" /> is <c>null</c>.
        /// </exception>
        public Stream Open([NotNull] string relativePath)
        {
            if (relativePath == null)
                throw new ArgumentNullException(nameof(relativePath));

            var path = Path.Combine(Directory, relativePath);
            var stream = File.OpenRead(path);

            return stream;
        }
    }
}