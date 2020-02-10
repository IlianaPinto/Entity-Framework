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
    public partial class Form2 : Form
    {
        public int? id;
        Persona oPersona = null;
        public Form2(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if(id != null)
            {
                cargarDatos();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cargarDatos()
        {
            using (EmpresaEntities db = new EmpresaEntities())
            {
                oPersona = db.Persona.Find(id);
                name.Text = oPersona.Nombre;
                lastname.Text = oPersona.Apellido;
                gender.Text = oPersona.Genero;
                phone.Text = oPersona.Telefono.ToString();
                mail.Text = oPersona.Correo;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (EmpresaEntities db = new EmpresaEntities())
            {
                if (id == null)
                {
                    oPersona = new Persona();
                }
                oPersona.Nombre = name.Text;
                oPersona.Apellido = lastname.Text;
                oPersona.Genero = gender.Text;
                oPersona.Correo = mail.Text;
                oPersona.Telefono = Convert.ToInt32(phone.Text);

                if(id == null)
                {
                    db.Persona.Add(oPersona);
                }
                else
                {
                    db.Entry(oPersona).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
