using System;

namespace CastQRValidator.Attributes
{
    /// <summary>
    /// Attribute "Marker Class" used to automaticaly inject the targeted class 
    /// as a transient service into the IOC container.
    /// </summary>
    internal class TransientAttribute : Attribute
    {
        public TransientAttribute()
        {
        }
    }
}
