using EasyCrudNET.Mappers.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCrudLocalPlayground.Entities
{
    public class Factura
    {
        [Field("Id")]
        public int Id { get; set; }

        [Field("cliente_Id")]
        public int Cliente { get; set; }

        [Field("fecha_emision")]
        public DateTime FechaEmision { get; set; }
    
        [Field("fecha_vto")]
        public DateTime FechaVto { get; set; }
        
        [Field("fecha_pago")]
        public DateTime FechaPago { get; set; }
    }
}
