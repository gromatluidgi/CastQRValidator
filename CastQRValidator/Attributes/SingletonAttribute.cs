using System;

namespace CastQRValidator.Attributes
{
    /// <summary>
    /// Attribute "Marker Class" used to automaticaly inject the targeted class 
    /// as a singleton service into the IOC container.
    /// </summary>
    internal class SingletonAttribute : Attribute
    {
        public SingletonAttribute()
        {
        }
    }
}
