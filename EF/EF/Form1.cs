using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listar();
        }

        #region HELPER
        private void Listar()
        {
            using (EmpresaEntities db = new EmpresaEntities())
            {
                var lst = from d in db.Persona select d;
                tabla.DataSource = lst.ToList();
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 agregar = new Form2();
            agregar.ShowDialog();
            Listar();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int? id;
            try
            {
                id = int.Parse(tabla.Rows[tabla.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                id = null;
            }
            if(id != null)
            {
                Form2 form = new Form2(id);
                form.ShowDialog();
                Listar();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int? id;
            try
            {
                id = int.Parse(tabla.Rows[tabla.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                id = null;
            }
            using (EmpresaEntities db = new EmpresaEntities())
            {
                Persona p = db.Persona.Find(id);
                db.Persona.Remove(p);
                db.SaveChanges();

            }
            Listar();

        }
    }
}
