using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class
{
    public class Alumnos
    {
        private string nombre;
        private string apellido;
        private string dni;
        private double notaUno;
        private double notaDos;
        private double notaFinal;
        private List<Alumnos> estudiantes;

        public Alumnos()
        {
            estudiantes = new List<Alumnos>();
        }
        public Alumnos(string nombre, string apellido, string dni, double notaUno, double notaDos,double notaFinal)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.NotaUno = notaUno;
            this.NotaDos = notaDos;
            this.NotaFinal = notaFinal;
        }
        

        public string Nombre
        {
            get
            {
                if (ValidarNombre(this.nombre))
                {
                    return this.nombre;
                }
                return this.nombre;
            }
            set
            {
                if (ValidarNombre(value))
                {
                    this.nombre = value;
                }
            }
        }
        
        public string Dni
        {
            get
            {
                if (ValidarDni(this.dni))
                {
                    return this.dni;
                }
                return this.dni;
            }
            set
            {
                if (ValidarDni(value))
                {
                    this.dni = value;
                }
            }
        }

        public string Apellido
        {
            get
            {
                if (ValidarApellido(this.apellido))
                {
                    return this.apellido;
                }
                return this.apellido;
            }
            set
            {
                if (ValidarApellido(value))
                {
                    this.apellido = value;
                }
            }
        }
        public double NotaUno { get => notaUno; set => notaUno = value; }
        public double NotaDos { get => notaDos; set => notaDos = value; }
        public double NotaFinal
        {
            get
            {
                return CalcularNota();
            }
            set
            {
                this.notaFinal = value;
            }
        }

        public List<Alumnos> Estudiantes
        {
            get
            {
                return this.estudiantes;
            }
            set
            {
                this.estudiantes = value; 
            }
        }

        public bool ValidarDni(string dni)
        {
            int dniParse = 0;
            if (int.TryParse(dni, out dniParse))
            {
                return true;
            }
            return false;
        }
        public bool ValidarNombre(string nombre)
        {
            bool retorno = false;
            foreach (char c in nombre)
            {
                if (char.IsLetter(c))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }

        public bool ValidarApellido(string apellido)
        {
            bool retorno = false;
            foreach (char c in apellido)
            {
                if (char.IsLetter(c))
                {
                    retorno = true;
                }
                else
                {
                    retorno = false;
                    break;
                }
            }
            return retorno;
        }
        public double CalcularNota()
        {
            return this.notaUno + this.notaDos / 2;
        }
        

    }
}
