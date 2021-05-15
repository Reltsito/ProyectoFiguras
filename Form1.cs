using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw
{
    enum FiguraActual {seleccionado, rectangulo, elipse }

    public partial class Form1 : Form
    {
        List<Figura> figuras = new List<Figura>();

        private string Estado = "Dibujando";
        private Punto p1actual;
        private Figura figuraseleccionada;
        FiguraActual figuraActual = FiguraActual.seleccionado;
        
        private Figura Selecciona(int x, int y)
        {
            for (int i = figuras.Count - 1; i >= 0 ; i--)
            {
                if(figuras[i].EstáDentro(x, y));
                return figuras[i];
            }
            return null;
        }

        private void DibujaFiguras()
        {
            foreach (var figura in figuras)
                figura.Dibuja(this);
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (Estado == "Dibujando")
            {
            label1.Text = String.Format($"X: {e.X}, Y: {e.Y}");
            Estado = "Moviendo";
            p1actual = new Punto(e.X, e.Y);
            }
            else if (Estado == "Seleccionando")
            {
                figuraseleccionada = Selecciona(e.X, e.Y);
                if (figuraseleccionada != null)
                {
                    button2.Text = String.Format($"X: {figuraseleccionada.punto1.X}, Y: {figuraseleccionada.punto1.Y}");
                }
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Estado == "Moviendo")
            {
                label1.Text = String.Format($"X: {e.X}, Y: {e.Y}");
                Estado = "Dibujando";

                /* Graphics graphics = this.CreateGraphics();
                 graphics.DrawRectangle(new Pen(Color.Red, 2), r.Punto1.X, r.Punto1.Y, r.Punto2.X - r.Punto1.X, r.Punto2.Y - r.Punto1.Y);
                */

                if (e.Button == MouseButtons.Left)
                {
                    Rectangulo r = new Rectangulo(p1actual, new Punto(e.X, e.Y));

                    r.Dibuja(this);
                    figuras.Add(r);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    Elipse elip = new Elipse(p1actual, new Punto(e.X, e.Y));

                    elip.Dibuja(this);
                    figuras.Add(elip);
                }
           
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Estado=="Dibujando")
            {
            label1.Text = String.Format($"X: {e.X}, Y: {e.Y}");
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            this.DibujaFiguras();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Estado = "Seleccionando";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Estado = "Dibujando";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "Rojo":
                     figuraseleccionada.colorRelleno = Color.Red;
                    break;
                case "Azul":
                    figuraseleccionada.colorRelleno = Color.Blue;
                    break;
                case "Amarillo":
                    figuraseleccionada.colorRelleno = Color.Yellow;
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            figuras.Sort();
            figuras.Reverse();
            DibujaFiguras();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
          /*  foreach (var d in figuras)
            {
                figuras.Reverse();
                figuras.Remove(d);
            }
            */

           // figuras.Reverse();
           // figuras.Remove();

           figuraseleccionada.colorRelleno = Color.WhiteSmoke;
           figuraseleccionada.colorContorno = Color.WhiteSmoke;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void button5_Click(object sender, EventArgs e)
        {
            figuraActual = FiguraActual.elipse;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            figuraActual = FiguraActual.rectangulo;
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "Negro":
                    figuraseleccionada.colorContorno = Color.Red;
                    break;
                case "Morado":
                    figuraseleccionada.colorContorno = Color.Purple;
                    break;
                case "Gris":
                    figuraseleccionada.colorContorno = Color.Gray;
                    break;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            {
                case "2":
                    figuraseleccionada.anchopluma = 2;
                    break;
                case "4":
                    figuraseleccionada.anchopluma = 4;
                    break;
                case "6":
                    figuraseleccionada.anchopluma = 6;
                    break;
                case "8":
                    figuraseleccionada.anchopluma = 8;
                    break;
                case "10":
                    figuraseleccionada.anchopluma = 10;
                    break;

            }
        }

        
    }
}
