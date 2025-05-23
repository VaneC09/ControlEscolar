using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ControlEscolarCore.Utilities;

namespace ControlEscolarCore.Bussines
{
    public class EstudianteNegocio
    {
        public static bool EsCorreoValido(string correo)
        {
            return Validaciones.EsCorreroValido(correo);
        }

        public static bool EsCURPValido(string curp)
        {
            return Validaciones.EsCURPValido(curp);
        }

        ///<sumary>
        ///Valida si el numero de control es válido
        ///Ejemplos válidos: T-2021-1234, M-2021-1234
        ///Ejemplos no válidos: X-2025-123, T-25-123, M-2023-12
        ///</sumary>
        ///<param name="nocontrol"></param>
        ///

        public static bool EsNoControlValido(String nocontrol)
        {
            string patron = @"^(T|M)-\d{4}-\d{3,5}$";
            return Regex.IsMatch(nocontrol, patron);
        }
    }
}
