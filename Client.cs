namespace WarehouseTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Client")]
    public partial class Client
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Mobile { get; set; }

        public int? Fax { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        public int? Telephone { get; set; }

        public int? productID { get; set; }

        [StringLength(50)]
        public string WebSite { get; set; }

        public virtual Product Product { get; set; }
    }
}
