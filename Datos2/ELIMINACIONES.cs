//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Datos2
{
    using System;
    using System.Collections.Generic;
    
    public partial class ELIMINACIONES
    {
        public decimal ID { get; set; }
        public Nullable<decimal> USU_ID { get; set; }
        public Nullable<decimal> MOT_ID { get; set; }
        public Nullable<decimal> MED_ID { get; set; }
        public Nullable<decimal> PAR_ID { get; set; }
        public Nullable<decimal> CANTIDAD { get; set; }
        public Nullable<System.DateTime> FECHA { get; set; }
    
        public virtual MEDICAMENTOS MEDICAMENTOS { get; set; }
        public virtual MOTIVO_ELIMINACION MOTIVO_ELIMINACION { get; set; }
        public virtual PARTIDAS PARTIDAS { get; set; }
        public virtual USUARIOS USUARIOS { get; set; }
    }
}