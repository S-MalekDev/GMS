using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsClient.Enums.Operations
{
    public enum enOperationType
    {
        LoadAll,
        LoadByRelatedId,
        LoadSingle,
        Create ,
        Update,
        Delete,
        CheckExistence,
    }
}
