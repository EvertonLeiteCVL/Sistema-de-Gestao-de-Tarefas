using System;
using System.Collections.Generic;

class Program
{
    static List<string> aFazer = new List<string>();
    static List<string> emProgresso = new List<string>();
    static List<string> concluido = new List<string>();

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Sistema de Gestão de Tarefas");
            Console.WriteLine("1 - Adicionar nova tarefa");
            Console.WriteLine("2 - Exibir tarefas");
            Console.WriteLine("3 - Mover tarefa");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");
            string input = Console.ReadLine();

            while (string.IsNullOrEmpty(input) || !int.TryParse(input, out opcao))
            {
                Console.WriteLine("Entrada inválida. Por favor, insira um número.");
                input = Console.ReadLine();
            }

            switch (opcao)
            {
                case 1:
                    AdicionarTarefa();
                    break;
                case 2:
                    ExibirTarefas();
                    break;
                case 3:
                    MoverTarefa();
                    break;
                case 4:
                    Console.WriteLine("Saindo do sistema...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }

            Console.WriteLine();
        } while (opcao != 4);
    }

    static void AdicionarTarefa()
    {
        Console.Write("Digite o nome da tarefa: ");
        string tarefa = Console.ReadLine(); // Removido o operador de nulidade

        if (!string.IsNullOrWhiteSpace(tarefa))
        {
            aFazer.Add(tarefa);
            Console.WriteLine("Tarefa adicionada à lista 'A Fazer'.");
        }
        else
        {
            Console.WriteLine("Tarefa não pode ser vazia.");
        }
    }

    static void ExibirTarefas()
    {
        Console.WriteLine("\nTarefas 'A Fazer':");
        foreach (var tarefa in aFazer)
            Console.WriteLine($"- {tarefa}");

        Console.WriteLine("\nTarefas 'Em Progresso':");
        foreach (var tarefa in emProgresso)
            Console.WriteLine($"- {tarefa}");

        Console.WriteLine("\nTarefas 'Concluído':");
        foreach (var tarefa in concluido)
            Console.WriteLine($"- {tarefa}");
    }

    static void MoverTarefa()
    {
        Console.WriteLine("Escolha a lista de origem:");
        Console.WriteLine("1 - A Fazer");
        Console.WriteLine("2 - Em Progresso");
        Console.WriteLine("3 - Concluído");

        string input = Console.ReadLine();
        int origem;

        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out origem))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número.");
            input = Console.ReadLine();
        }

        Console.Write("Digite o índice da tarefa que deseja mover (começando de 0): ");
        input = Console.ReadLine();
        int indice;

        while (string.IsNullOrEmpty(input) || !int.TryParse(input, out indice))
        {
            Console.WriteLine("Entrada inválida. Por favor, insira um número.");
            input = Console.ReadLine();
        }

        string tarefaMovida = null;

        switch (origem)
        {
            case 1:
                if (indice >= 0 && indice < aFazer.Count)
                {
                    tarefaMovida = aFazer[indice];
                    aFazer.RemoveAt(indice);
                    emProgresso.Add(tarefaMovida);
                    Console.WriteLine("Tarefa movida para 'Em Progresso'.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
                break;

            case 2:
                if (indice >= 0 && indice < emProgresso.Count)
                {
                    tarefaMovida = emProgresso[indice];
                    emProgresso.RemoveAt(indice);
                    concluido.Add(tarefaMovida);
                    Console.WriteLine("Tarefa movida para 'Concluído'.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
                break;

            case 3:
                if (indice >= 0 && indice < concluido.Count)
                {
                    tarefaMovida = concluido[indice];
                    concluido.RemoveAt(indice);
                    emProgresso.Add(tarefaMovida);
                    Console.WriteLine("Tarefa movida para 'Em Progresso'.");
                }
                else
                {
                    Console.WriteLine("Índice inválido.");
                }
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }

        if (tarefaMovida != null)
        {
            Console.WriteLine($"Tarefa '{tarefaMovida}' movida com sucesso.");
        }
    }
}
