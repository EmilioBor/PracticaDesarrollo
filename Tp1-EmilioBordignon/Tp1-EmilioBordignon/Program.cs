Console.WriteLine("Bienvenid@s a la Consola");
Console.WriteLine("Donde podras Elegir entre realizar Operaciones matematicas, Logicas o de Cadenas de caracteres!!!");

menu();


static void menu()
{
    Console.WriteLine("1- Realizar Una Operacion matematica");
    Console.WriteLine("2- Realizar Una Operacion Logica");
    Console.WriteLine("3- Realizar Una Operacion de Cadenas de Caracteres");
    Console.WriteLine("4- Salir");
    Console.WriteLine("Ingrese una Opcion: ");
    char op = Console.ReadKey(false).KeyChar;
    Console.WriteLine();
    Console.WriteLine(op);

    switch (op)
    {
        case '1':
            Matematica();
            break;
        case '2':
            Logica();
            break;
        case '3':
            Cadenas();
            break;
        case '4':
            Console.WriteLine("Hasta la Proxima");
            break; 
        default: Console.WriteLine();
            break;
    }
}

static void Cadenas()
{
    Console.WriteLine("Agregando un valor: ");
    char n1 = Console.ReadKey().KeyChar;

    
    int valorAscii = (int)n1;

    Console.WriteLine("Valor ASCII de 'A': " + valorAscii);

}

static void Logica()
{
    string cadena1 = "Hola";
    string cadena2 = " Mundo";

    // Método 1: Usando el operador +
    string resultado1 = cadena1 + cadena2;

    // Método 2: Usando el método Concat
    string resultado2 = string.Concat(cadena1, cadena2);

    Console.WriteLine(resultado1);
    Console.WriteLine(resultado2);

    string miCadena = "Hola Mundo";
    int longitud = miCadena.Length;

    Console.WriteLine("Longitud de la cadena: " + longitud);

}

static void Matematica()
{
    Console.WriteLine("Vamos a Realizar Una Operacion matematica");
    
    Console.WriteLine("Agregando el primer valor: ");
    float n1 = Console.ReadKey().KeyChar;
    Console.WriteLine("Agregando el Segundo valor: ");
    float n2 = Console.ReadKey().KeyChar;

    Console.WriteLine("1- Suma: ");
    Console.WriteLine("2- Resta:");
    Console.WriteLine("3- Multuplicacion:");
    Console.WriteLine("4- Dividir:");
    Console.WriteLine("Infrese Opcion");
    char op = Console.ReadKey(false).KeyChar;

    switch (op)
    {
        case '1':
            Console.WriteLine(n1 + n2);
            break;
        case '2':
            Console.WriteLine(n1 - n2);
            break;
        case '3':
            Console.WriteLine(n1 * n2);
            break;
        case '4':
            Console.WriteLine(n1 / n2);

            break;
        default:
            Console.WriteLine("No ingreso ninguna opcion");
            break;
    }

}