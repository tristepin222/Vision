
namespace VisionTest.Exceptions
{
    public class Exception <T>
    {
    }
   
    public class GoogleDataObjectImplException : Exception { }

    public class ObjectAlreadyExistsException : GoogleDataObjectImplException { }
    public class ObjectNotFoundException : GoogleDataObjectImplException { }
    public class NotEmptyObjectException : GoogleDataObjectImplException { }
}
