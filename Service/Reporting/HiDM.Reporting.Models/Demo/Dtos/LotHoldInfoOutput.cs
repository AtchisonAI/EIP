using EIP.Common.Entities.Dtos;

namespace HiDM.Reporting.Models
{
    public class LotHoldInfoOutput :BaseHoldInfo,IOutputDto
    {

        public string ProductName { get; set; }

        public string StepSEQ { get; set; }

        public string StepName { get; set; }

        public string ReasonDescription { get; set; }

        public string HoldToOwnerID { get; set; }

        public string HoldToOwnerName { get; set; }

        public string HoldToOwnerDept { get; set; }

        public string Comments { get; set; }

        public string HoldUserID { get; set; }

        public string HoldUserName { get; set; }

        public string HoldTime { get; set; }
    }
}
