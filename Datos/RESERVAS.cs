//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos
{
    using System;
    using System.Collections.Generic;
    
    public partial class RESERVAS
    {
        public RESERVAS()
        {
            this.ALERTAS = new HashSet<ALERTAS>();
        }
    
        public decimal ID { get; set; }
        public Nullable<decimal> PAC_ID { get; set; }
        public Nullable<decimal> MED_ID { get; set; }
        public Nullable<decimal> USU_ID { get; set; }
        public Nullable<decimal> CANTIDAD { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
        public string ESTADO { get; set; }
    
        public virtual ICollection<ALERTAS> ALERTAS { get; set; }
        public virtual MEDICAMENTOS MEDICAMENTOS { get; set; }
        public virtual PACIENTES PACIENTES { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}
