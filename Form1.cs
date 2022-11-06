using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gaus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[,] A2 = {{ 5,  2, 1, 12},
                        {4,  7,  3, 24 },
                        { 2, 2,  4, 9} };

        double[,] Mass3 = { {0, -1, 3,  1, 5},
                            {4, -1, 5,  4, 4},
                            {2, -2, 4,  1, 6},
                            {1, -4, 5, -1, 3} };

        double[,] Mass2 = { {1, 2, 3, 3 },
                            {3, 5, 7, 0 },
                            {1, 3, 4, 1 }};


        private void button1_Click(object sender, EventArgs e)
        {
            double[] x = Gaus(Mass3, 4);
            Label[] labels = { label1, label2, label3, label4 };
            for (int i = 0; i < x.Length; i++)
            {
                labels[i].Text = x[i].ToString();
            }
        }


        double[] Gaus(double[,] Matrix, int n)
        {
            for (int i = 0; i < n - 1; i++)
            {
                if (Matrix[i, i] == 0)
                {
                    for (int j = 0; j < n + 1; j++)
                    {
                        double temp = Matrix[i, j];
                        Matrix[i, j] = Matrix[i + 1, j];
                        Matrix[i + 1, j] = temp;
                    }
                }
            }
            double[] x = new double[n];
            for (int k = 1; k < n; k++)
            {
                for (int j = k; j < n; j++)
                {
                    double m = Matrix[j, k - 1] / Matrix[k - 1, k - 1];
                    for (int i = 0; i < n+1; i++)
                    {
                        Matrix[j, i] = Matrix[j, i] - m * Matrix[k - 1, i];
                    }
                }
            }
            for (int i = n-1; i >=0; i--)
            {
                x[i] = Matrix[i, n] / Matrix[i, i];
                for (int j = n-1; j >i; j--)
                {
                    x[i] = x[i] - Matrix[i, j] * x[j] / Matrix[i, i];
                }
            }
            return x;
        }
    }
}
