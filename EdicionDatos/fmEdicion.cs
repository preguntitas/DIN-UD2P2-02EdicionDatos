﻿using elFormulario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdicionDatos
{
    public partial class fmEdicion : Form
    {
        fmIntroDatos VentanaIntroduccion = new fmIntroDatos(); //Definición global

        public fmEdicion()
        {
            InitializeComponent();
        }

        private void btCambiar_Click(object sender, EventArgs e)
        {
            Single total, formatea; //Variables para cálculos
            try
            {
                if (Convert.ToSingle(tbDolares.Text) > 0)
                { // Convertimos de dólares a Euros
                    formatea = Convert.ToSingle(tbDolares.Text);
                    total = Convert.ToSingle(tbDolares.Text) *
                    Convert.ToSingle(tbCoEuro.Text);
                    // Formateo numérico
                    tbEuros.Text = total.ToString("#,###,##0.00");
                    tbDolares.Text = formatea.ToString("#,###,##0.00");
                }
                else
                { // Convertimos de Euros a Dólares
                    formatea = Convert.ToSingle(tbEuros.Text);
                    total = Convert.ToSingle(tbEuros.Text) *
                    Convert.ToSingle(tbCoDolar.Text);
                    tbDolares.Text = total.ToString("#,###,##0.00");
                    tbEuros.Text = formatea.ToString("#,###,##0.00");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }

        }

        private void tbEuros_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btCambiar.PerformClick();
            }
            switch (e.KeyChar)
            {
                case (char)8:
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                case '0':
                case ',': break;
                default:
                    e.KeyChar = (char)0; //anulamos la pulsación
                    break;
            }
        }

        private void tbEuros_TextChanged(object sender, EventArgs e)
        {
            btCambiar.Enabled = true;
        }

        private void tbEuros_Click(object sender, EventArgs e)
        {
            tbDolares.Text = "0"; // Iniciamos para nuevo cálculo
            tbEuros.Text = "0";
            TextBox mitextbox = (TextBox)sender; // Seleccionamos
            mitextbox.SelectAll(); // para que al teclear se borre todo
        }

        private void btIntroDatos_Click(object sender, EventArgs e)
        {
            VentanaIntroduccion.tbNombreMostrar = tbNombrePrincipal;
            tbNombrePrincipal.Text = "";
            if (VentanaIntroduccion.ShowDialog() == DialogResult.OK)
            {
                //Los nombres de los controles label: laNombre,laDirección, etc. son los indicados con una X en la Interface.
            //Recordar poner propiedad modifiers=public en los TextBox del formulario secundario precedidos aquí por VentanaIntroduccion
            laNombre.Text = VentanaIntroduccion.tbNombreSecundario.Text;
                laDireccion.Text = VentanaIntroduccion.tbDireccion.Text;
                laLocalidad.Text = VentanaIntroduccion.tbLocalidad.Text;
                laTelefono.Text = VentanaIntroduccion.tbTelefono.Text;
                laEmail.Text = VentanaIntroduccion.tbEmail.Text;
                laCodigoPostal.Text = VentanaIntroduccion.tbCodigopos.Text;
                laCIFNIF.Text = VentanaIntroduccion.tbDNICIF.Text;
            }
        }

        private void btAcercade_Click(object sender, EventArgs e)
        {
            fmAcercade VentanaAcercade;
            VentanaAcercade = new fmAcercade();
            VentanaAcercade.ShowDialog(); // la queremos modal, ya que queremos tomar el control de la aplicacion.
            VentanaAcercade.Dispose(); // ya no necesitamos el objeto, así que lo destruimos.
        }
    }
}
