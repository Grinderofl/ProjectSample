using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NHibernate;
using NHibernate.Linq;
using ProjectSample.Core.Domain;
using ProjectSample.Core.Infrastructure.DataAccess;

namespace ProjectSample.Controllers
{
    public class OrderController : Controller
    {
        private ISession _session;
        private IRepository _repository;

        public OrderController(ISession session, IRepository repository)
        {
            this._session = session;
            _repository = repository;
        }

        public ActionResult Index()
        {


            var orders = _session.Query<Order>().Where(x => x.CurrentState == OrderState.Accepted).ToList();
            return View(orders);
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            var order = Order.Create();
            _repository.Save(order);
            //_session.SaveOrUpdate(order);
            order.Progress(OrderState.Accepted);
            _repository.Save(order);
            return Content("Done");
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
