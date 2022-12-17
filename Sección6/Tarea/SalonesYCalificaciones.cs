﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea
{   
    //Por motivos de ahorrar tiempo voy a usar el código que ofrece el profesor hasta el momento, voy a agregar y/o hacer los cambios que pida o vea necesarios


    //1. Agregar el cálculo del promedio de calificaciones para cada salón en el ejercicio de matrices escalonadas.
    internal class SalonesYCalificaciones
    {
        static void Main(string[] args)
        {
            //Variables
            byte i, j, numAlumnos, salones;
            double sumaCalif = 0, sumaAlumnos = 0, promedio, califMin = 10, califMax = 0;

            //Pedimos el número de salones
            Console.Write("Ingrese el número de salones: ");
            salones = Convert.ToByte(Console.ReadLine());

            //Creación de la matriz
            double[][] calificaciones = new double[salones][];

            // Pedimos el número de alumnos por salón
            for (i = 0; i < salones; i++)
            {
                Console.Write("Ingrese el número de alumnos para el salón {0}: ", i+1);
                numAlumnos = Convert.ToByte(Console.ReadLine());

                //Acumulamos el número de alumnos totales, para el promedio de toda la escuela
                sumaAlumnos += numAlumnos;

                //Instanciamos las matrices internas (alumnos en cada salón)
                calificaciones[i] = new double[numAlumnos];
            }

            //Pedimos las calificaciones de los alumnos de cada salón
            for (i = 0; i < salones; i++)
            {
                Console.WriteLine("Salón {0}", i);
                for (j = 0; j < calificaciones[i].Length; j++)
                {
                    //Pedimos la califiación
                    Console.Write("Ingresa la calificación del alumno {0}: ", j);
                    calificaciones[i][j] = Convert.ToDouble(Console.ReadLine());

                    //Acumulamos las califiaciones
                    sumaCalif += calificaciones[i][j];
                }
            }

            //Calculamos el promedio
            promedio = sumaCalif / sumaAlumnos;

            //Calculamos la calificación mínima
            for (i = 0; i < salones; i++)
            {
                for (j = 0; j < calificaciones[i].Length; j++)
                {
                    if (calificaciones[i][j] < califMin)
                    {
                        califMin = calificaciones[i][j];
                    }
                }
            }

            //Calculamos la califiación máxima
            for (i = 0; i < salones; i++)
            {
                for (j = 0; j < calificaciones[i].Length; j++)
                {

                    if (calificaciones[i][j] > califMax)
                    {
                        califMax = calificaciones[i][j];
                    }
                }
            }


            //Mostramos las calificaciones de todos los alumnos de la escuela
            for (i = 0; i < salones; i++)
            {
                Console.WriteLine("Salón {0}", i);
                for (j = 0; j < calificaciones[i].Length; j++)
                {
                    Console.WriteLine("El alumno {0}, tiene {1} de calificación", j, calificaciones[i][j]);
                }
            }

            //Mostramos los resultados
            Console.WriteLine("El promedio es: {0}", promedio);
            Console.WriteLine("La califiación mínima es: {0}", califMin);
            Console.WriteLine("La califiación máxima es: {0}", califMax);

            //Mostramos el promedio por salon
            for (i = 0; i < salones; i++)
            {
                PromedioSalon(i,calificaciones[i]);
            }
            
        }
        static void PromedioSalon(byte numSalon, double[] calificaciones)
        {
            double sumaAlumnos = 0, sumaCalif = 0, promedio;

            for (int i = 0; i < calificaciones.Length; i++)
            {
                sumaCalif += calificaciones[i];
                sumaAlumnos++;
            }
            promedio = sumaCalif / sumaAlumnos;

            Console.WriteLine("El promedio del salón {0} es: {1}", numSalon+1, promedio);
        }




    }
}
