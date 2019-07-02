using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    //Перечисление всех возможных типов сортировки для реализации механизма сортировки.
    public enum Sorts
    {
        IdAsc,
        IdDesc,
        NameAsc,
        NameDesc,
        CntAsc,
        CntDesc,
        ScoreAsc,
        ScoreDesc,
        OdateAsc,
        OdateDesc,
        BdateAsc,
        BdateDesc
    }
}