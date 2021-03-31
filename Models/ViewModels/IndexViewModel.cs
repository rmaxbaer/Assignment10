using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment10.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Bowlers> Bowlers{ get; set; }
        public PageNumberingInfo PageNumberingInfo { get; set; }
        public Teams Team { get; set; }
        
        //public string TeamName = Team.TeamName.ToString();
    }
}
