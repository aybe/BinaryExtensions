using BinaryExtensions.Annotations;

// ReSharper disable once CheckNamespace
namespace System.IO
{
    internal struct LoggedBinaryReaderScope : IDisposable
    {
        private LoggedBinaryReaderJournal Journal { get; }

        internal LoggedBinaryReaderScope([NotNull] LoggedBinaryReaderJournal journal)
        {
            if (journal == null) 
                throw new ArgumentNullException(nameof(journal));

            Journal = journal;
            Journal.BeginLog();
        }

        public void Dispose()
        {
            Journal.EndLog();
        }
    }
}