using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TA_GesBib_Cliente.ServicioJava;

namespace TA_GesBib_Cliente
{
    public partial class frmDistribuirPersonalSemana : Form
    {

        private Form var_formPerfil; //byTyS
        private ServicioJava.personal personal = new ServicioJava.personal();
        private BindingList<ServicioJava.distribucionPersonal> listaDist;
        private BindingList<BindingList<ServicioJava.distribucionPersonal>> matrizDist=new BindingList<BindingList<distribucionPersonal>>();
        private ServicioJava.distribucionPersonal distrib = new ServicioJava.distribucionPersonal();
        ServicioJava.ServicioClient DBController = new ServicioJava.ServicioClient();
        BindingList<ServicioJava.puntosAtencion> puntoA;
        int idBib;
        ServicioJava.biblioteca bib;
        private usuario user;

        public frmDistribuirPersonalSemana()
        {
            InitializeComponent();
            
            //dgvDitribucion.Rows[0].Cells[1].Style.BackColor = Color.PowderBlue;
            //dgvDitribucion.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
            //Daywisegrid.Rows[RowIndex].Cells[columnIndex].Style.BackColor = Color.Red;

        }
    

        public frmDistribuirPersonalSemana(Form formPerfil, ServicioJava.usuario usuario)
        {

            var_formPerfil = formPerfil; //byTyS
            InitializeComponent();
            personal.id = usuario.id;
            
            dgvDitribucion.AutoGenerateColumns = false;

            bib = Program.DBController.getBibliotecaGestor(personal.id);

            puntoA = new BindingList<puntosAtencion>(Program.DBController.listarPuntosAtencion(bib.id));


        }

        public frmDistribuirPersonalSemana(usuario var_usuario)
        {
            this.user = var_usuario;
            //int idBib = Program.DBController.getBibliotecaGestor(user.id);
            //puntoA = new BindingList<puntosAtencion>(Program.DBController.listarPuntosAtencion(idBib));
            //foreach (ServicioJava.puntosAtencion pa in puntoA) {

            //    dgvDitribucion.Rows.Add(pa);
            //}
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDitribucion_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {

                if (e.RowIndex >= 0 && e.ColumnIndex >= 1)
                {
                    int fil = dgvDitribucion.CurrentCell.RowIndex;
                    int col = dgvDitribucion.CurrentCell.ColumnIndex;

                    frmAsignarPersonalPuntoAtencion formAsignarPersonal = new frmAsignarPersonalPuntoAtencion(bib,puntoA[fil], matrizDist[fil],dtpSemana.Value,col);
                    if (formAsignarPersonal.ShowDialog() == DialogResult.OK) {
                        //BindingList<ServicioJava.distribucionPersonal> auxDist = formAsignarPersonal.ListaNuevos;
                        //foreach (ServicioJava.distribucionPersonal dp in auxDist)
                        //{
                        //    matrizDist[fil].Add(dp);
                        //}                        

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
            //((frmPerfilGestor)this.var_formPerfil).PanelBIPO.Visible = true;
        }

        private void btnBuscarDistribucion_Click(object sender, EventArgs e)
        {
            matrizDist = new BindingList<BindingList<distribucionPersonal>>();
            if(dgvDitribucion!=null)dgvDitribucion.RowCount = 0;
            int fila = 0;
            foreach (ServicioJava.puntosAtencion pa in puntoA)
            {

                dgvDitribucion.Rows.Add(pa.nombre);
                try
                {
                    listaDist = new BindingList<distribucionPersonal>(Program.DBController.listarDistribucionPersonalPorFecha(personal.id, pa.id, dtpSemana.Value, dtpSemana.Value));
                    matrizDist.Add(listaDist);
                    foreach (ServicioJava.distribucionPersonal distAux in listaDist)
                    {
                        int col1 = Convert.ToInt32(distAux.horaInicio.Substring(0, 2)) - 7;
                        int col2 = Convert.ToInt32(distAux.horaFin.Substring(0, 2)) - 7;

                        for (int  i=col1; i<col2; i++)
                            dgvDitribucion.Rows[fila].Cells[i].Style.BackColor = Color.PowderBlue;
                    }
                }
                catch (Exception ex)
                {
                    matrizDist.Add(new BindingList<distribucionPersonal>());
                    System.Console.Write("Lista vacía");
                }
                fila++;
            }

        }

        private void frmDistribuirPersonalSemana_Load(object sender, EventArgs e)
        {

        }
    }
}
