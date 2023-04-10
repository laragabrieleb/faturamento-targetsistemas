
using faturamento_targetsistemas;
using Newtonsoft.Json;

string faturamentoJson = File.ReadAllText("./dados/Dados.json");

List<Faturamento> faturamentos = JsonConvert.DeserializeObject<List<Faturamento>>(faturamentoJson);

//remover faturamento de feriados e dia de semana
faturamentos.RemoveAll(x => x.Valor == 0);

//achar e armazenar o menor valor de faturamento 
Faturamento menorFaturamento = faturamentos.MinBy(x => x.Valor);

//achar e armazenar o maior valor de faturamento
Faturamento maiorFaturamento = faturamentos.MaxBy(x => x.Valor);

//achar a média mensal
//pegar o faturamento de todos os dias e dividir pela quantidade de dias
double somaValores = faturamentos.Sum(x => x.Valor);

int quantidadeDias = faturamentos.Count;

double mediaFaturamentoMensal = somaValores / quantidadeDias;

List<Faturamento> faturamentosSuperioresMedia = new List<Faturamento>();

//Número de dias no mês em que o valor de faturamento diário foi superior à média mensal.
List<Faturamento> diasFaturamentoSuperiorMedia = faturamentos.FindAll(x => x.Valor > mediaFaturamentoMensal);

faturamentosSuperioresMedia.AddRange(diasFaturamentoSuperiorMedia);

Console.WriteLine("Menor faturamento mensal - Dia: " + menorFaturamento.Dia + " Valor: " + menorFaturamento.Valor.ToString("F2"));

Console.WriteLine("Maior faturamento mensal - Dia: " + maiorFaturamento.Dia + " Valor: " + maiorFaturamento.Valor.ToString("F2"));

Console.WriteLine("Média de faturamento mensal - Valor " + mediaFaturamentoMensal.ToString("F2"));

Console.WriteLine("Quantidade de dias que o valor de faturamento foi superior à média mensal: " + diasFaturamentoSuperiorMedia.Count);

Console.WriteLine("Dias que o valor de faturamento foi superior à média mensal:");

foreach (var item in faturamentosSuperioresMedia)
{
    Console.Write(item.Dia + "; ");
}




Console.ReadLine();

