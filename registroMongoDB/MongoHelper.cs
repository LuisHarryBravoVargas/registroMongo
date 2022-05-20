using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace registroMongoDB
{
    public class MongoHelper
    {
        public IMongoClient client { get; set; }
        public IMongoDatabase database { get; set; }
        public IMongoCollection<Usuario> coleccionUsuario;
        //public IMongoCollection<Producto> coleccionProducto;
        public string MongoConnection = "mongodb+srv://punto_usuario:proyecto@2019@cluster0-nzjsa.mongodb.net/test?retryWrites=true";        //"mongodb+srv://Progra3Usr:progra3.-1324@claseprogra3-quyq2.mongodb.net/test?retryWrites=true";
        public string MongoDatabase = "punto_de_venta";

        public void ConnectToMongoService()
        {
            try
            {
                client = new MongoClient(MongoConnection);
                database = client.GetDatabase(MongoDatabase);
                //coleccionUsuario = database.GetCollection<Usuario>("PuntoDeVenta");
                coleccionUsuario = database.GetCollection<Usuario>("PuntoDeVenta");

                //coleccionProducto = database.GetCollection<Producto>("PuntoDeVenta");
            }
            catch
            {

            }
        }
    }
}
