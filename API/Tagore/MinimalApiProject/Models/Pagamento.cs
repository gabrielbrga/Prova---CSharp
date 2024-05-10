using System.ComponentModel.DataAnnotations;
namespace API.Models;
public class Pagamento
{
public Pagamento()
{
    

}

public Pagamento( int quantidade, double salarioBruto,
                double impostoIr, double Inss, double salarioLiquido, double Fgts)
{
    Fgts = 0;
    ImpostoIr = 0;
    SalarioBruto = 20;
    SalarioLiquido = 0;
    Quantidade = 0;

    salarioBruto = quantidade * 20;
    Fgts = (salarioBruto * 0.8);
    if(salarioBruto <= 1693.72){
        Inss = (salarioBruto * 0.8);
    }if (salarioBruto >= 1693.73 && salarioBruto <= 2822.90)
    {
        Inss = (salarioBruto * 0.9);
    }if (salarioBruto >= 2822.91 && salarioBruto <= 5645.80)
    {
        Inss = (salarioBruto * 0.11);
    }else
    {
        Inss = 621.03;
    }
    if(salarioBruto <= 1903.98){
        impostoIr = 0;
    }
    if(salarioBruto >= 1903.99 && salarioBruto <= 2826.65){
        impostoIr = (salarioBruto * 0.75) + 142.80;
    }
    if(salarioBruto >= 2826.66 && salarioBruto <=3751.05){
        impostoIr = (salarioBruto * 1.05) + 354.80;
    }
    if (salarioBruto >= 3751.06 && salarioBruto <=4664.68)
    {
        impostoIr = (salarioBruto * 2.25) + 636.13;
    }
    else
    {
        impostoIr = 4664.68 + 869.36;
    }

    salarioLiquido = salarioBruto - impostoIr - Inss;
}



    public int quantidade {get; set;}
    public double salarioLiquido{ get; set; }
    public double salarioBruto { get; set; }
    public double Inss { get; set; }
    public double impostoIr  { get; set; }

}





 
 
