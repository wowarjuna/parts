using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoPP.ApplicationServices.Exceptions
{
    public class GalleryException : Exception
    {
        public GalleryException()
            : base("Gallery not found")
        {
            
        }

        public GalleryException(string Message)
            : base(Message)
        {
            
        }
    }
}
