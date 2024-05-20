using System;

class Program
{
    static void Main(string[] args)
    {
        Program program = new Program();
        program.Menu();
    }

    private Inventario inventario;

    public Program()
    {
        inventario = new Inventario(65);
    }

    public void Menu()
    {
        while (true)
        {
            Console.WriteLine("Menú:");
            Console.WriteLine("1. Registrar Teléfono");
            Console.WriteLine("2. Mostrar Teléfonos Registrados");
            Console.WriteLine("3. Consultar Stock de un Teléfono Específico");
            Console.WriteLine("4. Salir");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarTelefono();
                    break;
                case "2":
                    inventario.MostrarTelefonosRegistrados();
                    break;
                case "3":
                    ConsultarStock();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Grave error");
                    break;
            }
        }
    }

    private void RegistrarTelefono()
    {
        Console.Write("Digite el tipo de teléfono |1. Inteligente | 2. Básico|: ");
        string tipo = Console.ReadLine();

        Telefono telefono = null;
        if (tipo == "1")
        {
            TelefonoInteligente telefonoInteligente = new TelefonoInteligente();
            Console.Write("Marca: ");
            telefonoInteligente.Marca = Console.ReadLine();
            Console.Write("Modelo: ");
            telefonoInteligente.Modelo = Console.ReadLine();
            Console.Write("Precio: ");
            telefonoInteligente.Precio = decimal.Parse(Console.ReadLine());
            Console.Write("Sistema Operativo: ");
            telefonoInteligente.SistemaOperativo = Console.ReadLine();
            Console.Write("Memoria RAM : ");
            telefonoInteligente.MemoriaRam = int.Parse(Console.ReadLine());
            telefono = telefonoInteligente;
        }
        else if (tipo == "2")
        {
            TelefonoBasico telefonoBasico = new TelefonoBasico();
            Console.Write("Marca: ");
            telefonoBasico.Marca = Console.ReadLine();
            Console.Write("Modelo: ");
            telefonoBasico.Modelo = Console.ReadLine();
            Console.Write("Precio: ");
            telefonoBasico.Precio = decimal.Parse(Console.ReadLine());
            Console.Write("Tiene Radio FM (si/no): ");
            telefonoBasico.TieneRadioFM = Console.ReadLine().ToLower() == "si";
            Console.Write("Tiene Linterna (si/no): ");
            telefonoBasico.TieneLinterna = Console.ReadLine().ToLower() == "si";
            telefono = telefonoBasico;
        }
        else
        {
            Console.WriteLine("Tipo de telefono inexistente");
        }

        if (telefono != null)
        {
            inventario.RegistrarTelefono(telefono);
        }
    }

    private void ConsultarStock()
    {
        Console.Write("Digite el modelo del telefono: ");
        string modelo = Console.ReadLine();
        inventario.ConsultarStock(modelo);
    }

    public class Telefono
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public decimal Precio { get; set; }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Precio: {Precio:C}");
        }
    }
    public class TelefonoInteligente : Telefono
    {
        public string SistemaOperativo { get; set; }
        public int MemoriaRam { get; set; } 

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Sistema Operativo: {SistemaOperativo}, Memoria RAM: {MemoriaRam}GB");
        }
    }
    public class TelefonoBasico : Telefono
    {
        public bool TieneRadioFM { get; set; }
        public bool TieneLinterna { get; set; }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"tiene Radio FM: {(TieneRadioFM ? "Sí" : "No")}, tiene linterna: {(TieneLinterna ? "Sí" : "No")}");
        }
    }
    public class Inventario
    {
        private Telefono[] inventario;
        private int contador;

        public Inventario(int capacidad)
        {
            inventario = new Telefono[capacidad];
            contador = 0;
        }

        public void RegistrarTelefono(Telefono telefono)
        {
            if (contador < inventario.Length)
            {
                inventario[contador++] = telefono;
            }
            else
            {
                Console.WriteLine("El inventario esta topado");
            }
        }

        public void MostrarTelefonosRegistrados()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay telefonos registrados");
            }
            else
            {
                for (int i = 0; i < contador; i++)
                {
                    inventario[i].MostrarInformacion();
                    Console.WriteLine();
                }
            }
        }

        public void ConsultarStock(string modelo)
        {
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (inventario[i].Modelo == modelo)
                {
                    encontrado = true;
                    inventario[i].MostrarInformacion();
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("Telefono no hayado");
            }
        }
    }

}
