using estacionamento_basico;

List<Estacionamento> Estacionados = new List<Estacionamento>();

void mostarMenu()
{
    Console.WriteLine("\n---------------------------------------------------------------");
    Console.WriteLine("Menu de opções: ");
    Console.WriteLine("1 - Cadastrar veículo.");
    Console.WriteLine("2 - Remover veículo.");
    Console.WriteLine("3 - Listar cadastrados veículo.");
    Console.WriteLine("4 - Encerrar.\n");
}

void cadastrarVeiculo()
{
    Console.WriteLine("Digite a placa do véiculo:");
    Estacionamento novoEstacionamento = new(Console.ReadLine());
    Estacionados.Add(novoEstacionamento);
    Console.WriteLine($"\nVeiculo cadastrado em {novoEstacionamento.DataHoraCadastrada}.");
}

void listarVeiculos()
{
    Console.WriteLine("Lista de Veículos Cadastrados\n");
    Estacionados.ForEach(estacionado => Console.WriteLine(estacionado.EstacionamentoToEstring()));
}

void removerVeiculoEstacionado(Estacionamento veiculoEstacionado)
{
    listarVeiculos();
    Estacionados.Remove(veiculoEstacionado);
}

void verificarPlacaCadastrada(string placa)
{
    Estacionamento veiculoEstacionado;
    bool placaEncontrada = Estacionados.Any(veiculoSelecionado => {
        if(veiculoSelecionado.Placa.ToUpper() == placa.ToUpper())
        {
            removerVeiculoEstacionado(veiculoSelecionado);
            Console.WriteLine($"Veículo com a placa {placa} foi removido com sucesso!");
        }
        else Console.WriteLine("Placa não cadastrada.");
        return veiculoSelecionado.Placa == placa;
    });
}

decimal calcularValor(decimal taxaFixa, decimal taxaPorHora , Estacionamento estacionado)
{
    TimeSpan tempoEstacionado = DateTime.Now.Subtract(DateTime.Parse(estacionado.DataHoraCadastrada));
    decimal valorCobrado = taxaFixa + tempoEstacionado.Minutes * taxaPorHora;
    return valorCobrado;
}

void retirarAutomovel(bool pago)
{
    string mensagem = pago ? "Obrigado por guardar seu carro conosco. E volte sempre!": "É Necessario efetuar o pagamento";
    Console.WriteLine(mensagem);
}

Console.WriteLine("Bem-vindo ao Sistema de estacionamento Alfa.");

Console.Write("Informe o valor fixo da taxa: R$ ");
decimal taxaFixa = decimal.Parse(Console.ReadLine());

Console.Write("\nInforme o valor da taxa de estacionamento por hora: R$ ");
decimal taxaPorHora = decimal.Parse(Console.ReadLine());

bool continuar = true;

do
{
    mostarMenu();
    Console.Write("Opção: ");
    int opcaoSelecionada = int.Parse(Console.ReadLine());

    switch (opcaoSelecionada)
    {
        case 1:
            cadastrarVeiculo();
            break;

        case 2:
            listarVeiculos();
            Console.WriteLine("Digite o numero da placa do veiculo que deseja remover.");
            string placa = Console.ReadLine();
            verificarPlacaCadastrada(placa);
            break;

        case 3:
            listarVeiculos();
            break;

        case 4:
            retirarAutomovel(true);
            continuar = false;
            break;
        default:
            Console.WriteLine("Valor Inválido... Tente Novamenbte!");
            break;
    }
} while (continuar);