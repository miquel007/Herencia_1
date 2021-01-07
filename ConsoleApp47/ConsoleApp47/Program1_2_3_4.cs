using System;
using System.Collections.Generic;

namespace ConsoleApp47
{
    class Program1_2_3_4
    {

        public class Cuenta
        {
            private string _Titiular;
            private double _Cantidad;

            public string Titular
            {
                get { return _Titiular; }
                set { _Titiular = value; }
            }

            public double Cantidad
            {
                get { return _Cantidad; }
                set { _Cantidad = value; }
            }

            public Cuenta(string tit)
            {
                Titular = tit;

                Cantidad = 0;
            }

            public void  ingresar (double can)
            {
                double op = _Cantidad;
                if (can >= 0)
                    Cantidad = op + can;
                else
                    throw new ArgumentException("La cuantitat ha de ser positiu");
            }

            public void retirar (double can)
            {
                double op = _Cantidad;
                op = op - can;
                if (op >= 0)
                    Cantidad = op;
                else
                    Cantidad = 0;
            }

            public override string ToString()
            {
                return string.Format(" {0} {1} ", _Titiular, _Cantidad);
            }


        }
        
        public class Persona
        {
            private string _nombre;
            private int _edad;
            private string DNI;
            private int _pos;
            private string[] Sexo = {"H","M"};
            private double _peso;
            private double _altura;

            public string Nombre
            {
                get { return _nombre; }
                set { _nombre = value; }
            }
          
            public int Edad
            {
                get { return _edad; }
                set { _edad = value; }
            }

            public int Pos
            {
                get { return _pos; }
                set { _pos = value; }
            }

            public double Peso
            {
                get { return _peso; }
                set { _peso = value; }
            }

            public double Altura
            {
                get { return _altura; }
                set { _altura = value; }
            }

            public Persona()
            {
                Nombre = "";
                Edad = 0;
                DNI = generarDNI();
                Pos = 0;
                Peso = 0;
                Altura = 0;
            }

            public Persona(string n, int e, int sexo)
            {
                Nombre = n;
                Edad = e;
                DNI = generarDNI();
                Pos = sexo;
                Peso = 0;
                Altura = 0;
            }

            public Persona(string n, int e, int sexo, double p, double a)
            {
                Nombre = n;
                Edad = e;
                DNI = generarDNI();
                Pos = sexo;
                Peso = p;
                Altura = a;
            }

            public int calcularMC()
            {
                double op = 0;
                int estado;

                op = _peso / (Math.Pow(_altura,2)) ;

                if (op < 20)
                    estado = -1;
                else if (op > 25)
                    estado = 1;
                else
                    estado = 0;

                return estado;
            }

            public bool esMayorDeEdad()
            {
                if (_edad < 18)
                    return false;
                else
                    return true;
            }

            private void comprobarSexo (char sexo)
            {
                if (!Sexo[_pos].Equals(sexo))
                    Pos = 0;
            }

            private string generarDNI()
            {
                Random rnd = new Random();
                string num = rnd.Next(0, 9).ToString();

                for (int i = 0; i < 7; i++)
                {
                    rnd = new Random();
                    num = num + rnd.Next(0,9).ToString();
                }

                num = num + (char)rnd.Next('a', 'z');

                return num;
            }

            public override string ToString()
            {
                return string.Format(" Nombre:{0} Edad:{1} DNI:{2} Sexo:{3} Peso{4} Altura:{5} ", _nombre, _edad,DNI,Sexo[_pos],_peso,_altura);
            }

        }
       
        public class Password
        {
            private int _longitud;
            private string _contraseña;

            public int Longitud
            {
                get { return _longitud; }
                set { _longitud = value; }
            }

            public Password()
            {
                Longitud = 8;
                generar();
            }

            public Password(int lon)
            {
                Longitud = lon;
                generar();
            }

            private void generar()
            {
                for (int i = 0; i < Longitud; i++)
                {
                    Random rnd = new Random();
                    _contraseña = _contraseña + (char)rnd.Next(32, 217);
                }
            }

