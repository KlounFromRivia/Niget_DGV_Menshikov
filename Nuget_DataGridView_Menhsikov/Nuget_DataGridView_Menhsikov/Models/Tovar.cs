using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuget_DataGridView_Menhsikov.Models
{
    /// <summary>
    /// Сущность студента
    /// </summary>
    public class Tovar
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Наименование товара
        /// </summary>
        public string TovarName { get; set; }
        /// <summary>
        /// Пол
        /// </summary>
        public Material Material { get; set; }
        /// <summary>
        /// Размер
        /// </summary>
        public string Size { get; set; }
        /// <summary>
        /// Кол-во на складе
        /// </summary>
        public int Count { get; set; }
        /// <summary>
        /// Минимальное кол-во на складе
        /// </summary>
        public int MinCount { get; set; }
        /// <summary>
        /// Цена без ндс
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// Общая сумма товара
        /// </summary>
        public double AllPrice { get; set; }

    }
}
