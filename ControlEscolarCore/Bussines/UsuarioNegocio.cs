using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;


namespace ControlEscolarCore.Bussines
{
    public class UsuarioNegocio
    {
        public static bool EsFormatoValido (string correo)
        {
            return Validaciones.EsCorreroValido(correo);
        }
    }
}
