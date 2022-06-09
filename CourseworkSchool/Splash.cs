using System;
using System.Windows.Forms;

namespace CourseProject
{
    /// <summary>
    /// Заставка приложения
    /// </summary>
    public partial class Splash : Form
    {
        private Timer timer = new();

        /// <summary>
        /// Конструктор заставки
        /// </summary>
        public Splash()
        {
            InitializeComponent();
            timer.Interval = 7500;
            timer.Tick += (sender, e) => Close();
        }

        private void Splash_Load(object sender, EventArgs e) => timer.Start();
        private void Splash_FormClosed(object sender, FormClosedEventArgs e) => timer.Dispose();
        private void Splash_Click(object sender, EventArgs e) => Close();
        private void Splash_KeyPress(object sender, KeyPressEventArgs e) => Close();
    }
}
