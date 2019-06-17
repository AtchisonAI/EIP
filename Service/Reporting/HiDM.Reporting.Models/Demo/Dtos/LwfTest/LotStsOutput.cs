using EIP.Common.Entities.Dtos;

namespace HiDM.Reporting.Models
{
    public class LotStsOutput : BaseHoldInfo, IOutputDto
    {

        public string LOTID { get; set; }

        public string PLANNAME { get; set; }

        public string PRODUCTNAME { get; set; }

        public string QTY { get; set; }

        public string STAGENAME { get; set; }

        public string CARRIERID { get; set; }

        public string STEPNAME { get; set; }

        public string PROCESSINGSTATUS { get; set; }

        public string EXTRASTATUS { get; set; }

    }
}
