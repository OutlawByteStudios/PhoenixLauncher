using System;
using System.Drawing;
using System.Windows.Forms;

namespace PhoenixLauncher
{
    class Logger
    {
        private RichTextBox element;
        public Logger(RichTextBox element)
        {
            this.element = element;
        }

        //green
        public void success(string message)
        {
            this.write(message, Color.Green);
        }
        //blue
        public void notify(string message)
        {
            this.write(message, Color.Blue);
        }
        //orange
        public void warn(string message)
        {
            this.write(message, Color.DarkOrange);
        }
        //red
        public void error(string message)
        {
            this.write(message, Color.Red);
        }
        //black
        public void system(string message)
        {
            this.write(message, Color.Black);
        }

        private void write(string message, Color color)
        {
            message = "[" + DateTime.Now + "]::" + message;
            if (!string.IsNullOrWhiteSpace(this.element.Text))
            {
                this.element.SelectionStart = this.element.TextLength;
                this.element.SelectionLength = 0;

                this.element.SelectionColor = color;
                this.element.AppendText("\r\n" + message);
                this.element.SelectionColor = this.element.ForeColor;
            }
            else
            {
                this.element.SelectionStart = this.element.TextLength;
                this.element.SelectionLength = 0;

                this.element.SelectionColor = color;
                this.element.AppendText(message);
                this.element.SelectionColor = this.element.ForeColor;
            }
            this.element.ScrollToCaret();
        }

    }
}
