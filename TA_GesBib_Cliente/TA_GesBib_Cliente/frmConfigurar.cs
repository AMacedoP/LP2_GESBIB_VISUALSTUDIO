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
    public partial class frmConfigurar : Form
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

        public frmConfigurar()
        {
            InitializeComponent();

        }

        //Estados
        public void estadoComponentes(Estado estado)
        {
            switch (estado)
            {
                case Estado.Inicial:

                    //Etiquetas
                    //Botones
                    //btnBuscar.Enabled = true;
                    btnModificar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
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
                case Estado.Buscar:
                    //Etiquetas
                    //Botones
                    //btnBuscar.Enabled = false;
                    btnModificar.Enabled = true;
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = true;
                    break;
                case Estado.Modificar:
                    //Etiquetas
                    //Botones
                    //btnBuscar.Enabled = true;
                    btnModificar.Enabled =false;
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    //Campos de Texto
                    txtCodigo.Enabled = false;
                    txtNombre.Enabled = true;
                    txtApellido.Enabled = true;
                    txtBiblioteca.Enabled = false;
                    txtPuesto.Enabled = false;
                    txtCorreo.Enabled = true;
                    txtCantidadHE.Enabled = false;
                    dtpFecha.Enabled = false;
                    break;
            }
        }


        public frmConfigurar(Form formPerfilPersonal, TipoPerfil tipoPerfil, ServicioJava.usuario _user,ServicioJava.personalBiblioteca _datosUsuario)
        {
            var_usuario = _user;
            var_datosUsuario=_datosUsuario;
            var_perfilPersonal = formPerfilPersonal;
            var_tipoPerfil = tipoPerfil;
            
            //Para mostrar los datos

            InitializeComponent();
            txtNombre.Text = var_usuario.nombre;
            txtApellido.Text = var_usuario.apellido;
            txtCorreo.Text = var_usuario.email;
            txtCodigo.Text = var_datosUsuario.codigo;
            dtpFecha.Value = var_datosUsuario.fecha_ingreso;
            if (var_datosUsuario.foto != null)
            {
                MemoryStream ms1 = new MemoryStream(var_datosUsuario.foto);
                pbPortada.Image = new Bitmap(ms1);
            }
            switch (var_tipoPerfil)
            {
                case TipoPerfil.PerfilBibliotecario:
                    txtPuesto.Text = "Bibliotecario";
                    break;
                case TipoPerfil.PerfilGestor:
                    txtPuesto.Text = "Gestor";
                    break;
                case TipoPerfil.PerfilPracticante:
                    txtPuesto.Text = "Practicante";
                    break;
                case TipoPerfil.PerfilAuxiliar:
                    txtPuesto.Text = "Auxiliar";
                    break;
                default:
                    break;
            }
            txtCantidadHE.Text = var_datosUsuario.totalHorasExtra.ToString();
            txtBiblioteca.Text = var_datosUsuario.biblioteca.nombre;
            estadoComponentes(Estado.Inicial);
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            switch (var_tipoPerfil)
            {
                case TipoPerfil.PerfilBibliotecario:
                    ServicioJava.bibliotecario bib = new ServicioJava.bibliotecario();
                    //para imagen
                    FileStream fs = new FileStream(ruta, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    bib.foto = br.ReadBytes((int)fs.Length);
                    Program.DBController.actualizarDatosUsuario(var_usuario.id, txtNombre.Text, txtApellido.Text, txtCorreo.Text,bib.foto);
                    MessageBox.Show("Éxito al modificar sus datos");
                    break;
                case TipoPerfil.PerfilAuxiliar:
                    
                    break;
                case TipoPerfil.PerfilPracticante:
                    
                    break;
                case TipoPerfil.PerfilGestor:
                    ServicioJava.gestor ges = new ServicioJava.gestor();
                    ges.nombre = txtNombre.Text;
                    ges.apellido = txtApellido.Text;
                    ges.email = txtCorreo.Text;
                    ges.id = var_usuario.id;
                    Program.DBController.actualizarGestor(ges);
                    break;
                default:
                    break;
            }
            estadoComponentes(Estado.Inicial);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            estadoComponentes(Estado.Inicial);
            txtNombre.Text = var_usuario.nombre;
            txtApellido.Text = var_usuario.apellido;
            txtCorreo.Text = var_usuario.email;
            txtCodigo.Text = var_datosUsuario.codigo;
            dtpFecha.Value = var_datosUsuario.fecha_ingreso;
            switch (var_tipoPerfil)
            {
                case TipoPerfil.PerfilBibliotecario:
                    txtPuesto.Text = "Bibliotecario";
                    break;
                case TipoPerfil.PerfilGestor:
                    txtPuesto.Text = "Gestor";
                    break;
                case TipoPerfil.PerfilPracticante:
                    txtPuesto.Text = "Practicante";
                    break;
                case TipoPerfil.PerfilAuxiliar:
                    txtPuesto.Text = "Auxiliar";
                    break;
                default:
                    break;
            }
            txtCantidadHE.Text = var_datosUsuario.totalHorasExtra.ToString();
            txtBiblioteca.Text = var_datosUsuario.biblioteca.nombre;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            estadoUsuario = Estado.Modificar;
            estadoComponentes(Estado.Modificar);
            //ruta = "";

        }

        private void btnCambiarClave_Click(object sender, EventArgs e)
        {
            frmCambiarClaveConfig formCC = new frmCambiarClaveConfig(var_usuario);
            formCC.Show();
        }

        private void btnSubirImagen_Click(object sender, EventArgs e)
        {
            try
            {
                if (ofdPortada.ShowDialog() == DialogResult.OK)
                {
                    ruta = ofdPortada.FileName;
                    pbPortada.Image = Image.FromFile(ruta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }
            /*try
            {
                if (ofdPortada.ShowDialog() == DialogResult.OK)
                {
                    ruta = ofdPortada.FileName;
                    pbPortada.Image = Image.FromFile(ruta);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen válido");
            }*/
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
                //var_tipoPerfil=Program.DBController.Perfil
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
                estadoComponentes(Estado.Buscar);
            }
        }

        private void frmConfigurar_Load(object sender, EventArgs e)
        {

        }
    }
}
