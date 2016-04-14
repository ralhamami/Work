using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WisconsinApiJsonParser
{
    #region Case Class for Creating Case Objects (Not currently in use)
    class Case
    {
        public string caseNo { get; set; }
        public string filingDate { get; set; }
        public string lastModified { get; set; }
        public object status { get; set; }
    }
    #endregion
}
