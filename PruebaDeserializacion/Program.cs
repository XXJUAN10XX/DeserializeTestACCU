using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Prueba de concepto para des-serializar en CONSOLA GUPM
 * */
namespace PruebaDeserializacion
{
    //Esta es la clase que deberias tener, que contendra la cantidad total de elementos y el resultado de la busqueda.
    public class PageResponse<T>
    {
        public long cant;
        public List<T> elements;

        public PageResponse(long cant, List<T> elements)
        {
            this.cant = cant;
            this.elements = elements;
        }

        public PageResponse()
        {
        } 
    }


    //Clase BnfReducido que podria ser cualquier clase de GUPM
    public class BnfReducido
    {
        public string estado;
        public long id;
        public long lote;
        public List<DatoComplementario> complementarios;

        public BnfReducido(string estado, long id, long lote)
        {
            this.estado = estado;
            this.id = id;
            this.lote = lote;
        }

        public BnfReducido(string estado, long id, long lote, List<DatoComplementario> complementarios) : this(estado, id, lote)
        {
            this.complementarios = complementarios;
        }

        public BnfReducido()
        {
        }

        public override string ToString()
        {
            return "estado:" + this.estado + ", id:" + this.id + ", lote:"+this.lote ;
        }
    }

    //Clase dato complementario

    public class DatoComplementario
    {
        string valor;
        string tipo_dato;
        string nombre;

        public DatoComplementario(string valor, string tipo_dato, string nombre)
        {
            this.valor = valor;
            this.tipo_dato = tipo_dato;
            this.nombre = nombre;
        }

        public override string ToString()
        {
            return "valor:" + this.valor + ", tipo:" + this.tipo_dato + ", nombre:" + this.nombre;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //Json de prueba, simil al que vendra del servidor. En este caso solo tiene 2 elementos.
            string json = "{\n" +
                "  \"elements\": [\n" +

                "    {\n" +
                "      \"lote\": 1,\n" +
                "      \"id\": 1,\n" +
                "      \"estado\": \"INGRESADO\",\n" +
                "      \"complementarios\":[" +
                "           {\"valor\": \"v1\", \"tipo_dato\":\"P\", \"nombre\": \"version\" }" +
                "]"+
                "    },\n" +

                "    {\n" +
                "      \"lote\": 1,\n" +
                "      \"id\": 2,\n" +
                "      \"estado\": \"CARGANDO\"\n" +
                "    }\n" +

                "  ],\n" +
                "  \"cant\": 1\n" +
                "}";

            //Aqui deberias poner en ves de BnfReducido tu clase, por ejemplo NominaBeneficiario
            //entonces la lista de elementos de PageResponse sera de tipo NominaBeneficiario
            PageResponse<BnfReducido> response = JsonConvert.DeserializeObject<PageResponse<BnfReducido>>(json);


            Console.WriteLine("Prueba de concepto para deserializacion GUPM ");

            Console.WriteLine("Objeto:");
            Console.WriteLine(response.ToString());

            //Para acceder a los elementos de tu clase
            Console.WriteLine("Elementos:");
            Console.WriteLine("Elemento 1:");
            Console.WriteLine(response.elements[0].ToString());

            //Para poder recuperar los complementarios
            Console.WriteLine("Elemento 1 (complementarios):");
            Console.WriteLine(response.elements[0].complementarios[0].ToString());
            Console.WriteLine("Elemento 2:");
            Console.WriteLine(response.elements[1].ToString());
            //Para poder recuperar los complementarios
            Console.WriteLine("Elemento 2 (complementarios):");
            Console.WriteLine(response.elements[1].complementarios);

            //Para poder recuperar la cantidad
            Console.WriteLine("Cantidad");
            Console.WriteLine(response.cant);
            Console.ReadLine();
        }
    }
}
