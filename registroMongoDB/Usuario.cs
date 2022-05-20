using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;
using MongoDB.Driver;

namespace registroMongoDB
{
    public class Usuario
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("Nombre")]
        public string Nombre { get; set; }
        [BsonElement("ApellidoP")]
        public string ApellidoP { get; set; }
        [BsonElement("ApellidoM")]
        public string ApellidoM { get; set; }
        [BsonElement("Direccion")]
        public string Direccion { get; set; }
        [BsonElement("Calle")]
        public string Calle { get; set; }
        [BsonElement("Colonia")]
        public string Colonia { get; set; }
        [BsonElement("CodigoP")]
        public string CodigoP { get; set; }
        [BsonElement("Telefono")]
        public string Telefono { get; set; }
        [BsonElement("Email")]
        public string Email { get; set; }
        [BsonElement("FaceBook")]
        public string FaceBook { get; set; }
        [BsonElement("Contraseña")]
        public string Contraseña { get; set; }
    }
}
