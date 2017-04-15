using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.Data;

namespace ITAdvices.Business
{
    public interface IBasePageView 
    {
        IPrincipal User { get; }
    }
}
