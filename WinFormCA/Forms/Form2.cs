using Serilog;

using System.Windows.Forms;
using WinFormCA.Domain.Form2;

namespace WinFormCA.Forms
{
    public partial class Form2 : Form
    {
        private readonly ILogger _logger;
        public Form2(ILogger logger)
        {
            _logger = logger;
            _logger.Debug("Form 2 constructor");
            InitializeComponent();
        }

        private void Form2_Load(object sender, System.EventArgs e)
        {
           
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            Hide();
        }

        private void Form2_VisibleChanged(object sender, System.EventArgs e)
        {
            if (this.Visible)
            {
                _logger.Debug("Form 2 Visible");
                var model = (Form2Model)Tag;
                label1.Text = model.Date;
            }
            else
            {
                _logger.Debug("Form 2 Invisible");
            }
        }
    }
}