            public bool esFuerte()
            {
                char[] array = _contraseña.ToCharArray();
                int COUNT1 = 0;
                int count2 = 0;
                int count3 = 0;

                for(int i = 0; i < _contraseña.Length; i++)
                {
                    var vol = array[i];
                    if (char.IsUpper(vol))
                        COUNT1++;
                    if (char.IsLower(vol))
                        count2++;
                    if (char.IsDigit(vol))
                        count3++;
                }

                if (COUNT1 > 2 && count2 > 1 && count3 > 5)
                    return true;
                else
                    return false;
            }

            public override string ToString()
            {
                return string.Format(" Longitud:{0} Contraseña:{1} ", _longitud, _contraseña);
            }
        }
        
        public class Electrodomestico
        {
            private double _precio;
            private string _color;
            private int _pos;
            private char[] consumo = { 'A', 'B', 'C', 'D', 'E', 'F' };
            private int _peso;
           
            public double Precio
            {
                get { return _precio; }
                set { _precio = value; }
            }

            public string Color
            {
                get { return _color; }
                set { _color = value; }
            }

            public int Pos
            {
                get { return _pos; }
                set { _pos = value; }
            }

            public int Peso
            {
                get { return _peso; }
                set { _peso = value; }
            }

            public Electrodomestico()
            {
                Color = "blanco";
                Pos = 5;
                Precio = 100;
                Peso = 5;
            }

            public Electrodomestico(int price, int pes)
            {
                Color = "blanco";
                Pos = 5;
                Precio = price;
                Peso = pes;
            }

            public Electrodomestico(int price, int pes, int posi, string colour)
            {
                Precio = price;
                Peso = pes;
                Pos = posi;
                Color = comprovarColor(colour);
            }

            private string comprovarColor(string e)
            {
                bool trobat = false;
                string[] opciones = { "blanco", "negro", "rojo", "azul", "gris" };

                foreach (string i in opciones)
                {
                    if (i.Equals(e))
                        trobat = true;
                }

                if (!trobat)
                    e = "Blanco";

                return e;
            }

            public virtual double precioFinal()
            {
                double suma = 0;

                switch (Pos)
                {
                    case 0:
                        suma = 100;
                        break;
                    case 1:
                        suma = 80;
                        break;
                    case 2:
                        suma = 60;
                        break;
                    case 3:
                        suma = 50;
                        break;
                    case 4:
                        suma = 30;
                        break;
                    case 5:
                        suma = 10;
                        break;

                }

                

                if (Peso < 20)
                    suma = suma + 20;
                else if (Peso < 50)
                    suma = suma + 50;
                else if (Peso < 80)
                    suma = suma + 80;
                else
                    suma = suma + 100;

                suma = Precio + suma;

                return suma;
            }

        }

        public class Lavadora : Electrodomestico 
        {
            private int _carga;

            public int Carga
            {
                get { return _carga; }
                set { _carga = value; }
            }

            public Lavadora() 
                : base()
            {
                Carga = 5;
            }

            public Lavadora(int price, int pes)
                : base(price,pes)
            {
                Carga = 5;
            }

            public Lavadora(int price, int pes, int posi, string colour,int car)
                :base(price,pes,posi,colour)
            {
                Carga = car;
            }

            public override double precioFinal()
            {
                double num;

                if (Carga < 30)
                    num = 0;
                else
                    num = 30;

                return base.precioFinal() + num;
            }
        }

        public class Television : Electrodomestico
        {
            private int _resolucio;
            private bool _TDT;

            public int Resolucio
            {
                get { return _resolucio; }
                set { _resolucio = value; }
            }

            public bool TDT
            {
                get { return _TDT; }
                set { _TDT = value; }
            }

            public Television()
                : base()
            {
                Resolucio = 20;
                TDT = false;
            }

            public Television(int price, int pes)
                : base(price, pes)
            {
                Resolucio = 20;
                TDT = false;
            }

            public Television(int price, int pes, int posi, string colour, int car, bool prova)
                : base(price, pes, posi, colour)
            {
                Resolucio = car;
                TDT = prova;
            }
            public override double precioFinal()
            {
                double num = base.precioFinal();
               
                if (Resolucio > 40)
                    num = num*1.3;

                if (TDT)
                    num = num + 50;
                

                return num;
            }

        }

        static void Main(string[] args)
        {
            //ex1();

            //ex2();

            //ex3();

            //ex4();

        }

