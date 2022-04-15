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
                if (!string.IsNullOrEmpty(Semanas.Text) && !string.IsNullOrEmpty(Salario.Text))
                {
                    var semanasUsuario = Convert.ToInt32(Semanas.Text);
                    var salarioUsuario = Convert.ToDouble(Salario.Text);

                    // dteerminar que funcion se va a llamar...
                    if (semanasUsuario >= 250 && semanasUsuario <= 749)
                    {
                        Alerta.Text = "Aplica a pensión reducida";
                        Resultado.Text ="C$ " + Convert.ToString(pensionReducida(semanasUsuario));
                    }
                    else if (semanasUsuario >= 750)
                    {
                        Alerta.Text = "Aplica a pensión jubilación";
                        Resultado.Text = "C$ " + Convert.ToString(pensionJubilacion(semanasUsuario, salarioUsuario));
                    }
                    else
                    {
                        Resultado.Text = "0";
                        DisplayAlert("!!!","Las semanas que cotizó no son suficientes para optar a una pensión", "Aceptar");
                    }
                    limpiarControles();
                }
                else
                {
                    Alerta.Text = "";
                    DisplayAlert("Datos  vacíos", "Debe de llenar toda la información", "Aceptar");
                }

               
            }
            catch (Exception)
            {
                //Resultado.Text = "Ocurrió un error inesperado";
                DisplayAlert("¡Error!", "Ocurrió un eror en la entrada de datos", "Aceptar");
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
            //limpiarControles();
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
            }else if(pension >= 53595)
            {
                pension = 53595;
            }


            //limpiarControles();
            return Math.Round(pension,2);
            
        }

        public void limpiarControles()
        {
            Semanas.Text = "";
            Salario.Text = "";
            
        }
    }
}
