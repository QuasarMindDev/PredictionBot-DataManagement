using System.Runtime.Serialization;

namespace PredictionBot_DataManagement_Domain.Exceptions
{
    public class DataCollectionException : Exception
    {
        public DataCollectionException() 
            : this(null, null)
        { }

        public DataCollectionException(string message) 
            : base(message)
        { }

        public DataCollectionException(string message, Exception innerException) 
            : base(message, innerException)
        { }
    }
}
