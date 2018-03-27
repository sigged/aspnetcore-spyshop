using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCourse.Spyshop.Domain
{
    public abstract class BaseEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
