using PrjDSII3Tin.Interfaces;
using PrjDSII3Tin.Model_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjDSII3Tin.Data_Access_Layer
{
    class DALTipoUsuario : DALConnection , IPadraoDALModel
    {

        #region Incluir
        public int Incluir(object obj)
        {
            int resp;

            TipoUsuarioModel objTPUsuario = new TipoUsuarioModel();
            objTPUsuario = (TipoUsuarioModel)obj;

            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Comando.Parameters.Clear();
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "INSERT INTO TIPOUSUARIO(DESCTPUSUARIO)" +
                                             "VALUES (@Descricao)";

                        Comando.Parameters.Add("@Descricao", sqlDbType: System.Data.SqlDbType.VarChar).Value = objTPUsuario.DescricaoTipo ;
                        

                        resp = Comando.ExecuteNonQuery();

                        Conexao.Close();
                    }
                    catch (SqlException ex1)
                    {
                        return ex1.Number;
                        throw new Exception(ex1.Message);
                    }
                    catch (Exception ex)
                    {
                        return 00000;
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        this.Dispose();
                    }

                }

                return resp;
            }

        }
        #endregion


        #region Editar
        public int Editar(object obj)
        {
            TipoUsuarioModel objTPUsuario = new TipoUsuarioModel();
            objTPUsuario = (TipoUsuarioModel)obj;

            int resp;

            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Comando.Parameters.Clear();
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "UPDATE TIPOUSUARIO SET DESCTPUSUARIO = @Descricao WHERE CODTPUsuario = @IdUsuario ";

                        Comando.Parameters.Add("@Descricao", sqlDbType: System.Data.SqlDbType.VarChar).Value = objTPUsuario.DescricaoTipo;
                        Comando.Parameters.Add("@IdUsuario", sqlDbType: System.Data.SqlDbType.Int).Value = objTPUsuario.TipoID;

                        

                       resp = Comando.ExecuteNonQuery();

                        Conexao.Close();
                    }
                    catch (SqlException ex1)
                    {
                        return ex1.Number;
                        throw new Exception(ex1.Message);
                    }
                    catch (Exception ex)
                    {
                        return 00000;
                        throw new Exception(ex.Message);
                    }
                    finally
                    {
                        this.Dispose();
                    }
                }
                return resp;
            }
        }
        #endregion


        #region Excluir
        public int Excluir(int codigo)
        {
            int resp;

            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Comando.Parameters.Clear();
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "DELETE FROM TIPOUSUARIO WHERE CODTPUSUARIO = @Codigo";

                        Comando.Parameters.Add("@Codigo", sqlDbType: System.Data.SqlDbType.Int).Value = codigo;


                        resp = Comando.ExecuteNonQuery();

                        Conexao.Close();
                    }
                    catch (SqlException ex1)
                    {
                        
                        throw new Exception(ex1.Message + ex1.ErrorCode);
                    }
                    catch (Exception ex)
                    {
                        
                        throw new Exception(ex.Message + "0000");
                    }
                    finally
                    {
                        this.Dispose();
                    }

                }

                return resp;
            }
        }
        #endregion


        #region Listar Todos
        public System.Data.DataTable ListarRegistros()
        {
            DataTable tabelaretorno = new DataTable();

            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "SELECT * FROM TIPOUSUARIO";

                        Dtr = Comando.ExecuteReader();

                        tabelaretorno.Load(Dtr);

                        return tabelaretorno;

                    }
                    catch (SqlException ex1)
                    {

                        throw new Exception(ex1.Message);
                    }
                    catch (Exception ex2)
                    {

                        throw new Exception(ex2.Message);
                    }
                }
            }
        }
        #endregion


        #region Listar por Codigo
        public object ConsultaRegistro(int codigo)
        {
            TipoUsuarioModel objTPUsuario = new TipoUsuarioModel();
            
            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "SELECT * FROM TIPOUSUARIO WHERE CODTPUSUARIO = @Codigo";

                        Comando.Parameters.Add("@Codigo", sqlDbType: System.Data.SqlDbType.Int).Value = codigo;

                        Dtr = Comando.ExecuteReader();

                        if (Dtr.HasRows)
                        {
                            objTPUsuario.TipoID = codigo;
                            objTPUsuario.DescricaoTipo = Dtr["DescTPUsuario"].ToString();
                            


                        }

                        return objTPUsuario;

                    }
                    catch (SqlException ex1)
                    {

                        throw new Exception(ex1.Message + ex1.ErrorCode);
                    }
                    catch (Exception ex2)
                    {

                        throw new Exception(ex2.Message);
                    }
                }
            }
        }
        #endregion

        
        #region Listar por Nome
        public System.Data.DataTable ListarRegistros(string nome)
        {
            DataTable tabelaretorno = new DataTable();

            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "SELECT * FROM TIPOUSUARIO WHERE DESCTPUSUARIO LIKE %@Desc%";

                        Comando.Parameters.Add("@Desc", sqlDbType: System.Data.SqlDbType.VarChar).Value = nome;
                        
                        Dtr = Comando.ExecuteReader();

                        tabelaretorno.Load(Dtr);

                        return tabelaretorno;

                    }
                    catch (SqlException ex1)
                    {

                        throw new Exception(ex1.Message);
                    }
                    catch (Exception ex2)
                    {

                        throw new Exception(ex2.Message);
                    }
                }
            }
        }
        #endregion
    }
}
