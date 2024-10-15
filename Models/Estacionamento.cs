namespace DesafioFundamentos.Models
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
            // TODO: Pedir para o usuário digitar uma placa (ReadLine) e adicionar na lista "veiculos"
            
            Console.WriteLine("Digite a placa do veículo para estacionar (Só letras e Números):");
            string? entrada = Console.ReadLine(); // pode aceitar null

            //if (entrada != null)  //estava passando vazio 

            if (!string.IsNullOrEmpty(entrada)) // só executa se não for null
            {
                string placa = entrada;
                
                veiculos.Add(placa.ToUpper());
                Console.WriteLine($"O veículo {placa.ToUpper()} foi estacionado com sucesso.");      
            }
            else
            {
                Console.WriteLine("Entrada inválida. Por favor, tente novamente.");
            }
                 
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            // Pedir para o usuário digitar a placa e armazenar na variável placa
            // *IMPLEMENTE AQUI*
            string? entrada = Console.ReadLine();

            if (entrada != null)
            {   
                string placa = entrada.ToUpper(); // Converte para uppercase
                // Verifica se o veículo existe
                if (veiculos.Any(x => x == placa))
                {
                    Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                    // TODO: Pedir para o usuário digitar a quantidade de horas que o veículo permaneceu estacionado,
                    // TODO: Realizar o seguinte cálculo: "precoInicial + precoPorHora * horas" para a variável valorTotal                
                    // *IMPLEMENTE AQUI*
                    
                    
                    // TODO: Remover a placa digitada da lista de veículos
                    // *IMPLEMENTE AQUI*
                    // Usando TryParse para garantir a conversão correta
                    if (int.TryParse(Console.ReadLine(), out int horas))
                    {
                        decimal valorTotal = precoInicial + (precoPorHora * horas);
                        veiculos.Remove(placa); // Remove a placa diretamente

                        Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida para horas. Por favor, digite um número inteiro.");
                    }   

                }
                else
                {
                    Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                }
                
            }
            else
            {
                   Console.WriteLine("Entrada inválida. Por favor, tente novamente.");
            }
        }
        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                // TODO: Realizar um laço de repetição, exibindo os veículos estacionados
                // *IMPLEMENTE AQUI*
                int indice = 1;
                foreach (var veiculo in veiculos)
                {
                    Console.WriteLine($"{indice}º - {veiculo}"); // Itera sobre a lista de veículos e exibe cada um
                    indice++;
                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}