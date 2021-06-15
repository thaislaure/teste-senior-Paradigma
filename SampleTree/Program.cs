using System;

namespace SampleTree
{
    class StaticData
    {
        public static Arvore Tree = new Arvore();
    }
    class Program
    {
        static void Main(string[] args)
        {
            // Arvores corretas
             var values = "[A,B] [A,C] [B,D] [G,H] [D,G] [G,I] [B,E] [C,J] [C,M] [M,L] [E,C] [A,K]";

           // var values = "[B,D] [D,E] [A,B] [C,F] [E,G] [A,C]";

            // Raizes multiplas
            // var values = "[A,B] [A,C] [B,D] [G,H] [D,G] [G,B] [B,E]";

            // Arvore ciclica
            // var values = "[A,B] [A,C] [B,D] [D,C]";
            // var values = "[A,B] [B,C] [C,D] [D,B]";

            Console.WriteLine("-----------------------------------------------------");
            Console.WriteLine($"Array de Entrada: {values}");
            Console.WriteLine("");

            try
            {
                Executar(values);
            }
            catch (ExceptionTree ex)
            {
                Console.WriteLine("Exceção: " + ex.GetMessage());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exceção: E4 - " + ex.Message);
            }

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------------------");
        }

        static void Executar(string values)
        {
            var arvore = StaticData.Tree;
            var valuesToLoop = GetValues(values);

            for (int i = 0; i < valuesToLoop.Length - 1; i += 2)
            {
                var pai = valuesToLoop[i].ToString();
                var filho = valuesToLoop[i + 1].ToString();

                arvore.InserirNo(pai, filho);
            }

            if (arvore.Raizes.Count == 0)
                throw new ExceptionTree("E4", "Árvore sem raiz");

            else if (arvore.Raizes.Count > 1)
                throw new ExceptionTree("E3", "Raízes múltiplas");
            
            Console.WriteLine("Árvore Montada: " + arvore.ObterTextoImpressao());
        }

        static string GetValues(string values)
        {
            return values.Replace("[", "").Replace("]", "").Replace(",", "").Replace(" ", "");
        }
    }
}
