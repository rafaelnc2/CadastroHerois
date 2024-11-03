using System.Data;
using System.Data.SqlClient;

namespace CadastroHerois.Api.Infra.DataAccess;

public class DapperContext: IDisposable
{
    public SqlConnection Connection { get; set; }

    public DapperContext(IConfiguration configuration)
    {
        Connection = new SqlConnection(configuration.GetConnectionString("SqlServer"));
        Connection.Open();
    }
    
    public void Dispose()
    {
        if(Connection.State != ConnectionState.Closed)
        {
            Connection.Close();
        }
    }
}