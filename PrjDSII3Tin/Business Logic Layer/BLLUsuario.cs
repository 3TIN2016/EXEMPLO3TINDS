using PrjDSII3Tin.Data_Access_Layer;
using PrjDSII3Tin.Interfaces;
using PrjDSII3Tin.Model_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjDSII3Tin.Business_Logic_Layer
{
    class BLLUsuario : IPadraoBLL
    {

        DALUsuario objDalUsuario = new DALUsuario();
        UsuarioModel objUsuarioModel;

        #region Incluir
        public int Incluir(object obj)
        {
            objUsuarioModel = (UsuarioModel)obj;

            try
            {
                if (String.IsNullOrEmpty(objUsuarioModel.NomeUsuario) ||
                    String.IsNullOrEmpty(objUsuarioModel.SenhaUsuario) ||
                    String.IsNullOrEmpty(objUsuarioModel.TipoID.ToString())
                    )
                {
                    throw new Exception("Dados inválidos, nulos ou vazios!");
                }
                else
                {
                    return objDalUsuario.Incluir(objUsuarioModel);
                }
            }
            catch (Exception ex)
            {
               
               throw new Exception("Erro!" + ex.Message);
            }
        }
        #endregion

        public int Editar(object obj)
        {
            throw new NotImplementedException();
        }

        public int Excluir(int codigo)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarRegistros()
        {
            throw new NotImplementedException();
        }

        public object ConsultaRegistro(int codigo)
        {
            throw new NotImplementedException();
        }

        public DataTable ListarRegistros(string nome)
        {
            throw new NotImplementedException();
        }

        #region Controle Usuario
        public bool ControlarUsuario(string nome, string senha)
        {
            try
            {
                if (String.IsNullOrEmpty(nome) ||
                    String.IsNullOrEmpty(senha) )
                {
                    throw new Exception("Dados inválidos, nulos ou vazios!");
                }
                else
                {
                    return objDalUsuario.ControlarUsuario(nome, senha);
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Erro! " + ex.Message);
            }
        }
        #endregion
    }
}
