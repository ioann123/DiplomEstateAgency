//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DiplomEstateAgency
{
    using System;
    using System.Collections.Generic;
    
    public partial class Apartaments
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Apartaments()
        {
            this.Deals = new HashSet<Deals>();
        }
    
        public int ID { get; set; }
        public Nullable<int> HousesOrPlots { get; set; }
        public Nullable<int> GarageParking { get; set; }
        public Nullable<int> Flats { get; set; }
    
        public virtual Flats Flats1 { get; set; }
        public virtual GarageParking GarageParking1 { get; set; }
        public virtual Houses_Plots Houses_Plots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Deals> Deals { get; set; }
    }
}