namespace Shop_Nhi.Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seo")]
    public partial class Seo
    {
        public int ID { get; set; }

        public int? key { get; set; }

        [StringLength(100)]
        public string value { get; set; }

        public bool? status { get; set; }
    }
}
