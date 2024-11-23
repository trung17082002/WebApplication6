using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        private static List<GiaoVien> danhSachGiaoVien = new List<GiaoVien>
    {
        new GiaoVien(1, "Trương Khoa", "2021-04-18", "Hà Nội", "0987654321", "gv1@gmail.com"),
        new GiaoVien(2, "Trịnh Thị Lý", "2021-04-08", "Sài Gòn", "0912345678", "gv2@gmail.com"),
        new GiaoVien(3, "Trịnh Khắc Tùng", "2021-04-29", "Quy Nhơn", "0912348765", "gv3@gmail.com"),
        // Add more mock data to test pagination
        new GiaoVien(4, "Nguyễn Văn A", "2021-03-15", "Đà Nẵng", "0912456789", "gv4@gmail.com"),
        new GiaoVien(5, "Lê Thị B", "2021-02-10", "Hải Phòng", "0912567890", "gv5@gmail.com"),
        new GiaoVien(6, "Phan Minh C", "2021-01-05", "Bình Dương", "0912678901", "gv6@gmail.com"),
        new GiaoVien(7, "Nguyễn Thị D", "2020-12-20", "Nha Trang", "0912789012", "gv7@gmail.com"),
        new GiaoVien(8, "Trần Thanh E", "2020-11-25", "Quảng Ninh", "0912890123", "gv8@gmail.com")
    };

        // Màn 1: Hiển thị danh sách giáo viên với phân trang
        public IActionResult Index(int page = 1, int pageSize = 5)
        {
            // Tính toán tổng số trang
            var totalItems = danhSachGiaoVien.Count();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            // Lấy danh sách giáo viên cho trang hiện tại
            var giaoVienPage = danhSachGiaoVien.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            // Truyền thông tin phân trang vào ViewBag
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(giaoVienPage);
        }

       
    


    // Màn 2: Chi tiết giáo viên
    public IActionResult ChiTiet(int id)
        {
            var giaoVien = danhSachGiaoVien.FirstOrDefault(gv => gv.Id == id);
            if (giaoVien == null && id != 0) return NotFound();
            return View(giaoVien);
        }

        // Lưu thông tin giáo viên (Thêm/Sửa)
        [HttpPost]
        public IActionResult Luu(GiaoVien giaoVien)
        {
            if (giaoVien.Id == 0)
            {
                giaoVien.Id = danhSachGiaoVien.Count + 1; // Thêm giáo viên mới
                danhSachGiaoVien.Add(giaoVien);
            }
            else
            {
                var existingGiaoVien = danhSachGiaoVien.FirstOrDefault(gv => gv.Id == giaoVien.Id);
                if (existingGiaoVien != null)
                {
                    existingGiaoVien.HoTen = giaoVien.HoTen;
                    existingGiaoVien.NgaySinh = giaoVien.NgaySinh;
                    existingGiaoVien.DiaChi = giaoVien.DiaChi;
                    existingGiaoVien.SoDienThoai = giaoVien.SoDienThoai;
                    existingGiaoVien.Email = giaoVien.Email;
                }
            }

            return RedirectToAction("Index");
        }

        // Xóa giáo viên
        public IActionResult Xoa(int id)
        {
            var giaoVien = danhSachGiaoVien.FirstOrDefault(gv => gv.Id == id);
            if (giaoVien != null)
            {
                danhSachGiaoVien.Remove(giaoVien);
            }

            return RedirectToAction("Index");
        }

         public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
