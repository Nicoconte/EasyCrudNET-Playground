using EasyCrudNET.Mappers.Attributes;

namespace EasyCrudLocalPlayground.Entities
{
    public class Cliente
    {
        [Field("cliente_num")]
        public int Id { get; set; }
            
        [Field("nombre")]
        public string Nombre { get; set; }

        [Field("apellido")]
        public string Apellido { get; set; }

        [Field("empresa")]
        public string Empresa { get; set; }

        public string domicilio { get; set; }
        public string ciudad { get; set; }
        public string codPostal { get; set; }
        public string telefono { get; set; }
        public bool estado { get; set; }
    }
}
