using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrjDSII3Tin.Data_Access_Layer
{
    internal class DALConnection : IDisposable
    {
        protected string CnnStr = "Data Source=.;Initial Catalog=BD3TINDS;Persist Security Info=True;User ID=sa;Password=123456"; //ConfigurationManager.ConnectionStrings["ConnString"].ConnectionString;
        protected SqlConnection Conexao = new SqlConnection();
        protected SqlCommand Comando = new SqlCommand();
        protected SqlDataReader Dtr;
        protected SqlDataAdapter Dta = new SqlDataAdapter();

        private bool disposed = false;



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Conexao.Dispose();
                    Comando.Dispose();
                    Dtr.Dispose();
                    Dta.Dispose();
                }

                disposed = true;
            }
        }
    }
}
