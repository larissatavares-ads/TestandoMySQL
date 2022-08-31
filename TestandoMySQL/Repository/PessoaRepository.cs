using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;
using TestandoMySQL.Models;
using TestandoMySQL.Settings;

namespace TestandoMySQL.Repository
{
    public class PessoaRepository : IPessoaRepository
    {
        public string _connectionString { get; set; }

        public PessoaRepository(ConnectionStringSettings settings)
        {
            _connectionString = settings.ConnexionString();
        }
        public async Task CriarPessoa(Pessoa pessoa)
        {
            using (IDbConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                await conexao
                    .ExecuteAsync($"INSERT INTO Pessoa (Id, Nome, Idade) VALUES (@Id, @Nome, @Idade);", pessoa);
            }
        }
        public async Task<List<Pessoa>> RecuperarPessoas()
        {
            using (IDbConnection conexao = new MySqlConnection(_connectionString))
            {
                conexao.Open();
                return (await conexao
                    .QueryAsync<Pessoa>("SELECT * FROM Pessoa;")).ToList();
            }
        }
    }
}
