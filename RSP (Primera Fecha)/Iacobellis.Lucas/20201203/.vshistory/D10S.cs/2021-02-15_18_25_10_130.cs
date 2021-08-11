using System;
using System.Threading;
using System.Windows.Forms;
using Audio;
using Entidades;
using Entidades.Extension;
using Interfaces;
using Serializacion;

namespace _20201203
{
    public partial class D10S : Form
    {
        private Pic estado = Pic.SePrepara;
        private GolDelSiglo golDelSiglo;

        Log logFile = new Log();
        LogDB logDB = new LogDB();

        public D10S()
        {
            InitializeComponent();
            Relato.Avanzar += MostrarGrafico;
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
                                this.pic1.Visible = false;
                                this.pic2.Visible = false;
                                this.pic3.Visible = false;
                                this.pic4.Visible = false;
                                this.pic5.Visible = false;

                                //this.picFondo.Refresh();
                                //this.pic1.Refresh();
                                //this.pic2.Refresh();
                                //this.pic3.Refresh();
                                //this.pic4.Refresh();
                                //this.pic5.Refresh();
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
                                //this.pic1.Refresh();
                            });
                        }
                        break;
                    case Pic.ArrancaConLaPelota:
                        if (this.pic1.InvokeRequired)
                        {
                            this.pic1.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic1.Visible = false;
                                //this.pic1.Refresh();
                            });
                        }

                        if (this.pic2.InvokeRequired)
                        {
                            this.pic2.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic2.Visible = true;
                                //this.pic2.Refresh();
                            });
                        }
                        break;
                    case Pic.DejaElTendal:
                        if (this.pic2.InvokeRequired)
                        {
                            this.pic2.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic2.Visible = false;
                                //this.pic2.Refresh();
                            });
                        }

                        if (this.pic3.InvokeRequired)
                        {
                            this.pic3.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic3.Visible = true;
                                //this.pic3.Refresh();
                            });
                        }
                        break;
                    case Pic.VaATocarPara:
                        if (this.pic3.InvokeRequired)
                        {
                            this.pic3.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic3.Visible = false;
                                //this.pic3.Refresh();
                            });
                        }

                        if (this.pic4.InvokeRequired)
                        {
                            this.pic4.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic4.Visible = true;
                                //this.pic4.Refresh();
                            });
                        }
                        break;
                    case Pic.Gooool:
                        if (this.pic4.InvokeRequired)
                        {
                            this.pic4.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic4.Visible = false;
                                //this.pic4.Refresh();
                            });
                        }

                        if (this.pic5.InvokeRequired)
                        {
                            this.pic5.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic5.Visible = true;
                                //this.pic5.Refresh();
                            });
                        }
                        break;
                    case Pic.Festeja:
                        if (this.pic5.InvokeRequired)
                        {
                            this.pic5.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.pic5.Visible = false;
                                //this.pic5.Refresh();
                            });
                        }

                        if (this.picFondo.InvokeRequired)
                        {
                            this.picFondo.BeginInvoke((MethodInvoker)delegate ()
                            {
                                this.picFondo.Visible = true;
                                //this.picFondo.Refresh();
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
