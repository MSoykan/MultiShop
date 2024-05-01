using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using MultiShop.Cargo.DataAccessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.EntityFramework {
    public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal {
        // aynı and neden cargo compant ve ICargoCompant interfacelerini implemente ediyoruz?
        //ICargoCompanyDal içinde sadece cargocompany'e özgü işlemler barınır
        public EfCargoCompanyDal(CargoContext context) : base(context) {
        }
    }
}
