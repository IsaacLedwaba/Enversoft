using FrontDAL.Models;
using System.Collections.Generic;
using System.Linq;

namespace FrontDAL
{
    public class SupplierManager
    {
        public List<Supplier> GetSuppliers()
        {
            using (var context = new SupplierDBContext())
            {
                return context.Suppliers.ToList();
            }
        }

        public void AddSupplier(Supplier supplier)
        {
            using (var context = new SupplierDBContext())
            {
                context.Add(supplier);
                context.SaveChanges();
            }
        }
    }
}
