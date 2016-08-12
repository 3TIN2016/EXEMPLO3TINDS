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
    class DALUsuario : DALConnection, IPadraoDALModel
    {
        #region Incluir
        public int Incluir(object obj)
        {
            int resp;

            UsuarioModel objUsuario = new UsuarioModel();
            objUsuario = (UsuarioModel)obj;

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

                        Comando.CommandText = "INSERT INTO USUARIO(NOMEUSUARIO, SENHAUSUARIO, CODTPUSUARIO)" +
                                             "VALUES (@Nome, @Senha, @CodTpUsuario)";

                        Comando.Parameters.Add("@Nome", sqlDbType: System.Data.SqlDbType.VarChar).Value = objUsuario.NomeUsuario;
                        Comando.Parameters.Add("@Senha", sqlDbType: System.Data.SqlDbType.VarChar).Value = objUsuario.SenhaUsuario;
                        Comando.Parameters.Add("@CodTpUsuario", sqlDbType: System.Data.SqlDbType.Int).Value = objUsuario.TipoID;

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
            UsuarioModel objUsuario = new UsuarioModel();
            objUsuario = (UsuarioModel)obj;

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

                        Comando.CommandText = "UPDATE USUARIO SET NOMEUSUARIO = @Nome , SENHAUSUARIO = @Senha , CODTPUSUARIO = @CodTpUsuario WHERE CODUSUARIO = @IdUsuario ";

                        Comando.Parameters.Add("@IdUsuario", sqlDbType: System.Data.SqlDbType.Int).Value = objUsuario.UsuarioID;
                        Comando.Parameters.Add("@Nome", sqlDbType: System.Data.SqlDbType.VarChar).Value = objUsuario.NomeUsuario;
                        Comando.Parameters.Add("@Senha", sqlDbType: System.Data.SqlDbType.VarChar).Value = objUsuario.SenhaUsuario;
                        Comando.Parameters.Add("@CodTpUsuario", sqlDbType: System.Data.SqlDbType.Int).Value = objUsuario.TipoID;


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

                        
                        Comando.CommandText = "DELETE FROM USUARIO WHERE CODUSUARIO = @Codigo";

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

                        Comando.CommandText = "SELECT * FROM USUARIO";

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
            UsuarioModel objUsuario = new UsuarioModel();

            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "SELECT * FROM USUARIO WHERE CODUSUARIO = @Codigo";

                        Comando.Parameters.Add("@Codigo", sqlDbType: System.Data.SqlDbType.Int).Value = codigo;

                        Dtr = Comando.ExecuteReader();

                        if (Dtr.HasRows)
                        {
                            objUsuario.TipoID = codigo;
                            objUsuario.NomeUsuario = Dtr["NOMEUSUARIO"].ToString();
                            objUsuario.SenhaUsuario = Dtr["SENHAUSUARIO"].ToString();
                            objUsuario.TipoID = Convert.ToInt16(Dtr["CODTPUSUARIO"].ToString());

                        }

                        return objUsuario;

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

                        Comando.CommandText = "SELECT * FROM USUARIO WHERE NOMEUSUARIO LIKE %@Desc%";

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


        #region Controle Usuario
        public bool ControlarUsuario(string nome, string senha)
        {
            int resposta;

            using (Conexao)
            {
                using (Comando)
                {
                    try
                    {
                        Conexao.ConnectionString = CnnStr;
                        Conexao.Open();
                        Comando.Connection = Conexao;

                        Comando.CommandText = "SELECT * FROM USUARIO WHERE NOMEUSUARIO = @Usr AND SENHAUSUARIO = @Passwd";

                        Comando.Parameters.Add("@Usr", sqlDbType: System.Data.SqlDbType.VarChar).Value = nome;
                        Comando.Parameters.Add("@Passwd", sqlDbType: System.Data.SqlDbType.VarChar).Value = senha;


                        Dtr = Comando.ExecuteReader();

                        return Dtr.HasRows;                                              

                    }
                    catch (SqlException ex1)
                    {

                        throw new Exception(ex1.Message);
                    }
                    catch (Exception ex2)
                    {

                        throw new Exception(ex2.Message);
                    }
                    finally
                    {
                        this.Dispose();
                    }
                }
            }
        }
        #endregion
    }
}
