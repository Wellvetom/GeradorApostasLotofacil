using System.Drawing.Drawing2D;

namespace GeradorApostasLotofacil.Controls
{
    /// <summary>
    /// Gráfico de setores (pizza) desenhado com GDI+ e animação de crescimento.
    /// Ao receber dados via <see cref="SetData"/>, os setores são desenhados
    /// progressivamente (varredura de 0° até o ângulo final) por ~600ms.
    /// Sem dependências externas.
    /// </summary>
    public class PieChartControl : Panel
    {
        public record Fatia(string Rotulo, double Valor);

        private readonly List<Fatia> _fatias = new();
        private double _totalValor;

        private readonly System.Windows.Forms.Timer _timer;
        private double _progresso;          // 0.0 → 1.0
        private const int DuracaoMs = 600;
        private const int IntervaloMs = 15;
        private DateTime _inicioAnimacao;

        // Paleta consistente com o tema escuro da aplicação
        private static readonly Color[] Paleta =
        {
            Color.FromArgb(63, 81, 181),    // azul
            Color.FromArgb(0, 150, 136),    // teal
            Color.FromArgb(255, 152, 0),    // laranja
            Color.FromArgb(156, 39, 176),   // roxo
            Color.FromArgb(76, 175, 80),    // verde
            Color.FromArgb(233, 30, 99),    // rosa
            Color.FromArgb(3, 169, 244),    // azul claro
            Color.FromArgb(255, 193, 7),    // âmbar
            Color.FromArgb(121, 85, 72),    // marrom
            Color.FromArgb(96, 125, 139),   // cinza azulado ("Outros")
        };

        [System.ComponentModel.DesignerSerializationVisibility(
            System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string Titulo { get; set; } = string.Empty;

        public PieChartControl()
        {
            DoubleBuffered = true;
            BackColor = Color.FromArgb(45, 55, 72);
            ForeColor = Color.White;

            _timer = new System.Windows.Forms.Timer { Interval = IntervaloMs };
            _timer.Tick += Timer_Tick;
        }

        /// <summary>
        /// Define os dados do gráfico e dispara a animação de crescimento.
        /// Limita a <paramref name="maxFatias"/> categorias; o restante é
        /// agrupado em uma fatia "Outros".
        /// </summary>
        public void SetData(IEnumerable<Fatia> fatias, int maxFatias = 8)
        {
            _fatias.Clear();

            var lista = fatias
                .Where(f => f.Valor > 0)
                .OrderByDescending(f => f.Valor)
                .ToList();

            if (lista.Count > maxFatias)
            {
                var principais = lista.Take(maxFatias - 1).ToList();
                double resto = lista.Skip(maxFatias - 1).Sum(f => f.Valor);
                _fatias.AddRange(principais);
                if (resto > 0)
                    _fatias.Add(new Fatia("Outros", resto));
            }
            else
            {
                _fatias.AddRange(lista);
            }

            _totalValor = _fatias.Sum(f => f.Valor);

            // (Re)inicia a animação
            _progresso = 0.0;
            _inicioAnimacao = DateTime.Now;
            _timer.Start();
            Invalidate();
        }

        /// <summary>
        /// Reinicia a animação de crescimento sem alterar os dados.
        /// Útil quando o controle estava oculto durante o SetData inicial.
        /// </summary>
        public void Replay()
        {
            if (_fatias.Count == 0 || _totalValor <= 0) return;
            _progresso = 0.0;
            _inicioAnimacao = DateTime.Now;
            _timer.Start();
            Invalidate();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            double decorrido = (DateTime.Now - _inicioAnimacao).TotalMilliseconds;
            _progresso = Math.Min(1.0, decorrido / DuracaoMs);

            // Easing suave (ease-out)
            Invalidate();

            if (_progresso >= 1.0)
                _timer.Stop();
        }

        private static double EaseOut(double t) => 1 - Math.Pow(1 - t, 3);

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            int topo = 0;
            if (!string.IsNullOrEmpty(Titulo))
            {
                using var fonteTitulo = new Font("Segoe UI", 10F, FontStyle.Bold);
                g.DrawString(Titulo, fonteTitulo, Brushes.White, new PointF(8, 6));
                topo = 30;
            }

            if (_totalValor <= 0 || _fatias.Count == 0)
            {
                using var fonte = new Font("Segoe UI", 9F);
                g.DrawString("Sem dados para exibir", fonte, Brushes.LightGray,
                    new PointF(10, topo + 10));
                return;
            }

            // Área da pizza (lado esquerdo) e legenda (lado direito)
            int margem = 12;
            int areaLegenda = 130;
            int dispLargura = Width - areaLegenda - margem * 2;
            int dispAltura = Height - topo - margem * 2;
            int diametro = Math.Max(20, Math.Min(dispLargura, dispAltura));

            var retPizza = new Rectangle(
                margem,
                topo + margem + (dispAltura - diametro) / 2,
                diametro,
                diametro);

            double fator = EaseOut(_progresso);
            float anguloInicial = -90f; // começa no topo

            for (int i = 0; i < _fatias.Count; i++)
            {
                float varreduraTotal = (float)(_fatias[i].Valor / _totalValor * 360.0);
                float varreduraAnimada = (float)(varreduraTotal * fator);
                var cor = Paleta[i % Paleta.Length];

                using (var brush = new SolidBrush(cor))
                    g.FillPie(brush, retPizza, anguloInicial, varreduraAnimada);

                anguloInicial += varreduraTotal;
            }

            // Borda separando as fatias (desenhada ao final da animação para nitidez)
            if (_progresso >= 1.0)
            {
                anguloInicial = -90f;
                using var penBorda = new Pen(Color.FromArgb(45, 55, 72), 2);
                for (int i = 0; i < _fatias.Count; i++)
                {
                    float varredura = (float)(_fatias[i].Valor / _totalValor * 360.0);
                    g.DrawPie(penBorda, retPizza, anguloInicial, varredura);
                    anguloInicial += varredura;
                }
            }

            // Legenda
            using var fonteLegenda = new Font("Segoe UI", 8.5F);
            int lx = margem + diametro + margem;
            int ly = topo + margem;
            int quadrado = 12;
            int linhaAltura = 20;

            for (int i = 0; i < _fatias.Count; i++)
            {
                var cor = Paleta[i % Paleta.Length];
                double perc = _fatias[i].Valor / _totalValor * 100.0;

                using (var brush = new SolidBrush(cor))
                    g.FillRectangle(brush, lx, ly + 2, quadrado, quadrado);

                string texto = $"{_fatias[i].Rotulo}  ({perc:F1}%)";
                g.DrawString(texto, fonteLegenda, Brushes.White,
                    new PointF(lx + quadrado + 6, ly));

                ly += linhaAltura;
                if (ly + linhaAltura > Height - margem) break; // evita estourar
            }
        }
    }
}
