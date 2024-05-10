using System.ComponentModel.DataAnnotations;
namespace API.Models;
public class Funcionario
{
    public Funcionario(){
    Id = Guid.NewGuid().ToString();
   
}
    public Funcionario(string Nome, double Valor, int funcinarioId)
    {
        Nome = nome;
        Valor = 0;
        FuncinarioId = 0;
    }

    public string? Id { get; set; }
    public string? nome { get; set; }
    public int? cpf { get; set; }

}