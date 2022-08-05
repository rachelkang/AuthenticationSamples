using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIAUI.Model
{
    public class Subtask
    {
        public string DetailsInfo {get; set;}
        public ObservableCollection<Subtask> Details { get; set; }

        public Subtask(string detailsInfo)
        {
            DetailsInfo = detailsInfo;
            Details = new ObservableCollection<Subtask>();
;       }
    }
}
