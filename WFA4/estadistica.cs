using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WFA4
{
    class estadistica 
    {
        estadisticas_colegio colegio = new estadisticas_colegio();

       public void menu()
        {

            int option = 0;

            do
            {
                Console.Clear();
                Console.WriteLine("Estudiantes");
                Console.WriteLine("1.\tGenerar\n2.\tMostrar\n3.\tImprimir\n4.\tSalir");
                option = int.Parse(Console.ReadLine());


                switch (option)
                {
                    case 1:
                        //Generar
                        Console.Clear();
                        colegio.generar();
                        break;


                    case 2:
                        //Mostrar
                        Console.Clear();
                        colegio.mostrar();
                        break;

                    case 3:
                        //Imprimir
                        Console.Clear();
                        colegio.imprimir();
                        break;

                    case 4:
                        //Salir
                        break;



                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Seleccione una opción válida..");
                            Console.ReadKey();
                            break;
                        }
                }


            } while (option != 4);

            //fin main

        }

    }



    }

