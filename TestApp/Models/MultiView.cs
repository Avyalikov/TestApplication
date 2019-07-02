using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    //Класс, объединяющий данные из двух сущностей БД.
    public class MultiView
    {
        public int ViewId { get; set; }
        public string ViewName { get; set; }
        public int ViewCnt { get; set; }
        public int ViewScore { get; set; }
        public string ViewDesc { get; set; }
        public DateTime ViewOdate { get; set; }
        public DateTime ViewBdate { get; set; }
    }
}