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
    
    public partial class Houses_Plots
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Houses_Plots()
        {
            this.Apartaments = new HashSet<Apartaments>();
        }
    
        public int ID { get; set; }
        public Nullable<int> City { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Flat { get; set; }
        public string Entrance { get; set; }
        public Nullable<decimal> Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Apartaments> Apartaments { get; set; }
        public virtual City City1 { get; set; }
    }
}
