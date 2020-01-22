using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraComNumeros
{
    public partial class Form1 : Form
    {
        double Total;
        double UltimoNumero;
        string Operador;

        private void Limpar()
        {
            Total = 0;
            UltimoNumero = 0;
            Operador = "+";
            txtBoxResultado.Text = "0";
        }

        private void Calcular()
        {
            switch(Operador)
            {
                case "+": Total = Total + UltimoNumero;
                    break;

                case "-": Total = Total - UltimoNumero;
                    break;

                case "/": Total = Total / UltimoNumero;
                    if (UltimoNumero == 0)
                    {
                        Limpar();
                        MessageBox.Show("Não é possivel dividir por zero", "Alerta Calculadora",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    else
                    {
                        Total = Total / UltimoNumero;
                    }
                    break;

                case "*": Total = Total * UltimoNumero;
                    break;
            }

            UltimoNumero = 0;
            txtBoxResultado.Text = Total.ToString();
        }

        public Form1()
        {
            InitializeComponent();

            Limpar();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            Limpar();
        }

        private void btnNumero(object sender, EventArgs e)
        {
            if (UltimoNumero == 0)
            {
                txtBoxResultado.Text = (sender as Button).Text;
            }
            else
            {
                txtBoxResultado.Text = txtBoxResultado.Text + (sender as Button).Text;
            }
                UltimoNumero = Convert.ToDouble(txtBoxResultado.Text);

        }

        private void btnOperador(object sender, EventArgs e)
        {
            UltimoNumero = Convert.ToDouble(txtBoxResultado.Text);

            Calcular();

            Operador = (sender as Button).Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            UltimoNumero = Convert.ToDouble(txtBoxResultado.Text);

            Calcular();

            Operador = "+";

            Total = 0;
        }
    }
}
