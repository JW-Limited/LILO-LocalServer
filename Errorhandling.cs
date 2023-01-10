using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Local;
public class Errorhandling
{
    public void ThrowError(string msg)
    {
        throw new Exception(msg);
    }

}
