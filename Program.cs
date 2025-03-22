using System;

class Program
{
    static void Main()
    {
        int[] array1 = new int[7];
        int[] array2 = new int[7];
        int[] diferencia = new int[7];
        int sumaTotal = 0;


        Console.WriteLine("Punto 1:");
        Console.WriteLine("--------------------------------------------------------");

        Console.WriteLine("Ingrese 7 números para el primer arreglo:");
        for (int i = 0; i < 7; i++)
        {
            array1[i] = LeerNumero($"Número {i + 1}: ");
            sumaTotal += array1[i];
        }
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("\nIngrese 7 números para el segundo arreglo:");
        for (int i = 0; i < 7; i++)
        {
            array2[i] = LeerNumero($"Número {i + 1}: ");
            sumaTotal += array2[i];
        }

        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine("\nDiferencia entre los dos arreglos:");
        for (int i = 0; i < 7; i++)
        {
            diferencia[i] = array1[i] - array2[i];
            Console.WriteLine($"Diferencia {i + 1}: {diferencia[i]}");
            sumaTotal += diferencia[i];
        }

        double promedio = (double)sumaTotal / (7 * 3);
        Console.WriteLine("--------------------------------------------------------");
        Console.WriteLine($"\nEl promedio de todos los datos es: {promedio:F2}");

        Console.WriteLine("\n--------------------------------------------------------");
        Console.WriteLine("Punto 2:");

        int[] A = new int[17];
        int[] B = new int[17];
        int[] C = new int[17];

        Console.WriteLine("Ingrese el stock actual de los 17 productos:");
        for (int i = 0; i < 17; i++)
        {
            A[i] = LeerNumero($"Stock del producto {i + 1}: ");
        }

        Console.WriteLine("\nIngrese la cantidad de pedidos de los 17 productos:");
        for (int i = 0; i < 17; i++)
        {
            B[i] = LeerNumero($"Pedidos del producto {i + 1}: ");
        }

        Console.WriteLine("\nCalculando lo que se necesita comprar...");
        int totalTicks = 20; 
        int delay = 100;
        Console.Write("[");
        for (int i = 0; i < totalTicks; i++)
        {
            Console.Write("=");
            Thread.Sleep(delay);
        }

        Console.WriteLine("]");

        for (int i = 0; i < 17; i++)
        {
            if (A[i] == B[i])
                C[i] = A[i];
            else if (B[i] > A[i])
                C[i] = 2 * (B[i] - A[i]);
            else
                C[i] = B[i];

            Console.WriteLine($"Producto {i + 1}: Stock = {A[i]}, Pedidos = {B[i]}, Compra necesaria = {C[i]}");
        }

        Console.WriteLine("\n--------------------------------------------------------");
        Console.WriteLine("Punto 3: La champions");

        int equipos = 3;
        int[,] liga = new int[equipos, 6]; 

        Console.WriteLine("Ingrese los datos de los 10 equipos:");

        for (int i = 0; i < equipos; i++)
        {
            Console.WriteLine($"\nEquipo {i + 1}:");
            liga[i, 0] = LeerNumeroLiga("Partidos jugados: ");
            liga[i, 1] = LeerNumeroLiga($"Partidos ganados (máximo {liga[i, 0]}): ", 0, liga[i, 0]);
            int maxPuntos = liga[i, 0] * 3; 
            liga[i, 2] = LeerNumeroLiga($"Puntos obtenidos (entre {liga[i, 1] * 3} y {maxPuntos}): ", liga[i, 1] * 3, maxPuntos);

            liga[i, 3] = (liga[i, 2] - (liga[i, 1] * 3));
            liga[i, 4] = liga[i, 0] - (liga[i, 1] + liga[i, 3]);

            Console.WriteLine($"✅ Partidos empatados: {liga[i, 3]}, Partidos perdidos: {liga[i, 4]}");
        }

        var listaLiga = Enumerable.Range(0, equipos)
                                  .Select(i => new int[] { i + 1, liga[i, 0], liga[i, 1], liga[i, 2], liga[i, 3], liga[i, 4] })
                                  .OrderByDescending(e => e[3]) 
                                  .ToArray();

        Console.WriteLine("\nResultados de la liga (Ordenados por puntos de mayor a menor):");
        Console.WriteLine("Equipo  Jugados Ganados Puntos  Empatados Perdidos");
        foreach (var equipo in listaLiga)
        {
            Console.WriteLine($"{equipo[0],-7} {equipo[1],-7} {equipo[2],-7} {equipo[3],-7} {equipo[4],-9} {equipo[5]}");
        }

    }


    static int LeerNumeroLiga(string mensaje, int min = 0, int max = int.MaxValue)
    {
        int numero;
        do
        {
            Console.Write(mensaje);
        } while (!int.TryParse(Console.ReadLine(), out numero) || numero < min || numero > max);

        return numero;
    }

    static int LeerNumero(string mensaje)
    {
        int numero;
        while (true)
        {
            Console.Write(mensaje);
            if (int.TryParse(Console.ReadLine(), out numero))
                return numero;
            else
                Console.WriteLine("Entrada inválida. Por favor, ingrese un número válido.");
        }
    }
}
