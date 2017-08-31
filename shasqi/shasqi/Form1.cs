using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shasqi
{
    public partial class Form1 : Form
    {
        int turno = 0;
        bool movextra = false;
        Button seleccionado = null;
        List<Button> yellow = new List<Button>();
        List<Button> green = new List<Button>();
        public Form1()
        {
            InitializeComponent();
            cargerlist();
        }
        private void cargerlist()
        {
            yellow.Add(yellow1);
            yellow.Add(yellow2);
            yellow.Add(yellow3);
            yellow.Add(yellow4);
            yellow.Add(yellow5);
            yellow.Add(yellow6);
            yellow.Add(yellow7);
            yellow.Add(yellow8);
            yellow.Add(yellow9);
            yellow.Add(yellow10);
            yellow.Add(yellow11);
            yellow.Add(yellow12);

            green.Add(green1);
            green.Add(green2);
            green.Add(green3);
            green.Add(green4);
            green.Add(green5);
            green.Add(green6);
            green.Add(green7);
            green.Add(green8);
            green.Add(green9);
            green.Add(green10);
            green.Add(green11);
            green.Add(green12);
        }
        public void seleccion(object objeto)
        {
            try
            {
                seleccionado.BackColor = Color.Black;
            }
            catch 
            {

               
            }
            Button ficha = (Button)objeto;
            seleccionado = ficha;
            seleccionado.BackColor = Color.Blue;
        }

        private void button122_Click(object sender, EventArgs e)
        {

        }

        private void sectionGreen(object sender, MouseEventArgs e)
        {
            seleccion(sender);
        }

        private void sectionYellow(object sender, MouseEventArgs e)
        {
            seleccion(sender);
        }

        private void click(object sender, MouseEventArgs e)
        {
            movimento((Button)sender);
        }
        private void movimento (Button click)
        {
            if (seleccionado !=null)
            {
                if (true)
                {
                    string color = seleccionado.Name.ToString().Substring(0, 4);
                    Point anterior = seleccionado.Location;
                    seleccionado.Location = click.Location;
                    int avance = anterior.Y - click.Location.Y;
                    if (true)
                    {
                        ifqueen(color);
                       turno++;
                        seleccionado.BackColor = Color.Black;
                        seleccionado = null;
                        movextra = false;
                    }
                    else
                    {
                        movextra = true;

                    }
                }
            }
        }
        private int promedio(int n1, int n2)
        {
            int resulado = n1 + n2;
            resulado = resulado / 2;
            return Math.Abs(resulado);
        }
        private bool validacation (Button origen,Button destino,string color)
        {
            Point puntorigen = origen.Location;
            Point puntdestino = destino.Location;
            int avance = puntorigen.Y - puntdestino.Y;
            avance = color == "yellow" ? avance : (avance * -1);
            avance = seleccionado.Tag == "queen" ? Math.Abs(avance) : avance;
            if (avance == 50)
            {
                return true;
            }
            else if (avance == 100)
            {
                Point puntoMedio = new Point(promedio(puntdestino.X, puntorigen.X), promedio(puntdestino.Y, puntorigen.Y));
            }
        }
        private void ifqueen( string color)
        {
            if (color =="green" && seleccionado.Location.Y == 400)
            {
                seleccionado.BackgroundImage = Properties.Resources.green_queen_crown_md;
                seleccionado.Tag = "queen";
            }
            else if (color == "yellow" && seleccionado.Location.Y == 50)
            {
                seleccionado.BackgroundImage = Properties.Resources.yellow_crown_no_outline_md;
                seleccionado.Tag = "queen";
            }
        }
    }
}
