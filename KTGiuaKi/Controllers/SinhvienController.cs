using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using KTGiuaKi.Models;

namespace KTGiuaKi.Controllers
{
    public class SinhVienController : Controller
    {
        MydataDataContext data = new MydataDataContext();
        // GET: SinhVien
        public ActionResult Index()
        {
            var all_sinhvien = from ss in data.SinhViens select ss;

            return View(all_sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien s)
        {
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = collection["NgaySinh"];
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];
            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Không được để trống!";
            }
            else
            {
                s.MaSV = collection["MaSV"];
                s.HoTen = E_HoTen.ToString();
                s.NgaySinh = DateTime.Parse(E_NgaySinh);
                s.Hinh = E_Hinh;
                s.MaNganh = E_MaNganh;
                data.SinhViens.InsertOnSubmit(s);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }
        public ActionResult Edit(string id)
        {
            var E_SinhVien = data.SinhViens.(m => m.MaSV == id);
            return View(E_SinhVien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_MaSinhVien = data.SinhViens.First(m => m.MaSV == id);
            var E_HoTen = collection["HoTen"];
            var E_GioiTinh = collection["GioiTinh"];
            var E_NgaySinh = collection["NgaySinh"];
            var E_Hinh = collection["Hinh"];
            var E_MaNganh = collection["MaNganh"];
            E_MaSinhVien.MaSV = id;
            if (string.IsNullOrEmpty(E_HoTen))
            {
                ViewData["Error"] = "Không được để trống";
            }
            else
            {
                E_MaSinhVien.HoTen = E_HoTen;
                E_MaSinhVien.GioiTinh = E_GioiTinh;
                E_MaSinhVien.NgaySinh = DateTime.Parse(E_NgaySinh);
                E_MaSinhVien.Hinh = E_Hinh;
                E_MaSinhVien.MaNganh = E_MaNganh;
                UpdateModel(E_MaSinhVien);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }
        public ActionResult Delete(string id)
        {
            var D_SinhVien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_SinhVien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_SinhVien = data.SinhViens.where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_SinhVien);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
        public ActionResult Detail(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
    }
}



