using System.Windows.Forms;

namespace PhoenixLauncher
{
    class ProgressController
    {
        private ProgressBar bar;

        public ProgressController(ProgressBar element)
        {
            this.bar = element;

            this.bar.Maximum = 100;
            this.bar.Value = 0;
        }

        public void setup()
        {
            this.bar.Visible = true;
            this.bar.Maximum = 100;
            this.bar.Value = 0;
        }

        public void setMax(int max)
        {
            this.bar.Maximum = max;
        }

        public void step()
        {
            this.bar.Value += 1;
        }

        public void hide()
        {
            this.bar.Visible = false;
        }
    }
}
