using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace registroMongoDB
{
    public partial class Form1 : Form
    {
        //private Usuario usuario = new Usuario();
        public Usuario usuario = new Usuario();

        //public Usuario User = new Usuario();

        //private int edit_index = -1;
        public int edit_index = -1;

        //private MongoHelper mongo;
        public MongoHelper mongo;
        //private Usuario datosUsr;
        public Usuario datosUsr;

        Boolean boleanoGuardar = false;
        Boolean boleanoContraseña = false;
        public Boolean unNumero = false;
        public Boolean unaletra = false;
        //Boolean unaLetra = false;
        public Boolean longitud = false;
        public int numero;
        public char letra;
        public string cadenaContraseña;
       
        public Form1(MongoHelper mongo) //Form1
        {
            this.mongo = mongo;
            InitializeComponent();
            actualizarGrid();
        }
       
        /*public usuarios(MongoHelper mongo, string Nombre)//, Usuario datosUsr)
        {
            InitializeComponent();
            this.mongo = mongo;
            actualizarGrid();
            label14.Text = Nombre;
        }*/
        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e) //nuevo boton
        {
            edit_index = -1;
            limpiar();
            actualizarGrid();
            Console.WriteLine("soy un perro mensaje");
        }

        private async void button2_Click(object sender, EventArgs e) //boton editar
        {
            try
            {
                var filter = Builders<Usuario>.Filter.Eq("_id", dvg_capturarUsuario.
                                SelectedCells[0].Value);
                var result = await mongo.coleccionUsuario.Find(filter).ToListAsync();
                edit_index = 1;

                usuario = result[0];
                textBox1Nombre.Text = usuario.Nombre;
                textBox2Paterno.Text = usuario.ApellidoP;
                textBox3Materno.Text = usuario.ApellidoM;
                textBox4Direccion.Text = usuario.Direccion;
                textBox5Calle.Text = usuario.Calle;
                textBox6Colonia.Text = usuario.Colonia;
                textBox7CodigoP.Text = usuario.CodigoP;
                textBox8Cel.Text = usuario.Telefono;
                textBox9Email.Text = usuario.Email;
                textBox10Face.Text = usuario.FaceBook;
                textBox11Contraseña.Text = usuario.Contraseña;

            }
            catch
            {
                MessageBox.Show("revisa tu coneccion", "sin internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private async void actualizarGrid()
        {
            Console.WriteLine("soy la funcion de actualizar");
            try
            {
                dvg_capturarUsuario.DataSource = null;
                dvg_capturarUsuario.DataSource = await mongo.coleccionUsuario.Find(new BsonDocument()).ToListAsync();
                dvg_capturarUsuario.ClearSelection();
                Console.WriteLine(mongo.coleccionUsuario);
            }
            catch
            {

            }
        }
        private void limpiar()
        {
            textBox1Nombre.Text = "";
            textBox2Paterno.Text = "";
            textBox3Materno.Text = "";
            textBox4Direccion.Text = "";
            textBox5Calle.Text = "";
            textBox6Colonia.Text = "";
            textBox7CodigoP.Text = "";
            textBox8Cel.Text = "";
            textBox9Email.Text = "";
            textBox10Face.Text = "";
            textBox11Contraseña.Text = "";
            /*mongodb+srv://<username>:<password>@prueba-skw0n.gcp.mongodb.net/test?retryWrites=true  coneccion a mongo (quiza no sirva es de node)*/
            // mongodb://<username>:<password>@prueba-shard-00-00-skw0n.gcp.mongodb.net:27017,prueba-shard-00-01-skw0n.gcp.mongodb.net:27017,prueba-shard-00-02-skw0n.gcp.mongodb.net:27017/test?ssl=true&replicaSet=prueba-shard-0&authSource=admin&retryWrites=true
        }

        private async void button3_Click(object sender, EventArgs e) //boton guardar
        {
            try
            {


                Usuario User = new Usuario();



                User.Nombre = textBox1Nombre.Text;
                User.ApellidoP = textBox2Paterno.Text;
                User.ApellidoM = textBox3Materno.Text;
                User.Direccion = textBox4Direccion.Text;
                User.Calle = textBox5Calle.Text;
                User.Colonia = textBox6Colonia.Text;
                User.CodigoP = textBox7CodigoP.Text;
                User.Telefono = textBox8Cel.Text;
                User.Email = textBox9Email.Text;
                User.FaceBook = textBox10Face.Text;
                User.Contraseña = textBox11Contraseña.Text;
                cadenaContraseña = textBox11Contraseña.Text;
                Console.WriteLine(User);
                if (textBox1Nombre.Text != "" && textBox2Paterno.Text != "" &&
                        textBox3Materno.Text != "" && textBox4Direccion.Text != "" && textBox5Calle.Text != ""
                        && textBox6Colonia.Text != "" && textBox7CodigoP.Text != "" && textBox8Cel.Text != ""
                        && textBox9Email.Text != "" && textBox10Face.Text != "" && textBox11Contraseña.Text != "")
                {
                    boleanoGuardar = true;
                    if (cadenaContraseña.Length > 5)
                    {
                        for (int i = 0, numero = 0; i <= cadenaContraseña.Length; i++)
                        {

                            try
                            {
                                numero = Int32.Parse(cadenaContraseña[i].ToString());
                                boleanoContraseña = true;
                            }
                            catch
                            {
                                unaletra = true;
                                //boleanoContraseña = false;
                            }
                        }


                    }
                    else
                    {
                        boleanoContraseña = false;
                        MessageBox.Show("Contraseña invalidad", "la contraseña debe ser mayor de 5 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    boleanoGuardar = false;
                    MessageBox.Show("Ningun Campo Debe Estar Vacio", "Todos Los Campos Debe Estar Llenos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }




                if (boleanoGuardar == true && boleanoContraseña == true)
                {



                    if (edit_index != -1)
                    {
                        User.Id = usuario.Id;
                        var filtro = Builders<Usuario>.Filter.Eq("_id", User.Id);
                        var update = Builders<Usuario>.Update.Set("Nombre", User.Nombre).
                                                       Set("Apellido Paterno", User.ApellidoP).
                                                       Set("ApellidoM", User.ApellidoM).
                                                       Set("Dirección", User.Direccion).
                                                       Set("Calle", User.Calle).
                                                       Set("Colonia", User.Colonia).
                                                       Set("Codigo Postal", User.CodigoP).
                                                       Set("Telefono", User.Telefono).
                                                       Set("Email", User.Email).
                                                       Set("FaceBook", User.FaceBook).
                                                       Set("Contraseña", User.Contraseña);
                        mongo.coleccionUsuario.UpdateOne(filtro, update);
                        usuario = new Usuario(); //persona
                        edit_index = -1;
                    }


                    else
                    {
                        Console.WriteLine("a continuacion voy a imprimir al usuario");
                        Console.WriteLine(User.Nombre);
                        Console.WriteLine(User.ApellidoP);
                        Console.WriteLine(User.ApellidoM);
                        Console.WriteLine(User.Direccion);
                        Console.WriteLine(User.Calle);
                        Console.WriteLine(User.Colonia);
                        Console.WriteLine(User.CodigoP);
                        Console.WriteLine(User.Telefono);
                        Console.WriteLine(User.Email);
                        Console.WriteLine(User.FaceBook);
                        Console.WriteLine(User.Contraseña);



                        await mongo.coleccionUsuario.InsertOneAsync(User);
                        //await mongo.coleccionUsuario.insertOne(User);
                    }
                    actualizarGrid();
                    limpiar();
                    MessageBox.Show("Exito", "El usuario se a guardado con exito", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                    MessageBox.Show("Contraseña invalidad", "la contraseña debe ser mayor de 5 caracteres, y debe ser alfanumerica", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }

            }

            catch
            {
                MessageBox.Show("revisa tu coneccion", "sin internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private async void button4_Click(object sender, EventArgs e) //boton eliminar
        {
            try
            {
                if (edit_index != -1)
                {
                    var filter = Builders<Usuario>.Filter.Eq("_id", usuario.Id);
                    var result = await mongo.coleccionUsuario.DeleteOneAsync(filter);
                    edit_index = -1;
                    limpiar();
                    actualizarGrid();
                }
            }
            catch
            {
                MessageBox.Show("Revisa tu conexion", "Sin internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

       /* private async void DVG(object sender, DataGridViewCellEventArgs e)
        {
           
        }*/

        private async void DVG_DoubleClick(object sender, EventArgs e)
        {
            try
            {
               var filter = Builders<Usuario>.Filter.Eq("_id", dvg_capturarUsuario.SelectedCells[0].Value);
                var result = await mongo.coleccionUsuario.Find(filter).ToListAsync();
                edit_index = 1;

                usuario = result[0];
                textBox1Nombre.Text = usuario.Nombre;
                textBox2Paterno.Text = usuario.ApellidoP;
                textBox3Materno.Text = usuario.ApellidoM;
                textBox4Direccion.Text = usuario.Direccion;
                textBox5Calle.Text = usuario.Calle;
                textBox6Colonia.Text = usuario.Colonia;
                textBox7CodigoP.Text = usuario.CodigoP;
                textBox8Cel.Text = usuario.Telefono;
                textBox9Email.Text = usuario.Email;
                textBox10Face.Text = usuario.FaceBook;
                textBox11Contraseña.Text = usuario.Contraseña;

            }
            catch
            {
                MessageBox.Show("revisa tu coneccion", "sin internet", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DVG_cell(object sender, DataGridViewCellEventArgs e)
        {

        }
        /*private async void DVG_DoubleClick(object sender, EventArgs e)
{

}*/
    }
}
