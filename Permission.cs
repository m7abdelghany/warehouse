namespace WarehouseTask
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequestNo { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? Quantity { get; set; }

        public int SupplierID { get; set; }

        public DateTime? Date { get; set; }

        public int? ProductCode { get; set; }

        public int? warehouseID { get; set; }

        [StringLength(50)]
        public string Type { get; set; }

        public virtual Product Product { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Warehouse Warehouse { get; set; }

        public virtual Supplier Supplier1 { get; set; }
    }
}
