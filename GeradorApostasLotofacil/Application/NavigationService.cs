using System;
using System.Collections.Generic;
using System.Text;

namespace GeradorApostasLotofacil.Application
{
    public class NavigationService
    {
        private readonly Panel _panel;
   
        public NavigationService(Panel panel)
        {
            _panel = panel;
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

        public void NavegarPara<T>() where T : Form, new()
        {
            NavegarPara(new T());
        }
    }
}
