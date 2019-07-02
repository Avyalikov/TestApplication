using System;
using TestApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace TestApr.Controllers
{
    public class HomeController : Controller
    {
        Entities db = new Entities();

        public ActionResult Index(String searchString, Sorts sortOrder = Sorts.IdAsc)
        {
            List<orders> order = db.orders.ToList();
            List<users> user = db.users.ToList();

            var result = from a in order
                         join b in user on a.UserId equals b.Id
                         select new MultiView { ViewId = a.UserId, ViewName = b.Name,  ViewDesc = a.Desc,
                             ViewCnt = Convert.ToInt32(a.Cnt), ViewScore = Convert.ToInt32(b.Score),
                             ViewOdate = Convert.ToDateTime(a.Odate), ViewBdate = Convert.ToDateTime(b.Bdate)};

            //Получение типа сортировки, которую нужно применить.
            ViewBag.IdSort = sortOrder == Sorts.IdAsc ? Sorts.IdDesc : Sorts.IdAsc;
            ViewBag.NameSort = sortOrder == Sorts.NameAsc ? Sorts.NameDesc : Sorts.NameAsc;
            ViewBag.CntSort = sortOrder == Sorts.CntAsc ? Sorts.CntDesc : Sorts.CntAsc;
            ViewBag.ScoreSort = sortOrder == Sorts.ScoreAsc ? Sorts.ScoreDesc : Sorts.ScoreAsc;
            ViewBag.OdateSort = sortOrder == Sorts.OdateAsc ? Sorts.OdateDesc : Sorts.OdateAsc;
            ViewBag.BdateSort = sortOrder == Sorts.BdateAsc ? Sorts.BdateDesc : Sorts.BdateAsc;

            //Реализация строки поиска.
            if (!String.IsNullOrEmpty(searchString))
            {
                result = result.Where(s => s.ViewName.Contains(searchString));
            }

            //Сортировки по всем полям, кроме поля "Описание".
            switch (sortOrder)
            {
                case Sorts.IdDesc:
                    result = result.OrderByDescending(s => s.ViewId);
                    break;
                case Sorts.NameAsc:
                    result = result.OrderBy(s => s.ViewName);
                    break;
                case Sorts.NameDesc:
                    result = result.OrderByDescending(s => s.ViewName);
                    break;
                case Sorts.CntAsc:
                    result = result.OrderBy(s => s.ViewCnt);
                    break;
                case Sorts.CntDesc:
                    result = result.OrderByDescending(s => s.ViewCnt);
                    break;
                case Sorts.ScoreAsc:
                    result = result.OrderBy(s => s.ViewScore);
                    break;
                case Sorts.ScoreDesc:
                    result = result.OrderByDescending(s => s.ViewScore);
                    break;
                case Sorts.OdateAsc:
                    result = result.OrderBy(s => s.ViewOdate);
                    break;
                case Sorts.OdateDesc:
                    result = result.OrderByDescending(s => s.ViewOdate);
                    break;
                case Sorts.BdateAsc:
                    result = result.OrderBy(s => s.ViewBdate);
                    break;
                case Sorts.BdateDesc:
                    result = result.OrderByDescending(s => s.ViewBdate);
                    break;
                default:
                    result = result.OrderBy(s => s.ViewId);
                    break;
            }
            return View(result.ToList());
        }

        public ActionResult About()
        {
            return View();
        }
    }
}