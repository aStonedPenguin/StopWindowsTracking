using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StopWindowsTracking.Methods;

namespace StopWindowsTracking.Base
{
    public interface IRegEdit
    {
        string GetName();
        string GetInfo();
        RegEdit[] GetRegEdits();
    }
}
