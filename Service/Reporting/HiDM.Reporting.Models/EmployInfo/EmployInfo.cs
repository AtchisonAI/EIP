using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiDM.Reporting.Models
{
    public class EmployInfo
    {
        public string EmployId { get; set; }
        public string EmployName { get; set; }
        public string EmployEnglishName { get; set; }
        public string Email { get; set; }
        public string Pager { get; set; }
        public string ExtensionNo { get; set; }
        public string ChineseTitle { get; set; }
        public string EnglishTitle { get; set; }
        public string DepetCode { get; set; }
        public string DepetName { get; set; }
        public string EnglishDeptName { get; set; }
        public string GroupCode { get; set; }
        public string DirManager { get; set; }
        public string RepEmpNo { get; set; }
        public string ActionFlag { get; set; }
        public string RcdDate{get;set;}
        public string BasicPerson { get; set; }
        public string BasicOrg { get; set; }
    }
}
