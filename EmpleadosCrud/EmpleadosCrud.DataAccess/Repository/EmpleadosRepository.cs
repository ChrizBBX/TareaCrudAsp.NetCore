using EmpleadosCrud.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EmpleadosCrud.DataAccess.Repository
{
    public class EmpleadosRepository: IRepository<tbEmpleados>
    {
        public int Delete(tbEmpleados item)
        {
            throw new NotImplementedException();
        }

        public tbEmpleados find(int? id)
        {
            using var db = new TareacrudEmpleadoContext();
            var listado = db.tbEmpleados.Find(id);
            return listado;
        }

        public int Insert(tbEmpleados item)
        {
            using var db = new TareacrudEmpleadoContext();
            db.tbEmpleados.Add(item);
            db.SaveChanges();
            return item.empe_Id;
        }

        public IEnumerable<tbEmpleados> List()
        {
            using var db = new TareacrudEmpleadoContext();
            return db.tbEmpleados.ToList();
        }

        public tbEmpleados GetById(int id)
        {
            using var db = new TareacrudEmpleadoContext();
            return db.tbEmpleados.FirstOrDefault(e => e.empe_Id == id);
        }

        public int Update(tbEmpleados item)
        {
            using var db = new TareacrudEmpleadoContext();
            db.Entry(item).State = EntityState.Modified;
            db.SaveChanges();
            return item.empe_Id;
        }

    }
}
