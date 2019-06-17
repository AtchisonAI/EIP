using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EIP.Common.Entities
{
    public class ParameterRequiredException:Exception
    {
        public ParameterRequiredException(string message, string parameterName):base(message)
        {
            RequiredParameter = parameterName;
        }


        public ParameterRequiredException( string parameterName)
            : base("Please Input Required Parameters!")
        {
            RequiredParameter = parameterName;
        }

        public string RequiredParameter { get; set; }

        public override string ToString()
        {
            return string.Format("{0} ParameterName:[{1}]", Message, RequiredParameter);
        }
    }
}
