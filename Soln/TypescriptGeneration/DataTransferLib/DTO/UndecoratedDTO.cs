using System;
using System.Collections.Generic;
using System.Text;

namespace DataTransferLib.DTO
{
    /// <summary>
    /// USed to test that reflection is working. This class/type should not be found
    /// by code using the DTOModelAttribute.
    /// </summary>
    public class UndecoratedDTO
    {
        public int Id { get; set; }
    }
}
