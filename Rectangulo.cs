namespace Draw
{
    class Rectangulo
    {
        public Punto Punto1 { get; set; }
        public Punto Punto2 { get; set; }

    public Rectangulo(Punto punto1, Punto punto2)
        {
            this.Punto1 = punto1;
            this.Punto2= punto2;
        }

    }
}