        public static void ex1()
        {
            Console.WriteLine("Como se llama el titular de la cuenta?");
            string titular = Console.ReadLine();

            Cuenta try1 = new Cuenta(titular);

            Console.WriteLine("Cantidad que quiere ingresar");
            string Kfake = Console.ReadLine();
            double cantidad = Convert.ToDouble(Kfake);

            try
            {
                try1.ingresar(cantidad);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Cantidad que quiere ingresar");
            Kfake = Console.ReadLine();
            cantidad = Convert.ToDouble(Kfake);

            try
            {
                try1.ingresar(cantidad);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine(try1.ToString());

            Console.WriteLine("Cantidad que quiere retirar");
            Kfake = Console.ReadLine();
            cantidad = Convert.ToDouble(Kfake);

            try1.retirar(cantidad);

            Console.WriteLine(try1.ToString());
        }
    
        public static void ex2()
        {
            List<Persona> array = new List<Persona>();

            Console.WriteLine("Cual es tu nombre?");
            string nom = Console.ReadLine(); 

            Console.WriteLine("Cual es tu edad?");
            string Kfake = Console.ReadLine();
            int edad = Convert.ToInt32(Kfake);

            Console.WriteLine("Cual es tu sexo? 1)Hombre 2)Mujer");
            string Lfake = Console.ReadLine();
            int pos = Convert.ToInt32(Lfake);

            Console.WriteLine("Cual es tu peso?");
            string jake = Console.ReadLine();
            double peso = Convert.ToDouble(jake);

            Console.WriteLine("Cual es tu altura?");
            string hake = Console.ReadLine();
            double altura = Convert.ToDouble(hake);

            Persona try1 = new Persona(nom, edad, pos - 1, peso, altura);
            array.Add(try1);
            Persona try2 = new Persona(nom, edad, pos - 1);
            array.Add(try2);
            Persona try3 = new Persona();
            try3.Nombre = nom;
            try3.Edad = edad;
            try3.Peso = peso;
            try3.Altura = altura;
            array.Add(try3);

            foreach (Persona n in array)
            {
                int ideal = n.calcularMC();

                switch (ideal)
                {
                    case -1:
                        Console.WriteLine("Estas en tu peso ideal");
                        break;
                    case 0:
                        Console.WriteLine("Estas por debajo de tu peso ideal");
                        break;
                    case 1:
                        Console.WriteLine("Tienes sobrepeso");
                        break;
                }

                if (n.esMayorDeEdad())
                    Console.WriteLine("Es mayor de edad");
                else
                    Console.WriteLine("Es menor de edad");

                Console.WriteLine( n.ToString());

            }
        
            
        }
    
        public static void ex3()
        {
            List<Password> array = new List<Password>();
            List<bool> fuerte = new List<bool>();

            Console.WriteLine("Cunatas contraseñas quieres generar");
            String kfake = Console.ReadLine();
            int num = Convert.ToInt32(kfake);

            Console.WriteLine("Longitud de la contraseñas que quieres generar");
            String lfake = Console.ReadLine();
            int longi = Convert.ToInt32(lfake);

            for (int i = 0; i < num; i++)
            {
                Password pass = new Password(longi);
                array.Add(pass);
                fuerte.Add(pass.esFuerte());

                Console.WriteLine(pass.ToString() + " " + pass.esFuerte());
            }
        }
   
        public static void ex4()
        {
            List<Electrodomestico> array = new List<Electrodomestico>();

            array.Add(new Electrodomestico());
            array.Add(new Television());

            for (int i = 0; i < 4; i++)
            {
                array.Add(new Television(500,i*20,i, "rojo",20 +i*20,true));
                array.Add(new Lavadora(500, i * 20, i, "rojo", 20 + i * 20));
            }
            double count_electro = 0;
            double count_TV = 0;
            double count_Lavadora = 0;

            foreach (var n in array)
            {
                if (n is Television)
                    count_TV = count_TV + n.precioFinal();
                if (n is Lavadora)
                    count_Lavadora = count_Lavadora + n.precioFinal();
                if (n is Electrodomestico)
                    count_electro = count_electro + n.precioFinal();
            }

            Console.WriteLine("Les teles costen "+ count_TV);
            Console.WriteLine("Les lavadores costen " + count_Lavadora);
            Console.WriteLine("Els electrodumestics costen " + count_electro);
        }
       
    }
}
