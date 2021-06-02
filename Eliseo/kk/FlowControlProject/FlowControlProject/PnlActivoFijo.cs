using FlowControlProject.poco;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FlowControlProject
{
    public partial class PnlActivoFijo : Form
    {
        private ActivoFijo[] activosFijo;
        //List<ActivoFijo> activos;
        public PnlActivoFijo()
        {
            InitializeComponent();
            loadTipoActivo();
            //activos = new List<ActivoFijo>();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            ReadActivoFijo();

            
        }

        private void ReadActivoFijo()
        {
            try
            {
                string codigo = txtCodigo.Text;
                string nombre = txtNombre.Text;
                ValidateActivoFijo(codigo, nombre, out decimal valor, out decimal valorSalv);
                int index = cmbTipo.SelectedIndex;
                TipoActivo tipoActivo = (TipoActivo)Enum.GetValues(typeof(TipoActivo)).GetValue(index);
                //TipoActivo tipo = index == 0 ? TipoActivo.Edificio :
                //                  index == 1 ? TipoActivo.Vehiculo :
                //                  index == 2 ? TipoActivo.Mobiliario :
                //                  index == 3 ? TipoActivo.Maquinaria :
                //                  TipoActivo.Equipo_Computo;

                //decimal.TryParse(txtValor.Text, out decimal valor);
                //decimal.TryParse(txtValorSalv.Text, out decimal valorsalv);


                ActivoFijo af = new ActivoFijo()
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Tipo = tipoActivo,
                    ValorActivo = valor,
                    ValorSalvamento = valorsalv,


                };

                activosFijoModel.Add(af);
                MessageBox.Show("Activo agregado correctamente :D");
                dgvActivos.DataSource = activosFijoModel.GetAll();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje de Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void loadTipoActivo()
        {
            cmbTipo.Items.AddRange(Enum.GetValues(typeof(TipoActivo)).Cast<object>().ToArray());
            cmbTipo.SelectedIndex = 0;
        }

        private void ValidateActivoFijo(string codigo, string nombre, out decimal valor, out decimal valorSalv)
        {
            if (string.IsNullOrWhiteSpace(codigo))
            {
                throw new ArgumentException("El código es requerido");
            }
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new ArgumentException("El nombre es requerido");
            }
            if(!decimal.TryParse(txtValor.Text, out decimal v))
            {
                throw new ArgumentException($"El valor \" {txtValor.Text} \"es invalido");
            }
            if(!decimal.TryParse(txtValorSalv.Text, out decimal vs))
            {
                throw new ArgumentException($"Ek valor \"{txtValorSalv.Text}\"es invalido");
            }
            valorSalv = vs;
        }
        private void txtCodigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                txtCodigo.BackColor = Color.Pink;
                e.Cancel = true;
            }
            else
            {
                txtCodigo.BackColor = Color.White;
            }
        }

        private void PnlActivoFijo_Load(object sender, EventArgs e)
        {
          
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            txtCodigo.Text  = "";
            txtNombre.Text = "";
            txtValor.Text = "";
            txtValorSalv.Text = "";
            cmbTipo.SelectedIndex = 0;
            cmbMetodo.SelectedIndex = 0;
        }

        
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(dgvActivos.Rows.Count == 0)
            {
                return;
            }
            int index = dgvActivos.CurrentCell.RowIndex;
            activosFijoModel.Remove(index);
            dgvActivos.DataSource = activosFijoModel.GetAll();
        }
    }
}
