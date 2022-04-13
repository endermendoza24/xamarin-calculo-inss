using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculadoraINSS
{
    public partial class MainPage : ContentPage
    {
        double factorBasico = 0.20;
        double factorAplicacion = 0.010;
        int semanaAnual = 52;

        public MainPage()
        {
            InitializeComponent();
        }

        public void Button_Clicked(object sender, EventArgs e)
        {           
            try
            {
                var semanasUsuario = Convert.ToInt32(Semanas.Text);
                var salarioUsuario = Convert.ToDouble(Salario.Text);

                // dteerminar que funcion se va a llamar...
                if (semanasUsuario >= 250 && semanasUsuario <= 749)
                {
                    Resultado.Text = Convert.ToString(pensionReducida(semanasUsuario));
                }
                else if (semanasUsuario >= 750)
                {
                    Resultado.Text = Convert.ToString(pensionJubilacion(semanasUsuario, salarioUsuario));
                }
                else
                {
                    Resultado.Text = "Las semanas que usted cotizó no son suficientes para optar a una pensión";
                }
            }
            catch (Exception)
            {
                Resultado.Text = "Ocurrió un error inesperado";
            }

        }

        public double pensionReducida(int semanasU)
        {
            double pension = 0;

            if (semanasU >= 250 && semanasU < 350)
            {
                pension = 1910;
            }else if(semanasU >= 350 && semanasU < 449)
            {
                pension = 2356;
            }else if(semanasU >= 450 && semanasU < 549)
            {
                pension = 2884;
            }else if(semanasU >= 550 && semanasU < 649)
            {
                pension = 3290;
            }else if(semanasU >= 650 && semanasU < 749)
            {
                pension = 3656;
            }
            
            return pension;
        }

        public double pensionJubilacion(int semanasU, double salario)
        {
            double excesoSemanas = semanasU - 150;
            double semanas = excesoSemanas / semanaAnual;
            double factorAnual = semanas * factorAplicacion;
            double tasaReemplazo = factorAnual + factorBasico;
            double pension = tasaReemplazo * salario;

            //que no sea menor de 5000

            if (pension < 5000)
            {
                pension = 5000;
            }else if(pension >= 53.595)
            {
                pension = 53.595;
            }
            


            return Math.Round(pension,2);
        }
    }
}
