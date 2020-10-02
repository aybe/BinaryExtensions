using System;
using JetBrains.Annotations;

namespace BinaryExtensions.WorkInProgress.Experimental
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