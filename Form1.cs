using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EjemploCRUDEntityframework.Models;

namespace EjemploCRUDEntityframework
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CargarGrid();
         
        }

        private void CargarGrid() {

            using (TestEntities dbContext = new TestEntities())
            {
                var list = from d in dbContext.TablaPersonas select d;
                dataGridView1.DataSource = list.ToList();
            }

        }

        private void AgregarNuevo()
        {

            using (TestEntities dbContext = new TestEntities())
            {
                TablaPersonas t = new TablaPersonas();
                t.Nombre = "Nuevo Nombre desde EF " + DateTime.Now.ToString();
                dbContext.TablaPersonas.Add(t);
                dbContext.SaveChanges();
                
            }

        }

        private void GuardarModificacion() {

            int? idRow = GetId();
            using (TestEntities dbContext = new TestEntities())
            {
                if (idRow != null) {

                    TablaPersonas t = new TablaPersonas();
                    t.Nombre = "Dato Modificado..";
                    dbContext.Entry(t).State = System.Data.Entity.EntityState.Added;
                    
                    dbContext.SaveChanges();
                    CargarGrid();
                }
            }
        }


        private void EliminarRow()
        {

            int? id = GetId();
            if (id != null)
            {
                using (TestEntities dbContext = new TestEntities())
                {
                    TablaPersonas t = dbContext.TablaPersonas.Find(id);
                    dbContext.TablaPersonas.Remove(t);

                    dbContext.SaveChanges();
                }

                CargarGrid();

            }
        }

        private int? GetId()
        {
            try
            {
                return int.Parse(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void button_agregar_Click(object sender, EventArgs e)
        {
            AgregarNuevo();
            CargarGrid();
        }

        private void button_GuardarEdicion_Click(object sender, EventArgs e)
        {
            GuardarModificacion();
        }

        private void button_Eliminar_Click(object sender, EventArgs e)
        {
            EliminarRow();
        }
    }
}
