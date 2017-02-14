using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FocusLineWinForms {
    public partial class Form1 : Form {

        private Point stPoint;
        private Point lastPoint = Point.Empty;
        private bool isDragging = false;

        private FocusLine focusLine = new FocusLine();
        public Form1() {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(1, 1);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
            if (lastPoint != stPoint)
            {
                // remove last line.
                focusLine.DrawFocusLine(pictureBox1.Handle, stPoint, lastPoint);
            }

        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                if (lastPoint != stPoint)
                {
                    // remove last line.
                    focusLine.DrawFocusLine(pictureBox1.Handle, stPoint, lastPoint);
                }

                focusLine.DrawFocusLine(pictureBox1.Handle, stPoint, e.Location);
                lastPoint = e.Location;

            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                stPoint = e.Location;
                lastPoint = e.Location;
                isDragging = true;
            }
        }
    }
}
