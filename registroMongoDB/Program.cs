using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
namespace registroMongoDB
{
    static class Program
    {

        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {

            MongoHelper mongo = new MongoHelper();
            mongo.ConnectToMongoService();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form1 inicio = new Form1(mongo);
            Console.WriteLine("inicio");
            //Application.Run(new Form1(mongo));
            Application.Run(inicio);

        }
    }
}
