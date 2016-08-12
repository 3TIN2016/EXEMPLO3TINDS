using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjDSII3Tin.Interfaces
{
    interface IPadraoBLL
    {
        #region Incluir
        int Incluir(object obj);
        #endregion

        #region Editar
        int Editar(object obj);
        #endregion

        #region Excluir
        int Excluir(Int32 codigo);
        #endregion

        #region Listar Todos Registros
        DataTable ListarRegistros();
        #endregion

        #region Consulta Unico Registro
        object ConsultaRegistro(Int32 codigo);
        #endregion

        #region Consulta Registro Nome
        DataTable ListarRegistros(string nome);
        #endregion
    }
}
