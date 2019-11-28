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
    //creo como atributos los formularios de mi menu d cada booton
    //al aser click pregunto si es null(para ver si ya lo he creado y no hacer otro)
    //if(form == null){
    //    //aca pongo visible false a todos  los demas que EXISTEN (OTRO if X CADA UNO)
    //    form = new frmTipoFrm();
    //}else{
    //    form.Visible = true; //es xq en algun momento lo he puesto false
    //}


    public partial class frmPerfilAuxiliar : Form
    {
        //se agrego
        private ServicioJava.usuario var_usuario;
        private frmLogin var_formLogin;
        private frmRegHE var_frmRegistrarHE_Auxiliar;
        private frmRegInasistencias var_frmRegistrarInasis_Auxiliar;
        private frmSolicitarHL var_frmSolicitarHL_Auxiliar;
        private frmSolicitarCambioTurno var_frmSolicitarCambioTurno_Auxiliar;
        private frmRespuestaValidaciones var_frmRespuestasSolicitudes_Auxiliar;
        private frmVisualizarHorarios var_frmVerHorarios_Auxiliar;
        private ServicioJava.personalBiblioteca var_datosUsuario;

        public Panel PanelAviso { get => panelAviso; set => panelAviso = value; }
        public Label LblBienvenido { get => lblBienvenido; set => lblBienvenido = value; }


        public frmPerfilAuxiliar()
        {
            InitializeComponent();
            customizeDesign();
        }


        public frmPerfilAuxiliar(frmLogin formLogin, ServicioJava.usuario _usuario, ServicioJava.personalBiblioteca var_datosUsuario) //con paramtero this 
        {
            var_usuario = _usuario;
            var_formLogin = formLogin;
            InitializeComponent();
            customizeDesign();
            lblNombreUsuario.Text = _usuario.nombre;
        }

        //...................PANELES v2 ................................

        private void customizeDesign()
        {
            panelBtn_Registrar.Visible = false;
            panelBtn_Solicitar.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelBtn_Registrar.Visible == true)
                panelBtn_Registrar.Visible = false;

            if (panelBtn_Solicitar.Visible == true)
                panelBtn_Solicitar.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            //alterna la visibilidad del submenu actual con el submenu anterior

            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        //...................PANELES v2 ................................



        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            showSubMenu(panelBtn_Registrar);

        }
        

        private void btnSolicitar_Click(object sender, EventArgs e)
        {
            showSubMenu(panelBtn_Solicitar);
        }



        private void muestraMensajeCerraroGuardarCambios()
        {
            //mostramos mensaje de error
            MessageBox.Show("Cierre o guarde los cambios !",
                "Advertencia",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button1);
        }

        private void btnReg_HE_Click(object sender, EventArgs e)
        {

            panelBIPO.Visible = false;
            //......
            //preguntar si hay algun form "activo" para no cargar este form

            if ((var_frmRegistrarInasis_Auxiliar != null &&
                        var_frmRegistrarInasis_Auxiliar.Visible == true) ||
                    (var_frmSolicitarHL_Auxiliar != null &&
                        var_frmSolicitarHL_Auxiliar.Visible == true) ||
                    (var_frmSolicitarCambioTurno_Auxiliar != null &&
                        var_frmSolicitarCambioTurno_Auxiliar.Visible == true) ||
                    (var_frmRespuestasSolicitudes_Auxiliar != null &&
                        var_frmRespuestasSolicitudes_Auxiliar.Visible == true) ||
                    (var_frmVerHorarios_Auxiliar != null &&
                        var_frmVerHorarios_Auxiliar.Visible == true))
            {

                this.muestraMensajeCerraroGuardarCambios();

            }
            else
            {

                //seguimos con nuestra programacion
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmRegistrarHE_Auxiliar == null)
                {

                    var_frmRegistrarHE_Auxiliar = new frmRegHE(this, TipoPerfil.PerfilAuxiliar,
                var_usuario);

                    var_frmRegistrarHE_Auxiliar.MdiParent = this;

                    //...add
                    var_frmRegistrarHE_Auxiliar.StartPosition = FormStartPosition.Manual;
                    var_frmRegistrarHE_Auxiliar.Left = 0;
                    var_frmRegistrarHE_Auxiliar.Top = 0;
                    //...


                    var_frmRegistrarHE_Auxiliar.Show();
                }
                else
                {
                    var_frmRegistrarHE_Auxiliar.limpiarComponentes();
                    var_frmRegistrarHE_Auxiliar.estadoComponentes(Estado.Inicial);
                    var_frmRegistrarHE_Auxiliar.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Auxiliar != null)
                {
                    var_frmSolicitarHL_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                if (var_frmRegistrarInasis_Auxiliar != null)
                {
                    var_frmRegistrarInasis_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmSolicitarCambioTurno_Auxiliar != null)
                {
                    var_frmSolicitarCambioTurno_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }


            //....            

        }

        private void btnReg_Inas_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarHE_Auxiliar != null &&
                        var_frmRegistrarHE_Auxiliar.Visible == true) ||
               (var_frmSolicitarHL_Auxiliar != null &&
                       var_frmSolicitarHL_Auxiliar.Visible == true) ||
               (var_frmSolicitarCambioTurno_Auxiliar != null &&
                        var_frmSolicitarCambioTurno_Auxiliar.Visible == true) ||
               (var_frmRespuestasSolicitudes_Auxiliar != null &&
                        var_frmRespuestasSolicitudes_Auxiliar.Visible == true) ||
               (var_frmVerHorarios_Auxiliar != null &&
                        var_frmVerHorarios_Auxiliar.Visible == true))
            {
                this.muestraMensajeCerraroGuardarCambios();
            }
            else
            {
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmRegistrarInasis_Auxiliar == null)
                {
                    var_frmRegistrarInasis_Auxiliar = new frmRegInasistencias(this, TipoPerfil.PerfilAuxiliar, var_usuario);
                    var_frmRegistrarInasis_Auxiliar.MdiParent = this;

                    //...add
                    var_frmRegistrarInasis_Auxiliar.StartPosition = FormStartPosition.Manual;
                    var_frmRegistrarInasis_Auxiliar.Left = 0;
                    var_frmRegistrarInasis_Auxiliar.Top = 0;
                    //...


                    var_frmRegistrarInasis_Auxiliar.Show();
                }
                else
                {
                    var_frmRegistrarInasis_Auxiliar.limpiarComponentes();
                    var_frmRegistrarInasis_Auxiliar.estadoComponentes(Estado.Inicial);
                    var_frmRegistrarInasis_Auxiliar.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Auxiliar != null)
                {
                    var_frmSolicitarHL_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();

            }

        }



        private void btnSolicitar_HLibres_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarHE_Auxiliar != null &&
                        var_frmRegistrarHE_Auxiliar.Visible == true) ||
               (var_frmRegistrarInasis_Auxiliar != null &&
                        var_frmRegistrarInasis_Auxiliar.Visible == true) ||
               (var_frmSolicitarCambioTurno_Auxiliar != null &&
                        var_frmSolicitarCambioTurno_Auxiliar.Visible == true) ||
               (var_frmRespuestasSolicitudes_Auxiliar != null &&
                        var_frmRespuestasSolicitudes_Auxiliar.Visible == true) ||
               (var_frmVerHorarios_Auxiliar != null &&
                        var_frmVerHorarios_Auxiliar.Visible == true))
            {
                this.muestraMensajeCerraroGuardarCambios();
            }
            else
            {
                //aca llamamos al formulario de solicitar horas libres
                if (var_frmSolicitarHL_Auxiliar == null)
                {
                    var_frmSolicitarHL_Auxiliar = new frmSolicitarHL(this, TipoPerfil.PerfilAuxiliar,
                        var_usuario);
                    var_frmSolicitarHL_Auxiliar.MdiParent = this;

                    //...add
                    var_frmSolicitarHL_Auxiliar.StartPosition = FormStartPosition.Manual;
                    var_frmSolicitarHL_Auxiliar.Left = 0;
                    var_frmSolicitarHL_Auxiliar.Top = 0;
                    //...


                    var_frmSolicitarHL_Auxiliar.Show();
                }
                else
                {
                    var_frmSolicitarHL_Auxiliar.limpiarComponentes();
                    var_frmSolicitarHL_Auxiliar.estadoComponentes(Estado.Inicial);
                    var_frmSolicitarHL_Auxiliar.Visible = true;
                }

                //....
                if (var_frmSolicitarCambioTurno_Auxiliar != null)
                {
                    var_frmSolicitarCambioTurno_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }

        }


        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.var_formLogin.Visible = true;
        }

        private void frmPerfilAuxiliar_Load(object sender, EventArgs e)
        {
            //escondemos los paneles
            //panelBtn_Registrar.Hide();
            //panelBtn_Solicitar.Hide();
        }

        private void btnSolicitar_CambioTurno_Click(object sender, EventArgs e)
        {

            panelBIPO.Visible = false;

            if ((var_frmRegistrarHE_Auxiliar != null &&
                        var_frmRegistrarHE_Auxiliar.Visible == true) ||
               (var_frmRegistrarInasis_Auxiliar != null &&
                        var_frmRegistrarInasis_Auxiliar.Visible == true) ||
               (var_frmSolicitarHL_Auxiliar != null &&
                        var_frmSolicitarHL_Auxiliar.Visible == true) ||
               (var_frmRespuestasSolicitudes_Auxiliar != null &&
                        var_frmRespuestasSolicitudes_Auxiliar.Visible == true) ||
               (var_frmVerHorarios_Auxiliar != null &&
                        var_frmVerHorarios_Auxiliar.Visible == true))
            {
                this.muestraMensajeCerraroGuardarCambios();
            }
            else
            {
                //aca llamamos al formulario de solicitar cambio de turno
                if (var_frmSolicitarCambioTurno_Auxiliar == null)
                {
                    var_frmSolicitarCambioTurno_Auxiliar = new frmSolicitarCambioTurno(this, TipoPerfil.PerfilAuxiliar);
                    var_frmSolicitarCambioTurno_Auxiliar.MdiParent = this;

                    //...add



                    var_frmSolicitarCambioTurno_Auxiliar.StartPosition = FormStartPosition.Manual;
                    var_frmSolicitarCambioTurno_Auxiliar.Left = 0;
                    var_frmSolicitarCambioTurno_Auxiliar.Top = 0;
                    //...


                    var_frmSolicitarCambioTurno_Auxiliar.Show();
                }
                else
                {

                    var_frmSolicitarCambioTurno_Auxiliar.limpiarComponentes();
                    var_frmSolicitarCambioTurno_Auxiliar.estadoComponentes(Estado.Inicial);
                    var_frmSolicitarCambioTurno_Auxiliar.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Auxiliar != null)
                {
                    var_frmSolicitarHL_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }

        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarInasis_Auxiliar != null &&
                        var_frmRegistrarInasis_Auxiliar.Visible == true) ||
                (var_frmSolicitarHL_Auxiliar != null &&
                        var_frmSolicitarHL_Auxiliar.Visible == true) ||
                (var_frmSolicitarCambioTurno_Auxiliar != null &&
                        var_frmSolicitarCambioTurno_Auxiliar.Visible == true) ||
                (var_frmRespuestasSolicitudes_Auxiliar != null &&
                        var_frmRespuestasSolicitudes_Auxiliar.Visible == true) ||
                (var_frmVerHorarios_Auxiliar != null &&
                        var_frmVerHorarios_Auxiliar.Visible == true))
            {

                this.muestraMensajeCerraroGuardarCambios();

            }
            else
            {

                //seguimos con nuestra programacion
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmRespuestasSolicitudes_Auxiliar == null)
                {
                    var_frmRespuestasSolicitudes_Auxiliar = new frmRespuestaValidaciones(this, TipoPerfil.PerfilAuxiliar,
                        var_usuario);
                    var_frmRespuestasSolicitudes_Auxiliar.MdiParent = this;

                    //...add
                    var_frmRespuestasSolicitudes_Auxiliar.StartPosition = FormStartPosition.Manual;
                    var_frmRespuestasSolicitudes_Auxiliar.Left = 0;
                    var_frmRespuestasSolicitudes_Auxiliar.Top = 0;
                    //...


                    var_frmRespuestasSolicitudes_Auxiliar.Show();
                }
                else
                {
                    //var_frmRespuestasSolicitudes_Auxiliar.limpiarComponentes();
                    //var_frmRespuestasSolicitudes_Auxiliar.estadoComponentes(Estado.Inicial);
                    var_frmRespuestasSolicitudes_Auxiliar.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Auxiliar != null)
                {
                    var_frmSolicitarHL_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                if (var_frmRegistrarInasis_Auxiliar != null)
                {
                    var_frmRegistrarInasis_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmSolicitarCambioTurno_Auxiliar != null)
                {
                    var_frmSolicitarCambioTurno_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmRegistrarHE_Auxiliar != null)
                {
                    var_frmRegistrarHE_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = true;
        }

        private void btnVisualizarHorarios_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarInasis_Auxiliar != null &&
                        var_frmRegistrarInasis_Auxiliar.Visible == true) ||
                (var_frmSolicitarHL_Auxiliar != null &&
                        var_frmSolicitarHL_Auxiliar.Visible == true) ||
                (var_frmSolicitarCambioTurno_Auxiliar != null &&
                        var_frmSolicitarCambioTurno_Auxiliar.Visible == true) ||
                (var_frmRespuestasSolicitudes_Auxiliar != null &&
                        var_frmRespuestasSolicitudes_Auxiliar.Visible == true) ||
                (var_frmRegistrarHE_Auxiliar != null &&
                        var_frmRegistrarHE_Auxiliar.Visible == true))
            {

                this.muestraMensajeCerraroGuardarCambios();

            }
            else
            {

                //seguimos con nuestra programacion
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmVerHorarios_Auxiliar == null)
                {
                    var_frmVerHorarios_Auxiliar = new frmVisualizarHorarios(this, TipoPerfil.PerfilAuxiliar);
                    var_frmVerHorarios_Auxiliar.MdiParent = this;

                    //...add
                    var_frmVerHorarios_Auxiliar.StartPosition = FormStartPosition.Manual;
                    var_frmVerHorarios_Auxiliar.Left = 0;
                    var_frmVerHorarios_Auxiliar.Top = 0;
                    //...


                    var_frmVerHorarios_Auxiliar.Show();
                }
                else
                {
                    //var_frmRespuestasSolicitudes_Auxiliar.limpiarComponentes();
                    //var_frmRespuestasSolicitudes_Auxiliar.estadoComponentes(Estado.Inicial);
                    var_frmVerHorarios_Auxiliar.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Auxiliar != null)
                {
                    var_frmSolicitarHL_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                if (var_frmRegistrarInasis_Auxiliar != null)
                {
                    var_frmRegistrarInasis_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmSolicitarCambioTurno_Auxiliar != null)
                {
                    var_frmSolicitarCambioTurno_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmRegistrarHE_Auxiliar != null)
                {
                    var_frmRegistrarHE_Auxiliar.Visible = false;
                    //todos los demas formularios

                }

                var_frmVerHorarios_Auxiliar.Size = new Size(930, 657);

                lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }
        }

        private void buttonVerOtrosPerfiles_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;
            frmBuscarOtrosPerfiles frmBuscarOtros = new frmBuscarOtrosPerfiles(this, TipoPerfil.PerfilAuxiliar);
            frmBuscarOtros.MdiParent = this;

            //...add
            frmBuscarOtros.StartPosition = FormStartPosition.Manual;
            frmBuscarOtros.Left = 0;
            frmBuscarOtros.Top = 0;
            //...

            frmBuscarOtros.Show();
        }
    }
}
