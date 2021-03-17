using System.Collections.Generic;

namespace ETAPA3.Models
{
    public static class UsuarioDados
    {
       
        private static List<Usuario> listaUsuario = new List<Usuario>();

        public static void Incluir(Usuario usuario)
        {
            listaUsuario.Add(usuario);
        }
        public static List<Usuario> Listar()
        {
            return listaUsuario;
        }
    }
}