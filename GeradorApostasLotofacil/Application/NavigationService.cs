using Microsoft.Extensions.DependencyInjection;

namespace GeradorApostasLotofacil.Application
{
    public class NavigationService
    {
        private readonly Panel _panel;
        private readonly IServiceProvider _serviceProvider;

        public NavigationService(Panel panel, IServiceProvider serviceProvider)
        {
            _panel = panel;
            _serviceProvider = serviceProvider;
        }

        public void NavegarPara(Form form)
        {
            _panel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            _panel.Controls.Add(form);
            form.Show();
        }

        public void NavegarPara<T>() where T : Form
        {
            var form = _serviceProvider.GetRequiredService<T>();
            NavegarPara(form);
        }
    }
}
