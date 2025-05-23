using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolarCore.Bussines;
using NLog;
using ControlEscolarCore.Utilities;

namespace ControlEscolar.View
{
    public partial class Login : Form
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.View.Login");

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            _logger.Info("Usuario accedio ha inicar sesion");
            _logger.Warn("Espacio en disco bajo");

            try
            {
                //Aqui provocamos una primera excepcion
                try
                {
                    int divisor = 0;
                    int resultado = 10 / divisor; //Esto generara un DivideByZeroExcepcion
                }
                catch (DivideByZeroException ex)
                {
                    //Capturamos la primera excepcion y la envolveos en otra
                    throw new ApplicationException("Error al realizar el cálculo en la aplicación", ex);
                }
            }
            catch (Exception ex)
            {
                //Aqui puedes manejar la excepcion que contiene l inner expection
                _logger.Error(ex, "Se produlo un error en la operación");

                //O registra especificamente usando la inner exception
                if (ex.InnerException != null)
                {
                    _logger.Fatal(ex, $"Error crítico con detalle interno: {ex.InnerException.Message}");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El campo de usuario no puede estar vacio.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("El campo de contraseña no puede estar vacio.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if(!UsuarioNegocio.EsFormatoValido(txtUsuario.Text))
            {
                MessageBox.Show("El nombre del usuario no tiene el formato correcto", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // MessageBox.Show("Listo para iniciar sesion", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Estamos listos para inicar sesion 
            //this.Hide();
            //MDI_Cotrol_escolar mdi = new MDI_Cotrol_escolar();
            //mdi.Show();

           this.DialogResult = DialogResult.OK;
           this.Close();
            
        }
    }
}
