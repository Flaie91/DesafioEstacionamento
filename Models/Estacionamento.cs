using System.Text.RegularExpressions;

namespace DesafioEstacionamento.Models

{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {                        
            Console.WriteLine("Digite a placa do veículo para cadastrar. (Só letras e Números):");
            
            string? entrada = Console.ReadLine(); // pode aceitar null

            //if (entrada != null)  //estava passando vazio  

            if ((!string.IsNullOrEmpty(entrada)) && (ValidarPlaca(entrada)))  // só executa se não for null e for uma placa válida
            {
                string placa = entrada;
                
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"O veículo {placa.ToUpper()} foi cadastrado com sucesso.");                
                      
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, tente novamente.");
            }

            bool ValidarPlaca(string placa)
            {
                // Padrão para placas antigas
                string padraoAntigo = @"(?i)^[A-Z]{3}-?\d{4}$";     
                // Padrão para placas do Mercosul
                string padraoMercosul = @"(?i)^[A-Z]{3}\d[A-Z]\d{2}$";     

                // Verifica se a placa corresponde a um dos padrões
                return Regex.IsMatch(placa, padraoAntigo) || Regex.IsMatch(placa, padraoMercosul);
            }
                 
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            
            string? entrada = Console.ReadLine();

            if (entrada != null)
            {   
                string placa = entrada.ToUpper(); // Converte para uppercase

                // Verifica se o veículo existe
                if (veiculos.Any(x => x == placa))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                                        
                    // Usando TryParse para garantir a conversão correta
                    if (int.TryParse(Console.ReadLine(), out int horas))
                    {
                        decimal valorTotal = precoInicial + (precoPorHora * horas);
                        veiculos.Remove(placa); 

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida para horas. Por favor, digite um número inteiro.");
                    }   

                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui! Confira se digitou a placa corretamente.");
                }
                
            }
            else
            {
                   Console.WriteLine("Entrada inválida! Por favor, tente novamente.");
            }
        }
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                
                int indice = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{indice}º - {veiculo}"); // Itera sobre a lista de veículos e exibe cada um
                    indice++;
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados no momento!");
            }
        }
    }
}

