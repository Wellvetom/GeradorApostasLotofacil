using System.ComponentModel;

namespace GeradorApostasLotofacil
{
    public class LoadingPanel : Panel
    {
        private System.Windows.Forms.Timer _timerSpinner = null!;
        private float _angulo;
        private string _mensagem = "Carregando...";

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public string Mensagem
        {
            get => _mensagem;
            set
            {
                _mensagem = value;
                Invalidate();
            }
        }

        public LoadingPanel()
        {
            this.SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.ResizeRedraw, true);

            this.BackColor = Color.FromArgb(30, 30, 46);
            this.Visible = false;
            this.Anchor = AnchorStyles.None; // Sem anchor nem dock

            _timerSpinner = new System.Windows.Forms.Timer
            {
                Interval = 16
            };
            _timerSpinner.Tick += (s, e) =>
            {
                _angulo = (_angulo + 8) % 360;
                Invalidate();
            };
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Fundo sólido (cobre tudo por baixo)
            using (var brushFundo = new SolidBrush(Color.FromArgb(30, 30, 46)))
            {
                g.FillRectangle(brushFundo, this.ClientRectangle);
            }

            // Caixa central
            int boxWidth = 240;
            int boxHeight = 140;
            int boxX = (this.Width - boxWidth) / 2;
            int boxY = (this.Height - boxHeight) / 2;
            var boxRect = new Rectangle(boxX, boxY, boxWidth, boxHeight);

            using (var brushBox = new SolidBrush(Color.FromArgb(45, 45, 65)))
            {
                g.FillRectangle(brushBox, boxRect);
            }
            using (var penBorda = new Pen(Color.FromArgb(100, 100, 149, 237), 1.5f))
            {
                g.DrawRectangle(penBorda, boxRect);
            }

            // Spinner
            int tamanho = 44;
            int espessura = 4;
            int spinnerX = (this.Width - tamanho) / 2;
            int spinnerY = boxY + 25;
            var spinnerRect = new Rectangle(spinnerX, spinnerY, tamanho, tamanho);

            using (var penFundo = new Pen(Color.FromArgb(60, 255, 255, 255), espessura))
            {
                penFundo.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                penFundo.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawArc(penFundo, spinnerRect, 0, 360);
            }

            using (var penArco = new Pen(Color.FromArgb(100, 149, 237), espessura))
            {
                penArco.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                penArco.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawArc(penArco, spinnerRect, _angulo, 90);
            }

            using (var penArco2 = new Pen(Color.FromArgb(120, 100, 149, 237), espessura))
            {
                penArco2.StartCap = System.Drawing.Drawing2D.LineCap.Round;
                penArco2.EndCap = System.Drawing.Drawing2D.LineCap.Round;
                g.DrawArc(penArco2, spinnerRect, _angulo + 180, 60);
            }

            // Texto
            var textRect = new Rectangle(boxX, spinnerY + tamanho + 15, boxWidth, 35);
            TextRenderer.DrawText(g, _mensagem,
                new Font("Segoe UI", 11F, FontStyle.Regular),
                textRect, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        public void Exibir(string mensagem = "Carregando...")
        {
            _mensagem = mensagem;

            // Cobrir todo o container pai (form ou panel)
            var container = this.Parent;
            if (container != null)
            {
                this.Location = new Point(0, 0);
                this.Size = container.ClientSize;
                container.Resize += Parent_Resize;
            }

            this.Visible = true;
            this.BringToFront();
            _timerSpinner.Start();

            // Forçar repaint imediato
            System.Windows.Forms.Application.DoEvents();
            this.Refresh();
        }

        public void Ocultar()
        {
            _timerSpinner.Stop();
            this.Visible = false;

            if (this.Parent != null)
            {
                Parent.Resize -= Parent_Resize;
            }
        }

        private void Parent_Resize(object? sender, EventArgs e)
        {
            if (this.Parent != null && this.Visible)
            {
                this.Bounds = new Rectangle(0, 0, Parent.ClientSize.Width, Parent.ClientSize.Height);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _timerSpinner?.Stop();
                _timerSpinner?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
