using MediatR;
using System;
using System.Windows.Forms;
using WinFormCA.Forms;
using WinFromCA.Application.CommonContext.Queries.GetTodayDate;

namespace WinFormCA
{
    public partial class MainForm : Form
    {
        private readonly IMediator _mediator;
        private readonly Form2 _form2;
        private readonly RadForm1 _radform;

        public MainForm(IMediator mediator, Form2 form2, RadForm1 radform)
        {
            _mediator = mediator;
            _form2 = form2;
            _radform = radform;
            InitializeComponent();
        }

        private async void button1_Click(object sender, System.EventArgs e)
        {
           var result = _mediator.Send(new GetTodayDateQuery());
           DateTime date = await result;
           DateLabel.Text = date.ToString("dd/MM/yyyy");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _radform.ShowDialog();
        }
    }
}
