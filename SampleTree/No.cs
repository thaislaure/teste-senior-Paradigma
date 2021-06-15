using System.Text;

namespace SampleTree
{
    public class No
    {
        public No(string letra) => Letra = letra;
        public No() { }

        public string Letra { get; private set; }
        public No Esquerda { get; private set; }
        public No Direita { get; private set; }

        public bool ExisteEsquerda() => this.Esquerda != null;
        public bool ExisteDireita() => this.Direita != null;

        public bool ProcurarEInserirNo(string pai, string filho)
            => this.ProcurarEInserirNo(this, pai, filho);

        public void InserirNo(string pai, string filho)
            => this.InserirNo(this, pai, filho);

        private void InserirNo(No no, string pai, string filho)
        {
            no.Letra = pai;
            InserirFilho(no, filho);
        }

        public bool NoExiste(string valor)
            => this.NoExiste(this, valor);

        private bool NoExiste(No no, string valor)
        {
            if (no.Letra == valor)
                return true;

            else if (no.ExisteEsquerda())
                return NoExiste(no.Esquerda, valor);

            else if (no.ExisteDireita())
                return NoExiste(no.Direita, valor);

            return false;
        }

        private bool ProcurarEInserirNo(No no, string pai, string filho)
        {
            if (no.Letra == pai)
                return InserirFilho(no, filho);

            if (no.ExisteEsquerda())
            {
                if (ProcurarEInserirNo(no.Esquerda, pai, filho))
                    return true;
            }

            if (no.ExisteDireita())
            {
                if (ProcurarEInserirNo(no.Direita, pai, filho))
                    return true;
            }

            return false;
        }

        public bool InserirFilho(No no, string filho)
        {
            if (StaticData.Tree.VerificaArvoreCiclica(no, filho))
                 throw new ExceptionTree("E2", $"Ciclo presente para filho {filho}");

            var noMovimentado = StaticData.Tree.MovimentarNo(no, filho);
            if (noMovimentado)
                return true;

            Vincular(no, new No(filho));
            return true;
        }

        public void Vincular(No noPai, No noFilho)
        {
            if (!noPai.ExisteEsquerda())
                noPai.Esquerda = noFilho;

            else if (!noPai.ExisteDireita())
                noPai.Direita = noFilho;

            else
                throw new ExceptionTree("E1", $"Múltiplos Filhos do No {noPai.Letra}");
        }

        public bool MovimentarNo(No noDestino, string filho)
            => MovimentarNo(this, null, noDestino, filho);

        private bool MovimentarNo(No noAtual, No noPai, No noDestino, string filho)
        {
            if (noAtual.Letra == filho)
            {
                Vincular(noDestino, noAtual);

                if (noPai.ExisteEsquerda() && noPai.Esquerda.Letra == filho)
                    noPai.Esquerda = null;

                if (noPai.ExisteDireita() && noPai.Direita.Letra == filho)
                    noPai.Direita = null;

                return true;
            }

            if (noAtual.ExisteEsquerda())
            {
                if (MovimentarNo(noAtual.Esquerda, noAtual, noDestino, filho))
                    return true;
            }

            if (noAtual.ExisteDireita())
            {
                if (MovimentarNo(noAtual.Direita, noAtual, noDestino, filho))
                    return true;
            }

            return false;
        }

        public string ObterTextoImpressao()
            => ObterTextoImpressao(this, "");

        private string ObterTextoImpressao(No no, string space)
        {
            var str = new StringBuilder();
            str.AppendLine("");
            str.Append(space + no.Letra);
            if (no.ExisteEsquerda() || no.ExisteDireita())
            {
                if (no.ExisteEsquerda())
                    str.Append(ObterTextoImpressao(no.Esquerda, space + "--"));

                if (no.ExisteDireita())
                {
                    str.Append(ObterTextoImpressao(no.Direita, space + "--"));
                }
            }

            return str.ToString();
        }
    }
}