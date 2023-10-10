using DE02.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DE02.BUS
{
    public class LoaiSPService
    {
        public List<LoaiSP> GetAll()
        {
            Database db = new Database();
            return db.LoaiSP.ToList();
        }
    }
}
