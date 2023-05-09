using OtroRepaso1erParcialProg3;
using System;
using System.ComponentModel;
using System.IO;

namespace TestRepa
{
    public class UnitTest1
    {
        
        [Fact]
        public void DebeFormatearUnaFecha()
        {
            var fechaDeHoy = DateTime.Now;

            //"Lunes 08 de Mayo de 2023 a las 'HH:mm'

            var fechaStr = fechaDeHoy.ToString("dddd dd 'de' MMMM 'de' yyyy 'a' 'las' HH:mm");

            //Assert.Equal("lunes 08 de mayo de 2023 a las xx:xx", fechaStr);

            var fechaToString = fechaDeHoy.ToString("D");

            Assert.Equal("martes, 9 de mayo de 2023", fechaToString);

            //fecha corta modificada para que aparezca ceros en dia y mes
            var fechaToStringCorto = fechaDeHoy.ToString("dd/MM/yyyy");

            Assert.Equal("09/05/2023", fechaToStringCorto);
        }

        [Fact]
        public void DebeDarNombreAlArchivoYDirectoriosYCrearloAdemasVerificarElContenido()
        {
            var fechaDeHoy = DateTime.Now.ToString("D");

            var a = new Class1();

            a._fecha = fechaDeHoy;
            a._nombreArchivo = fechaDeHoy;
            

            var d = Directory.CreateDirectory($"C:/Users/EliasRS/Desktop/{fechaDeHoy}");
            d.CreateSubdirectory("otromas");

            var sw = new StreamWriter($"C:/Users/EliasRS/Desktop/{fechaDeHoy}/otromas/{a._nombreArchivo}.txt", false);
            //var sw = new StreamWriter($"C:/Users/EliasRS/Desktop/{a._nombreArchivo}.txt", false);
            
                sw.Write(a._fecha);

            

            sw.Close();

            Assert.True(true);


            var sr = new StreamReader($"C:/Users/EliasRS/Desktop/{fechaDeHoy}/otromas/{a._nombreArchivo}.txt");
            //var sr = new StreamReader($"C:/Users/EliasRS/Desktop/{a._nombreArchivo}.txt");

            var texto = sr.ReadToEnd();

            sr.Close();

            Assert.Equal(fechaDeHoy, texto);

        }
        [Fact]
        public void DebeCrearQueueAgregarElementosEliminarUnoYContar()
        {
            var a = new Class1();

            for (int i = 0; i < 10; i++)
            {
                a.AddItems(i.ToString());
            }

            a.EliminarItem();

            Assert.Equal(9, a._coleccion.Count());

        }

        [Fact]
        public void AgregarYBorrar()
        {
            var a = new Class1();

            a.AddItems("tomate");
            a.AddItems("pera");
            a.AddItems("lechuga");
            a.AddItems("Banana");


            Assert.Equal(4, a._coleccion.Count());

            a.EliminarItem();

            Assert.Equal(3, a._coleccion.Count());
            var x = a._coleccion.Peek();

            Assert.Equal(a._coleccion.Peek(), x);
            Assert.Equal(3, a._coleccion.Count());

            a.AddItems("manzana");
            Assert.Equal(4, a._coleccion.Count());


        }
        [Fact]
        public void DebeConsultarConLinqYBorrar()
        {

            var lista = new Queue<string>();

            lista.Enqueue("a");
            lista.Enqueue("B");
            lista.Enqueue("C");
            lista.Enqueue("D");
            lista.Enqueue("F");

            var aux = (from c in lista
                       where c == "c"
                       select c).ToList().FindIndex(c => c == "C");


            if (aux >= 0)
            {
                for (int i = 0; i <= lista.Count; i++)
                {
                    if (i < aux)
                    {
                        lista.Enqueue(lista.Dequeue());
                    }
                    else if(i == aux)
                    {
                        lista.Dequeue();
                    }
                    else if(i> aux)
                    {
                        lista.Enqueue(lista.Dequeue());
                    }
                }

            }
            lista = new Queue<string>((from c in lista
                                       where c != "C"
                                       select c).ToList());


            Assert.False(lista.Contains("C"));
            Assert.Equal(4, lista.Count);
        }
        [Fact]
        public void DebeAgregarAlumnoEnPosicionEspecifica()
        {
            var lista = new Queue<string>();

            lista.Enqueue("A");
            lista.Enqueue("B");
            lista.Enqueue("C");
            lista.Enqueue("D");
            lista.Enqueue("F");

            Assert.Equal(5, lista.Count());

            var aux = (from c in lista
                       where c == "c"
                       select c).ToList().FindIndex(c => c == "C");

            if (aux >= 0)
            {
                for (int i = 0; i <= lista.Count+1; i++)
                {
                    if (i < aux)
                    {
                        lista.Enqueue(lista.Dequeue());
                    }
                    else if (i == aux)
                    {
                        lista.Enqueue("agregado");
                        lista.Enqueue(lista.Dequeue());
                    }
                    else if (i > aux)
                    {
                        lista.Enqueue(lista.Dequeue());
                    }
                }

            }

            //Assert.True(lista.Contains("agregado"));
            Assert.Equal(6, lista.Count);
        }
    }
}