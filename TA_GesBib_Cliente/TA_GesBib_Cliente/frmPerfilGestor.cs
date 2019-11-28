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
    public partial class frmPerfilGestor : Form
    {

        /*by tys */

        private frmDistribuirPersonalSemana var_formDistSemana;
        private frmDistribucionSemestre var_formDistSemestre;
        private frmAsignarTurnos var_formAsignarTurnos;
        private frmAdminPerfilesExp var_formPerfilExp;
        private frmCapacitaciones var_formCapa;
        private frmValidaciones formValidaciones;
        private frmAvisos formAvisos;
        private ServicioJava.personalBiblioteca var_datosUsuario;


        public Panel PanelBIPO { get => panelBIPO; set => panelBIPO = value; }

        /*by tys */

        private frmLogin var_formLogin;
        private ServicioJava.usuario var_usuario;

        //public Panel PanelAviso { get => panelAviso; set => panelAviso = value; }
        //public Label LblBienvenido { get => lblBienvenido; set => lblBienvenido = value; }



        public frmPerfilGestor()
        {
            InitializeComponent();
        }

        public frmPerfilGestor(frmLogin formLogin, ServicioJava.usuario _user, ServicioJava.personalBiblioteca var_datosUsuario) //con paramtero this 
        {
            var_formLogin = formLogin;
            var_usuario = _user;
            
            InitializeComponent();
            lblNombreUsuario.Text = var_usuario.nombre;
            customizeDesign(); // <---- para los PANELES
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.var_formLogin.Visible = true;
        }

        private void btnAsignarTurnos_Click(object sender, EventArgs e)
        {
            //lblBienvenido.Visible = false;
            //panelAviso.Visible = false;


            //cambiar el color del boton "sombreado"
            this.btnAsignarTurnos.BackColor = Color.PowderBlue;
            //..y poner los otros botones a color normal 
            this.btnValidaciones.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAdmPerfilesExp.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAvisos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnCapacitacion.BackColor = Color.FromArgb(58, 175, 169);
            this.btnDistribucionPersonal.BackColor = Color.FromArgb(58, 175, 169);


            panelBIPO.Visible = false;
            //poner los demas forms no visibles (si existen)
            if (var_formCapa != null) var_formCapa.Visible = false;
            if (var_formDistSemana != null) var_formDistSemana.Visible = false;
            if (var_formDistSemestre != null) var_formDistSemestre.Visible = false;
            if (var_formPerfilExp != null) var_formPerfilExp.Visible = false;

            if (var_formAsignarTurnos == null)
            {
                var_formAsignarTurnos = new frmAsignarTurnos(this);
                var_formAsignarTurnos.MdiParent = this;
                var_formAsignarTurnos.Show();
                var_formAsignarTurnos.Location = new Point(0, 0);
            }
            else
            {
                var_formAsignarTurnos.StartPosition = FormStartPosition.Manual;
                var_formAsignarTurnos.Left = 0;
                var_formAsignarTurnos.Top = 0;
                var_formAsignarTurnos.Visible = true;
            }
                     
        }

        //...................PANELES v2 ................................

        private void customizeDesign()
        {
            panelDistribucion.Visible = false;
        }

        private void hideSubMenu()
        {
            if (panelDistribucion.Visible == true)
                panelDistribucion.Visible = false;
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


        private void btnAdmPerfilesExp_Click(object sender, EventArgs e)
        {
            //lblBienvenido.Visible = false;
            //panelAviso.Visible = false;

            //byTyS........................................................................

            //cambiar el color del boton "sombreado"
            this.btnAdmPerfilesExp.BackColor = Color.PowderBlue;
            //..y poner los otros botones a color normal 
            this.btnValidaciones.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAsignarTurnos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAvisos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnCapacitacion.BackColor = Color.FromArgb(58, 175, 169);
            this.btnDistribucionPersonal.BackColor = Color.FromArgb(58, 175, 169);

            panelBIPO.Visible = false;
            //poner los demas forms no visibles (si existen)
            if (var_formAsignarTurnos != null) var_formAsignarTurnos.Visible = false;
            if (var_formDistSemana != null) var_formDistSemana.Visible = false;
            if (var_formDistSemestre != null) var_formDistSemestre.Visible = false;
            if (var_formCapa != null) var_formCapa.Visible = false;

            if (var_formPerfilExp == null)
            {
                var_formPerfilExp = new frmAdminPerfilesExp(this);
                var_formPerfilExp.MdiParent = this;
                var_formPerfilExp.Show();
                var_formPerfilExp.Location = new Point(0, 0);
            }
            else
            {
                var_formPerfilExp.StartPosition = FormStartPosition.Manual;
                var_formPerfilExp.Left = 0;
                var_formPerfilExp.Top = 0;
                var_formPerfilExp.Visible = true;
            }
                
 
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            //panelBIPO.Visible = true;
        }

        private void btnCapacitacion_Click(object sender, EventArgs e)
        {

            //cambiar el color del boton "sombreado"
            this.btnCapacitacion.BackColor = Color.PowderBlue;
            //..y poner los otros botones a color normal 
            this.btnValidaciones.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAsignarTurnos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAdmPerfilesExp.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAvisos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnDistribucionPersonal.BackColor = Color.FromArgb(58, 175, 169);


            panelBIPO.Visible = false;            
            
            /*poner los demas forms no visibles (si existen)*/
            if (var_formAsignarTurnos != null) var_formAsignarTurnos.Visible = false;
            if (var_formDistSemana != null) var_formDistSemana.Visible = false;
            if (var_formDistSemestre != null) var_formDistSemestre.Visible = false;
            if (var_formPerfilExp != null) var_formPerfilExp.Visible = false;

            if (var_formCapa == null)
            {
                var_formCapa =  new frmCapacitaciones(this);
                var_formCapa.MdiParent = this;
                var_formCapa.Show();
                var_formCapa.Location = new Point(0, 0);
            }
            else
            {
                var_formCapa.StartPosition = FormStartPosition.Manual;
                var_formCapa.Left = 0;
                var_formCapa.Top = 0;
                var_formCapa.Visible = true;
                System.Console.WriteLine("paso el visible");
            }

            
        }

        private void btnDistribucionPersonal_Click(object sender, EventArgs e)
        {

            //cambiar el color del boton "sombreado"
            this.btnDistribucionPersonal.BackColor = Color.PowderBlue;
            //..y poner los otros botones a color normal 
            this.btnValidaciones.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAsignarTurnos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAdmPerfilesExp.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAvisos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnCapacitacion.BackColor = Color.FromArgb(58, 175, 169);


            showSubMenu(panelDistribucion);
        }

        private void btnSemestre_Click(object sender, EventArgs e)
        {                      
            panelBIPO.Visible = false;
            if (var_formAsignarTurnos != null) var_formAsignarTurnos.Visible = false;
            if (var_formDistSemana != null) var_formDistSemana.Visible = false;
            if (var_formCapa != null) var_formCapa.Visible = false;
            if (var_formPerfilExp != null) var_formPerfilExp.Visible = false;

            if (var_formDistSemestre == null)
            {
                var_formDistSemestre = new frmDistribucionSemestre(this,var_usuario);
                var_formDistSemestre.MdiParent = this;
                var_formDistSemestre.Show();
                var_formDistSemestre.Location = new Point(0, 0);
                var_formDistSemestre.Size = new Size(934, 675);
            }
            else
            {
                var_formDistSemestre.StartPosition = FormStartPosition.Manual;
                var_formDistSemestre.Left = 0;
                var_formDistSemestre.Top = 0;
                var_formDistSemestre.Visible = true;
            }                

            hideSubMenu();
        }

        private void btnSemana_Click(object sender, EventArgs e)
        {
            var_formDistSemana = new frmDistribuirPersonalSemana(var_formDistSemana,var_usuario);
            var_formDistSemana.MdiParent = this;
            //formDistSemana.Location = new Point(0, 0);
            //formDistSemana.Size = new Size(934, 675);
            var_formDistSemana.StartPosition = FormStartPosition.Manual;
            var_formDistSemana.Left = 0;
            var_formDistSemana.Top = 0;
            var_formDistSemana.Show();
            hideSubMenu();
            
            panelBIPO.Visible = false;
            /*poner los demas forms no visibles (si existen)*/
            if (var_formAsignarTurnos != null) var_formAsignarTurnos.Visible = false;
            if (var_formCapa != null) var_formCapa.Visible = false;
            if (var_formDistSemestre != null) var_formDistSemestre.Visible = false;
            if (var_formPerfilExp != null) var_formPerfilExp.Visible = false;

            if (var_formDistSemana == null)
            {              
                var_formDistSemana = new frmDistribuirPersonalSemana(this,var_usuario);
                var_formDistSemana.MdiParent = this;
                var_formDistSemana.StartPosition = FormStartPosition.Manual;
                var_formDistSemana.Left = 0;
                var_formDistSemana.Top = 0;
                var_formDistSemana.Show();            
            }
            else
            {
                var_formDistSemana.StartPosition = FormStartPosition.Manual;
                var_formDistSemana.Left = 0;
                var_formDistSemana.Top = 0;
                var_formDistSemana.Visible = true;
            }            
                       
                        
            /*var_formDistSemana = new frmDistribuirPersonalSemana(var_usuario);           
            var_formDistSemana.MdiParent = this;
            var_formDistSemana.StartPosition = FormStartPosition.Manual;
            var_formDistSemana.Left = 0;
            var_formDistSemana.Top = 0;
            var_formDistSemana.Show();*/

            hideSubMenu();                     

        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            //cambiar el color del boton "sombreado"
            this.btnValidaciones.BackColor = Color.PowderBlue;
            //..y poner los otros botones a color normal 
            this.btnAsignarTurnos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAdmPerfilesExp.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAvisos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnCapacitacion.BackColor = Color.FromArgb(58, 175, 169);
            this.btnDistribucionPersonal.BackColor = Color.FromArgb(58, 175, 169);
           


            panelBIPO.Visible = false;
            /*poner los demas forms no visibles (si existen)*/
            if (var_formAsignarTurnos != null) var_formAsignarTurnos.Visible = false;
            if (var_formCapa != null) var_formCapa.Visible = false;
            if (var_formDistSemestre != null) var_formDistSemestre.Visible = false;
            if (var_formPerfilExp != null) var_formPerfilExp.Visible = false;

            if (formValidaciones == null)
            {
                formValidaciones = new frmValidaciones(this, var_usuario);
                formValidaciones.MdiParent = this;
                formValidaciones.StartPosition = FormStartPosition.Manual;
                formValidaciones.Left = 0;
                formValidaciones.Top = 0;
                formValidaciones.Show();
            }
            else
            {
                formValidaciones.StartPosition = FormStartPosition.Manual;
                formValidaciones.Left = 0;
                formValidaciones.Top = 0;
                formValidaciones.Visible = true;
            }

        }

        private void btnAvisos_Click(object sender, EventArgs e)
        {
            //cambiar el color del boton "sombreado"
            this.btnAvisos.BackColor = Color.PowderBlue;
            //..y poner los otros botones a color normal 
            this.btnValidaciones.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAsignarTurnos.BackColor = Color.FromArgb(58, 175, 169);
            this.btnAdmPerfilesExp.BackColor = Color.FromArgb(58, 175, 169);
            this.btnCapacitacion.BackColor = Color.FromArgb(58, 175, 169);
            this.btnDistribucionPersonal.BackColor = Color.FromArgb(58, 175, 169);


            panelBIPO.Visible = false;
            /*poner los demas forms no visibles (si existen)*/
            if (var_formAsignarTurnos != null) var_formAsignarTurnos.Visible = false;
            if (var_formCapa != null) var_formCapa.Visible = false;
            if (var_formDistSemestre != null) var_formDistSemestre.Visible = false;
            if (var_formPerfilExp != null) var_formPerfilExp.Visible = false;

            if (formAvisos == null)
            {
                formAvisos = new frmAvisos(this, var_usuario);
                formAvisos.MdiParent = this;
                formAvisos.StartPosition = FormStartPosition.Manual;
                formAvisos.Left = 0;
                formAvisos.Top = 0;
                formAvisos.Show();
            }
            else
            {
                formAvisos.StartPosition = FormStartPosition.Manual;
                formAvisos.Left = 0;
                formAvisos.Top = 0;
                formAvisos.Visible = true;
            }





        }

        private void btnAsignarTurnos_BackColorChanged(object sender, EventArgs e)
        {

        }

        private void buttonVerOtrosPerfiles_Click(object sender, EventArgs e)
        {
            panelBIPO.Visible = false;
            frmBuscarOtrosPerfiles frmBuscarOtros = new frmBuscarOtrosPerfiles(this, TipoPerfil.PerfilGestor);
            frmBuscarOtros.MdiParent = this;

            //...add
            frmBuscarOtros.StartPosition = FormStartPosition.Manual;
            frmBuscarOtros.Left = 0;
            frmBuscarOtros.Top = 0;
            //...

            frmBuscarOtros.Show();
        }

        private void lblTipoPerfil_Click(object sender, EventArgs e)
        {

        }
    }
}
