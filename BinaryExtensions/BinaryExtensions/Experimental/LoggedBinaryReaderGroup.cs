using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    internal sealed class LoggedBinaryReaderGroup : IDisposable
    {
        public LoggedBinaryReaderGroup([NotNull] LoggedBinaryReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(nameof(reader));

            Reader = reader;
            reader.BeginGroupInternal();
        }

        private LoggedBinaryReader Reader { get; }

        public void Dispose()
        {
            Reader.EndGroupInternal();
        }
    }
}