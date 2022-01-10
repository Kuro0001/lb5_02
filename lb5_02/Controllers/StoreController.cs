using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyLibLB1;

namespace lb5_02.Controllers
{
    public class StoreController : Controller
    {
        public static Store store = new Store();

        // GET: StoreController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            ViewBag.action = "add";
            if (name != null)
            {
                if (!store.Exists(name))
                {
                    store.AddItem(name);
                    ViewBag.message_item_name = store.Items[store.Items.Count - 1].name;
                    ViewBag.message = "Продукт добавлен";
                    ViewBag.count = store.Items.Count;
                }
                else
                {
                    ViewBag.message = "Продукт с введенным наименованим уже есть в списке";
                }
            }
            else
            {
                ViewBag.message = "Введен пустой текст";
            }
            TableList();
            return View("Index");
        }

        [HttpPost]
        public IActionResult TableList()
        {
            ViewBag.products = store.GetListAsText();
            ViewBag.count = store.Items.Count;
            ViewBag.count_on_counter = store.CalculateCountOnCounter();
            ViewBag.count_not_on_counter = store.CalculateCountNotOnCounter();
            return View("Index");
        }

        [HttpPost]
        public IActionResult Delete(string name)
        {
            ViewBag.action = "delete";
            if (name != null)
            {
                if (store.Exists(name))
                {
                    store.DeleteItem(name);
                    ViewBag.message_item_name = name;
                    ViewBag.message = "Продукт удален";
                    ViewBag.count = store.Items.Count;
                }
                else
                {
                    ViewBag.message = "Продукта с введенным наименование нет в списке";
                }
            }
            else
            {
                ViewBag.message = "Введен пустой текст";
            }
            TableList();
            return View("Index");
        }

        [HttpPost]
        public IActionResult PutOn(string name)
        {
            ViewBag.action = "PutOn";
            if (name != null)
            {
                if (store.Exists(name))
                {
                    store.PutItemOnCounter(name);
                    ViewBag.message_item_name = name;
                    ViewBag.message = "Продукт выложен на прилавок";
                }
                else
                {
                    ViewBag.message = "Продукта с введенным наименование нет в списке";
                }
            }
            else
            {
                ViewBag.message = "Введен пустой текст";
            }
            TableList();
            return View("Index");
        }

        [HttpPost]
        public IActionResult PutOff()
        {
            ViewBag.action = "PutOff";
            if (store.Items.Count != 0)
            {
                store.ClearStore();
                ViewBag.message = "Продукты сняты с прилавка";
            }
            else
            {
                ViewBag.message = "В магазине нет продуктов";
            }

            TableList();
            return View("Index");
        }
    }
}
