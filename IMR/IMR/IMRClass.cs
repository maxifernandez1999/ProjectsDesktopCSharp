using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMR
{
    public class IMRClass
    {
        private string sexo;
        private int peso;
        private float altura;
        private int edad;

        public IMRClass(string sexo, int peso, float altura, int edad)
        {
            this.sexo = sexo;
            this.peso = peso;
            this.altura = altura;
            this.edad = edad;
        }

        public double CalcularIMR()
        {
            double kcalDia = 0;
            if (this.sexo == "masculino")
            {
                kcalDia = (10 * this.peso) + (6.25 * this.altura) + (5 * this.edad) - 5;
            }
            if (this.sexo == "femenino")
            {
                kcalDia = (10 * this.peso) + (6.25 * this.altura) + (5 * this.edad) - 161;

            }
            return kcalDia;
        }
    }
}
