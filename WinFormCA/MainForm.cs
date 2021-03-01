using MediatR;
using Serilog;
using System;
using System.Windows.Forms;
using WinFormCA.Domain.Form2;
using WinFormCA.Forms;
using WinFromCA.Application.CommonContext.Queries.GetTodayDate;

namespace WinFormCA
{
    public partial class MainForm : Form
    {
        private readonly IMediator _mediator;
        private readonly Form2 _form2;
        private readonly RadForm1 _radform;
        private readonly ILogger _logger;


        public MainForm(IMediator mediator, Form2 form2, RadForm1 radform, ILogger logger)
        {
            _mediator = mediator;
            _form2 = form2;
            _radform = radform;
            _logger = logger;
            InitializeComponent();
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
           var result = _mediator.Send(new GetTodayDateQuery());
           DateTime date = await result;
           DateLabel.Text = date.ToString("dd/MM/yyyy");
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var result = _mediator.Send(new GetTodayDateQuery());
            DateTime date = await result;           

            _form2.Tag = new Form2Model() { Date = date.ToString("dd/MM/yyyy HH:mm:ss") };
            //If calling show, form will auto dispose when close, causing an error because autofac will not call the constructor again.
            _form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //When using ShowDialog, dispose doesn't get called.
            _radform.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _logger.Debug("Form Loaded");
        }
    }
}
