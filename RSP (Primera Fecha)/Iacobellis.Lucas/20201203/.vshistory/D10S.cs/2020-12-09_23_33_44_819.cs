﻿using System;
using System.Threading;
using System.Windows.Forms;
using Entidades;
using Entidades.Extension;
using Interfaces;
using Serializacion;

namespace _20201203
{
    public partial class D10S : Form
    {
        private Pic estado;
        private GolDelSiglo golDelSiglo;
        private delegate void DelegadoMostrarGrafico();
        private Thread threadSecundario;

        Log logFile = new Log();
        LogDB logDB = new LogDB();

        public D10S()
        {
            InitializeComponent();
        }

        private void ThreadSecundarioMostrarGrafico() 
        {
            while (true)
            {
                DelegadoMostrarGrafico delegadoMostrarGrafico = new DelegadoMostrarGrafico(MostrarGrafico);
                delegadoMostrarGrafico.Invoke();
            }
        }
        private void MostrarGrafico()
        {
                switch (estado)
                {
                    case Pic.SePrepara:
                        if (this.picFondo.InvokeRequired)
                        {
                            this.picFondo.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.picFondo.Visible = false;
                            });
                        }
                        break;
                    case Pic.LaTieneMaradona:
                    case Pic.PisaLaPelota:
                        if (this.pic1.InvokeRequired)
                        {
                            this.pic1.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic1.Visible = true;
                            });
                        }
                        break;
                    case Pic.ArrancaConLaPelota:
                        if (this.pic1.InvokeRequired)
                        {
                            this.pic1.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic1.Visible = false;
                            });
                        }

                        if (this.pic2.InvokeRequired)
                        {
                            this.pic2.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic2.Visible = true;
                            });
                        }
                        break;
                    case Pic.DejaElTendal:
                        if (this.pic2.InvokeRequired)
                        {
                            this.pic2.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic2.Visible = false;
                            });
                        }

                        if (this.pic3.InvokeRequired)
                        {
                            this.pic3.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic3.Visible = true;
                            });
                        }
                        break;
                    case Pic.VaATocarPara:
                        if (this.pic3.InvokeRequired)
                        {
                            this.pic3.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic3.Visible = false;
                            });
                        }

                        if (this.pic4.InvokeRequired)
                        {
                            this.pic4.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic4.Visible = true;
                            });
                        }
                        break;
                    case Pic.Gooool:
                        if (this.pic4.InvokeRequired)
                        {
                            this.pic4.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic4.Visible = false;
                            });
                        }

                        if (this.pic5.InvokeRequired)
                        {
                            this.pic5.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic5.Visible = true;
                            });
                        }
                        break;
                    case Pic.Festeja:
                        if (this.pic5.InvokeRequired)
                        {
                            this.pic5.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic5.Visible = false;
                            });
                        }

                        if (this.picFondo.InvokeRequired)
                        {
                            this.picFondo.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.picFondo.Visible = true;
                            });
                        }
                        estado--;
                        break;
                }
                estado++;
        }
        private string ExtenderClasePictureBox(PictureBox pictureBox) 
        {
            return pictureBox.ObtenerUltimoCaracterDelNombre();
        }
        private void btnGolDelSiglo_Click(object sender, EventArgs e)
        {
            golDelSiglo = new GolDelSiglo();
            golDelSiglo.IniciarJugada();

            threadSecundario = new Thread(ThreadSecundarioMostrarGrafico);
            threadSecundario.Start();

            logDB.Info(string.Format("Se disfrutó el gol del siglo a las {0:HH:mm:ss} hs", DateTime.Now));
            logFile.Info(string.Format("Se disfrutó el gol del siglo a las {0:HH:mm:ss} hs", DateTime.Now));
        }

        private void D10S_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("¿Esta seguro de que desea salir?", "", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes) 
            {
                golDelSiglo.CerrarApp();
            }
            
        }
        private void btnLeerLogBaseDeDatos_Click(object sender, EventArgs e)
        {
            string info = "";
            logDB.GetInfo(out info);
            MessageBox.Show(info);
        }
        private void btnLeerLogTXT_Click(object sender, EventArgs e)
        {
            string info = "";
            logFile.GetInfo(out info);
            MessageBox.Show(info);
        }
    }
}