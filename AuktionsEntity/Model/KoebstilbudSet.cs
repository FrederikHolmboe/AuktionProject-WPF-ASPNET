//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AuktionsEntity.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class KoebstilbudSet
    {
        public int KoebstilbudId { get; set; }
        public int Pris { get; set; }
        public System.DateTime OpretningsDato { get; set; }
    
        public virtual KundeSet KundeSet { get; set; }
        public virtual SalgsudbudSet SalgsudbudSet { get; set; }
    }
}
