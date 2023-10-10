using DE02.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE02.BUS
{
    public class SanPhamService
    {
        Database db = new Database();
        public List<SanPham> GetAll()
        {
            return db.SanPham.ToList();
        }

        public SanPham FindByMaSP(string maSP)
        {
            return db.SanPham.FirstOrDefault(p => p.MaSP == maSP);
        }
        public void InsertUpdate(List<SanPham> listSP)
        {
            foreach (var item in listSP)
            {
                var ExistingSP = db.SanPham.Find(item.MaSP);
                if (ExistingSP != null)
                {
                    ExistingSP.TenSP = item.TenSP;
                    ExistingSP.NgayNhap = item.NgayNhap;
                    ExistingSP.MaLoai = item.MaLoai;
                    db.SanPham.AddOrUpdate(ExistingSP);
                }
                else
                {
                    db.SanPham.Add(item);
                }
            }
            db.SaveChanges();
        }
    }
}
