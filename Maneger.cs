using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Malshinon
{
    internal class Maneger
    {
        People people = new People("avi", "cohen");
        public void starter ()
        {
            people.checkMalshin("avi", "moshe");
            people.checkTarget("avi", "moshe");
        }
    }
}
