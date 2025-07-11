using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OfficeHelperWPF1.Data;
using OfficeHelperWPF1.Interfaces;
using OfficeHelperWPF1.Models;

namespace OfficeHelperWPF1.Repositories
{
    class OfficeEquipmentRepository : IOfficeEquipmentRepository
    {
        private readonly OfficeHelperContext _context; 

        public OfficeEquipmentRepository()
        {
            _context = new OfficeHelperContext();
            _context.Database.EnsureCreated();
        }

        /// <summary>
        /// Сохраняет изменения базы данных
        /// </summary>
        /// <returns></returns>
        public bool Save()
        {
            return _context.SaveChanges() > 0 ? true : false;
        }

        /// <summary>
        /// Возвращает все данные из таблицы OfficeEquipment в виде ObservableCollection
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<OfficeEquipment> GetOfficeEquipment()
        {
            _context.OfficeEquipment.Load();
            return _context.OfficeEquipment.Local.ToObservableCollection();
        }

        /// <summary>
        /// Вставляет одну переданную запись в таблицу OfficeEquipment
        /// </summary>
        /// <param name="officeEquipment">Вставляемый инвентарь</param>
        /// <returns>Возвращает true в случае успешной вставки, иначе false</returns>
        public bool InsertOfficeEquipment(OfficeEquipment officeEquipment)
        {
            _context.OfficeEquipment.Add(officeEquipment);
            GetOfficeEquipment();
            return Save();
        }

        /// <summary>
        /// Обновляет переданную запись в таблице OfficeEquipment
        /// </summary>
        /// <param name="officeEquipment">Обновляемый инвентарь</param>
        /// <returns>Возвращает true в случае успешного обновления, иначе false</returns>
        public bool UpdateOfficeEquipment(OfficeEquipment officeEquipment)
        {
            _context.Update(officeEquipment);
            return Save();
        }

        /// <summary>
        /// Удаляет переданные записи из таблицы OfficeEquipment
        /// </summary>
        /// <param name="officeEquipmentList">List из удаляемых экземпляров инвентаря</param>
        /// <returns>Возвращает true в случае успешного удаления, иначе false</returns>
        public bool DeleteOfficeEquipment(List<OfficeEquipment> officeEquipmentList)
        {
            _context.OfficeEquipment.RemoveRange(officeEquipmentList);
            return Save();
        }
    }
}
