﻿using System;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            //abrir diferentes usuarios
            if (placeHolderUsuario.Text=="ariana")
            {
                frmPerfilAdministrador formPAdmin = new frmPerfilAdministrador(this);
                formPAdmin.Visible = true;
                this.Visible = true;
            }
            else if (placeHolderUsuario.Text == "practicante")
            {
                frmPerfilPracticante frmPracticante = new frmPerfilPracticante(this);
                frmPracticante.Visible = true;
                this.Visible = true;
            }
            else if (placeHolderUsuario.Text == "auxiliar")
            {
                frmPerfilAuxiliar frmAuxiliar = new frmPerfilAuxiliar(this);
                frmAuxiliar.Visible = true;
                this.Visible = true;
            }
            else if (placeHolderUsuario.Text == "gaston")
            {
                frmPerfilGestor frmGestor = new frmPerfilGestor(this);
                frmGestor.Visible = true;
                this.Visible = true;
            }
            else
            {
                //BIBLIOTECARIO
                frmPerfilBibliotecario formBibliotecario = new frmPerfilBibliotecario(this);
                formBibliotecario.Visible = true;
                this.Visible = false;
            }
  

        }

        private void placeHolderUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
