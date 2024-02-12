namespace Imc.Models
{
    public class ImcResult
    {

        public DateTime MeasureDate{ get; set; }
        public double ImcValue { get; set; }

        public IMCstatus Status { get; set; }
    }
}

public enum IMCstatus
{
    Magreza,
    Normal,
    Sobrepeso,
    Obesidade,
    ObesidadeGrave
}
