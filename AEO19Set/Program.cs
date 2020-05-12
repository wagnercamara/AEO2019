using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AEO19Set
{
    class Program
    {
        static Dictionary <Int32, string> professores = new Dictionary <Int32, string> ();
        static HashSet <Int32> salas = new HashSet<Int32> ();
        static Dictionary <Int32, Int32> reservas = new Dictionary <Int32, Int32> ();
        static Int32 LerIntPositivo()
        {
            Int32 x = 0;
            Boolean numValido = true;
            Boolean numPositivo = true;

            while (numPositivo == true)
            {
                while (numValido == true)
                {
                    try
                    {
                        x = Convert.ToInt32(Console.ReadLine());
                        numValido = false;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Por favor insira um numero inteiro maior que Zero...");
                    }    
                }
                if (x <= 0)
                {
                    Console.WriteLine("O numero informar tem que ser maior que 'Zero'...");
                    numValido = true;
                }
                else
                {
                    numPositivo = false;
                }
                
            }
            return x;
        }
        static void CadastrarProfessor()
        {
            Boolean posicao = true;
            Console.WriteLine("Informe o cadastro do professor");
            Int32 matricula = LerIntPositivo();

            posicao = professores.ContainsKey(matricula);

            if (posicao == true)
            {
                Console.WriteLine("Professor já cadastrado");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Informe o nome do Professor");
                string nome = Console.ReadLine();

                professores.Add(matricula,nome);

                Console.WriteLine("Professor Cadastrado!");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
        }
        static void CadastrarSala()
        {
            Boolean salaValida = true;
            Console.WriteLine("Informe o cadastro da sala");
            Int32 numSala = LerIntPositivo();

            salaValida = salas.Contains(numSala);

            if (salaValida == true)
            {
                Console.WriteLine("Sala já cadastrada");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                salas.Add(numSala);
                Console.WriteLine("Sala Cadastrada");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
        }
        static void ReservarSala()
        {
            Boolean salaExite = true;
            Boolean reservExiste = true;
            Console.WriteLine("Informe o numero da sala");
            Int32 x = LerIntPositivo();
            salaExite = salas.Contains(x); // a sala existe
            reservExiste = reservas.ContainsKey(x); // verifica se existe reserva para esta sala.

            if (salaExite == true)
            {
                if(reservExiste == false)
                {
                    Console.WriteLine("Informe a matricula do professor");
                    Int32 mat = LerIntPositivo();
                    Boolean matValida = professores.ContainsKey(mat);
                    if (matValida == true)
                    {
                        reservas.Add(x, mat);
                        Console.WriteLine("Reserva concluida");
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Professor não está cadastrado.");
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Já existe uma reserva para está sala.");
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Sala não cadastrada.");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }

        }
        static void ConsultarReserva()
        {
            Console.WriteLine("Informe o numero da sala");
            Int32 numSala = LerIntPositivo();
            Boolean salaExiste = salas.Contains(numSala);
            
            if (salaExiste == true)
            {
                Boolean reservExite = reservas.ContainsKey(numSala);

                if (reservExite == true)
                {
                    Console.WriteLine(String.Format("{0} - {1}",reservas[numSala],professores[reservas[numSala]]));
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Sala Livre");
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Sala não existe");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
        }
        static void AlterarReserva()
        {
            Console.WriteLine("Informe o numero da sala");
            Int32 numSala = LerIntPositivo();
            Boolean salaExiste = salas.Contains(numSala);
            Boolean reservExite = reservas.ContainsKey(numSala);
            
            if (salaExiste == true)
            {
                if (reservExite == true)
                {
                    Console.WriteLine("Informe o numero da sala de deseja reservar");
                    Int32 numSalaSubstituta = LerIntPositivo();
                    Boolean salaDisponivel = reservas.ContainsKey(numSalaSubstituta);
                    Boolean sala2existe = salas.Contains(numSalaSubstituta);

                    if (sala2existe == true)
                    {
                         if (salaDisponivel == false)
                        {
                            Int32 nprof = reservas[numSala];
                            reservas.Remove(numSala);
                            reservas.Add(numSalaSubstituta,nprof);
                            Console.WriteLine("Reserva alterada");
                            Console.WriteLine("<>Precione ENTER para continuar");
                            Console.ReadKey();
                        }
                        else
                        {
                        Console.WriteLine("Sala Indisponível");
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sala {0} não existe", numSalaSubstituta);
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();   
                    }
                   
                }
                else
                {
                    Console.WriteLine("A sala {0} não conten reserva",numSala);
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Sala não existe");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }    

        }
        static void ExcluirReserva()
        {
            Console.WriteLine("Informe o numero da sala");
            Int32 numSala = LerIntPositivo();
            Boolean salaExiste = salas.Contains(numSala);
            
            if (salaExiste == true)
            {
                Boolean reservExite = reservas.ContainsKey(numSala);

                if (reservExite == true)
                {
                        reservas.Remove(numSala);
                        Console.WriteLine("Reserva Excluida");
                        Console.WriteLine("<>Precione ENTER para continuar");
                        Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Está reserva não existe");
                    Console.WriteLine("<>Precione ENTER para continuar");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Sala não existe");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }    
        }
        static void ListarProfessores()
        {
            if (professores.Count != 0)
            {
                foreach (var item in professores)
                {
                    Console.WriteLine("Matricula:{0}, Nome:{1}", item.Key, item.Value);
                }

                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey(); 
            }
            else
            {
                Console.WriteLine("Não há professores cadastrados");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
        }
        static void ListarSalas()
        {
            if(salas.Count != 0)
            {
                foreach(int i in salas) 
                { 
                    Console.WriteLine(i); 
                } 
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não há Salas cadastradas");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }

        }
        static void ListarReservas()
        {
            if(reservas.Count != 0)
            {
                foreach (var item in reservas)
                {
                    Console.WriteLine("Sala:{0}, Maricula Professor:{1}", item.Key, item.Value);
                }
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não há Reservas no sistema");
                Console.WriteLine("<>Precione ENTER para continuar");
                Console.ReadKey();
            }
        }
        static void MontarMenu(String[] opcao, Action[] metodo)
        {
            if(opcao.Length > 0)
            {
                Boolean imprimirMenu = true;
                Int32 opcaoEscolhida = 0;
                StringBuilder x = new StringBuilder();
                x.Append(1).Append("-").Append(opcao[0]).Append("\n");
                for(Int32 i = 2; i <= opcao.Length;i++)
                {
                    x.Append(i).Append("-").Append(opcao[i-1]).Append("\n");
                }

                while(imprimirMenu == true)
                {
                    Console.Clear();
                    Console.WriteLine(x);
                    opcaoEscolhida = LerIntPositivo();

                    if(opcaoEscolhida  < opcao.Length)
                    {
                        metodo[opcaoEscolhida - 1]();
                    }
                    else if (opcaoEscolhida == opcao.Length)
                    {
                        Console.WriteLine("bye..");
                        imprimirMenu = false;
                    }
                    else
                    {
                        Console.WriteLine("Ops.. opção invalida.");
                    }
                }
            }
        }       
        static void Main(string[] args)
        {
            MontarMenu(new String[]{
                "Cadastrar Professor",
                "Cadastrar Sala",
                "Reservar Sala",
                "Consultar Reserva",
                "Alterar Reserva",
                "Excluir Reserva",
                "Listar Professores",
                "Listar Salas",
                "Listar Reservas",
                "Sair"},
                new Action[]{
                CadastrarProfessor,
                CadastrarSala,
                ReservarSala,
                ConsultarReserva,
                AlterarReserva,
                ExcluirReserva,
                ListarProfessores,
                ListarSalas,
                ListarReservas,
                }
            );
        }
    }
}
