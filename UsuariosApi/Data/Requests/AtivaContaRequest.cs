using System.ComponentModel.DataAnnotations;

namespace UsuariosApi.Data.Requests
{
    public class AtivaContaRequest
    {
        [Required]
        public string CodigoDeAtivacao { get; set; }

        [Required]
        public int UsuarioID{ get; set; }
    }
}
