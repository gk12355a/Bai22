using bai22.Models;
using Microsoft.AspNetCore.Mvc;

namespace bai22.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()
        {
            return View(new Models_HinhTronModel()); // Trả về model mặc định nếu chưa có dữ liệu
        }

        // POST: Home/Index
        [HttpPost]
        public IActionResult TinhToan(Models_HinhTronModel model)
        {
            if (model.BanKinh <= 0)
            {
                ViewBag.Error = "Bán kính phải lớn hơn 0.";
                return View("Index", model); // Trả lại model để không mất giá trị đã nhập
            }

            // Tính toán diện tích, chu vi, và đường kính
            model.DienTich = Math.PI * model.BanKinh * model.BanKinh;
            model.ChuVi = Math.PI * 2 * model.BanKinh;
            model.DuongKinh = 2 * model.BanKinh;

            // Trả lại model đã tính toán về View
            return View("Index", model);
        }
    }
}
