using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuget_DataGridView_Menhsikov.Models
{
    /// <summary>
    /// Материал
    /// </summary>
    public enum Material
    {
        /// <summary>
        /// Медь
        /// </summary>
        [Description("Медь")]
        Med,
        /// <summary>
        /// Сталь
        /// </summary>
        [Description("Сталь")]
        Stal,
        /// <summary>
        /// Сталь
        /// </summary>
        [Description("Железо")]
        Iron,
        /// <summary>
        /// Сталь
        /// </summary>
        [Description("Хром")]
        Hrom,
    }
}
