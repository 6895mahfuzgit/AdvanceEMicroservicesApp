using System;

namespace OrderingApplication.Exceptions
{
    public class NotFoundException : ApplicationException
    {

        public NotFoundException(string name, Object key)
            : base($" Entity \" {name} \" ({key})  was not found")
        {

        }
    }
}
