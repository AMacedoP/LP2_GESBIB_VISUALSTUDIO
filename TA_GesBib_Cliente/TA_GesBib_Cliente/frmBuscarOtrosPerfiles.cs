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
    public partial class frmBuscarOtrosPerfiles : Form
    {
        Estado estadoUsuario;
        private ServicioJava.usuario var_usuario;
        private ServicioJava.personalBiblioteca var_datosUsuario;
        private ServicioJava.personalBiblioteca personal;
        private ServicioJava.bibliotecario bibliotecario;
        private ServicioJava.bibliotecario gestor;
        private Form var_perfilPersonal;
        private TipoPerfil var_tipoPerfil = TipoPerfil.PerfilBibliotecario;
        //PARA IMAGEN
        private String ruta = "";

        public frmBuscarOtrosPerfiles()
        {
            InitializeComponent();
            estadoComponentes(Estado.Inicial);
        }

        public frmBuscarOtrosPerfiles(Form formPerfilPersonal, TipoPerfil tipoPerfil)
        {
            InitializeComponent();
            estadoComponentes(Estado.Inicial);
            var_tipoPerfil = tipoPerfil;
            var_perfilPersonal = formPerfilPersonal;
        }

        //Estados
        public void estadoComponentes(Estado estado)
        {
            switch (estado)
            {
                case Estado.Inicial:

                    //Etiquetas
                    //Botones
                    btnBuscar.Enabled = true;
                    //Campos de Texto
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    txtBiblioteca.Enabled = false;
                    txtPuesto.Enabled = false;
                    txtCorreo.Enabled = false;
                    txtCantidadHE.Enabled = false;
                    dtpFecha.Enabled = false;
                    break;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            switch (var_tipoPerfil)
            {
                /*case TipoPerfil.PerfilBibliotecario:
                    this.Visible = false;
                    this.var_perfilBibliotecario.LblBienvenido.Visible = true;
                    this.var_perfilBibliotecario.PanelAviso.Visible = true;
                    break;*/
                case TipoPerfil.PerfilBibliotecario:
                    this.Visible = false;
                    //((frmPerfilBibliotecario)this.var_perfilPersonal).LblBienvenido.Visible = true;
                    ((frmPerfilBibliotecario)this.var_perfilPersonal).PanelAviso.Visible = true;
                    ((frmPerfilBibliotecario)this.var_perfilPersonal).PanelBIPO.Visible = true;
                    break;
                case TipoPerfil.PerfilAuxiliar:
                    this.Visible = false;
                    //((frmPerfilAuxiliar)this.var_perfilPersonal).LblBienvenido.Visible = true;
                    ((frmPerfilAuxiliar)this.var_perfilPersonal).PanelAviso.Visible = true;
                    //((frmPerfilAuxiliar)this.var_perfilPersonal).PanelBIPO.Visible = true;
                    break;
                case TipoPerfil.PerfilPracticante:
                    this.Visible = false;
                    //((frmPerfilPracticante)this.var_perfilPersonal).LblBienvenido.Visible = true;
                    ((frmPerfilPracticante)this.var_perfilPersonal).PanelAviso.Visible = true;
                    //((frmPerfilPracticante)this.var_perfilPersonal).PanelBIPO.Visible = true;
                    break;
                default:
                    break;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //ruta = "";
            frmBuscarPersonalConTodo frmBPCT = new frmBuscarPersonalConTodo();
            if (frmBPCT.ShowDialog() == DialogResult.OK)
            {
                personal = frmBPCT.PersonalSeleccionado;

                
                txtNombre.Text = personal.nombre;
                txtApellido.Text = personal.apellido;
                txtCorreo.Text = personal.email;
                txtCodigo.Text = personal.codigo;
                
                dtpFecha.Value = personal.fecha_ingreso;
                txtCantidadHE.Text = personal.totalHorasExtra.ToString();
                txtBiblioteca.Text = personal.biblioteca.nombre;
                if (personal.foto != null)
                {
                    pbPortada.Visible = true;
                    MemoryStream ms1 = new MemoryStream(personal.foto);
                    pbPortada.Image = new Bitmap(ms1);
                }
                else
                {
                    pbPortada.Visible = false;
                    MessageBox.Show("No hay foto encontrada");
                }
                pbPortada.Visible = true;
            }
            estadoComponentes(Estado.Inicial);
        }
    }
}
