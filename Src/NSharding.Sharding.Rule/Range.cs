using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSharding.Sharding.Rule
{
    public class Range<T>
    {
        public T Start { get; set; }

        public T End { get; set; }
    }
}
