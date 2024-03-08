using System;

namespace CalculadoraCombustivel
{
    class Program
    {
        static void Main(string[] args)
        {
            float proporcaoPadrao = 0.7f;
            float eficienciaEtanol = 0.7f;
            float eficienciaGasolina = 1.0f;

            while (true)
            {
                Console.WriteLine("1. Calcular combustível");
                Console.WriteLine("2. Editar dados");
                Console.WriteLine("3. Sair");
                Console.WriteLine("Escolha uma opção:");

                int opcao;
                if (!int.TryParse(Console.ReadLine(), out opcao))
                {
                    Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                    continue;
                }

                switch (opcao)
                {
                    case 1:
                        CalcularCombustivel(proporcaoPadrao, eficienciaEtanol, eficienciaGasolina);
                        break;
                    case 2:
                        EditarDados(out eficienciaEtanol, out eficienciaGasolina);
                        break;
                    case 3:
                        if (ConfirmarSaida())
                            Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Por favor, tente novamente.");
                        break;
                }
            }
        }

        static void CalcularCombustivel(float proporcaoPadrao, float eficienciaEtanol, float eficienciaGasolina)
        {
            Console.WriteLine("(E para etanol, G para gasolina, ou F para flex) Digite uma sigla para informar o tipo do seu carro: ");
            string tipoCarro = Console.ReadLine().ToUpper();

            float precoEtanol = 0f, precoGasolina = 0f;

            if (tipoCarro == "F")
            {
                Console.WriteLine("Informe o preço do etanol: ");
                precoEtanol = LerFloatPositivo();

                Console.WriteLine("Informe o preço da gasolina: ");
                precoGasolina = LerFloatPositivo();

                float proporcaoEficiencia = eficienciaEtanol / eficienciaGasolina;

                if (precoEtanol / precoGasolina < proporcaoEficiencia)
                {
                    Console.WriteLine("O combustível mais vantajoso é o etanol.");
                }
                else
                {
                    Console.WriteLine("O combustível mais vantajoso é a gasolina.");
                }
            }
            else if (tipoCarro == "E")
            {
                Console.WriteLine("Etanol é mais vantajoso.");
            }
            else if (tipoCarro == "G")
            {
                Console.WriteLine("A Gasolina é mais vantajosa.");
            }
            else
            {
                Console.WriteLine("Tipo de carro inválido. Por favor, tente novamente.");
            }
        }

        static void EditarDados(out float eficienciaEtanol, out float eficienciaGasolina)
        {
            Console.WriteLine("Digite a eficiência do seu carro com etanol (km/l): ");
            eficienciaEtanol = LerFloatPositivo();

            Console.WriteLine("Digite a eficiência do seu carro com gasolina (km/l): ");
            eficienciaGasolina = LerFloatPositivo();
        }

        static bool ConfirmarSaida()
        {
            Console.WriteLine("Deseja realmente sair? (S/N): ");
            string resposta = Console.ReadLine().ToUpper();
            return resposta == "S";
        }

        static float LerFloatPositivo(string mensagem = "")
        {
            float valor;
            while (true)
            {
                Console.Write(mensagem);
                if (float.TryParse(Console.ReadLine(), out valor) && valor >= 0)
                    return valor;
                Console.WriteLine("Valor inválido. Tente novamente.");
            }
        }
    }
}
