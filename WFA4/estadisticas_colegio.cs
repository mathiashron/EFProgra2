using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace WFA4
{
    class estadisticas_colegio
    {
        ControladorEmpleado controladorempleado = new ControladorEmpleado();
        EntidadEmpleado entidadempleado = new EntidadEmpleado();
        private int cantidadmenores = 0;
        private int cantidadmayores = 0;
        
        private int cont = 0;
        DataTable estudiante = new DataTable();
        DataTable materia = new DataTable();
        DataTable profe = new DataTable();
       private  int[,] cupo;
        private int[,] asistencia;
        private int[,] profesores;
        String[] menor5;
        String[] entre5y10;
        String[] mayo10;
        public void generar()
        {
            cantidadmenores = 0;
            cantidadmayores = 0;

            cont = 0;
            estudiante = controladorempleado.leer();
            materia = controladorempleado.leermateria();
            profe = controladorempleado.leerprofe();
            cupo = new int[materia.Rows.Count, 2];
            asistencia = new int[profe.Rows.Count, 2];
            profesores = new int[profe.Rows.Count, 2];
            menor5 = new string[profe.Rows.Count];
            entre5y10 = new string[profe.Rows.Count];
            mayo10 = new string[profe.Rows.Count];



            //Cantiadad de estudiantes mayoes y menores
            for (int i = 0; i < estudiante.Rows.Count; i++)
            {
                string dato = estudiante.Rows[i][4].ToString();
                int datos = Convert.ToInt16(dato);
                string dato1 = estudiante.Rows[i][5].ToString();
                int datos1 = Convert.ToInt16(dato1);

                if (datos >= 18)
                {
                    cantidadmayores = cantidadmayores + 1;

                }
                else
                {
                    cantidadmenores = cantidadmenores + 1;
                }


            }
            // cantidad de estudiantes por materia
            for (int i = 0; i < materia.Rows.Count; i++)
            {
                string dato1 = materia.Rows[i][0].ToString();

                int datos1 = Convert.ToInt16(dato1);
                int c = 0;
                for (int k = 0; k < estudiante.Rows.Count; k++)
                {
                    string dato2 = estudiante.Rows[k][5].ToString();
                    int datos2 = Convert.ToInt16(dato2);

                    if (datos1 == datos2)
                    {
                        cont = cont + 1;


                    }

                }

                cupo[i, c] = datos1;
                c = c + 1;
                cupo[i, c] = cont;
                cont = 0;


            }
            //cantidad de estudiantes por profesor
            for (int i = 0; i < profe.Rows.Count; i++)
            {
                string dato1 = profe.Rows[i][0].ToString();

                int datos1 = Convert.ToInt16(dato1);
                int c = 0;
                for (int k = 0; k < estudiante.Rows.Count; k++)
                {
                    string dato2 = estudiante.Rows[k][5].ToString();
                    int datos2 = Convert.ToInt16(dato2);

                    if (datos1 == datos2)
                    {
                        cont = cont + 1;




                    }

                }

                asistencia[i, c] = datos1;
                c = c + 1;
                asistencia[i, c] = cont;
                cont = 0;
            }

            //cantidad de materia por profesor
            for (int i = 0; i < profe.Rows.Count; i++)
            {
                string dato1 = profe.Rows[i][0].ToString();

                int datos1 = Convert.ToInt16(dato1);
                int c = 0;
                for (int k = 0; k < materia.Rows.Count; k++)
                {
                    string dato2 = materia.Rows[k][2].ToString();
                    int datos2 = Convert.ToInt16(dato2);

                    if (datos1 == datos2)
                    {
                        cont = cont + 1;
                        

                    }

                }

                profesores[i, c] = datos1;
                c = c + 1;
                profesores[i, c] = cont;
                cont = 0;
                for (int x = 0; x < profe.Rows.Count; x++)
                {

                    if (profesores[x, 1] < 5)
                    {

                        menor5[x] = profe.Rows[x][1].ToString();

                    }
                    if (profesores[x, 1] > 5 && profesores[x, 1] < 10)
                    {

                        entre5y10[x] = profe.Rows[x][1].ToString();

                    }
                    if (profesores[x, 1] > 10)
                    {

                        mayo10[x] = profe.Rows[x][1].ToString();

                    }
                }
            }


        }

        public void mostrar() { 
                Console.WriteLine("Curso - CantidadEstudiantes");

            for(int x = 0; x < materia.Rows.Count; x++)
            {
                Console.Write(materia.Rows[x][1].ToString());
                Console.Write("        -       ");
                Console.WriteLine(cupo[x, 1]);
            }
            Console.WriteLine("Profesor - CantidadEstudiantes");
            
            for (int x = 0; x < profe.Rows.Count; x++)
            {
                

                Console.Write(profe.Rows[x][1].ToString());
                
                Console.Write("        -       ");
                Console.WriteLine(asistencia[x, 1]);
               

            }
            Console.WriteLine("Profesor - Cantidad Materias");

            for (int x = 0; x < profe.Rows.Count; x++)
            {
                
                
                    Console.Write(profe.Rows[x][1].ToString());

                    Console.Write("        -       ");
                    Console.WriteLine(profesores[x, 1]);
                }
            Console.WriteLine("Profesores menores a 5 materias");
            for (int x = 0; x < profe.Rows.Count; x++)
            {
                Console.WriteLine(menor5[x]);
            }
            Console.WriteLine("Profesores entre 5 y 10 materias");
            for (int x = 0; x < profe.Rows.Count; x++)
            {
                Console.WriteLine(entre5y10[x]);
            }
            Console.WriteLine("Profesores mayores a 10 materias");
            for (int x = 0; x < profe.Rows.Count; x++)
            {
                Console.WriteLine(mayo10[x]);
            }


            Console.WriteLine("Mayores");
            Console.WriteLine(cantidadmayores);
            Console.WriteLine("Menores");
            Console.WriteLine(cantidadmenores);
            Console.ReadKey();
        }

        public void imprimir()
        {
            string currentPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName);
            Console.WriteLine(currentPath + @"\reporte.txt");

            StreamWriter sw = new StreamWriter(currentPath + @"\reporte.txt");
            sw.WriteLine("Curso - CantidadEstudiantes");

            for (int x = 0; x < materia.Rows.Count; x++)
            {
                sw.Write(materia.Rows[x][1].ToString());
                sw.Write("        -       ");
                sw.WriteLine(cupo[x, 1]);
            }
            sw.WriteLine("Profesor - CantidadEstudiantes");

            for (int x = 0; x < profe.Rows.Count; x++)
            {


                sw.Write(profe.Rows[x][1].ToString());

                sw.Write("        -       ");
                sw.WriteLine(asistencia[x, 1]);


            }
            for (int x = 0; x < profe.Rows.Count; x++)
            {

            }
            sw.WriteLine("Profesores menores a 5 materias");
            for (int x = 0; x < profe.Rows.Count; x++)
            {
                sw.WriteLine(menor5[x]);
            }
            sw.WriteLine("Profesores entre 5 y 10 materias");
            for (int x = 0; x < profe.Rows.Count; x++)
            {
                sw.WriteLine(entre5y10[x]);
            }
            sw.WriteLine("Profesores mayores a 10 materias");
            for (int x = 0; x < profe.Rows.Count; x++)
            {
                sw.WriteLine(mayo10[x]);
            }
            sw.WriteLine("Mayores");
            sw.WriteLine(cantidadmayores);
            sw.WriteLine("Menores");
            sw.WriteLine(cantidadmenores);
            //Console.ReadKey();
            sw.Close();
        }




        }
    }

