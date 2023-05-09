using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtroRepaso1erParcialProg3
{
    public class Class1
    {
        public string _fecha { set; get; }

        public string _nombreArchivo { set; get; }

        public Queue<string> _coleccion = new Queue<string>();

        public void AddItems(string valor)
        {
            _coleccion.Enqueue(valor);
        }

        public void EliminarItem()
        {
            _coleccion.Dequeue();
        }

        public Class1() { }


    }
}
