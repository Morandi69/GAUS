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

        double[,] Mass3 = { {1, -1, 3,  1, 5},
                            {4, 1, 5,  4, 4},
                            {2, -2,1,  1, 6},
                            {1, -4, 5, 0, 3} };


        double[,] Mass4 = { {0, 0, 0,  0, 5},
                            {0, 0, 0,  0, 4},
                            {2, -2,0,  1, 6},
                            {1, -4, 5, 0, 3} };

        double[,] Mass2 = { {1, 2, 3, 3 },
                            {3, 5, 7, 0 },
                            {1, 3, 4, 1 }};


        private void button1_Click(object sender, EventArgs e)
        {
            double[] x = Gaus(A2, 3);
            Label[] labels = { label1, label2, label3, label4 };
            for (int i = 0; i < x.Length; i++)
            {
                labels[i].Text = x[i].ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double det = Detreminant(A2, 3);
            label5.Text = det.ToString();
        }

        double Detreminant(double[,]Matrix,int n)
        {
            
            double d = 1;
            for (int k = 1; k < n; k++)
            {
                for (int j = k; j < n; j++)
                {
                    double m = Matrix[j, k - 1] / Matrix[k - 1, k - 1];
                    for (int i = 0; i < n + 1; i++)
                    {
                        Matrix[j, i] = Matrix[j, i] - m * Matrix[k - 1, i];
                    }
                }
            }
            for (int i = 0; i < n; i++)
            {
                d*=Matrix[i, i];
            }
            if (d <0||d>0)
            {
                return d;
            }
            else
            {
                return 0;
            }
        }


        double[] Gaus(double[,] Matrix, int n)
        {
            double[] x = new double[n];
            if (Detreminant(Matrix, n) == 0)
            {
                MessageBox.Show("Определитель == 0");
                return x;
            }
            for (int i = 0; i < n - 1; i++)
            {
                if (Matrix[i, i] == 0)
                {
                    if (i == n - 1)
                    {
                        for (int j = 0; j < n + 1; j++)
                        {
                            double temp = Matrix[i, j];
                            Matrix[i, j] = Matrix[i - 1, j];
                            Matrix[i - 1, j] = temp;
                        }
                    }
                    else
                    {
                        for (int j = 0; j < n + 1; j++)
                        {
                            double temp = Matrix[i, j];
                            Matrix[i, j] = Matrix[i + 1, j];
                            Matrix[i + 1, j] = temp;
                        }

                    }
                }
            }
            
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
