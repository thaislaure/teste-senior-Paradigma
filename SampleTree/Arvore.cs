using System.Collections.Generic;
using System.Linq;

namespace SampleTree
{
    public class Arvore
    {
        public Arvore() => this.Raizes = new List<No>();

        public List<No> Raizes { get; set; }

        public void InserirNo(string pai, string filho)
        {
            var noInserido = false;
            foreach (var raiz in this.Raizes)
            {
                noInserido = raiz.ProcurarEInserirNo(pai, filho);
                if (noInserido)
                    break;
            }

            if (!noInserido)
                this.InserirNoRaiz(pai, filho);
        }

        private void InserirNoRaiz(string pai, string filho)
        {
            var raiz = new No();
            raiz.InserirNo(pai, filho);

            Raizes.Add(raiz);
        }

        public bool NoExiste(string filho)
        {
            foreach (var raiz in this.Raizes)
            {
                if (raiz.NoExiste(filho))
                    return true;
            }
            return false;
        }
        public bool MovimentarNo(No noPai, string filho)
        {
            var noFilho = StaticData.Tree.Raizes.FirstOrDefault(raiz => raiz.Letra == filho);
            if (noFilho != null)
            {
                noPai.Vincular(noPai, noFilho);
                StaticData.Tree.Raizes.Remove(noFilho);
                return true;
            }
            foreach (var raiz in this.Raizes)
            {
                var noMovimentado = raiz.MovimentarNo(noPai, filho);
                if (noMovimentado)
                    return true;
            }

            return false;
        }

        public bool VerificaArvoreCiclica(No no, string filho)
        {
            return false;
        }

        public string ObterTextoImpressao()
        {
            var raiz = this.Raizes.FirstOrDefault();
            return raiz.ObterTextoImpressao();
        }
    }
}