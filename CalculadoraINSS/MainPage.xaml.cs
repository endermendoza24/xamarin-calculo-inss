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
            var semanasUsuario = Convert.ToInt32(Semanas.Text);
            var salarioUsuario = Convert.ToDouble(Salario.Text);


            Resultado.Text = Convert.ToString(pensionJubilacion(semanasUsuario, salarioUsuario));
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
            }
            


            return pension;
        }
    }
}
