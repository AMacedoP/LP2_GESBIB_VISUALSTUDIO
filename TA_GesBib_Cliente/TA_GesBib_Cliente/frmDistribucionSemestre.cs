using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA_GesBib_Cliente
{
    public partial class frmDistribucionSemestre : Form
    {

        private Form var_perfil;
        private ServicioJava.personal personal = new ServicioJava.personal();
        private BindingList<ServicioJava.distribucionPersonal> listaDist;
        private BindingList<BindingList<ServicioJava.distribucionPersonal>> matrizDist = new BindingList<BindingList<ServicioJava.distribucionPersonal>>();
        private ServicioJava.distribucionPersonal distrib = new ServicioJava.distribucionPersonal();
        ServicioJava.ServicioClient DBController = new ServicioJava.ServicioClient();
        BindingList<ServicioJava.puntosAtencion> puntoA;
        int idBib;
        ServicioJava.biblioteca bib;
        private ServicioJava.usuario usuario;

        public frmDistribucionSemestre()
        {
            InitializeComponent();
        }
        public frmDistribucionSemestre(Form formPerfil, ServicioJava.usuario user)
        {
            var_perfil = formPerfil;
            InitializeComponent();

            personal.id = user.id;

            dgvDitribucion.AutoGenerateColumns = false;

            bib = Program.DBController.getBibliotecaGestor(personal.id);

            puntoA = new BindingList<ServicioJava.puntosAtencion>(Program.DBController.listarPuntosAtencion(bib.id));



        }
        private void dgvDitribucion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
                {
                    int fil = dgvDitribucion.CurrentCell.RowIndex;
                    int col = dgvDitribucion.CurrentCell.ColumnIndex;

                    frmAsignarPersonalPuntoAtencion formAsignarPersonal = new frmAsignarPersonalPuntoAtencion(bib, puntoA[fil], matrizDist[fil], dtpInicioSem.Value, col);
                    if (formAsignarPersonal.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Se ha asignado correctamente el personal", "Mensaje de Éxito");
                    }
                }
            }
            catch (Exception)
            {
                System.Console.Write("Error");

            }
        }



        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ((frmPerfilGestor)this.var_perfil).PanelBIPO.Visible = true;
        }

        private void btnGuardarDistribucion_Click(object sender, EventArgs e)
        {
            foreach (BindingList<ServicioJava.distribucionPersonal> l1 in matrizDist) {
                foreach (ServicioJava.distribucionPersonal dist in l1) {
                    Program.DBController.insertarDistribucionPersonal(dist);
                }

            }
        }
    }
}
