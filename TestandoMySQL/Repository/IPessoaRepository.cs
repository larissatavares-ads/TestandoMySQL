using TestandoMySQL.Models;

namespace TestandoMySQL.Repository
{
    public interface IPessoaRepository
    {
        Task CriarPessoa(Pessoa pessoa);
        Task<List<Pessoa>> RecuperarPessoas();
    }
}
