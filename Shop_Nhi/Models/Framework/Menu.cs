namespace Shop_Nhi.Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string link { get; set; }

        [StringLength(300)]
        public string taget { get; set; }

        public int? dislayOrder { get; set; }

        public int? typeID { get; set; }

        public bool? status { get; set; }

        public virtual MenuType MenuType { get; set; }
    }
}
