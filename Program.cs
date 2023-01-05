namespace FilesDotnet
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("O que deseja fazer:\n");
            Console.WriteLine("\t1 - Abrir o arquivo.");
            Console.WriteLine("\t2 - Criar novo arquivo.");
            Console.WriteLine("\t0 - Sair.");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 0:
                    System.Environment.Exit(0);
                    break;

                case 1:
                    AbrirArquivo();
                    break;

                case 2:
                    CriarArquivo();
                    break;

                default:
                    Menu();
                    break;
            }
        }

        static void AbrirArquivo()
        {
            Console.Clear();
            Console.WriteLine("Qual o caminho do arquivo?");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text + "\n");
            }

            Console.ReadLine();
            Menu();
        }

        static void CriarArquivo()
        {
            Console.Clear();
            Console.WriteLine("Digite seu texto abaixo (ESC para sair): \n");

            string text = "";

            do
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Salvar(text);
        }

        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Qual será o caminho para salvar o arquivo?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }

            Console.WriteLine("Arquivo salvo com sucesso!");
            Menu();
        }
    }
}