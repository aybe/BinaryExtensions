using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    internal sealed class LoggedBinaryReaderGroup : IDisposable
    {
        public LoggedBinaryReaderGroup([NotNull] LoggedBinaryReader reader)
        {
            Reader = reader ?? throw new ArgumentNullException(nameof(reader));
            reader.BeginGroupInternal();
        }

        private LoggedBinaryReader Reader { get; }

        public void Dispose()
        {
            Reader.EndGroupInternal();
        }
    }
}