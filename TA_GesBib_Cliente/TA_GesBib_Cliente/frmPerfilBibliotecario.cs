using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TA_GesBib_Cliente
{     
            
    public partial class frmPerfilBibliotecario : Form
    {
        //se agrego
        private ServicioJava.usuario var_usuario;
        private ServicioJava.personalBiblioteca var_datosUsuario;
        private frmLogin var_formLogin;
        private frmRegHE var_frmRegistrarHE_Bibliotecario;
        private frmRegInasistencias var_frmRegistrarInasis_Bibliotecario;
        private frmSolicitarHL var_frmSolicitarHL_Bibliotecario;
        private frmSolicitarCambioTurno var_frmSolicitarCambioTurno_Bibliotecario;
        private frmRespuestaValidaciones var_frmRespuestasSolicitudes_Bibliotecario;
        private frmVisualizarHorarios var_frmVerHorarios_Bibliotecario;
        BindingList<ServicioJava.aviso> listaAvisos ;        

        public Panel PanelBIPO { get => panelBIPO; set => panelBIPO = value; }

        public Panel PanelAviso { get => panelAviso; set => panelAviso = value; }
        //public Label LblBienvenido { get => lblBienvenido; set => lblBienvenido = value; }                 

        public frmPerfilBibliotecario()
        {
            InitializeComponent();
            customizeDesign();
            listaAvisos= new BindingList<ServicioJava.aviso>(Program.DBController.listarAvisos());
            foreach (ServicioJava.aviso a in listaAvisos) {
                lblTitulo1.Text = a.titulo;
                txtDescripcion.Text = a.descripcion;
                //break;
            }

        }

        
        public frmPerfilBibliotecario(frmLogin formLogin,ServicioJava.usuario _usuario, ServicioJava.personalBiblioteca _datosUsuario) //con paramtero this 
        {
            var_usuario = _usuario;
            var_formLogin = formLogin;
            var_datosUsuario = _datosUsuario;
            InitializeComponent();
            //
            if(var_datosUsuario.foto != null)
            {
                MemoryStream ms1 = new MemoryStream(var_datosUsuario.foto);
                pbMinifoto.Image = new Bitmap(ms1);
            }
            //
            this.lblNombreUsuario.Text = var_usuario.nombre;
            customizeDesign(); // <---- para los PANELES

            List<Label> _lstaLabels = new List<Label> {lblTitulo1, lblTitulo2, lblTitulo3, lblTitulo4 };
            List<TextBox> _lstaText_Box = 
                new List<TextBox> {txtDescripcion, txtDescripcion2, txtDescripcion3, txtDescripcion4};
            
            int i=0;

            listaAvisos = new BindingList<ServicioJava.aviso>(Program.DBController.listarAvisos());
            foreach (ServicioJava.aviso a in listaAvisos)
            {
                _lstaLabels[i].Text = a.titulo;
                _lstaText_Box[i].Text = a.descripcion;
                i++;
                if(i==4)break;
            }
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
            //showSubMenu(panelBtn_Solicitar);
            this.btnSolicitar_HLibres_Click(sender, e);
        }

        private void btnDistribuir_Personal_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;
            frmDistribuirPersonalSemana frmDistribuir = new frmDistribuirPersonalSemana(this, var_usuario);
            frmDistribuir.Location = new Point(0, 0);
            frmDistribuir.Size = new Size(934, 675);
            frmDistribuir.MdiParent = this;

            //...add
            frmDistribuir.StartPosition = FormStartPosition.Manual;
            frmDistribuir.Left = 0;
            frmDistribuir.Top = 0;
            //...

            frmDistribuir.Show();

            //hoy agregeishion
            //lblBienvenido.Visible = false;
            panelAviso.Visible = false;
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

            if (  (var_frmRegistrarInasis_Bibliotecario != null &&
                        var_frmRegistrarInasis_Bibliotecario.Visible == true) ||
                    (var_frmSolicitarHL_Bibliotecario != null &&    
                        var_frmSolicitarHL_Bibliotecario.Visible == true) ||
                    (var_frmSolicitarCambioTurno_Bibliotecario != null &&
                        var_frmSolicitarCambioTurno_Bibliotecario.Visible == true)||
                    (var_frmRespuestasSolicitudes_Bibliotecario != null &&
                        var_frmRespuestasSolicitudes_Bibliotecario.Visible == true)||
                    (var_frmVerHorarios_Bibliotecario != null &&
                        var_frmVerHorarios_Bibliotecario.Visible == true))
                {

                this.muestraMensajeCerraroGuardarCambios();

                }
            else
            {              

                //seguimos con nuestra programacion
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmRegistrarHE_Bibliotecario == null)
                {
                    var_frmRegistrarHE_Bibliotecario = new frmRegHE(this,
                        TipoPerfil.PerfilBibliotecario, var_usuario);
                    var_frmRegistrarHE_Bibliotecario.MdiParent = this;

                    //...add
                    var_frmRegistrarHE_Bibliotecario.StartPosition = FormStartPosition.Manual;
                    var_frmRegistrarHE_Bibliotecario.Left = 0;
                    var_frmRegistrarHE_Bibliotecario.Top = 0;
                    //...


                    var_frmRegistrarHE_Bibliotecario.Show();
                }
                else
                {
                    var_frmRegistrarHE_Bibliotecario.limpiarComponentes();
                    var_frmRegistrarHE_Bibliotecario.estadoComponentes(Estado.Inicial);
                    var_frmRegistrarHE_Bibliotecario.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Bibliotecario != null)
                {
                    var_frmSolicitarHL_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                if (var_frmRegistrarInasis_Bibliotecario != null)
                {
                    var_frmRegistrarInasis_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmSolicitarCambioTurno_Bibliotecario != null)
                {
                    var_frmSolicitarCambioTurno_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                var_frmRegistrarHE_Bibliotecario.Location = new Point(0, 0);
                var_frmRegistrarHE_Bibliotecario.Size = new Size(934, 675);

                //lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }
             

            //....            

        }

        private void btnReg_Inas_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarHE_Bibliotecario != null &&
                        var_frmRegistrarHE_Bibliotecario.Visible == true) ||
               (var_frmSolicitarHL_Bibliotecario != null &&
                       var_frmSolicitarHL_Bibliotecario.Visible == true) ||
               (var_frmSolicitarCambioTurno_Bibliotecario != null &&
                        var_frmSolicitarCambioTurno_Bibliotecario.Visible == true) ||
               (var_frmRespuestasSolicitudes_Bibliotecario != null &&
                        var_frmRespuestasSolicitudes_Bibliotecario.Visible == true)||
               (var_frmVerHorarios_Bibliotecario != null &&
                        var_frmVerHorarios_Bibliotecario.Visible == true))
            {
                this.muestraMensajeCerraroGuardarCambios();
            }
            else
            {
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmRegistrarInasis_Bibliotecario == null)
                {
                    var_frmRegistrarInasis_Bibliotecario = new frmRegInasistencias(this,TipoPerfil.PerfilBibliotecario,var_usuario);
                    var_frmRegistrarInasis_Bibliotecario.MdiParent = this;

                    //...add
                    var_frmRegistrarInasis_Bibliotecario.StartPosition = FormStartPosition.Manual;
                    var_frmRegistrarInasis_Bibliotecario.Left = 0;
                    var_frmRegistrarInasis_Bibliotecario.Top = 0;
                    //...


                    var_frmRegistrarInasis_Bibliotecario.Show();
                }
                else
                {
                    var_frmRegistrarInasis_Bibliotecario.limpiarComponentes();
                    var_frmRegistrarInasis_Bibliotecario.estadoComponentes(Estado.Inicial);
                    var_frmRegistrarInasis_Bibliotecario.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Bibliotecario != null)
                {
                    var_frmSolicitarHL_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                var_frmRegistrarInasis_Bibliotecario.Location = new Point(0, 0);
                var_frmRegistrarInasis_Bibliotecario.Size = new Size(934, 675);

                //lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();

            }

        }

          

        private void btnSolicitar_HLibres_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarHE_Bibliotecario != null &&
                        var_frmRegistrarHE_Bibliotecario.Visible == true) ||
               (var_frmRegistrarInasis_Bibliotecario != null &&
                        var_frmRegistrarInasis_Bibliotecario.Visible == true) ||
               (var_frmSolicitarCambioTurno_Bibliotecario != null &&
                        var_frmSolicitarCambioTurno_Bibliotecario.Visible == true) ||
               (var_frmRespuestasSolicitudes_Bibliotecario != null &&
                        var_frmRespuestasSolicitudes_Bibliotecario.Visible == true) ||
               (var_frmVerHorarios_Bibliotecario != null &&
                        var_frmVerHorarios_Bibliotecario.Visible == true))
            {
                this.muestraMensajeCerraroGuardarCambios();
            }
            else
            {
                //aca llamamos al formulario de solicitar horas libres
                if (var_frmSolicitarHL_Bibliotecario == null)
                {
                    
                    var_frmSolicitarHL_Bibliotecario = new frmSolicitarHL(this,TipoPerfil.PerfilBibliotecario,
                        var_usuario);
                    var_frmSolicitarHL_Bibliotecario.MdiParent = this;

                    //...add
                    var_frmSolicitarHL_Bibliotecario.StartPosition = FormStartPosition.Manual;
                    var_frmSolicitarHL_Bibliotecario.Left = 0;
                    var_frmSolicitarHL_Bibliotecario.Top = 0;
                    //...


                    var_frmSolicitarHL_Bibliotecario.Show();
                }
                else
                {
                    var_frmSolicitarHL_Bibliotecario.limpiarComponentes();
                    var_frmSolicitarHL_Bibliotecario.estadoComponentes(Estado.Inicial);
                    var_frmSolicitarHL_Bibliotecario.Visible = true;
                }

                //....
                if (var_frmSolicitarCambioTurno_Bibliotecario != null)
                {
                    var_frmSolicitarCambioTurno_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                var_frmSolicitarHL_Bibliotecario.Location = new Point(0, 0);
                var_frmSolicitarHL_Bibliotecario.Size = new Size(934, 675);

                //lblBienvenido.Visible = false;
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

        private void frmPerfilBibliotecario_Load(object sender, EventArgs e)
        {
            //escondemos los paneles
            //panelBtn_Registrar.Hide();
            //panelBtn_Solicitar.Hide();
        }

        private void btnSolicitar_CambioTurno_Click(object sender, EventArgs e)
        {

            panelBIPO.Visible = false;

            if ((var_frmRegistrarHE_Bibliotecario != null &&
                        var_frmRegistrarHE_Bibliotecario.Visible == true) ||
               (var_frmRegistrarInasis_Bibliotecario != null &&
                        var_frmRegistrarInasis_Bibliotecario.Visible == true) ||
               (var_frmSolicitarHL_Bibliotecario != null &&
                        var_frmSolicitarHL_Bibliotecario.Visible == true) ||
               (var_frmRespuestasSolicitudes_Bibliotecario != null &&
                        var_frmRespuestasSolicitudes_Bibliotecario.Visible == true)||
               (var_frmVerHorarios_Bibliotecario != null &&
                        var_frmVerHorarios_Bibliotecario.Visible == true))
            {
                this.muestraMensajeCerraroGuardarCambios();
            }
            else
            {
                //aca llamamos al formulario de solicitar cambio de turno
                if (var_frmSolicitarCambioTurno_Bibliotecario == null)
                {
                    var_frmSolicitarCambioTurno_Bibliotecario = new frmSolicitarCambioTurno(this,TipoPerfil.PerfilBibliotecario);
                    var_frmSolicitarCambioTurno_Bibliotecario.MdiParent = this;

                    //...add

                    

                    var_frmSolicitarCambioTurno_Bibliotecario.StartPosition = FormStartPosition.Manual;
                    var_frmSolicitarCambioTurno_Bibliotecario.Left = 0;
                    var_frmSolicitarCambioTurno_Bibliotecario.Top = 0;
                    //...


                    var_frmSolicitarCambioTurno_Bibliotecario.Show();
                }
                else
                {
                    
                    var_frmSolicitarCambioTurno_Bibliotecario.limpiarComponentes();
                    var_frmSolicitarCambioTurno_Bibliotecario.estadoComponentes(Estado.Inicial);
                    var_frmSolicitarCambioTurno_Bibliotecario.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Bibliotecario != null)
                {
                    var_frmSolicitarHL_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                //lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                var_frmSolicitarCambioTurno_Bibliotecario.Location = new Point(0, 0);
                var_frmSolicitarCambioTurno_Bibliotecario.Size = new Size(934, 675);

                //escondemos el submenu
                hideSubMenu();
            }
            
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarInasis_Bibliotecario != null &&
                        var_frmRegistrarInasis_Bibliotecario.Visible == true) ||
                (var_frmSolicitarHL_Bibliotecario != null &&
                        var_frmSolicitarHL_Bibliotecario.Visible == true) ||
                (var_frmSolicitarCambioTurno_Bibliotecario != null &&
                        var_frmSolicitarCambioTurno_Bibliotecario.Visible == true)||
                (var_frmRespuestasSolicitudes_Bibliotecario != null &&
                        var_frmRespuestasSolicitudes_Bibliotecario.Visible == true)||
                (var_frmVerHorarios_Bibliotecario != null &&
                        var_frmVerHorarios_Bibliotecario.Visible == true))
            {

                this.muestraMensajeCerraroGuardarCambios();

            }
            else
            {

                //seguimos con nuestra programacion
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmRespuestasSolicitudes_Bibliotecario == null)
                {
                    var_frmRespuestasSolicitudes_Bibliotecario = new frmRespuestaValidaciones(this, TipoPerfil.PerfilBibliotecario,
                        var_usuario);
                    var_frmRespuestasSolicitudes_Bibliotecario.MdiParent = this;

                    //...add
                    var_frmRespuestasSolicitudes_Bibliotecario.StartPosition = FormStartPosition.Manual;
                    var_frmRespuestasSolicitudes_Bibliotecario.Left = 0;
                    var_frmRespuestasSolicitudes_Bibliotecario.Top = 0;
                    //...
                    
                    var_frmRespuestasSolicitudes_Bibliotecario.Show();
                }
                else
                {
                    //var_frmRespuestasSolicitudes_Bibliotecario.limpiarComponentes();
                    //var_frmRespuestasSolicitudes_Bibliotecario.estadoComponentes(Estado.Inicial);
                    var_frmRespuestasSolicitudes_Bibliotecario.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Bibliotecario != null)
                {
                    var_frmSolicitarHL_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                if (var_frmRegistrarInasis_Bibliotecario != null)
                {
                    var_frmRegistrarInasis_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmSolicitarCambioTurno_Bibliotecario != null)
                {
                    var_frmSolicitarCambioTurno_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmRegistrarHE_Bibliotecario != null)
                {
                    var_frmRegistrarHE_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion
                var_frmRespuestasSolicitudes_Bibliotecario.Location = new Point(0, 0);
                var_frmRespuestasSolicitudes_Bibliotecario.Size = new Size(934, 675);

                //lblBienvenido.Visible = false;
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

            if ((var_frmRegistrarInasis_Bibliotecario != null &&
                        var_frmRegistrarInasis_Bibliotecario.Visible == true) ||
                (var_frmSolicitarHL_Bibliotecario != null &&
                        var_frmSolicitarHL_Bibliotecario.Visible == true) ||
                (var_frmSolicitarCambioTurno_Bibliotecario != null &&
                        var_frmSolicitarCambioTurno_Bibliotecario.Visible == true) ||
                (var_frmRespuestasSolicitudes_Bibliotecario != null &&
                        var_frmRespuestasSolicitudes_Bibliotecario.Visible == true) ||
                (var_frmRegistrarHE_Bibliotecario != null &&
                        var_frmRegistrarHE_Bibliotecario.Visible == true))
            {

                this.muestraMensajeCerraroGuardarCambios();

            }
            else
            {

                //seguimos con nuestra programacion
                //aca llamamos al formulario de registrar Horas extras
                if (var_frmVerHorarios_Bibliotecario == null)
                {
                    var_frmVerHorarios_Bibliotecario = new frmVisualizarHorarios(this, TipoPerfil.PerfilBibliotecario);
                    var_frmVerHorarios_Bibliotecario.MdiParent = this;

                    //...add
                    var_frmVerHorarios_Bibliotecario.StartPosition = FormStartPosition.Manual;
                    var_frmVerHorarios_Bibliotecario.Left = 0;
                    var_frmVerHorarios_Bibliotecario.Top = 0;
                    //...


                    var_frmVerHorarios_Bibliotecario.Show();
                }
                else
                {
                    //var_frmRespuestasSolicitudes_Bibliotecario.limpiarComponentes();
                    //var_frmRespuestasSolicitudes_Bibliotecario.estadoComponentes(Estado.Inicial);
                    var_frmVerHorarios_Bibliotecario.Visible = true;
                }

                //....
                if (var_frmSolicitarHL_Bibliotecario != null)
                {
                    var_frmSolicitarHL_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion

                if (var_frmRegistrarInasis_Bibliotecario != null)
                {
                    var_frmRegistrarInasis_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmSolicitarCambioTurno_Bibliotecario != null)
                {
                    var_frmSolicitarCambioTurno_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                if (var_frmRegistrarHE_Bibliotecario != null)
                {
                    var_frmRegistrarHE_Bibliotecario.Visible = false;
                    //todos los demas formularios

                }

                //hoy agregeishion
                var_frmVerHorarios_Bibliotecario.Location = new Point(0, 0);
                var_frmVerHorarios_Bibliotecario.Size = new Size(934, 675);

                //lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            if ((var_frmRegistrarInasis_Bibliotecario != null &&
                        var_frmRegistrarInasis_Bibliotecario.Visible == true) ||
                (var_frmSolicitarHL_Bibliotecario != null &&
                        var_frmSolicitarHL_Bibliotecario.Visible == true) ||
                (var_frmSolicitarCambioTurno_Bibliotecario != null &&
                        var_frmSolicitarCambioTurno_Bibliotecario.Visible == true) ||
                (var_frmRespuestasSolicitudes_Bibliotecario != null &&
                        var_frmRespuestasSolicitudes_Bibliotecario.Visible == true) ||
                (var_frmRegistrarHE_Bibliotecario != null &&
                        var_frmRegistrarHE_Bibliotecario.Visible == true))
            {

                this.muestraMensajeCerraroGuardarCambios();

            }
            else
            {
                frmConfigurar config = new frmConfigurar(this, TipoPerfil.PerfilBibliotecario, var_usuario, var_datosUsuario);

                config.Location = new Point(0, 0);
                config.Size = new Size(934, 675);
                config.MdiParent = this;

                //...add
                config.StartPosition = FormStartPosition.Manual;
                config.Left = 0;
                config.Top = 0;
                //...
                
                config.Show();                                                              
                
                //hoy agregeishion
                //lblBienvenido.Visible = false;
                panelAviso.Visible = false;

                //escondemos el submenu
                hideSubMenu();
            }
        }

        private void btnCapac_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;

            frmRespuestaCapacitaciones  resCapas = new frmRespuestaCapacitaciones(this,
                TipoPerfil.PerfilBibliotecario,var_usuario);
            resCapas.Location = new Point(0, 0);
            resCapas.Size = new Size(934, 675);
            resCapas.MdiParent = this;

            //...add
            resCapas.StartPosition = FormStartPosition.Manual;
            resCapas.Left = 0;
            resCapas.Top = 0;
            //...

            resCapas.Show();
            /*
              var_frmRespuestasSolicitudes_Bibliotecario = new frmRespuestaValidaciones(this, TipoPerfil.PerfilBibliotecario,
                        var_usuario);
                    var_frmRespuestasSolicitudes_Bibliotecario.MdiParent = this;

                    //...add
                    var_frmRespuestasSolicitudes_Bibliotecario.StartPosition = FormStartPosition.Manual;
                    var_frmRespuestasSolicitudes_Bibliotecario.Left = 0;
                    var_frmRespuestasSolicitudes_Bibliotecario.Top = 0;
                    //...
                    
                    var_frmRespuestasSolicitudes_Bibliotecario.Show();
             */

        }

        private void buttonVerOtrosPerfiles_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;
            frmBuscarOtrosPerfiles frmBuscarOtros = new frmBuscarOtrosPerfiles(this, TipoPerfil.PerfilBibliotecario);
            frmBuscarOtros.Location = new Point(0, 0);
            frmBuscarOtros.Size = new Size(934, 675);
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
