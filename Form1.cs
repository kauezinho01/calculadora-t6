using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraDaT6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        enum Operacao
        {
            Soma,
            Subtrai,
            Divide,
            Multiplica,
            Nenhuma,


        }

        static Operacao ultimaOperacao = Operacao.Nenhuma;

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonLimpar_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Clear();
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            if (textBoxDisplay.Text.Length > 0)
            {
                textBoxDisplay.Text =
                    textBoxDisplay.Text.Remove(textBoxDisplay.Text.Length - 1, 1);
            }
        }

        private void buttonCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBoxDisplay.Text);
        }

        private void buttonSubtrai_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacao.Nenhuma)
            {
                ultimaOperacao = Operacao.Subtrai;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }

        private void buttonMultiplica_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacao.Nenhuma)
            {
                ultimaOperacao = Operacao.Multiplica;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }
    

        private void buttonDivide_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacao.Nenhuma)
            {
                ultimaOperacao = Operacao.Divide;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }
    

        private void buttonIgual_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao != Operacao.Nenhuma)
            {
                FazerCalculo(ultimaOperacao);
            }
        }

        private void buttonSoma_Click(object sender, EventArgs e)
        {
            if (ultimaOperacao == Operacao.Nenhuma)
            {
                ultimaOperacao = Operacao.Soma;
            }
            else
            {
                FazerCalculo(ultimaOperacao);
            }
            textBoxDisplay.Text += (sender as Button).Text;
        }


        private void FazerCalculo(Operacao ultimaOperacao)
        {
            List<double> ListaDeNumeros = new List<double>();


            switch (ultimaOperacao)
            {
                case Operacao.Soma:
                    ListaDeNumeros = textBoxDisplay.Text.Split('+').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] + ListaDeNumeros[1]).ToString();
                    break;
                case Operacao.Subtrai:
                    ListaDeNumeros = textBoxDisplay.Text.Split('-').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] - ListaDeNumeros[1]).ToString();
                    break;
                case Operacao.Divide:
                    ListaDeNumeros = textBoxDisplay.Text.Split('/').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] / ListaDeNumeros[1]).ToString();
                    break;
                case Operacao.Multiplica:
                    ListaDeNumeros = textBoxDisplay.Text.Split('*').Select(double.Parse).ToList();
                    textBoxDisplay.Text = (ListaDeNumeros[0] * ListaDeNumeros[1]).ToString();
                    break;
                case Operacao.Nenhuma:
                    break;
                default:
                    break;
            }
        }

        private void buttonNum_Click(object sender, EventArgs e)
        {
            textBoxDisplay.Text += (sender as Button).Text;
        }
    }
}

 
